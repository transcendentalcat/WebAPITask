using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class PublisherDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<GameDto> Games { get; set; }
    }
}
