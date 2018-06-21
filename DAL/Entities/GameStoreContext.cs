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

        public GameStoreContext()
            : base()
        {
        }

    }

    class StoreDbInitializer : DropCreateDatabaseIfModelChanges<GameStoreContext>
    {
        protected override void Seed(GameStoreContext db)
        {
            var genre1 = new Genre() { Name = "Strategy" };
            var genre2 = new Genre() { Name = "Shooter" };
            var genre3 = new Genre() { Name = "Adventure" };

            var subGenre1 = new Genre() { Name = "Turn Based Strategy", ParentGenre = genre1 };



            var platformType1 = new PlatformType() { Type = "PC" };
            var platformType2 = new PlatformType() { Type = "Nintendo" };
            var platformType3 = new PlatformType() { Type = "Mac" };

            var comment1 = new Comment() { Name = "someComment", Body = "its a comment" };

            var game1 = new Game() { Name = "Warcraft", Description = "warcraft is a  classical rts", Key = "Warcraft" };
            game1.Genres = new List<Genre>() { genre1 };
            game1.PlatformTypes = new List<PlatformType>() { platformType1 };
            game1.Comments = new List<Comment>() { comment1 };

            genre1.Games = new List<Game>() { game1 };
            subGenre1.Games = new List<Game>() { game1 };


            var game2 = new Game() { Name = "Doom", Description = "doom is very dynamic", Key = "Doom" };
            game2.Genres = new List<Genre>() { genre2 };
            game2.PlatformTypes = new List<PlatformType>() { platformType2 };

            genre2.Games = new List<Game>() { game2 };

            var game3 = new Game() { Name = "Heroes 3", Description = "Heroes 3 forever", Key = "Heroes 3" };
            game3.Genres = new List<Genre>() { genre3 };
            game3.PlatformTypes = new List<PlatformType>() { platformType3 };

            genre3.Games = new List<Game>() { game3 };

            db.Games.AddRange(new[] { game1, game2, game3 });

            db.SaveChanges();
        }
    }

}
