using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Validators
{
    class DigitClassesValidator
    {
        public bool IsCorrectIntValMax(short val, short max)
        {
            return val <= max;
        }

        public bool IsCorrectIntValMin(short val, short min)
        {
            return val >= min;
        }
    }
}
