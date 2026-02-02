using PX.Data;
using RentalServiceSetA;
using System;

namespace RentalServiceSetA
{
    [PXCacheName("Rental Equipment")]
    public class RSEquipment : PXBqlTable, IBqlTable
    {
        #region EquipmentID
        [PXDBIdentity(IsKey = true)]
        public virtual int? EquipmentID { get; set; }
        public abstract class equipmentID : PX.Data.BQL.BqlInt.Field<equipmentID> { }
        #endregion

        #region EquipmentCD
        [PXDBString(30, IsUnicode = true)]
        [PXUIField(DisplayName = "Equipment Code")]
        [PXDefault]
        public virtual string EquipmentCD { get; set; }
        public abstract class equipmentCD : PX.Data.BQL.BqlString.Field<equipmentCD> { }
        #endregion

        #region Description
        [PXDBString(255, IsUnicode = true)]
        [PXUIField(DisplayName = "Description")]
        public virtual string Description { get; set; }
        public abstract class description : PX.Data.BQL.BqlString.Field<description> { }
        #endregion

        #region CategoryID
        [PXDBInt]
        [PXUIField(DisplayName = "Category")]
        [PXSelector(
            typeof(Search<RSEquipmentCategory.categoryCD>),
            SubstituteKey = typeof(RSEquipmentCategory.categoryCD),
            DescriptionField = typeof(RSEquipmentCategory.description)
        )]
        [PXDefault]
        public virtual int? CategoryID { get; set; }
        public abstract class categoryID : PX.Data.BQL.BqlInt.Field<categoryID> { }
        #endregion

        #region DailyRate
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Daily Rate")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual decimal? DailyRate { get; set; }
        public abstract class dailyRate : PX.Data.BQL.BqlDecimal.Field<dailyRate> { }
        #endregion

        #region WeeklyRate
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Weekly Rate")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual decimal? WeeklyRate { get; set; }
        public abstract class weeklyRate : PX.Data.BQL.BqlDecimal.Field<weeklyRate> { }
        #endregion

        #region MonthlyRate
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Monthly Rate")]
        [PXDefault(TypeCode.Decimal, "0.0")]
        public virtual decimal? MonthlyRate { get; set; }
        public abstract class monthlyRate : PX.Data.BQL.BqlDecimal.Field<monthlyRate> { }
        #endregion

        #region RateType
        [PXDBString(1, IsFixed = true)]
        [RSRateType] // Custom attribute from Task 5.2
        [PXUIField(DisplayName = "Rate Type")]
        public virtual string RateType { get; set; }
        public abstract class rateType : PX.Data.BQL.BqlString.Field<rateType> { }
        #endregion

        #region Status
        [PXDBString(1, IsFixed = true)]
        [RSEquipmentStatus]
        [PXUIField(DisplayName = "Status")]
        [PXStringList(
            new[] { "A", "R", "M", "X" },
            new[] { "Available", "Rented", "Maintenance", "Retired" }
        )]
        [PXDefault("A")]
        public virtual string Status { get; set; }
        public abstract class status : PX.Data.BQL.BqlString.Field<status> { }
        #endregion

        #region PurchaseDate
        [PXDBDate]
        [PXUIField(DisplayName = "Purchase Date")]
        public virtual DateTime? PurchaseDate { get; set; }
        public abstract class purchaseDate : PX.Data.BQL.BqlDateTime.Field<purchaseDate> { }
        #endregion

        #region PurchaseCost
        [PXDBDecimal(4)]
        [PXUIField(DisplayName = "Purchase Cost")]
        public virtual decimal? PurchaseCost { get; set; }
        public abstract class purchaseCost : PX.Data.BQL.BqlDecimal.Field<purchaseCost> { }
        #endregion

        #region NoteID
        [PXNote]
        public virtual Guid? NoteID { get; set; }
        public abstract class noteID : PX.Data.BQL.BqlGuid.Field<noteID> { }
        #endregion

        #region Audit Fields
        [PXDBCreatedByID]
        public virtual Guid? CreatedByID { get; set; }

        [PXDBCreatedDateTime]
        public virtual DateTime? CreatedDateTime { get; set; }

        [PXDBLastModifiedByID]
        public virtual Guid? LastModifiedByID { get; set; }

        [PXDBLastModifiedDateTime]
        public virtual DateTime? LastModifiedDateTime { get; set; }

        [PXDBTimestamp]
        public virtual byte[] Tstamp { get; set; }
        #endregion
    }
}
