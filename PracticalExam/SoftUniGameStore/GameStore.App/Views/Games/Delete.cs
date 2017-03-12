using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.ViewModels;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;

namespace GameStore.App.Views.Games
{
    public class Delete : IRenderable<DeleteViewModel>
    {
        public DeleteViewModel Model { get; set; }


        public string Render()
        {
            string header = File.ReadAllText(Constants.Path + Constants.Header);
            string navigation = File.ReadAllText(Constants.Path + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["email"]);
            string delete = File.ReadAllText(Constants.Path + Constants.Delete);
            delete = string.Format(delete,this.Model.Id,this.Model.Title );
            string footer = File.ReadAllText(Constants.Path + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(delete);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}
