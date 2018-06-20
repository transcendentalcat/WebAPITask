using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.IServices
{
    public interface IGameService
    {
        GameDto GetGame(int id);
        IEnumerable<GameDto> GetAllGames();
        IEnumerable<GameDto> FindByCriteria(Func<GameDto, Boolean> predicate);
        IEnumerable<GameDto> GetGamesByGenre(string genre);
        IEnumerable<GameDto> GetGamesByPlatformtype(string platform);
        void Create(GameDto item);
        void Edit(GameDto item);
        void Delete(int id);
    }
}
