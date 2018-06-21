using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Genre : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentGenreId { get; set; }
        public virtual Genre ParentGenre { get; set; }
        public virtual ICollection<Game> Games { get; set; }
    }
}
