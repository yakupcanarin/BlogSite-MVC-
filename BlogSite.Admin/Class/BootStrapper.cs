using Autofac;
using Autofac.Integration.Mvc;
using BlogSite.Core.InfraStructure;
using BlogSite.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogSite.Admin.Class
{
    public class BootStrapper
    {// bootta çalışacak

        public static void RunConfig()
        {
            BuildAutoFac();
        }
        private static void BuildAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<PicturesRepository>().As<IPicturesRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();


            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}