using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.BindingModels;
using GameStore.App.Models;
using GameStore.App.Services;
using GameStore.App.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using AuthenticationManager = GameStore.App.Utilities.AuthenticationManager;

namespace GameStore.App.Controllers
{
  public class StoreController:Controller
  {
      private StoreService service;

      public StoreController()
      {
          this.service=new StoreService();
      }

      [HttpGet]
      public IActionResult<IEnumerable<GameViewModel>> Home(HttpSession session,HttpResponse response)
      {
          User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
          if (activeUser == null)
          {
              this.Redirect(response,"/users/login");
              return null;
          }

         var allVeiwGameModels= this.service.GetAllGameViewModels();

          return this.View(allVeiwGameModels);
      }

      [HttpGet]
      public IActionResult<GameDetailsViewModel> Details(int id,HttpSession session,HttpResponse response)
      {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
          GameDetailsViewModel detailsGame=this.service.GetDetailsFromGame(id);
            
          return this.View(detailsGame);
      }

      [HttpPost]
      public IActionResult Details(HttpResponse response, HttpSession session, BuyBindingModel bbm)
      {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
          this.service.Buy(activeUser,bbm);
          this.Redirect(response, "/store/home");
          return null;

      } 
  }
}
