using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork

    {

        private GameStoreContext db;

        private CommentRepository commentRepository;
        private GameRepository gameRepository;
        private GenreRepository genreRepository;
        private PlatformTypeRepository platformTypeRepository;
        private PublisherRepository publisherRepository;

        public UnitOfWork()
        {
            db = new GameStoreContext();();
        }

        public IRepository<Game> Games
        {
            get
            {
                if (gameRepository == null)
                    gameRepository = new GameRepository(db);
                return gameRepository;
            }
        }

        public IRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }

        public IRepository<PlatformType> PlatformType
        {
            get
            {
                if (platformTypeRepository == null)
                    platformTypeRepository = new PlatformTypeRepository(db);
                return platformTypeRepository;
            }
        }



        public IRepository<Comment> Comments
        {
            get
            {
                if (commentRepository == null)
                    commentRepository = new CommentRepository(db);
                return commentRepository;
            }
        }

        public IRepository<Publisher> Publishers
        {
            get
            {
                if (publisherRepository == null)
                    publisherRepository = new PublisherRepository(db);
                return publisherRepository;
            }
        }

        public async Task SaveAsync()

        {

            await db.SaveChangesAsync();

        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)

        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
