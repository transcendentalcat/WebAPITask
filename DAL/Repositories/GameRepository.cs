using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class GameRepository : Repository<Game>
    {
        public GameRepository(GameStoreContext context) : base(context)
        {
        }
    }
}
