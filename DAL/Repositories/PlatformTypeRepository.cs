using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Repositories
{
    public class PlatformTypeRepository : Repository<PlatformType>
    {
        public PlatformTypeRepository(GameStoreContext context) : base(context)
        {
        }
    }
}
