using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Plexform.Base;
using System.Collections.Generic;
using LOGIC.Base;

namespace ANEO.Base.P2P.General.Map
{
    public class MapGeneral
    {
        [JsonProperty("userid")]
        [Required]
        public virtual string UserID { get; set; }
        [JsonProperty("companyid")]
        [Required]
        public virtual string CompanyID { get; set; }

    }
    public class MapCountData
    {
        [JsonProperty("countdata")]
        public virtual int CountData { get; set; }
        [JsonProperty("countdate")]
        public virtual int CountDataDate { get; set; }
    }

    [Abp.AutoMapper.AutoMapTo(typeof(AgoraNEO.AgoraNEO.User))]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MapUser : MapGeneral
    {
        [JsonProperty("name")]
        public virtual string Name { get; set; }
        [JsonProperty("deptid")]
        public virtual string DeptID { get; set; }
        [JsonProperty("deptname")]
        public virtual string DeptName { get; set; }
        [JsonProperty("password")]
        public virtual string Password { get; set; }
        [JsonProperty("email")]
        public virtual string Email { get; set; }
        [JsonProperty("phoneno")]
        public virtual string PhoneNo { get; set; }
        [JsonProperty("faxno")]
        public virtual string FaxNo { get; set; }
        [JsonProperty("approvelimit")]
        public virtual string ApproveLimit { get; set; }
        [JsonProperty("poapprovelimit")]
        public virtual string POApproveLimit { get; set; }
        [JsonProperty("invoiceapprovelimit")]
        public virtual string InvoiceApproveLimit { get; set; }
        [JsonProperty("status")]
        public virtual char Status { get; set; }
        [JsonProperty("deleteind")]
        public virtual string DeleteInd { get; set; }
        [JsonProperty("pwdlastchg")]
        public virtual string PwdLastChg { get; set; }
        [JsonProperty("newpwdind")]
        public virtual string NewPwdInd { get; set; }
        [JsonProperty("lastlogin")]
        public virtual DateTime LastLogin { get; set; }
        [JsonProperty("nextexpireddt")]
        public virtual DateTime NextExpiredDt { get; set; }
        [JsonProperty("question")]
        public virtual int Question { get; set; }
        [JsonProperty("answer")]
        public virtual string Answer { get; set; }
        [JsonProperty("usergroup")]
        public virtual string UserGroup { get; set; }
        [JsonProperty("usergroupname")]
        public virtual string UserGroupName { get; set; }
        [JsonProperty("designation")]
        public virtual string Designation { get; set; }
        [JsonProperty("massapp")]
        public virtual string MassApp { get; set; }
        [JsonProperty("invoicemassapp")]
        public virtual string InvoiceMassApp { get; set; }
        [JsonProperty("mrsmassapp")]
        public virtual string MrsMassApp { get; set; }
        [JsonProperty("stocktypespot")]
        public virtual string StockTypeSpot { get; set; }
        [JsonProperty("stocktypestock")]
        public virtual string StockTypeStock { get; set; }
        [JsonProperty("stocktypemro")]
        public virtual string StockTypeMro { get; set; }
        [JsonProperty("pagecount")]
        public virtual int PageCount { get; set; }
        [JsonProperty("cclist")]
        [MaxLength(20)]
        public virtual string CCList { get; set; }
        [JsonProperty("strfixedrole")]
        public virtual string strFixedRole { get; set; }
        [JsonProperty("policyagreedt")]
        public virtual string PolicyAgreeDt { get; set; }
        [JsonProperty("scemailonoff")]
        public virtual string SCEmailOnOff { get; set; }
    }

