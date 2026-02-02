using PX.Data;

namespace RentalServiceSetA
{
    public class RSRateTypeAttribute : PXStringListAttribute
    {
        // Rate Type Codes
        public const string Daily = "D";
        public const string Weekly = "W";
        public const string Monthly = "M";

        public RSRateTypeAttribute()
            : base(
                new string[] { Daily, Weekly, Monthly },
                new string[] { "Daily", "Weekly", "Monthly" }
              )
        {
        }

        // Optional: nested static class for BQL constants
        public static class List
        {
            public class daily : PX.Data.BQL.BqlString.Constant<daily>
            {
                public daily() : base(Daily) { }
            }

            public class weekly : PX.Data.BQL.BqlString.Constant<weekly>
            {
                public weekly() : base(Weekly) { }
            }

            public class monthly : PX.Data.BQL.BqlString.Constant<monthly>
            {
                public monthly() : base(Monthly) { }
            }
        }
    }
}
