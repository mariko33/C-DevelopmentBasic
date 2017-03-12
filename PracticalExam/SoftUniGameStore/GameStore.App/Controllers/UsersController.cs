using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.BindingModels;
using GameStore.App.Models;
using GameStore.App.Services;
using GameStore.App.Utilities;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;

namespace GameStore.App.Controllers
{
  public class UsersController:Controller
  {
      private UsersService service;

      public UsersController()
      {
          this.service=new UsersService();
      }
        [HttpGet]
        public IActionResult Register()
        {
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(RegisterBindingModem rbm,HttpResponse response)
        {
            if (!this.service.IsValidModel(rbm))
            {
                this.Redirect(response,"users/register");
                return null;
            };
            this.service.RegisterUser(rbm);
            this.Redirect(response,"/users/login");
            return null;

        }

      [HttpGet]
      public IActionResult Login()
      {
          return this.View();
      }

      [HttpPost]
      public IActionResult Login(HttpResponse response, HttpSession session, LoginBindingModel lbm)
      {
          User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
          if (activeUser != null)
          {
              this.Redirect(response, "/store/home");
          }

            if (!service.IsLoginModelValid(lbm))
          {
              this.Redirect(response,"/users/login");
          }
          this.service.LoginUser(lbm, session);
            this.Redirect(response,"/store/home");
          return null;
      }

        [HttpGet]
        public IActionResult Logout(HttpResponse response, HttpSession session)
        {
            AuthenticationManager.Logout(response, session.Id);
            ViewBag.Bag["email"] = null;
            this.Redirect(response, "/users/login");
            return null;

        }

    }
}
