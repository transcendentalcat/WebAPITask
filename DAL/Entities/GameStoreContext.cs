using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class GameStoreContext : DbContext
    {
        
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<PlatformType> PlatformTypes { get; set; }
        public DbSet<Publisher> Publishers { get; set; }

        static GameStoreContext()
        {
            Database.SetInitializer<GameStoreContext>(new StoreDbInitializer());
        }
        public GameStoreContext(string connectionString)
            : base(connectionString)
        {
        }
        
    }
}
