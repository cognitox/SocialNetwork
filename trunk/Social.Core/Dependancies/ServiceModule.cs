using Ninject.Modules;
using Social.Core.Services;
using Social.Core.Services.Interface;
using Social.Core.UnitOfService.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Dependancies
{
    public class ServiceModule : NinjectModule
    {
        public override void Load()
        {
            //Service Unit
            Bind<IUnitOfService>().To<Social.Core.UnitOfService.UnitOfService>();

            //Services
            Bind<IEmailService>().To<EmailService>();
        }
    }
}
