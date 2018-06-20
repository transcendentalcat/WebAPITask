using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class PlatformType : Entity
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
