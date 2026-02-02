using PX.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalServiceSetA
{
    [PXLocalizable]
    public static class Messages
    {
        public const string dailyrate = "Daily Rate cannot exceed Weekly Rate divided by 6.";
        public const string monthlyrate = "Daily Rate cannot exceed Monthly Rate divided by 22.";
        public const string rentalLimit = "Rental Credit Limit must be greater than zero for rental customers.";
        public const string dailyrate_Warn = "At least one rate (Daily, Weekly, Monthly) must be greater than zero.";
        public const string dailyrate_Warn2 = "Daily Rate must be positive.";
        public const string dailyrate_Warn3 = "Category changed";

    }
}
