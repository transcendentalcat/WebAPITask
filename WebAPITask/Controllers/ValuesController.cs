using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class GameController : ApiController
    {
        private readonly IGameService _gameService;

        private readonly ICommentService _commentService;

        public GameController(IGameService gameService, ICommentService commentService)
        {
            _gameService = gameService;
            _commentService = commentService;
        }


        // GET api/values
        public HttpResponseMessage GetAllGames()
        {
            var games = _gameService.GetAllGames();
            return  Request.CreateResponse<IEnumerable<Game>>(HttpStatusCode.OK, games);
        }

        // GET api/values/5
        public string GetGameDetails(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public IEnumerable<string> CreateGame()
        {
            return new string[] { "value1", "value2" };
        }

        // PUT api/values/5
        [HttpPut]
        public void EditGame(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void DeleteGame(int id)
        {
        }
    }
}
