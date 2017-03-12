using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace GameStore.App.Views.Users
{
   public class Login:IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Path + Constants.Header);
            string navigation = File.ReadAllText(Constants.Path + Constants.NavNotLogged);
            string login = File.ReadAllText(Constants.Path + Constants.Login);
            string footer = File.ReadAllText(Constants.Path + Constants.Footer);
            StringBuilder builder = new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(login);
            builder.Append(footer);
            return builder.ToString();
        }
    }
}
