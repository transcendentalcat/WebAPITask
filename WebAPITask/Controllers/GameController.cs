using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using BLL.DTO;
using BLL.IServices;

namespace WebAPI.Controllers
{
    public class GamesController : ApiController
    {
        private readonly IGameService gameService;

        private readonly ICommentService commentService;

        public GamesController(IGameService gameService, ICommentService commentService)
        {
            this.gameService = gameService;
            this.commentService = commentService;

        }
        // GET /api/games

        public HttpResponseMessage GetAllGames()
        {
            var games = gameService.GetAllGames();
            return Request.CreateResponse(HttpStatusCode.OK, games);
        }

        // GET api/games/5
        public HttpResponseMessage GetGameDetails(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else if (gameService.GetGame(id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                var game = gameService.GetGame(id);
                return Request.CreateResponse(HttpStatusCode.OK, game);
            }
        }

        // POST api/games
        [HttpPost]
        public HttpResponseMessage CreateGame(GameDto game)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            gameService.Create(game);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT api/games/5

        [HttpPut]
        public HttpResponseMessage EditGame(int id, [FromBody]GameDto game)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            gameService.Edit(game);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/games/5
        public HttpResponseMessage DeleteGame(int id)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            else if (gameService.GetGame(id) == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
               gameService.Delete(id);
            return Request.CreateResponse(HttpStatusCode.OK); 
            }     
        }

        [HttpGet]
        [Route("api/games/{id}/download")]
        public HttpResponseMessage DownloadGame(int id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            var fileStream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + "/file.txt", FileMode.Open);
            response.Content = new StreamContent(fileStream);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileStream.Name;
            return response;
        }
    }
}
