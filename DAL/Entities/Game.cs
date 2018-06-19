using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Game
    {
        public string Id { get; set; }
	    public string Name { get; set; }
        public string Description { get; set; }
        public string PublisherId { get; set; }
        public Publisher Publisher { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}
