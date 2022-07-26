using Abp.Authorization;
using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.MultiTenancy;

namespace Plexform.Authorization
{
    /// <summary>
    /// Application's authorization provider.
    /// Defines permissions for the application.
    /// See <see cref="AppPermissions"/> for all permission names.
    /// </summary>
    public class P2PAuthorizationProvider : AuthorizationProvider
    {
        private readonly bool _isMultiTenancyEnabled;

        public P2PAuthorizationProvider(bool isMultiTenancyEnabled)
        {
            _isMultiTenancyEnabled = isMultiTenancyEnabled;
        }

        public P2PAuthorizationProvider(IMultiTenancyConfig multiTenancyConfig)
        {
            _isMultiTenancyEnabled = multiTenancyConfig.IsEnabled;
        }

        public override void SetPermissions(IPermissionDefinitionContext context)
        {
            //COMMON PERMISSIONS (FOR BOTH OF TENANTS AND HOST)

            //Check Root Exist
            var pages = context.GetPermissionOrNull(AppPermissions.Pages) ?? context.CreatePermission(AppPermissions.Pages, L("Pages"));

            //Local Permission
            var p2p = pages.CreateChildPermission(P2PPermissions.Pages_P2P, L("P2P"));

            #region Buyer Catalogue
            var bc = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_Buyer_Catalogue, L("BuyerCatalogue"));
            bc.CreateChildPermission(P2PPermissions.Pages_P2P_Buyer_Catalogue_View, L("BuyerCatalogueView"));
            bc.CreateChildPermission(P2PPermissions.Pages_P2P_Buyer_Catalogue_Raise, L("BuyerCatalogueRaise"));
            #endregion

            #region Purchase
            var purchase = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase, L("Purchase"));

            #region Purchase Request
            var pr = purchase.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Request, L("PurchaseRequest"));
            pr.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Request_Create, L("Create"));
            pr.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Request_Edit, L("Edit"));
            pr.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Request_Delete, L("Delete"));
            #endregion

            #region Purchase Order
            var po = purchase.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Order, L("PurchaseOrder"));
            po.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Order_ConvertPR, L("ConvertPR"));
            po.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Order_AcknowledgePO, L("acknowledge"));
            po.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Order_Create, L("Create"));
            po.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Order_Edit, L("Edit"));
            po.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Request_Detail, L("Detail"));
            po.CreateChildPermission(P2PPermissions.Pages_P2P_Purchase_Order_Delete, L("Delete"));
            #endregion

            #region acknowledgePO
            #endregion

            #endregion

            #region Approval Setup
            var app = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_Approval_Setup, L("ApprovalSetup"));
            app.CreateChildPermission(P2PPermissions.Pages_P2P_Approval_Setup_Purchase_Request, L("PRApproval"));
            app.CreateChildPermission(P2PPermissions.Pages_P2P_Approval_Setup_Purchase_Order, L("POApproval"));
            #endregion

            #region Invoice
            var inv = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice, L("Invoice"));
            inv.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Listing, L("InvoiceListing"));
            inv.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Issue, L("IssueInvoice"));
            inv.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Issue_Detail, L("IssueInvoiceDetail"));
            inv.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Issue_Proceed, L("IssueInvoiceProceed"));
            var tracking = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Tracking, L("Tracking"));
            tracking.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Tracking_Listing, L("TrackingListing"));
            tracking.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Tracking_Detail, L("TrackingDetail"));
            tracking.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Tracking_Paid, L("TrackingPaid"));
            tracking.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Tracking_Verified_Listing, L("TrackingVerifiedListing"));
            tracking.CreateChildPermission(P2PPermissions.Pages_P2P_Invoice_Tracking_Verified_Detail, L("TrackingVerifiedDetail"));
            #endregion

            #region DO
            var DO = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_DO, L("DeliveryOrder"));
            DO.CreateChildPermission(P2PPermissions.Pages_P2P_DO_Listing, L("DeliveryOrderListing"));
            DO.CreateChildPermission(P2PPermissions.Pages_P2P_DO_Issue_POListing, L("IssueDeliveryOrder"));
            DO.CreateChildPermission(P2PPermissions.Pages_P2P_DO_Issue_Create, L("IssueDeliveryOrderCreate"));
            DO.CreateChildPermission(P2PPermissions.Pages_P2P_DO_Issue_Edit, L("IssueDeliveryOrderEdit"));
            DO.CreateChildPermission(P2PPermissions.Pages_P2P_DO_Issue_View, L("IssueDeliveryOrderView"));
            #endregion

            #region GRN 
            var GRN = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_GRN, L("GRN"));
            GRN.CreateChildPermission(P2PPermissions.Pages_P2P_GRN_Listing, L("GRNListing"));
            GRN.CreateChildPermission(P2PPermissions.Pages_P2P_GRN_Issue, L("IssueGRN"));
            GRN.CreateChildPermission(P2PPermissions.Pages_P2P_GRN_Issue_Detail, L("IssueGRNDetail"));
            #endregion

            #region Item Master
            var item = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_ItemMaster, L("ItemMaster"));
            item.CreateChildPermission(P2PPermissions.Pages_P2P_ItemMaster_Listing, L("ItemMasterListing"));
            item.CreateChildPermission(P2PPermissions.Pages_P2P_ItemMaster_Create, L("ItemMasterCreate"));
            item.CreateChildPermission(P2PPermissions.Pages_P2P_ItemMaster_Edit, L("ItemMasterEdit"));
            item.CreateChildPermission(P2PPermissions.Pages_P2P_ItemMaster_View, L("ItemMasterView"));
            #endregion

            #region Manage
            var manage = p2p.CreateChildPermission(P2PPermissions.Pages_P2P_Manage, L("Manage"));
            manage.CreateChildPermission(P2PPermissions.Pages_P2P_Manage_CompProfil, L("CompProfil"));
            #endregion
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlexformConsts.LocalizationSourceName);
        }
    }
}
