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
    public class Edit : IRenderable<EditViewModel>
    {
        public EditViewModel Model { get; set; }


        public string Render()
        {
            string header = File.ReadAllText(Constants.Path + Constants.Header);
            string navigation = File.ReadAllText(Constants.Path + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["email"]);
            string edit = File.ReadAllText(Constants.Path + Constants.Edit);
            edit = string.Format(edit, this.Model.Id, this.Model.Title, this.Model.Description, this.Model.ImageThumbnail,
                this.Model.Price,
                this.Model.Size, this.Model.Trailer);
            string footer = File.ReadAllText(Constants.Path + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(edit);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}
