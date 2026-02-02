using PX.Data;
using PX.Objects.AR;
using RentalServiceSetA;

namespace RentalServiceSetA
{
    public class CustomerMaintExt : PXGraphExtension<CustomerMaint>
    {
        #region Views

        // Show all rental contracts for the current customer
        public PXSelect<RSRentalContract,
            Where<RSRentalContract.customerID, Equal<Current<Customer.bAccountID>>>>
            RentalContracts;

        #endregion

        #region Validation

        protected virtual void _(Events.RowPersisting<Customer> e)
        {
            var row = e.Row;
            if (row == null) return;

            var ext = row.GetExtension<ARCustomerExt>();

            // Validation: Rental customers must have credit limit > 0
            if (ext.UsrIsRentalCustomer == true &&
                (ext.UsrRentalCreditLimit == null || ext.UsrRentalCreditLimit <= 0))
            {
                throw new PXRowPersistingException(
                    typeof(ARCustomerExt.usrRentalCreditLimit).Name,
                    ext.UsrRentalCreditLimit,
                    Messages.rentalLimit
                );
            }
        }

        #endregion

        #region Actions

        public PXAction<Customer> ViewRentalHistory;
        [PXButton]
        [PXUIField(DisplayName = "View Rental History")]
        protected virtual void viewRentalHistory()
        {
            // Stub for inquiry screen navigation
            // For exam purposes, this is sufficient
            throw new PXRedirectRequiredException(
                Base,
                "Rental History Inquiry (Stub)"
            );
        }

        public static bool IsActive()
        {
            return true; // or add your custom logic to enable/disable the extension
        }

        #endregion
    }
}
