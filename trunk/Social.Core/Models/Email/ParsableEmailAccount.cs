using Social.Core.Agents.Commands.Args;
using Social.Core.Models.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Models.Email
{
    public class ParsableEmailAccount
    {
        public Guid Id { get; set; }

        public Guid AccountId { get; set; }

        public String Email { get; set; }

        public String UserName { get; set; }

        public String Password { get; set; }

        public String SMTPServerAddress { get; set; }

        public Int32 SMTPTLSPort { get; set; }

        public Int32 SMTPSSLPost { get; set; }

        public Boolean SMTP_TLS_SSL_REQUIRED { get; set; }

        public String POP3ServerAddress { get; set; }

        public Int32 POP3Port { get; set; }

        public Boolean POP3_TLS_SSL_REQUIRED { get; set; }

        public String IMAPServerAddress { get; set; }

        public Int32 IMAPPort { get; set; }

        public Boolean IMAP_TLS_SSL_REQUIRED { get; set; }


        public EmailCommandArgs EmailCommandArgs
        {
            get
            {
                return new EmailCommandArgs(Email, Password, IMAPServerAddress, IMAPPort, IMAP_TLS_SSL_REQUIRED);
            }
        }
    }
}
