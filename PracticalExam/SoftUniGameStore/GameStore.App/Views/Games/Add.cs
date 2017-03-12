using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace GameStore.App.Views.Games
{
    public class Add : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Path + Constants.Header);
            string navigation = File.ReadAllText(Constants.Path + Constants.NavLogged);
            navigation = string.Format(navigation, ViewBag.Bag["email"]);
            string add = File.ReadAllText(Constants.Path + Constants.Add);
            string footer = File.ReadAllText(Constants.Path + Constants.Footer);

            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(add);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}
