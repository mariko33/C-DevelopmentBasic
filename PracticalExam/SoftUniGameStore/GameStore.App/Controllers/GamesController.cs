using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.BindingModels;
using GameStore.App.Models;
using GameStore.App.Services;
using GameStore.App.Utilities;
using GameStore.App.ViewModels;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace GameStore.App.Controllers
{
   public class GamesController:Controller
   {
       private GamesService service;

       public GamesController()
       {
           this.service=new GamesService();
       }

       [HttpGet]
       public IActionResult<IEnumerable<GameAllViewModel>> All(HttpSession session, HttpResponse response)
       {
           User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
           if (activeUser == null)
           {
               this.Redirect(response,"/users/login");
               return null;
           }
           IEnumerable<GameAllViewModel> model = this.service.GetGameAllVieModel();
           return this.View(model);

       }

       [HttpGet]
       public IActionResult<IEnumerable<GameViewModel>> Owned(HttpSession session, HttpResponse response)
       {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }

            var allVeiwGameModels = this.service.GetGameOwned(activeUser);

            return this.View(allVeiwGameModels);
        }

       [HttpGet]
       public IActionResult Add(HttpResponse response, HttpSession session)
       {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
           if (!activeUser.IsAdmin)
           {
               this.Redirect(response,"/store/home");
               return null;
           }
           return this.View();
       }

       [HttpPost]
       public IActionResult Add(HttpResponse response, HttpSession session, NewGameBindingModel ngbm)
       {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/store/home");
                return null;
            }

           this.service.AddNewGame(ngbm);
           this.Redirect(response,"games/all");
           return null;

       }

       [HttpGet]
       public IActionResult<EditViewModel> Edit(HttpResponse response, HttpSession session, int id)
       {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/store/home");
                return null;
            }

           EditViewModel editGame = this.service.getEditGame(id);

           return this.View(editGame);


       }

       [HttpPost]
       public IActionResult Edit(HttpResponse response, HttpSession session, EditBindingModel ebm)
       {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/store/home");
                return null;
            }

           this.service.EditGame(ebm);
            this.Redirect(response,"/games/all");
           return null;
       }

       [HttpGet]
       public IActionResult<DeleteViewModel> Delete(HttpResponse response, HttpSession session,int id)
       {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/store/home");
                return null;
            }

           DeleteViewModel deleteModel = this.service.getDeleteModel(id);
           return this.View(deleteModel);

       }

       [HttpPost]
       public IActionResult Delete(HttpResponse response, HttpSession session, DeleteBindingModel dbm)
       {
            User activeUser = AuthenticationManager.GetAuthenticatedUser(session.Id);
            if (activeUser == null)
            {
                this.Redirect(response, "/users/login");
                return null;
            }
            if (!activeUser.IsAdmin)
            {
                this.Redirect(response, "/store/home");
                return null;
            }

           this.service.DeleteGame(dbm);
            this.Redirect(response, "/games/all");
           return null;

       }


   }
}
