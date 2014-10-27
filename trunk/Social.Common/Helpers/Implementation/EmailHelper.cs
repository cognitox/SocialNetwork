using Social.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Social.Common.Helpers.Implementation
{
    public class EmailHelper : IEmailHelper
    {
        private bool _emailIsInvalid = false;

        public bool IsValidEmail(string emailAddress)
        {
            _emailIsInvalid = false;
            if (String.IsNullOrEmpty(emailAddress))
                return false;
            try
            {
                emailAddress = Regex.Replace(emailAddress, @"(@)(.+)$", this.DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (_emailIsInvalid) return false;

            try
            {
                return Regex.IsMatch(emailAddress,
                      @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                      @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                      RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            IdnMapping idn = new IdnMapping();
            string domainName = match.Groups[2].Value;
            try { domainName = idn.GetAscii(domainName); }
            catch (ArgumentException) { _emailIsInvalid = true; }
            return match.Groups[1].Value + domainName;
        }
    }
}
