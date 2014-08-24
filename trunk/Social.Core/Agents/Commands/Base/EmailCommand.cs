using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Base
{
    public abstract class EmailCommand : ICommand<EmailCommandArgs>
    {
        public abstract void Execute(EmailCommandArgs args);
        public abstract void RollBack(EmailCommandArgs args);
    }
}
