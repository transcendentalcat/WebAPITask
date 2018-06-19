using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public string GameId { get; set; }
        public virtual Game Game { get; set; }
        public Comment ParentComment { get; set; }
    }
}
