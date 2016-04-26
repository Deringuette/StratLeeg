using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Mvc;
using StrategicLegion.Controllers;
using StrategicLegion.Models;
using StrategicLegionDatabaseFacade.Presentation;
using System.Data.Entity;
using System.Web.Mvc;

namespace StrategicLegion
{
    public class Bootstrapper
    {
        public static IUnityContainer Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            return container;
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            /*          container.RegisterType<IDatabaseRequestsFacade>(new HierarchicalLifetimeManager(), new InjectionFactory(c => new DatabaseRequestsFacade()));
                      container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
                      container.RegisterType<UserManager<ApplicationUser>>(new HierarchicalLifetimeManager());
                      container.RegisterType(typeof(IUserStore<ApplicationUser>), typeof(UserStore<ApplicationUser>));
          */
            container.RegisterType<IDatabaseRequestsFacade>(new HierarchicalLifetimeManager(), new InjectionFactory(c => new DatabaseRequestsFacade()));
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>();
            container.RegisterType<UserManager<ApplicationUser>>();
            container.RegisterType<DbContext, ApplicationDbContext>();
            container.RegisterType<ApplicationUserManager>();
            container.RegisterType<AccountController>(new InjectionConstructor());
        }
    }
}