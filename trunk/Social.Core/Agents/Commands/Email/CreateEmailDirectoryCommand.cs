using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base;
using Social.Core.Agents.Commands.Base.Interface;
using Social.Core.Models.Email;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Email
{
    public class CreateEmailDirectoryCommand : EmailCommand
    {
        public override void Execute(EmailCommandArgs args)
        {
            args.IsSuccessful = true;
            
        }
        public override void RollBack(EmailCommandArgs args)
        {
            Console.WriteLine(@"Rollback Create Email Directory Command.");
        }
    }
}
