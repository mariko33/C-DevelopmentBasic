﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.Models;
using GameStore.App.Models.Data;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utilities;

namespace GameStore.App.Utilities
{
   public class AuthenticationManager
    {
        public static bool IsAuthenticated(string sessionId)
        {
            return Data.Context.Logins.Any(login => login.SessionId == sessionId && login.IsActive);
        }

        public static User GetAuthenticatedUser(string sessionId)
        {
            User user = Data.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId && login.IsActive)?.User;
            if (user != null)
            {
                ViewBag.Bag["email"] = user.Email;
            }

            return user;
        }

        public static void Logout(HttpResponse response, string sessionId)
        {
            ViewBag.Bag["email"] = null;
            Login currentLogin = Data.Context.Logins.FirstOrDefault(login => login.SessionId == sessionId);
            currentLogin.IsActive = false;
            Data.Context.SaveChanges();

            var session = SessionCreator.Create();
            var sessionCookie = new Cookie("sessionId", session.Id + "; HttpOnly; path=/");
            response.Header.AddCookie(sessionCookie);
        }
    }
}
