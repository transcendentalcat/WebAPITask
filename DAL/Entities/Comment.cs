using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Comment : Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Body { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int? ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }
    }
}
