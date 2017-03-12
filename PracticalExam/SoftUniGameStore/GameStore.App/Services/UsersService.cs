using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using GameStore.App.BindingModels;
using GameStore.App.Models;
using SimpleHttpServer.Models;

namespace GameStore.App.Services
{
  public class UsersService:Service
    {
        public bool IsValidModel(RegisterBindingModem rbm)
        {
            if (!rbm.Email.Contains('@'))
            {
                return false;
            }
            if (this.Context.Users.Any(u => u.Email == rbm.Email))
            {
                return false;
            }

            Regex passRegex=new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$");
            if (!passRegex.IsMatch(rbm.Password))
            {
                return false;
            }
            
            if (rbm.Password != rbm.ConfirmPassword)
            {
                return false;
            }
            if (string.IsNullOrEmpty(rbm.FullName))
            {
                return false;
            }

            return true;
        }

        public void RegisterUser(RegisterBindingModem rbm)
        {
            User user=new User()
            {
                Email = rbm.Email,
                FullName = rbm.FullName,
                Password = rbm.Password
            };
            if (!this.Context.Users.Any())
            {
                user.IsAdmin = true;
            }
            else
            {
                user.IsAdmin = false;
            }
            this.Context.Users.Add(user);
            this.Context.SaveChanges();
        }

        internal bool IsLoginModelValid(LoginBindingModel lbm)
        {
            return this.Context.Users.Any(u => u.Email == lbm.Email && u.Password == lbm.Password);
        }

        public void LoginUser(LoginBindingModel lbm, HttpSession session)
        {
            User userLogin = this.Context.Users.FirstOrDefault(u => u.Email == lbm.Email && u.Password == lbm.Password);

            Login loginNew=new Login()
            {
                SessionId = session.Id,
                User = userLogin,
                IsActive = true
            };
            this.Context.Logins.Add(loginNew);
            this.Context.SaveChanges();
        }
    }
}
