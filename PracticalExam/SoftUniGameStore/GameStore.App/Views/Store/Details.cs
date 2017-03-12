using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.ViewModels;
using SimpleMVC.Interfaces.Generic;

namespace GameStore.App.Views.Store
{
    public class Details : IRenderable<GameDetailsViewModel>
    {
        public GameDetailsViewModel Model { get; set; }


        public string Render()
        {
            string header = File.ReadAllText(Constants.Path + Constants.Header);
            string navigation = File.ReadAllText(Constants.Path + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["email"]);
            string details = File.ReadAllText(Constants.Path + Constants.Details);
            details = string.Format(details, this.Model);
            string footer = File.ReadAllText(Constants.Path + Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(details);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}
