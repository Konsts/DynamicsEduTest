using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTest
{
    public class WorkDayCalculator : IWorkDayCalculator
    {
        public DateTime Calculate(DateTime startDate, int dayCount, WeekEnd[] weekEnds)
        {
            if (startDate == null)
            {
                throw new Exception("StartDay is null or day count < 0");
            }

            if (dayCount < 0)
            {
                throw new Exception("Day count < 0");
            }

            if (dayCount==0)
            {
                return startDate;
            }
            var endDate = startDate.AddDays(dayCount);
            if (weekEnds == null)
            {
                return endDate.AddDays(-1);
            }
            foreach (var weekEnd in weekEnds)
            {
                if (weekEnd.StartDate <= endDate)
                {
                    var day = (weekEnd.EndDate - weekEnd.StartDate).Days;
                    endDate = endDate.AddDays(day);
                }
            }
            return endDate;
        }
    }
}
