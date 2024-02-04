﻿namespace PasswordManagerClient.Services
{
    public class ExpirationCalculator
    {
       public string  CalculateDaysUntilExpiration(string startDate, string endDate, string monthsUntillExpiration){

            var res = calculateDays(startDate, endDate, monthsUntillExpiration);
            if(res <= 0) 
            {
                return "Expired";
            }
            else if(res <= 28)
            {
                return res.ToString() + " days";
            }
            else if(res <= 59)
            {
                return "1 month " + (res - 30).ToString() + " days";
            }
            else if(res <= 89)
            {
                return "2 months " + (res - 60).ToString() + " days";
            }
            else
            {
                return res.ToString() + " days";
            }

        }
       public uint calculateDays(string startDate, string endDate, string monthsUntillExpiration)
        {
            var t1 = DateTime.Parse(startDate);
            var t2 = DateTime.Parse(endDate);
            var nrOfMonths = getNrOfMonthsFromString(monthsUntillExpiration);
            var t3 = t1.AddMonths(nrOfMonths);
            var ret = (uint)(t3 - t2).TotalDays;
            if (ret <= 0)
                return 0;
            else
                return (uint)ret;
        }

        private int getNrOfMonthsFromString(string monthsUntillExpiration)
        {
            switch (monthsUntillExpiration)
            {
                case "1 month":
                    return 1;
                case "2 months":
                    return 2;
                case "3 months":
                    return 3;
                default:
                    return 1;
            }
        }
    }
}
