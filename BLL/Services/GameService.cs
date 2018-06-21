using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.IServices;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services
{
    public class GameService : IGameService
    {       
        private IUnitOfWork db { get; set; }

        public GameService(IUnitOfWork uow)
        {
            db = uow;
        }

        public void Create(GameDto item)
        {
            var mapper = MapBuilder.Initialize();
            var game = mapper.Map<GameDto, Game>(item);

            var genres = mapper.Map<IEnumerable<GenreDto>, IEnumerable<Genre>>(item.Genres);

            if (genres != null)
            {
                game.Genres = new List<Genre>();

                foreach (var genre in genres)
                {
                    var existingGenre = db.Genres.Get(genre.Id);
                    game.Genres.Add(existingGenre ?? genre);
                }
            }

            var platformTypes = mapper.Map<IEnumerable<PlatformTypeDto>, IEnumerable<PlatformType>>(item.PlatformTypes);

            if (platformTypes != null)
            {
                game.PlatformTypes = new List<PlatformType>();

                foreach (var platformType in platformTypes)
                {
                    var existingType = db.PlatformTypes.Get(platformType.Id);
                    game.PlatformTypes.Add(existingType ?? platformType);
                }
            }

            var comments = mapper.Map<IEnumerable<CommentDto>, IEnumerable<Comment>>(item.Comments);

            if (comments != null)
            {
                game.Comments = new List<Comment>();
                
                foreach (var comment in comments)
                {
                    if (comment.Id == 0)
                    {
                        game.Comments.Add(comment);
                    }
                    else
                    {
                        var existingComment = db.Comments.Get(comment.Id);
                        game.Comments.Add(existingComment ?? comment);
                    }
                }
                db.Games.Create(game);

                db.SaveAsync();
            }
        }

        public void Delete(int id)
        {
            db.Games.Delete(id);
            db.SaveAsync();
        }

        public void Edit(GameDto item)
        {
            var mapper = MapBuilder.Initialize();
            var game = mapper.Map<GameDto, Game>(item);
            db.Games.Update(game);
            db.SaveAsync();
        }

        public IEnumerable<GameDto> GetAllGames()
        {
            var mapper = MapBuilder.Initialize();
            return mapper.Map<IEnumerable<Game>, List<GameDto>>(db.Games.GetAll());
        }

        public GameDto GetGame(int id)
        {
            var game = db.Games.Get(id);
         
            var mapper = MapBuilder.Initialize();

            if (game == null)

                throw new Exception("Game is not found");

            return mapper.Map<Game, GameDto>(game);
        }

        public IEnumerable<GameDto> GetGamesByGenre(string genreName)
        {
            var genre = db.Genres.Find(g => g.Name == genreName).FirstOrDefault();
            var games = db.Games.Find(g => g.Genres.Contains(genre));

            var mapper = MapBuilder.Initialize();
            var result = mapper.Map<IEnumerable<Game>, List<GameDto>>(games);
            return result;
        }

        public IEnumerable<GameDto> GetGamesByPlatformtype(string platform)
        {
            var platformType = db.PlatformTypes.Find(p => p.Type == platform).FirstOrDefault();
            var games = db.Games.Find(g => g.PlatformTypes.Contains(platformType));

            var mapper = MapBuilder.Initialize();
            var result = mapper.Map<IEnumerable<Game>, List<GameDto>>(games);
            return result;
        }
    }
}
