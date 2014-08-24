using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Models.Server.Base
{
    public class BaseEmailServer
    {
        public Boolean ConnectedSuccessfully { get; set; }
        public Exception Exception { get; set; }
    }
}
