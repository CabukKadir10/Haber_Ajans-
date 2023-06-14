using Autofac;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.DependencyResolvers.AutoFac
{
    public class AutoFacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            //builder.RegisterType<EfNewsDal>().As<IEfNewsDal>().SingleInstance();
            //builder.RegisterType<EfUserDal>().As<IEfUserDal>().SingleInstance();


        }
    }
}
