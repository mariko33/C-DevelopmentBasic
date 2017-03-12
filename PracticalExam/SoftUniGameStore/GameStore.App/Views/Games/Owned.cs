using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace GameStore.App.Views.Games
{
    public class Owned : IRenderable<IEnumerable<GameViewModel>>
    {
        public IEnumerable<GameViewModel> Model { get; set; }


        public string Render()
        {
            string header = File.ReadAllText(Constants.Path + Constants.Header);
            string navigation = File.ReadAllText(Constants.Path + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["email"]);
            StringBuilder games = new StringBuilder();
            foreach (var game in this.Model)
            {
                games.Append(game);
            }
            string home = File.ReadAllText(Constants.Path + Constants.Home);
            home = string.Format(home, games);
            string footer = File.ReadAllText(Constants.Path + Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(home);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}
