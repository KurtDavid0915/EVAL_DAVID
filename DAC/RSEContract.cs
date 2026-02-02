using PX.Data;
using System;

namespace RentalServiceSetA
{
    [PXCacheName("Rental Contract")]
    public class RSRentalContract : PXBqlTable, IBqlTable
    {
        #region ContractID
        [PXDBIdentity(IsKey = true)]
        public virtual int? ContractID { get; set; }
        public abstract class contractID : PX.Data.BQL.BqlInt.Field<contractID> { }
        #endregion

        #region CustomerID
        [PXDBInt]
        [PXUIField(DisplayName = "Customer")]
        public virtual int? CustomerID { get; set; }
        public abstract class customerID : PX.Data.BQL.BqlInt.Field<customerID> { }
        #endregion

        #region ContractDate
        [PXDBDate]
        [PXUIField(DisplayName = "Contract Date")]
        public virtual DateTime? ContractDate { get; set; }
        public abstract class contractDate : PX.Data.BQL.BqlDateTime.Field<contractDate> { }
        #endregion
    }
}
