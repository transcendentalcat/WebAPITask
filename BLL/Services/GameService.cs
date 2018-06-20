using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;

namespace BLL.Services
{
    public class GameService : IGameService
    {
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
            throw new NotImplementedException();
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
