using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.IServices
{
    public interface ICommentService
    {
        //CommentDto GetComment(int id);
        IEnumerable<CommentDto> GetAllComments(int gameId);
        void AddComment(int gameId, CommentDto commentDto);
    }
}
