using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Base
{
    public abstract class Command : ICommand<CommandArgs>
    {
        public abstract void Execute(CommandArgs Args);
        public abstract void RollBack(CommandArgs Args);

    }
}
