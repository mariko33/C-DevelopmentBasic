using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleMVC.Interfaces;

namespace GameStore.App.Views.Users
{
    class Register : IRenderable
    {
        public string Render()
        {
            string header = File.ReadAllText(Constants.Path + Constants.Header);
            string navigation = File.ReadAllText(Constants.Path + Constants.NavNotLogged);
            string register = File.ReadAllText(Constants.Path + Constants.Register);
            string footer = File.ReadAllText(Constants.Path + Constants.Footer);
            StringBuilder builder=new StringBuilder();
            builder.Append(header);
            builder.Append(navigation);
            builder.Append(register);
            builder.Append(footer);
            return builder.ToString();

        }
    }
}