    [Abp.AutoMapper.AutoMapTo(typeof(AgoraNEO.AgoraNEO.AppMail))]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MapAppMail : MapGeneral
    {
        [JsonProperty("mailto")]
        public virtual string MailTo { get; set; }
        [JsonProperty("mailfrom")]
        public virtual string MailFrom { get; set; }
        [JsonProperty("mailacct")]
        public virtual string MailAcct { get; set; }
        [JsonProperty("mailacctp")]
        public virtual string MailAcctP { get; set; }
        [JsonProperty("mailacct2")]
        public virtual string MailAcct2 { get; set; }
        [JsonProperty("mailacctp2")]
        public virtual string MailAcctP2 { get; set; }
        [JsonProperty("mailacct3")]
        public virtual string MailAcct3 { get; set; }
        [JsonProperty("mailacctp3")]
        public virtual string MailAcctP3 { get; set; }
        [JsonProperty("subject")]
        public virtual string Subject { get; set; }
        [JsonProperty("body")]
        public virtual string Body { get; set; }
        [JsonProperty("mailcc")]
        public virtual string MailCc { get; set; }
        [JsonProperty("mailbcc")]
        public virtual string MailBCc { get; set; }
        [JsonProperty("mailserver")]
        public virtual string MailServer { get; set; }
        [JsonProperty("mailport")]
        public virtual string MailPort { get; set; }
        [JsonProperty("attachment")]
        public virtual System.Collections.ArrayList Attachment { get; set; }
        [JsonProperty("priority")]
        public virtual int Priority { get; set; }
    }

    //public class MapPRMaster : MapGeneral
    //{
    //    [JsonProperty("prno")]
    //    public virtual string PRNo { get; set; }
    //    [JsonProperty("reqname")]
    //    public virtual string ReqName { get; set; }
    //    [JsonProperty("attn")]
    //    public virtual string Attn { get; set; }
    //    [JsonProperty("reqphone")]
    //    public virtual string ReqPhone { get; set; }
    //    [JsonProperty("prsemail")]
    //    public virtual string PRSEmail { get; set; }
    //    [JsonProperty("internalremark")]
    //    public virtual string InternalRemark { get; set; }
    //    [JsonProperty("externalremark")]
    //    public virtual string ExternalRemark { get; set; }
    //    [JsonProperty("printcustom")]
    //    public virtual string PrintCustom { get; set; }
    //    [JsonProperty("printremark")]
    //    public virtual string PrintRemark { get; set; }
    //    [JsonProperty("urgent")]
    //    public virtual string Urgent { get; set; }
    //    [JsonProperty("shipmentterm")]
    //    public virtual string ShipmentTerm { get; set; }
    //    [JsonProperty("shipmentmode")]
    //    public virtual string ShipmentMode { get; set; }
    //    [JsonProperty("prtype")]
    //    public virtual string PRType { get; set; }
    //    [JsonProperty("prcost")]
    //    public virtual double PRCost { get; set; }
    //    [JsonProperty("billaddrCode")]
    //    public virtual string BillAddrCode { get; set; }
    //    [JsonProperty("billaddrline1")]
    //    public virtual string BillAddrLine1 { get; set; }
    //    [JsonProperty("billaddrline2")]
    //    public virtual string BillAddrLine2 { get; set; }
    //    [JsonProperty("billaddrline3")]
    //    public virtual string BillAddrLine3 { get; set; }
    //    [JsonProperty("billaddrpostcode")]
    //    public virtual string BillAddrPostCode { get; set; }
    //    [JsonProperty("billaddrstate")]
    //    public virtual string BillAddrState { get; set; }
    //    [JsonProperty("billaddrcity")]
    //    public virtual string BillAddrCity { get; set; }
    //    [JsonProperty("billaddrcountry")]
    //    public virtual string BillAddrCountry { get; set; }
    //    [JsonProperty("details")]
    //    public virtual List<MapPRMasterDetail> Details { get; set; }
    //    [JsonProperty("approvalorders")]
    //    public virtual List<MapApprovalOrder> ApprovalOrders { get; set; }
    //    [JsonProperty("fileattachments")]
    //    public virtual List<Master.Map.company_doc_attachment.MapFileAttachment> FileAttachments { get; set; }
    //    [JsonProperty("nonftn")]
    //    public virtual string NonFTN { get; set; }
    //    [JsonProperty("mode")]
    //    public virtual string Mode { get; set; }
    //    [JsonProperty("SaveMode")]
    //    public virtual int SaveMode { get; set; }
    //    [JsonProperty("attachmentid")]
    //    public virtual string AttachmentID { get; set; }
    //}
    //public class mapApprovedPR : MapGeneral
    //{
     
