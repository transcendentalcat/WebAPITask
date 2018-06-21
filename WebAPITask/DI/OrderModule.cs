using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL.IServices;
using BLL.Services;
using Ninject.Modules;

namespace WebAPI.DI
{
    public class OrderModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IGameService>().To<GameService>();
            Bind<CommentService>().To<CommentService>();
        }
    }
}