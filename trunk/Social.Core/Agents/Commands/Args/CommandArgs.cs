using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Args
{
    public class CommandArgs
    {
        public Boolean IsSuccessful { get; set; }
        public Exception Exception { get; set; }
        
        public CommandArgs()
        {
            _commandArgsID = new Guid();
        }

        #region Unique Identification

        //unique arguements identifier
        private Guid _commandArgsID;
        
        public String CommandArgsID
        {
            get
            {
                return _commandArgsID.ToString();
            }
        }

        #endregion

    }
}
