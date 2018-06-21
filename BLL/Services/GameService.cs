using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.IServices;
using DAL.Interfaces;
using AutoMapper;

namespace BLL.Services
{
    public class GameService : IGameService
    {       
        IUnitOfWork db { get; set; }
        IMapper mapper { get; set; }

        public GameService(IUnitOfWork uow, IMapper mapper)
        {
            db = uow;
            this.mapper = mapper;
        }

        public void Create(GameDto item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameDto, Game>()).CreateMapper();
            var game = mapper.Map<GameDto, Game>(item);

            mapper = new MapperConfiguration(cfg => cfg.CreateMap<GenreDto, Genre>()).CreateMapper();
            var genres = mapper.Map<IEnumerable<GenreDto>, IEnumerable<Genre>>(item.Genres);

            if (genres != null)
            {
                game.Genres = new List<Genre>();

                foreach (var genre in genres)
                {
                    var existingGenre = db.Genres.GetElementById(genre.Id);
                    game.Genres.Add(existingGenre ?? genre);
                }
            }


            mapper = new MapperConfiguration(cfg => cfg.CreateMap<PlatformTypeDto, PlatformType>()).CreateMapper();
            var platformTypes = mapper.Map<IEnumerable<PlatformTypeDTO>, IEnumerable<PlatformType>>(item.PlatformTypes);

            if (platformTypes != null)
            {
                game.PlatformTypes = new List<PlatformType>();

                foreach (var platformType in platformTypes)
                {
                    var existingType = _uow.PlatformTypes.GetElementById(platformType.Id);
                    game.PlatformTypes.Add(existingType ?? platformType);
                }
            }

            mapper = new MapperConfiguration(cfg => cfg.CreateMap<CommentTypeDto, Comment>()).CreateMapper();
            var comments = _mapper.Map<IEnumerable<CommentDTO>, IEnumerable<Comment>>(item.Comments);

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
                        var existingComment = _uow.Comments.GetElementById(comment.Id);
                        game.Comments.Add(existingComment ?? comment);
                    }
                }

                db.Games.Create(game);
                db.Save();

            }
        }

        public void Delete(int id)
        {
            db.Games.Delete(gameKey);
            db.Save();

        }

        public void Edit(GameDto item)
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<GameDto, Game>()).CreateMapper();
            var game = _mapper.Map<GameDTO, Game>(item);
            db.Games.Update(game);
            db.Save();

        }

        //public IEnumerable<GameDto> FindByCriteria(Func<GameDto, bool> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        public IEnumerable<GameDto> GetAllGames()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDto>()).CreateMapper();
            return mapper.Map<IEnumerable<Game>, List<GameDto>>(db.Games.GetAll());
        }

        public GameDto GetGame(int id)
        {
            var game = db.Games.Get(id);

            if (game == null)

                throw new Exception("Game is not found");

            return new GameDto { Id = id, Name = game.Name, Description = game.Description, PublisherId = game.PublisherId};

        }

        public IEnumerable<GameDto> GetGamesByGenre(string genreName)
        {
            var genre = db.Genres.Where(g => g.Name == genreName);
            var games = db.Games.Where(g => g.Genres.Contains(genre));

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDto>()).CreateMapper();
            var result = mapper.Map<IEnumerable<Game>, List<GameDto>>(games);
            return result;
        }

        public IEnumerable<GameDto> GetGamesByPlatformtype(string platform)
        {
            var platformType = db.PlatformTypes.Where(p => p.Name == platform);
            var games = db.Games.Where(g => g.PlatformTypes.Contains(platformTypes));

            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Game, GameDto>()).CreateMapper();
            var result = mapper.Map<IEnumerable<Game>, List<GameDto>>(games);
            return result;
        }

        //Comment

        public void AddComment(id gameId, CommentDto commentDto)
        {
            var comment = _mapper.Map<CommentDTO, Comment>(commentDto);

            if (comment.ParentCommentId.HasValue)
            {
                var author = "";

                var parentComment = db.Comments.GetElementById(comment.ParentCommentId.Value);

                comment.ParentComment = parentComment;
                comment.Game = parentComment?.Game;

                author += $"{parentComment?.Name} {Environment.NewLine}";
                comment.Body = author + comment.Body;
            }
            else if (!String.IsNullOrWhiteSpace(gameId))
            {
                comment.Game = db.Games.Get(gameKey);
            }
            else
            {
                throw new MissingFieldException("Comment is not attached neither to game, nor to other comment");
            }

            db.Comments.Create(comment);

            db.Save();
        }

        public IEnumerable<CommentDto> GetAllCommentsForGame(id gameId)
        {
            var comments = db.Games.Get(gameId).Comments;

            var result = _mapper.Map<IEnumerable<Comment>, IEnumerable<CommentDTO>>(comments);

            return result;
        }

    }
}
