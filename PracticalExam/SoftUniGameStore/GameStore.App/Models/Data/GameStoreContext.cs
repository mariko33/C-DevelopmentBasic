namespace GameStore.App.Models.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class GameStoreContext : DbContext
    {
        

        public GameStoreContext()
            : base("name=GameStoreContext")
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Login> Logins { get; set; }

    }

    
}