    //    [JsonProperty("prno")]
    //    public virtual string prno { get; set; }
    //    [JsonProperty("PRIndex")]
    //    public virtual long PRIndex { get; set; }
    //    [JsonProperty("blnhighestlevel")]
    //    public virtual bool blnhighestlevel { get; set; }
    //    [JsonProperty("urgent")]
    //    public virtual string Urgent { get; set; }
    //    [JsonProperty("buyer")]
    //    public virtual string buyer { get; set; }
    //    [JsonProperty("strApp")]
    //    public virtual string strApp { get; set; }
    //    [JsonProperty("ApprType")]
    //    public virtual string  ApprType { get; set; }
    //    [JsonProperty("strBC")]
    //    public virtual string strBC { get; set; }
    //    [JsonProperty("strAction")]
    //    public virtual string strAction { get; set; }
    //    [JsonProperty("seq")]
    //    public virtual int seq { get; set; }

    //}
    //public class mapRejectPR : MapGeneral
    //{

    //    [JsonProperty("prno")]
    //    public virtual string prno { get; set; }
    //    [JsonProperty("PRIndex")]
    //    public virtual long PRIndex { get; set; }
    //    [JsonProperty("blnhighestlevel")]
    //    public virtual bool blnhighestlevel { get; set; }
    //    [JsonProperty("urgent")]
    //    public virtual string Urgent { get; set; }
    //    [JsonProperty("buyer")]
    //    public virtual string buyer { get; set; }
    //    [JsonProperty("strApp")]
    //    public virtual string strApp { get; set; }
    //    [JsonProperty("ApprType")]
    //    public virtual string ApprType { get; set; }
    //    [JsonProperty("strBC")]
    //    public virtual string strBC { get; set; }
    //    [JsonProperty("strAction")]
    //    public virtual string strAction { get; set; }
    //    [JsonProperty("seq")]
    //    public virtual int seq { get; set; }

    //}
    //public class mapPRMasterDetailHead : MapPRMasterDetail
    //{
    //    [JsonProperty("dccreatedate")]
    //    public virtual string DtCreateDate { get; set; }
    //    [JsonProperty("prno")]
    //    public virtual string PRNo { get; set; }
    //    [JsonProperty("urgent")]
    //    public virtual string Urgent { get; set; }
    //    [JsonProperty("VV")]
    //    public virtual string Status { get; set; }

    //    [JsonProperty("reqname")]
    //    public virtual string ReqName { get; set; }

    //    [JsonProperty("prdate")]
    //    public virtual string PRDate { get; set; }
    //    [JsonProperty("reqcon")]
    //    public virtual string ReqCon { get; set; }
    //    [JsonProperty("att")]
    //    public virtual string Att { get; set; }
    //    [JsonProperty("internal")]
    //    public virtual string Internal { get; set; }

    //    [JsonProperty("external")]
    //    public virtual string External { get; set; }
    //    [JsonProperty("crdate")]
    //    public virtual string CrDate { get; set; }
    //    [JsonProperty("prtype")]
    //    public virtual string PRType { get; set; }
    //    [JsonProperty("requestor")]
    //    public virtual string Requestor { get; set; }
    //    [JsonProperty("prindex")]
    //    public virtual string PRIndex { get; set; }
    //    [JsonProperty("seq")]
    //    public virtual string seq { get; set; }
    //    [JsonProperty("gstpr")]
    //    public virtual string GSTPR { get; set; }
       
    //}
    //public class mapPRMasterDetailBody : MapPRMasterDetail
    //{
    //    [JsonProperty("attachindex")]
    //    public virtual string AttachIndex { get; set; }
    //    [JsonProperty("coyid")]
    //    public virtual string CoyID { get; set; }
    //    [JsonProperty("docno")]
    //    public virtual string DocNo { get; set; }
    //    [JsonProperty("doctype")]
    //    public virtual string DocType { get; set; }
    //    [JsonProperty("hubfilename")]
    //    public virtual string HubFilename { get; set; }
    //    [JsonProperty("attachfilename")]
    //    public virtual string AttachFilename { get; set; }
    //    [JsonProperty("filesize")]
    //    public virtual string Filesize { get; set; }
    //    [JsonProperty("type")]
    //    public virtual string Type { get; set; }

