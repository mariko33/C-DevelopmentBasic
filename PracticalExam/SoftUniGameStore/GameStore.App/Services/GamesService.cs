using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.BindingModels;
using GameStore.App.Models;
using GameStore.App.ViewModels;

namespace GameStore.App.Services
{
   public class GamesService:Service
    {
        public IEnumerable<GameAllViewModel> GetGameAllVieModel()
        {
           IList<GameAllViewModel> gamesModel=new List<GameAllViewModel>();
            var games = this.Context.Games;
            foreach (var game in games)
            {
                GameAllViewModel gameModel=new GameAllViewModel()
                {
                    Id = game.Id,
                    Name = game.Title,
                    Price = game.Price,
                    Size = game.Size
                };
                gamesModel.Add(gameModel);
            }
            return gamesModel.AsEnumerable();
        }

        public void AddNewGame(NewGameBindingModel ngbm)
        {
            Game game=new Game()
            {
                Description = ngbm.Description,
                ImageThumbnail = ngbm.ImageThumbnail,
                Price = ngbm.Price,
                ReleaseDate = ngbm.ReleaseDate,
                Size = ngbm.Size,
                Title = ngbm.Title,
                Trailer = ngbm.Trailer
            };
            this.Context.Games.Add(game);
            this.Context.SaveChanges();
        }

        public EditViewModel getEditGame(int id)
        {
          var game=this.Context.Games.Find(id);
            EditViewModel editGame=new EditViewModel()
            {
                Id = game.Id,
                Description = game.Description,
                ImageThumbnail = game.ImageThumbnail,
                Price = game.Price,
                Size = game.Size,
                Title = game.Title,
                Trailer = game.Trailer

            };
            return editGame;
        }

        internal IEnumerable<GameViewModel> GetGameOwned(User activeUser)
        {
            IList<GameViewModel> gamesModel = new List<GameViewModel>();
            var games = this.Context.Users.Find(activeUser.Id).Games;
            foreach (var game in games)
            {
                GameViewModel gameModel = new GameViewModel()
                {
                    Id = game.Id,
                    ImageThumbnail = game.ImageThumbnail,
                    Description = game.Description,
                    Price = game.Price,
                    Size = game.Size,
                    Title = game.Title
                };
                gamesModel.Add(gameModel);
            }
            return gamesModel.AsEnumerable();
        }



        public void EditGame(EditBindingModel ebm)
        {
            var game = this.Context.Games.Find(ebm.Id);
            game.Size = ebm.Size;
            game.Description = ebm.Description;
            game.ImageThumbnail = ebm.ImageThumbnail;
            game.Price = ebm.Price;
            game.Title = ebm.Title;
            game.Trailer = ebm.Trailer;

            this.Context.SaveChanges();

        }


        public DeleteViewModel getDeleteModel(int id)
        {
            var game = this.Context.Games.Find(id);
            DeleteViewModel deleteModel = new DeleteViewModel()
            {
                Id = game.Id,
                Title = game.Title
            };


            return deleteModel;
        }

        public void DeleteGame(DeleteBindingModel dbm)
        {
            var game = this.Context.Games.Find(dbm.Id);
            this.Context.Games.Remove(game);
            this.Context.SaveChanges();
        }
    }
}
