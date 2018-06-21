using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.IServices;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork db { get; set; }

        public CommentService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void AddComment(int gameId, CommentDto commentDto)
        {
            var mapper = MapBuilder.Initialize();
            var comment = mapper.Map<CommentDto, Comment>(commentDto);
          
            db.Comments.Create(comment);

            db.SaveAsync();
        }

        public IEnumerable<CommentDto> GetAllComments(int gameId)
        {
            var comments = db.Games.Get(gameId).Comments;
            var mapper = MapBuilder.Initialize();
            var result = mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDto>>(comments);

            return result;
        }
    }
}
