using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestingOOP
{
    internal class DateTimeConverstion
    {
        public void LocalToUTCConvrtion()
        {
            var currentLcoalTime = DateTime.Now;
            RegionInfo region = new RegionInfo("PK");
            var CountryName = region.EnglishName.ToString();
            TimeZoneInfo dubaiLocalTime = TimeZoneInfo.FindSystemTimeZoneById("Arabian Standard Time");
            var DubaiCurrentTimeZone = TimeZoneInfo.ConvertTime(currentLcoalTime, dubaiLocalTime);
            Console.WriteLine($"{CountryName} Local Time is: {currentLcoalTime}" +
                $"\x0AThe Dubai Local Time is: {DubaiCurrentTimeZone}");
            Console.ReadKey();

        }

    }
}