    //    [JsonProperty("status")]
    //    public virtual string Status { get; set; }

    //}
    //public class mapPRMasterDetailFoot
    //{
    //    [JsonProperty("pra_seq")]
    //    [Grid(IsVisible = true, Width = 50)]
    //    public virtual string PRA_SEQ { get; set; }
    //    [JsonProperty("ao_name")]
    //    [Grid(IsVisible = true, Width = 80)]
    //    public virtual string AO_NAME { get; set; }
    //    [JsonProperty("aao_name")]
    //    [Grid(IsVisible = true, Width = 80)]
    //    public virtual string AAO_NAME { get; set; }
    //    [JsonProperty("pra_approval_type")]
    //    [Grid(IsVisible = true, Width = 70)]
    //    public virtual string PRA_APPROVAL_TYPE { get; set; }
    //    [JsonProperty("pra_action_date")]
    //    [Grid(IsVisible = true, Width = 80)]
    //    public virtual string PRA_ACTION_DATE { get; set; }
    //    [JsonProperty("pra_ao_remark")]
    //    [Grid(IsVisible = true, Width = 80)]
    //    public virtual string PRA_AO_REMARK { get; set; }
    //    [JsonProperty("pra_pr_index")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_PR_INDEX { get; set; }
    //    [JsonProperty("pra_ao")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_AO { get; set; }
    //    [JsonProperty("pra_a_ao")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_A_AO { get; set; }
    //    [JsonProperty("pra_active_ao")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_ACTIVE_AO { get; set; }
    //    [JsonProperty("pra_ao_action")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_AO_ACTION { get; set; }
    //    [JsonProperty("pra_approval_grp_index")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_APPROVAL_GRP_INDEX { get; set; }
    //    [JsonProperty("pra_on_behalfof")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_ON_BEHALFOF { get; set; }
    //    [JsonProperty("pra_relief_ind")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_RELIEF_IND { get; set; }
    //    [JsonProperty("pra_for")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRA_FOR { get; set; }
    //    [JsonProperty("ao_limit")]
    //    [Grid(IsVisible = false)]
    //    public virtual string AO_LIMIT { get; set; }
    //    [JsonProperty("aao_limit")]
    //    [Grid(IsVisible = false)]
    //    public virtual string AAO_LIMIT { get; set; }

    //}

    //public class MapPRMasterDetail
    //{
    //    #region display
    //    [JsonProperty("prno")]
    //    [Grid(IsVisible = false, IsSortable = false)]
    //    public virtual string PRNo { get; set; }
    //    [JsonProperty("no")]
    //    [Grid(IsVisible = false, IsSortable = false)]
    //    public virtual string No { get; set; }
    //    [JsonProperty("line")]
    //    [Grid(Width = 50, IsSortable = false)]
    //    public virtual int Line { get; set; }
    //    [JsonProperty("fundtypedesc")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string FundTypeDesc { get; set; }
    //    [JsonProperty("personcodedesc")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string PersonCodeDesc { get; set; }
    //    [JsonProperty("projectcodedesc")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string ProjectCodeDesc { get; set; }
    //    [JsonProperty("glddescription")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string GLDESCRIPTION { get; set; }
    //    [JsonProperty("categorycode")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string CategoryCode { get; set; }
    //    [JsonProperty("productdesc")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string ProductDesc { get; set; }
    //    [JsonProperty("qty")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual double Qty { get; set; }
    //    [JsonProperty("commodity")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string Commodity { get; set; }
    //    [JsonProperty("uom")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string UOM { get; set; }
    //    [JsonProperty("currency")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string Currency { get; set; }
    //    [JsonProperty("unitcost")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual double UnitCost { get; set; }
    //    [JsonProperty("amount")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual double AMOUNT { get; set; }
    //    [JsonProperty("gstratedesc")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string GSTRateDesc { get; set; }
    //    [JsonProperty("gst")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string GST { get; set; }
    //    [JsonProperty("gsttaxcode")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string GstTaxCode { get; set; }
    //    [JsonProperty("vendoritemcodedesc")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string VendorItemCodeDesc { get; set; }
    //    [JsonProperty("deliveryaddrdesc")]
    //    [Grid(Width = 500, IsSortable = false)]
    //    public virtual string DeliveryAddrDesc { get; set; }
    //    [JsonProperty("est")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual DateTime Est { get; set; }
    //    [JsonProperty("warrantyterms")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual int WarrantyTerms { get; set; }
    //    [JsonProperty("fieldvaluedesc")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string FieldValueDesc { get; set; }
    //    [JsonProperty("remark")]
    //    [Grid(Width = 150, IsSortable = false)]
    //    public virtual string Remark { get; set; }
    //    #endregion


