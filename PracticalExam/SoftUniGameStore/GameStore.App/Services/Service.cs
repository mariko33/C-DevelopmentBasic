using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameStore.App.Models.Data;

namespace GameStore.App.Services
{
    public abstract class Service
    {
        public Service()
        {
            this.Context = Data.Context;
        }

        protected GameStoreContext Context { get; }
    }
}