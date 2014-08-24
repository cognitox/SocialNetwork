using Social.Core.Models.Email;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Core.Services.Interface
{
    public interface IEmailService
    {
        List<ParsableEmailAccount> GetParsableEmailAccounts();
    }
}
