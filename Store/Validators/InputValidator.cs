using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store.Validators
{
    class InputValidator
    {
        public bool IsDigitOrControl(char c)
        {
            if ((char.IsDigit(c) || char.IsControl(c))) return true;
            return false;
        }

        public bool isEmailSymbols(char c)
        {
            if (char.IsLetter(c) || char.IsDigit(c) || char.IsControl(c)
                || c == '@' || c == '.' || c == '-' || c == '_')
                return true;
            return false;
        }

        public bool isLetterOrControl(char c)
        {
            if (char.IsLetter(c) || char.IsControl(c) || c == '-')
                return true;
            return false;
        }

        public bool isNameSymbolsControl(char c)
        {
            if (IsDigitOrControl(c) || isLetterOrControl(c) || c == (char)Keys.Space)
                return true;
            return false;
        }

        public bool IsAddressElement(char c)
        {
            if (isLetterOrControl(c) || c == (char)Keys.Space)
                return true;
            return false;
        }

        public bool IsCorrectIndex(char c)
        {
            if (isLetterOrControl(c) || IsDigitOrControl(c))
                return true;
            return false;
        }

        public bool IdFloatSymbol(char c)
        {
            if (IsDigitOrControl(c) || c == ',')
                return true;
            return false;
        }
    }
}
