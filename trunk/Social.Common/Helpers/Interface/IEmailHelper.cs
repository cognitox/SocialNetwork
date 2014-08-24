using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social.Common.Helpers.Interface
{
    public interface IEmailHelper
    {
        bool IsValidEmail(string emailAddress);
    }
}
