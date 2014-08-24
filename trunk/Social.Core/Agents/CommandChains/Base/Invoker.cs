using Social.Core.Agents.Commands.Base;
using Social.Core.Agents.Commands.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.CommandChains.Base
{
    public abstract class Invoker<CommandType, CommandArgType>
        where CommandType : ICommand<CommandArgType>
    {
        public abstract void AddCommand(CommandType command);

        public abstract void ExecuteChain(CommandArgType args);
    }
}
