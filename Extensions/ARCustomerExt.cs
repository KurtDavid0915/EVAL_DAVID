using PX.Data;
using PX.Objects.AR;

namespace RentalServiceSetA
{
    public class ARCustomerExt : PXCacheExtension<Customer>
    {
        #region UsrIsRentalCustomer
        [PXDBBool]
        [PXUIField(DisplayName = "Rental Customer")]
        public virtual bool? UsrIsRentalCustomer { get; set; }
        public abstract class usrIsRentalCustomer : PX.Data.BQL.BqlBool.Field<usrIsRentalCustomer> { }
        #endregion

        #region UsrRentalCreditLimit
        [PXDBDecimal()]
        [PXUIField(DisplayName = "Rental Credit Limit")]
        public virtual decimal? UsrRentalCreditLimit { get; set; }
        public abstract class usrRentalCreditLimit : PX.Data.BQL.BqlDecimal.Field<usrRentalCreditLimit> { }
        #endregion

        #region Actions
        public static bool IsActive()
        {
            return true; // or add your custom logic to enable/disable the extension
        }
        #endregion

    }

}
