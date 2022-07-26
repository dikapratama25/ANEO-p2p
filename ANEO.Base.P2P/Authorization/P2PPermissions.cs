using System;
using System.Collections.Generic;
using System.Text;

namespace Plexform.Authorization
{
    public static class P2PPermissions
    {
        public const string Pages_P2P = "Pages.P2P";

        #region Buyer Catalogue
        public const string Pages_P2P_Buyer_Catalogue = "Pages.P2P.Buyer.Catalogue";
        public const string Pages_P2P_Buyer_Catalogue_View = "Pages.P2P.Buyer.Catalogue.View";
        public const string Pages_P2P_Buyer_Catalogue_Raise = "Pages.P2P.Buyer.Catalogue.Raise";
        #endregion

        #region Purchase
        public const string Pages_P2P_Purchase = "Pages.P2P.Purchase";

        #region Purchase Request
        public const string Pages_P2P_Purchase_Request = "Pages.P2P.Purchase.Request";
        public const string Pages_P2P_Purchase_Request_Create = "Pages.P2P.Purchase.Request.Create";
        public const string Pages_P2P_Purchase_Request_Edit = "Pages.P2P.Purchase.Request.Edit";
        public const string Pages_P2P_Purchase_Request_Delete = "Pages.P2P.Purchase.Request.Delete";
        #endregion

        #region Purchase Order
        public const string Pages_P2P_Purchase_Order = "Pages.P2P.Purchase.Order";
        public const string Pages_P2P_Purchase_Order_ConvertPR = "Pages.P2P.Purchase.Order.ConvertPR";
        public const string Pages_P2P_Purchase_Order_AcknowledgePO = "Pages.P2P.Purchase.Order.AcknowledgePO";
        public const string Pages_P2P_Purchase_Request_Detail = "Pages.P2P.Purchase.Request.Detail";
        public const string Pages_P2P_Purchase_Order_Create = "Pages.P2P.Purchase.Order.Create";
        public const string Pages_P2P_Purchase_Order_Edit = "Pages.P2P.Purchase.Order.Edit";
        public const string Pages_P2P_Purchase_Order_Delete = "Pages.P2P.Purchase.Order.Delete";
        #endregion

        #endregion

        #region Approval
        public const string Pages_P2P_Approval_Setup = "Pages.P2P.Approval.Setup";
        public const string Pages_P2P_Approval_Setup_Purchase_Request = "Pages.P2P.Approval.Setup.Purchase.Request";
        public const string Pages_P2P_Approval_Setup_Purchase_Order = "Pages.P2P.Approval.Setup.Purchase.Order";

        #endregion

        #region Invoice
        public const string Pages_P2P_Invoice = "Pages.P2P.Invoice";
        public const string Pages_P2P_Invoice_Listing = "Pages.P2P.Invoice.Listing";
        public const string Pages_P2P_Invoice_Issue = "Pages.P2P.Invoice.Issue";
        public const string Pages_P2P_Invoice_Issue_Detail = "Pages.P2P.Invoice.Issue.Detail";
        public const string Pages_P2P_Invoice_Issue_Proceed = "Pages.P2P.Invoice.Issue.Proceed";

        public const string Pages_P2P_Invoice_Tracking = "Pages.P2P.Invoice_Tracking";
        public const string Pages_P2P_Invoice_Tracking_Listing = "Pages.P2P.Invoice.Tracking.Listing";
        public const string Pages_P2P_Invoice_Tracking_Detail= "Pages.P2P.Invoice.Tracking.Detail";
        public const string Pages_P2P_Invoice_Tracking_Paid = "Pages.P2P.Invoice.Tracking.Paid";
        public const string Pages_P2P_Invoice_Tracking_Verified_Listing = "Pages.P2P.Invoice.Tracking.Verified.Listing";
        public const string Pages_P2P_Invoice_Tracking_Verified_Detail = "Pages.P2P.Invoice.Tracking.Verified.Detail";
        #endregion

        #region DO
        public const string Pages_P2P_DO = "Pages.P2P.DO";
        public const string Pages_P2P_DO_Listing = "Pages.P2P.DO.Listing";
        public const string Pages_P2P_DO_Issue_POListing = "Pages.P2P.DO.Issue.POListing";
        public const string Pages_P2P_DO_Issue_Create = "Pages.P2P.DO.Issue.Create";
        public const string Pages_P2P_DO_Issue_Edit = "Pages.P2P.DO.Issue.Edit";
        public const string Pages_P2P_DO_Issue_View = "Pages.P2P.DO.Issue.View";
        #endregion

        #region GRN 
        public const string Pages_P2P_GRN = "Pages.P2P.GRN";
        public const string Pages_P2P_GRN_Listing = "Pages.P2P.GRN.Listing";
        public const string Pages_P2P_GRN_Detail = "Pages.P2P.GRN.Detail";
        public const string Pages_P2P_GRN_Issue = "Pages.P2P.GRN.Issue";
        public const string Pages_P2P_GRN_Issue_Detail = "Pages.P2P.GRN.Issue.Detail";
        #endregion

        #region Item Master
        public const string Pages_P2P_ItemMaster = "Pages.P2P.ItemMaster";
        public const string Pages_P2P_ItemMaster_Listing = "Pages.P2P.ItemMaster.Listing";
        public const string Pages_P2P_ItemMaster_Create = "Pages.P2P.ItemMaster.Create";
        public const string Pages_P2P_ItemMaster_Edit = "Pages.P2P.ItemMaster.Edit";
        public const string Pages_P2P_ItemMaster_View = "Pages.P2P.ItemMaster.View";
        #endregion

        #region Manage
        public const string Pages_P2P_Manage = "Pages.P2P.Manage";
        public const string Pages_P2P_Manage_CompProfil = "Pages.P2P.Manage.CompProfil";
        #endregion

    }
}
