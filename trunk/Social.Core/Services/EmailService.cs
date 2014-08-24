using Social.Core.Services.Interface;
using Social.Data.UnitOfWork.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Services
{
    public class EmailService : IEmailService
    {
        private IUnitOfWork _unitOfWork;

        public EmailService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Models.Email.ParsableEmailAccount> GetParsableEmailAccounts()
        {

            //TODO, wire up with the database
            return new List<Models.Email.ParsableEmailAccount>()
            {
                new Models.Email.ParsableEmailAccount()
                {
                    Id = Guid.NewGuid(),
                    AccountId = Guid.NewGuid(),
                    Email = @"service@relsocial.com",
                    UserName = @"service@relsocial.com",
                    Password = @"bh46>XKZ",
                    SMTPServerAddress = @"smtp.gmail.com",
                    SMTPTLSPort = 587,
                    SMTPSSLPost = 465,
                    SMTP_TLS_SSL_REQUIRED = true,
                    POP3ServerAddress = @"pop.gmail.com",
                    POP3Port = 995,
                    POP3_TLS_SSL_REQUIRED = true,
                    IMAPServerAddress = @"imap.gmail.com",
                    IMAPPort = 993,
                    IMAP_TLS_SSL_REQUIRED = true,
                },
            };
        }
    }
}
