using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileBillCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime peakStartTime = DateTime.Parse("09:00:00");
            DateTime peakEndTime = DateTime.Parse("22:59:59");

            DateTime start = DateTime.Parse("2019-08-31 08:59:13 am");
            DateTime end = DateTime.Parse("2019-08-31 09:00:39 am");

            decimal peakRate = 0.30m; // 30 paisa
            decimal offPeakRate = 0.20m; // 20 paisa

            decimal totalCost = CalculateMobileBill(start, end, peakStartTime, peakEndTime, peakRate, offPeakRate);

            Console.WriteLine("Total Mobile Bill: " + totalCost + " Taka");
        }

        static decimal CalculateMobileBill(DateTime start, DateTime end, DateTime peakStartTime, DateTime peakEndTime, decimal peakRate, decimal offPeakRate)
        {
            decimal totalCost = 0;

            while (start < end)
            {
                DateTime pulseEnd = start.AddSeconds(20);
                decimal rate = IsPeakTime(start, peakStartTime, peakEndTime) ? peakRate : offPeakRate;
                totalCost += rate;

                start = pulseEnd;
            }

            return totalCost;
        }

        static bool IsPeakTime(DateTime time, DateTime peakStartTime, DateTime peakEndTime)
        {
            if (time.TimeOfDay >= peakStartTime.TimeOfDay && time.TimeOfDay <= peakEndTime.TimeOfDay)
            {
                return true;
            }
            return false;
        }
    }
}
