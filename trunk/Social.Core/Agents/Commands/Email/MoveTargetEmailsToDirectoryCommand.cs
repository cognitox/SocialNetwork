using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base;
using Social.Core.Agents.Commands.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Email
{
    public class MoveTargetEmailsToDirectoryCommand : EmailCommand, ICommand<EmailCommandArgs>
    {
        public override void Execute(EmailCommandArgs args)
        {
            args.IsSuccessful = false;
            Console.WriteLine(@"Execute MoveTargetEmails Command.");
        }
        public override void RollBack(EmailCommandArgs args)
        {
            Console.WriteLine(@"RollBack MoveTargetEmails Command.");
        }
    }
}
