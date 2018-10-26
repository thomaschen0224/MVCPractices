using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCPractices.Contracts.Repositories;
using MVCPractices.Contracts.Services;
using MVCPractices.Repositories;
using MVCPractices.Services;
using Ninject.Modules;

namespace MVCPractices.WebUI.NinjectBindings
{
    public class BindingModules: NinjectModule
    {
        public override void Load()
        {

            // Repositories
            Bind<IUserRepository>().To<CachedUserRepository>();


            // Services
            Bind<ITestService>().To<TestService>();
            Bind<ICurrentUserService>().To<CurrentUserService>();


        }
    }
}