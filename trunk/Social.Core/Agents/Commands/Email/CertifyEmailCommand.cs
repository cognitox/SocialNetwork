using Social.Common.Helpers;
using Social.Core.Agents.Commands.Args;
using Social.Core.Agents.Commands.Base;
using Social.Core.Agents.Commands.Base.Interface;
using Social.Core.Models.Email;
using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Agents.Commands.Email
{
    public class CertifyEmailCommand : EmailCommand
    {
        public override void Execute(EmailCommandArgs args)
        {
            //TODO, inject the email helper
            var emailHelper = new EmailHelper();
            var emailAddress = args.EmailAddress;
            var emailIsValid = emailHelper.IsValidEmail(emailAddress);
            Contract.Requires(emailIsValid);
            args.IsSuccessful = true;
        }
        public override void RollBack(EmailCommandArgs args)
        {
            //TODO, mark somewhere that this email address is not successful
        }
    }
}
