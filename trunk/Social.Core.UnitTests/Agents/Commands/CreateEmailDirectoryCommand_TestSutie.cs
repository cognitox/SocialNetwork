using Moq;
using NUnit.Framework;
using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Email;
using Social.Core.Models.Email;
using Social.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.UnitTests.Agents.Commands
{
    [TestFixture]
    public class CreateEmailDirectoryCommand_TestSuite
    {

        private List<ParsableEmailAccount> _emailAccountList;

        [TestFixtureSetUp]
        public void FixtureSetup()
        {
            _emailAccountList = new List<Models.Email.ParsableEmailAccount>()
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

        [Test]
        public void CreateEmailDirectoryExecute_Success()
        {
            var emailAccount = _emailAccountList[0];
            //arrange 
            var args = emailAccount.EmailCommandArgs;
            var command = new CreateEmailDirectoryCommand();
            
            //act
            command.Execute(args);

            //assert
            Assert.IsTrue(args.IsSuccessful);
            Assert.IsNull(args.Exception);
        }
    }
}
