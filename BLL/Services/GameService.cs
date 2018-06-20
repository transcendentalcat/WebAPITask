using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using DAL.Interfaces;

namespace BLL.Services
{
    public class GameService : IGameService
    {       
        IUnitOfWork db { get; set; }

        public GameService(IUnitOfWork uow)
        {
            db = uow;
        }

            public void Create(GameDto item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(GameDto item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameDto> FindByCriteria(Func<GameDto, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameDto> GetAllGames()
        {
            throw new NotImplementedException();
        }

        public GameDto GetGame(int id)
        {
            var game = db.Games.Get(id);

            if (game == null)

                throw new Exception("Game is not found");

            return new GameDto { Id = id, Name = game.Name, Description = game.Description, PublisherId = game.PublisherId};
        }

        public IEnumerable<GameDto> GetGamesByGenre(string genre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<GameDto> GetGamesByPlatformtype(string platform)
        {
            throw new NotImplementedException();
        }
    }
}
