using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Publisher
    {
        string Key { get; set;}
	    string Name { get; set;}
        public ICollection<Game> Games { get; set; }
    }

}
}
