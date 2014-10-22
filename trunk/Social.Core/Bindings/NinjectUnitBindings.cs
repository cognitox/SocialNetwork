using Social.Core.Services.Database;
using Social.Core.Services.Database.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject.Modules;
using Social.Core.UnitOfService;
using Social.Data.UnitOfWork;
using Social.Data.UnitOfWork.Implementation;

namespace Social.Core.Bindings
{
    public class NinjectUnitBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IUnitOfService>().To<Social.Core.UnitOfService.Implementation.UnitOfService>();
        }
    }
}