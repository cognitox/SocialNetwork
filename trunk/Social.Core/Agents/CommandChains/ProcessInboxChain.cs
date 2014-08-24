using Social.Core.Agents.CommandChains.Base;
using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base;
using Social.Core.Agents.Commands.Base.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.CommandChains
{
    public class ProcessInboxChain : Invoker<ICommand<EmailCommandArgs>, EmailCommandArgs>
    {
        private Int32 _current;

        private List<ICommand<EmailCommandArgs>> _commands;

        public ProcessInboxChain()
        {
            _commands = new List<ICommand<EmailCommandArgs>>();
        }

        public override void AddCommand(ICommand<EmailCommandArgs> command)
        {
            _commands.Add(command);
        }

        public override void ExecuteChain(EmailCommandArgs args)
        {
            _current = 0;
            args.IsSuccessful = true;

            while ((_current > -1) &&
                (_current <= _commands.Count))
            {
                try
                {
                    if (args.IsSuccessful)
                    {
                        if (_current == _commands.Count) break;
                        var command = _commands[_current++];
                        command.Execute(args);
                    }
                    else
                    {
                        if (_current == 0) break;
                        var command = _commands[--_current];
                        command.RollBack(args);
                    }
                }
                catch (Exception exception)
                {
                    args.Exception = exception;
                    args.IsSuccessful = false;
                }   
            }
        }

    }
}
