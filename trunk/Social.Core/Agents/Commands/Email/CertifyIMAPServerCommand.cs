using Social.Common.Helpers;
using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base;
using Social.Core.Agents.Commands.Base.Interface;
using Social.Core.Models.Email;
using Social.Core.Services;
using Social.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Email
{
    public class CertifyIMAPServerCommand : EmailCommand
    {
        private IServerService _serverService;
        public CertifyIMAPServerCommand(IServerService serverService)
        {
            _serverService = serverService;
        }

        public override void Execute(EmailCommandArgs args)
        {
            var madeConnection = _serverService.ServerExists(args.IMAPServer);
            Contract.Requires(madeConnection);


            args.IsSuccessful = true;
        }
        public override void RollBack(EmailCommandArgs args)
        {
            
        }
    }
}
