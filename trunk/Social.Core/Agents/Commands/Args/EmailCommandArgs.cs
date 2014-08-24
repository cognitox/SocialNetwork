using Social.Core.Models.Email;
using Social.Core.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Args
{
    public class EmailCommandArgs : CommandArgs
    {
        //[CertifyEmailCommand]
        public String EmailAddress { get; protected set; }
        public String EmailPassword { get; protected set; }

        //[CertifyServerCommand]
        public IMAPServer IMAPServer { get; protected set; }


        public EmailCommandArgs(String emailAddress, String emailPassword, String hostName, Int32 port, Boolean sslMode)
        {
            EmailAddress = emailAddress;
            EmailPassword = emailPassword;
            IMAPServer = new IMAPServer(emailAddress,emailPassword,hostName,port,sslMode);
        }
        
    }
}
