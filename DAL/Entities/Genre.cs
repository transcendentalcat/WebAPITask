using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Genre
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Genre Subgenre { get; set; }
        public ICollection<Game> Games { get; set; }
    }
}
