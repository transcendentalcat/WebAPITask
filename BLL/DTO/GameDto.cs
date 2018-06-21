using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int PublisherId { get; set; }
  
        public ICollection<GenreDto> Genres { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
        public ICollection<PlatformTypeDto> PlatformTypes { get; set; }

    }
}
