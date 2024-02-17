using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HolidayCounter
{
    internal class Utilities
    {
        public static int searchHoliday(DateTime[] newholidayDates, int position, DateTime[] holidayDates)
        {
            var nearestHolidayDate = newholidayDates[position];

            int index = Array.IndexOf(holidayDates, nearestHolidayDate);

            return index;
        }
    }
}
  