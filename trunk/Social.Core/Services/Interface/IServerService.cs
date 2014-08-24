using Social.Core.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Services.Interface
{
    public interface IServerService
    {
        Boolean ServerExists(IMAPServer server);
        Boolean ServerExists(POP3Server server);
        Boolean ServerExists(SMTPServer server);
    }
}
