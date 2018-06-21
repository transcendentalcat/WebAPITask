using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL.DTO;
using BLL.IServices;

namespace WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        private readonly IGameService gameService;

        private readonly ICommentService commentService;

        public CommentController(IGameService gameService, ICommentService commentService)
        {
            this.gameService = gameService;
            this.commentService = commentService;
        }

        [HttpPost]
        [Route("/api/games/{id}/comments")]
        public HttpResponseMessage CreateGame(int id, CommentDto comment)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            commentService.AddComment(id, comment);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [Route("/api/games/{id}/comments")]
        public HttpResponseMessage GetAllComments(int id)
        {
            var comments = commentService.GetAllComments(id);
            return Request.CreateResponse(HttpStatusCode.OK, comments);
        }
    }
}
