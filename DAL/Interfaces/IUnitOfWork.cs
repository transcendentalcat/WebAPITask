using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Comment> Comments { get; }
        IRepository<Game> Games { get; }
        IRepository<Genre> Genres { get; }
        IRepository<PlatformType> PlatformTypes { get; }
        IRepository<Publisher> Publishers { get; }
        Task SaveAsync();
    }
}
