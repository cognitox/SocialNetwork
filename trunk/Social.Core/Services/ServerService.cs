using S22.Imap;
using Social.Core.Models.Server;
using Social.Core.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Services
{
    public class ServerService : IServerService
    {
        //IMAP DOCUMENTATION, http://smiley22.github.io/S22.Imap/Documentation/

        private const Int32 MAXRETRY = 3;

        public Boolean ServerExists(IMAPServer server)
        {
            var retryAttempt = 0;
            var connectedSuccessfully = false;

            while ((retryAttempt < MAXRETRY) 
                       && (!connectedSuccessfully))
            {
                try
                {
                    using (ImapClient client = server.GetClient())
                    {
                        connectedSuccessfully = true;
                    }
                    retryAttempt++;
                }
                catch (Exception exception)
                {
                    connectedSuccessfully = false;
                    server.Exception = exception;
                }
            }
            server.ConnectedSuccessfully = connectedSuccessfully;
            return connectedSuccessfully;
        }

        
        public Boolean ServerExists(POP3Server server)
        {
            throw new NotImplementedException();
        }
        public Boolean ServerExists(SMTPServer server)
        {
            throw new NotImplementedException();
        }

    }
}
