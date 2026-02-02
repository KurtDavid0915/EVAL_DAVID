using PX.Data;

namespace RentalServiceSetA
{
    public class RSEquipmentStatusAttribute : PXStringListAttribute
    {
        // Status Codes
        public const string Available = "A";
        public const string Rented = "R";
        public const string Maintenance = "M";
        public const string Retired = "X";

        public RSEquipmentStatusAttribute()
            : base(
                new string[] { Available, Rented, Maintenance, Retired },
                new string[] { "Available", "Rented", "Maintenance", "Retired" }
              )
        {
        }

        // Optional: helper nested class for BQL
        public class available : PX.Data.BQL.BqlString.Constant<available>
        {
            public available() : base(Available) { }
        }

        public class rented : PX.Data.BQL.BqlString.Constant<rented>
        {
            public rented() : base(Rented) { }
        }

        public class maintenance : PX.Data.BQL.BqlString.Constant<maintenance>
        {
            public maintenance() : base(Maintenance) { }
        }

        public class retired : PX.Data.BQL.BqlString.Constant<retired>
        {
            public retired() : base(Retired) { }
        }
    }
}
