<%@ Page Language="C#" MasterPageFile="~/MasterPages/TabView.master" 
    AutoEventWireup="true" ValidateRequest="false" 
    CodeFile="RS301000.aspx.cs" Inherits="RentalServiceSetA.RS301000" 
    Title="Equipment Maintenance" %>

<%@ MasterType VirtualPath="~/MasterPages/TabView.master" %>
<%@ Register TagPrefix="px" Namespace="PX.Web.UI" Assembly="PX.Web.UI" %>

<!-- DataSource Content -->
<asp:Content ID="cont1" ContentPlaceHolderID="phDS" runat="Server">
    <px:PXDataSource ID="ds" runat="server" TypeName="RentalServiceSetA.RSEquipmentMaint" PrimaryView="Equipment" Visible="True">
        <CallbackCommands>
            <px:PXDSCallbackCommand Name="Save" CommitChanges="True" />
        </CallbackCommands>
    </px:PXDataSource>
</asp:Content>

<!-- Form / Tab Content -->
<asp:Content ID="cont2" ContentPlaceHolderID="phF" runat="Server">
    <px:PXTab ID="tab" runat="server" DataSourceID="ds" Width="100%" Height="500px" DataMember="Equipments" DefaultControlID="edEquipmentCD" TabIndex="100">
        <Items>
            <!-- General Info Tab -->
            <px:PXTabItem Text="General Info">
                <Template>
                    <px:PXLayoutRule StartColumn="True" />
                    <px:PXTextEdit ID="edEquipmentCD" runat="server" DataField="EquipmentCD" />
                    <px:PXTextEdit ID="edDescription" runat="server" DataField="Description" />
                    <px:PXSelector ID="selCategoryID" runat="server" DataField="CategoryID" />
                    <px:PXComboBox ID="cmbStatus" runat="server" DataField="Status" />
                    <px:PXDateTimeEdit ID="edPurchaseDate" runat="server" DataField="PurchaseDate" />
                    <px:PXCurrencyEdit ID="edPurchaseCost" runat="server" DataField="PurchaseCost" />
                    <px:PXTextEdit ID="edDaysOwned" runat="server" DataField="DaysOwned" ReadOnly="True" />
                </Template>
            </px:PXTabItem>

            <!-- Rental Rates Tab -->
            <px:PXTabItem Text="Rental Rates">
                <Template>
                    <px:PXLayoutRule StartColumn="True" />
                    <px:PXCurrencyEdit ID="edDailyRate" runat="server" DataField="DailyRate" />
                    <px:PXCurrencyEdit ID="edWeeklyRate" runat="server" DataField="WeeklyRate" />
                    <px:PXCurrencyEdit ID="edMonthlyRate" runat="server" DataField="MonthlyRate" />
                    <px:PXComboBox ID="cmbRateType" runat="server" DataField="RateType" />
                    <px:PXButton ID="btnCalculateRates" runat="server" Text="Calculate Rates" DataField="CalculateRates" />
                </Template>
            </px:PXTabItem>
        </Items>
        <AutoSize Container="Window" Enabled="True" MinHeight="300" />
    </px:PXTab>
</asp:Content>
