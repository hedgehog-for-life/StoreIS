using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Store.Validators
{
    class StringValidator
    {
        public bool IsPhoneNumber(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                return false;
            return (number[0] == '0' || number.Length != 10 ? false : true);
        }

        public bool IsLengthCorrectMax(string data, int maxLength)
        {
            if (data.Length > maxLength) return false;
            return true;
        }
        public bool IsLengthCorrectMin(string data, int minLength)
        {
            if (data.Length < minLength) return false;
            return true;
        }
        public bool IsLengthCorrectRequired(string data, int requiredLength)
        {
            if (data.Length != requiredLength) return false;
            return true;
        }
            
        public bool IsCorrectInfo(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                return false;
            return true;
        }

            public bool IsCorrectEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper,
                                      RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();

                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,
                    @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
                    RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        public bool IsCorrectName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;
            if (name.Contains("--") || name[0] == '-' || name.Length == 0) return false;
            return true;
        }
    }
}
