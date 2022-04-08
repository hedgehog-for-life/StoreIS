using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Validators
{
    class DateTimeValidator
    {
        public bool IsDataCorrect(DateTime dateTime)
        {
            if (dateTime <= DateTime.Now) return true;
            return false;
        }

        public bool IsDateAcceptable(DateTime dateToCompare, DateTime dateCompareWith)
        {
            return dateToCompare >= dateCompareWith;
        }
    }
}

