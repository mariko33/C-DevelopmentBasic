using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.BindingModels;
using GameStore.App.Models;
using GameStore.App.ViewModels;

namespace GameStore.App.Services
{
   public class StoreService:Service
    {
        public IEnumerable<GameViewModel> GetAllGameViewModels()
        {
            List<GameViewModel> gameViewModels=new List<GameViewModel>();

            var games = this.Context.Games;
            foreach (var game in games)
            {
                var gameModel = new GameViewModel()
                {
                    Id = game.Id,
                    ImageThumbnail = game.ImageThumbnail,
                    Description = game.Description,
                    Price = game.Price,
                    Size = game.Size,
                    Title = game.Title

                };
                gameViewModels.Add(gameModel);

            }

            return gameViewModels.AsEnumerable();
        }

        public GameDetailsViewModel GetDetailsFromGame(int id)
        {
            Game game = this.Context.Games.Find(id);
            GameDetailsViewModel model=new GameDetailsViewModel()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ReleaseDate = game.ReleaseDate,
                Price = game.Price,
                Size = game.Size,
                Trailer = game.Trailer


            };

            return model;
        }

        public void Buy(User activeUser,BuyBindingModel bbm)
        {
            var owner = this.Context.Users.Find(activeUser.Id);
            var game = this.Context.Games.Find(bbm.Id);
            owner.Games.Add(game);
            this.Context.SaveChanges();
        }
    }
}
