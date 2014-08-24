using S22.Imap;
using Social.Core.Models.Server.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Models.Server
{
    public class IMAPServer : BaseEmailServer, IDisposable
    {

        private ImapClient _context;
        
        private Int32 _port;
        private String _username;
        private String _password;
        private String _hostname;
        private Boolean _sslMode;

        public IMAPServer(String Username, String Password, String Hostname, Int32 Port, Boolean SslMode)
        {
            _port = Port;
            _username = Username;
            _password = Password;
            _hostname = Hostname;
            _sslMode = SslMode;
        }

        public ImapClient GetClient()
        {
            return (_context ?? new ImapClient(_hostname, _port, _username, _password, AuthMethod.Login, _sslMode));
        }

        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }
    }
}
