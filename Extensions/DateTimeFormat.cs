using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pathology.Extensions
{
    public static class DateTimeFormat
    {
        public static string GetDate(DateTime datetime)
        {
            return $"{datetime.ToString("MM dd")},{datetime.Year}";
        }
    }
}
