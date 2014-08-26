using Ninject.Modules;
using Social.Core.UnitOfService;
using Social.Core.UnitOfService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Social.App.Web.App_Inject
{
    public class NinjectBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfService>().To<UnitOfService>();
        }
    }
}