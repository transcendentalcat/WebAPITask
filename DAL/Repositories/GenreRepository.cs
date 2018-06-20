using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class GenreRepository : Repository<Genre>
    {
        public GenreRepository(GameStoreContext context) : base(context)
        {
        }
    }
}
