using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Base.Interface
{
    public interface ICommand<CommandArgType>
    {
        void Execute(CommandArgType args);
        void RollBack(CommandArgType args);

    }
}
