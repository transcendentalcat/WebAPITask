using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.IServices
{
    interface ICommentService
    {
        CommentDto GetComment(int id);
        IEnumerable<CommentDto> GetAllComments();
        IEnumerable<CommentDto> FindByCriteria(Func<CommentDto, Boolean> predicate);
        void Create(CommentDto item);
        void Delete(int id);
    }
}
