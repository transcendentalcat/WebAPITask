using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.DTO;
using DAL.Entities;

namespace BLL.Infrastructure
{
    public class MapBuilder
    {
        public static IMapper Initialize()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<GameDto, Game>().ReverseMap();
                cfg.CreateMap<CommentDto, Comment>().ReverseMap();
                cfg.CreateMap<GenreDto, Genre>().ReverseMap();
                cfg.CreateMap<PlatformTypeDto, PlatformType>().ReverseMap();
                cfg.CreateMap<PublisherDto, Publisher>().ReverseMap();
            });
           
            config.AssertConfigurationIsValid();
            var mapper = config.CreateMapper();
            return mapper;
        }
    }
}