    //    [JsonProperty("productcode")]
    //    [Grid(IsVisible = false)]
    //    public virtual string ProductCode { get; set; }
    //    [JsonProperty("quantity")]
    //    [Grid(IsVisible = false)]
    //    public virtual double QUANTITY { get; set; }
    //    [JsonProperty("gstrate")]
    //    [Grid(IsVisible = false)]
    //    public virtual string GSTRate { get; set; }
    //    [JsonProperty("deliveryaddr")]
    //    [Grid(IsVisible = false)]
    //    public virtual string DeliveryAddr { get; set; }
    //    [JsonProperty("etd")]
    //    [Grid(IsVisible = false)]
    //    public virtual int ETD { get; set; }
    //    [JsonProperty("source")]
    //    [Grid(IsVisible = false)]
    //    public virtual string Source { get; set; }
    //    [JsonProperty("vendorid")]
    //    [Grid(IsVisible = false)]
    //    public virtual string VendorID { get; set; }
    //    [JsonProperty("glcode")]
    //    [Grid(IsVisible = false)]
    //    public virtual string GLCode { get; set; }
    //    [JsonProperty("cdgroup")]
    //    [Grid(IsVisible = false)]
    //    public virtual string CDGroup { get; set; }
    //    [JsonProperty("acctindex")]
    //    [Grid(IsVisible = false)]
    //    public virtual string AcctIndex { get; set; }
    //    [JsonProperty("assetgroup")]
    //    [Grid(IsVisible = false)]
    //    public virtual string AssetGroup { get; set; }
    //    [JsonProperty("gift")]
    //    [Grid(IsVisible = false)]
    //    public virtual string Gift { get; set; }
    //    [JsonProperty("fundtype")]
    //    [Grid(IsVisible = false)]
    //    public virtual string FundType { get; set; }
    //    [JsonProperty("personcode")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PersonCode { get; set; }
    //    [JsonProperty("ProjectCode")]
    //    [Grid(IsVisible = false)]
    //    public virtual string ProjectCode { get; set; }
    //    [JsonProperty("vendoritemcode")]
    //    [Grid(IsVisible = false)]
    //    public virtual string VendorItemCode { get; set; }
    //    [JsonProperty("vendor")]
    //    [Grid(IsVisible = false)]
    //    public virtual string VENDOR { get; set; }
    //    [JsonProperty("fieldvalue")]
    //    [Grid(IsVisible = false)]
    //    public virtual string FieldValue { get; set; }
    //}
    //public class MapApprovallist
    //{
    //    [JsonProperty("AGM_GRP_NAME")]
    //    public virtual string AGM_GRP_NAME { get; set; }
    //    [JsonProperty("AGA_GRP_INDEX")]
    //    public virtual string AGA_GRP_INDEX { get; set; }
    //    [JsonProperty("AGM_CONSOLIDATOR")]
    //    public virtual string AGM_CONSOLIDATOR { get; set; }
      
