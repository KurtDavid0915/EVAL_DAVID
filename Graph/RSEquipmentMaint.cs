using PX.Common;
using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentalServiceSetA
{
    // Acuminator disable once PX1018 NoPrimaryViewForPrimaryDac [Justification]
    public class RSEquipmentMaint : PXGraph<RSEquipmentMaint, RSEquipment>
    {
        #region Views
        public PXSelect<RSEquipment> Equipment;
        public PXSelect<RSEquipmentCategory> Categories;
        #endregion

        #region Field Event Handlers

        // a) FieldDefaulting for Status - default to "A"
        protected virtual void RSEquipment_Status_FieldDefaulting(PXCache sender, PXFieldDefaultingEventArgs e)
        {
            if (e.Row != null)
            {
                e.NewValue = "A"; // Available
            }
        }

        // b) FieldVerifying for DailyRate - ensure positive
        protected virtual void RSEquipment_DailyRate_FieldVerifying(PXCache sender, PXFieldVerifyingEventArgs e)
        {
            if (e.NewValue != null && Convert.ToDecimal(e.NewValue) < 0)
            {
                throw new PXSetPropertyException(Messages.dailyrate_Warn2);
            }
        }

        // c) FieldUpdated for CategoryID - show confirmation message
        protected virtual void RSEquipment_CategoryID_FieldUpdated(PXCache sender, PXFieldUpdatedEventArgs e)
        {
            if (e.Row is RSEquipment equipment && equipment.CategoryID != null)
            {
                sender.RaiseExceptionHandling<RSEquipment.categoryID>(
                    equipment,
                    equipment.CategoryID,
                    new PXSetPropertyException(Messages.dailyrate_Warn3, PXErrorLevel.RowInfo)
                );
            }
        }

        // d) FieldSelecting for calculated field "DaysOwned"
        protected virtual void RSEquipment_DaysOwned_FieldSelecting(PXCache sender, PXFieldSelectingEventArgs e)
        {
            if (e.Row is RSEquipment equipment && equipment.PurchaseDate != null)
            {
                e.ReturnValue = (int)((PXTimeZoneInfo.Now - equipment.PurchaseDate.Value).TotalDays);
            }
            else
            {
                e.ReturnValue = 0;
            }
        }

        #endregion

        #region Row Event Handlers

        // a) RowSelected - disable rates if Status = "X"
        protected virtual void RSEquipment_RowSelected(PXCache sender, PXRowSelectedEventArgs e)
        {
            if (e.Row is RSEquipment equipment)
            {
                bool retired = equipment.Status == "X";
                PXUIFieldAttribute.SetEnabled<RSEquipment.dailyRate>(sender, e.Row, !retired);
                PXUIFieldAttribute.SetEnabled<RSEquipment.weeklyRate>(sender, e.Row, !retired);
                PXUIFieldAttribute.SetEnabled<RSEquipment.monthlyRate>(sender, e.Row, !retired);
            }
        }

        // b) RowInserting - set PurchaseDate if null
        protected virtual void RSEquipment_RowInserting(PXCache sender, PXRowInsertingEventArgs e)
        {
            if (e.Row is RSEquipment equipment && equipment.PurchaseDate == null)
            {
                equipment.PurchaseDate = PXTimeZoneInfo.Now;
            }
        }

        // c) RowPersisting - validate at least one rate > 0
        protected virtual void RSEquipment_RowPersisting(PXCache sender, PXRowPersistingEventArgs e)
        {
            if (e.Row is RSEquipment equipment)
            {
                if ((equipment.DailyRate ?? 0) <= 0 &&
                    (equipment.WeeklyRate ?? 0) <= 0 &&
                    (equipment.MonthlyRate ?? 0) <= 0)
                {
                    throw new PXRowPersistingException(
                        nameof(RSEquipment.dailyRate),
                        equipment.DailyRate,
                       Messages.dailyrate_Warn
                    );
                }
            }
        }

        #endregion

        #region Calculation Methods
        protected virtual decimal CalculateWeeklyRate(decimal dailyRate)
        {
            return dailyRate * 6m;
        }
        protected virtual decimal CalculateMonthlyRate(decimal dailyRate)
        {
            return dailyRate * 22m;
        }
        #endregion

        #region Actions

        public PXAction<RSEquipment> CalculateRates;
        [PXButton(CommitChanges = true)]
        [PXUIField(DisplayName = "Calculate Rates")]
        protected virtual void calculateRates()
        {
            var row = Equipment.Current;
            if (row == null || row.DailyRate == null)
                return;

            row.WeeklyRate = CalculateWeeklyRate(row.DailyRate.Value);
            row.MonthlyRate = CalculateMonthlyRate(row.DailyRate.Value);

            Equipment.Update(row);
        }

        #endregion

        #region Validations

        protected virtual void _(Events.RowPersisting<RSEquipment> e)
        {
            var row = e.Row;
            if (row == null || row.DailyRate == null)
                return;

            if (row.WeeklyRate != null && row.DailyRate > row.WeeklyRate / 6m)
            {
                // Acuminator disable once PX1050 HardcodedStringInLocalizationMethod [Justification]
                throw new PXRowPersistingException(
                    typeof(RSEquipment.dailyRate).Name,
                    row.DailyRate,
                    ""
                );
            }

            if (row.MonthlyRate != null && row.DailyRate > row.MonthlyRate / 22m)
            {
                // Acuminator disable once PX1050 HardcodedStringInLocalizationMethod [Justification]
                throw new PXRowPersistingException(
                    typeof(RSEquipment.dailyRate).Name,
                    row.DailyRate,
                    "Daily Rate cannot exceed Monthly Rate divided by 22."
                );
            }
        }

        #endregion

    }
}
