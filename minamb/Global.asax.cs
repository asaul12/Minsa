using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using minamb.Models;

namespace minamb
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var config = GlobalConfiguration.Configuration;

            config.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling
                            = Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));

            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));

            if (!roleManager.RoleExists("Agente"))
                roleManager.Create(new IdentityRole("Agente"));

            if (!roleManager.RoleExists("Gestor"))
                roleManager.Create(new IdentityRole("Gestor"));

            if (!roleManager.RoleExists("Estatisticas"))
                roleManager.Create(new IdentityRole("Estatisticas"));

            if (!roleManager.RoleExists("Admin"))
                roleManager.Create(new IdentityRole("Admin"));

            try
            {
                var user = new ApplicationUser()
                {
                    Nome = "System",
                    UserName = "system",
                    Email = "system@system.com",
                    PhoneNumber = "000000000"
                };

                var result = manager.Create(user, "system123456789#");

                if (result.Succeeded)
                {
                    manager.AddToRole(user.Id, "Admin");
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}