    //}
    //public class MapApprovalOrder
    //{
    //    [JsonProperty("prid")]
    //    public virtual string Prid { get; set; }
    //    [JsonProperty("ao")]
    //    public virtual string AO { get; set; }
    //    [JsonProperty("aao")]
    //    public virtual string AAO { get; set; }
    //    [JsonProperty("AO_NAME")]
    //    [Grid(IsVisible = true, Width = 100)]
    //    public virtual string AO_NAME { get; set; }
    //    [JsonProperty("seq")]
    //    public virtual string Seq { get; set; }
    //    [JsonProperty("type")]
    //    [Grid(IsVisible = true, Width = 100)]
    //    public virtual string Type { get; set; }
    //    [JsonProperty("grpindex")]
    //    public virtual int GrpIndex { get; set; }
    //    [JsonProperty("relief")]
    //    public virtual string Relief { get; set; }
    //    [JsonProperty("strType")]
    //    public virtual string strType { get; set; }

    //}
    //#region Convert PR to PO
    //public class MapConvertPRtoPO
    //{
    //    [JsonProperty("prm_pr_no")]
    //    [Grid(IsVisible = true,Width =140, Alignment = ColumnsAlignment.Center)]
    //    public virtual string PRM_PR_NO { get; set; }
    //    [JsonProperty("um_user_name")]
    //    [Grid(IsVisible = true, Width = 140)]
    //    public virtual string UM_USER_NAME { get; set; }
    //    [JsonProperty("prd_vendor_item_code")]
    //    [Grid(IsVisible = true, Width = 140)]
    //    public virtual string PRD_VENDOR_ITEM_CODE { get; set; }
    //    [JsonProperty("prd_product_desc")]
    //    [Grid(IsVisible = true, Width = 140)]
    //    public virtual string PRD_PRODUCT_DESC { get; set; }
    //    [JsonProperty("prm_pr_date")]
    //    [Grid(IsVisible = true, Width = 140,DatetimeFormat ="DD/MM/YYYY")]
    //    public virtual string PRM_PR_DATE { get; set; }
    //    [JsonProperty("pm_last_txn_s_coy_name")]
    //    [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Center)]
    //    public virtual string PM_LAST_TXN_S_COY_NAME { get; set; }
    //    [JsonProperty("prd_ordered_qty")]
    //    [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
    //    public virtual string PRD_ORDERED_QTY { get; set; }
    //    [JsonProperty("pm_last_txn_price_curr")]
    //    [Grid(IsVisible = true, Width = 140)]
    //    public virtual string PM_LAST_TXN_PRICE_CURR { get; set; }
    //    [JsonProperty("pm_last_txn_price")]
    //    [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
    //    public virtual string PM_LAST_TXN_PRICE { get; set; }
    //    [JsonProperty("prd_unit_cost")]
    //    [Grid(IsVisible = true, Width = 140,Alignment = ColumnsAlignment.Right)]
    //    public virtual string PRD_UNIT_COST { get; set; }
    //    [JsonProperty("prd_gst")]
    //    [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right)]
    //    public virtual string PRD_GST { get; set; }
    //    [JsonProperty("sst_ammount")]
    //    [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
    //    public virtual string SST_AMMOUNT { get; set; }
    //    [JsonProperty("prd_pr_line")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRD_PR_LINE { get; set; }
    //    [JsonProperty("prm_pr_index")]
    //    [Grid(IsVisible = false)]
    //    public virtual string PRM_PR_INDEX { get; set; }


    //    [JsonProperty("prd_acct_index")]
    //    [Grid(IsVisible = true, Width = 150)]
    //    public virtual string PRD_ACCT_INDEX { get; set; }

    //}
    //#endregion

    #region Map getBCMListByUserNew
    public class BCMListByUserNewMap
    {
        [JsonProperty("acct_list")]
        [Grid(Width = 150)]
        public virtual string Acct_List { get; set; }
        [JsonProperty("acct_index")]
        [Grid(IsVisible = false)]
        public virtual string Acct_Index { get; set; }
        [JsonProperty("acct_code")]
        [Grid(Width = 150)]
        public virtual string Acct_Code { get; set; }
        [JsonProperty("l1")]
        [Grid(IsVisible = false)]
        public virtual string L1 { get; set; }
        [JsonProperty("l2")]
        [Grid(IsVisible = false)]
        public virtual string L2 { get; set; }
        [JsonProperty("l3")]
        [Grid(IsVisible = false)]
        public virtual string L3 { get; set; }
    }
    #endregion
}
