//using Autofac;
//using AutoMapper;
//using DataAccess.Abstract;
//using DataAccess.Concrete;
//using DataAccess.Concrete.EntityFramework;
//using Entity.Concrete;
//using Microsoft.AspNetCore.Identity;
//using Service.Abstract;
//using Service.Concrete;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Service.DependencyResolvers.AutoFac
//{
//    public class AutoFacBusinessModule : Module
//    {
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterType<AuthManager>().As<IAuthService>();
//            builder.RegisterType<Mapper>().As<IMapper>();
//            builder.RegisterType<EfNewsDal>().As<IEfNewsDal>();
//            builder.RegisterType<RepositoryManager>().As<IRepositoryManager>();
//            builder.RegisterType<ServiceManager>().As<IServiceManager>();
//            builder.RegisterType<NewsManager>().As<INewsService>();
//        }
//    }
//}
