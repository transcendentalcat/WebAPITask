using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace BLL.DTO
{
    public class GenreDto
    {
        public string Name { get; set; }
        public int? ParentGenreId { get; set; }
        public ICollection<GenreDto> SubGenre { get; set; }
        public ICollection<GameDto> Games { get; set; }

    }
}
