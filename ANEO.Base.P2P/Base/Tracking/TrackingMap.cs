using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Plexform.Base;
using System.Collections.Generic;
using LOGIC.Base;


namespace ANEO.Base.P2P.Tracking.Map
{
    public class TrackingMap
    {
        #region Display
        [JsonProperty("IM_INVOICE_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_INVOICE_NO { get; set; }
        [JsonProperty("IM_INVOICE_TYPE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_INVOICE_TYPE { get; set; }
        [JsonProperty("IM_PAYMENT_DATE")]
        [Grid(IsVisible = true, Width = 140,DatetimeFormat ="DD/MM/YYYY")]
        public virtual DateTime IM_PAYMENT_DATE { get; set; }
        [JsonProperty("POM_S_COY_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_COY_NAME { get; set; }
        [JsonProperty("INVAMT_INMYR")]
        [Grid(IsVisible = true, Width = 140,Alignment = ColumnsAlignment.Right, DecimalPlaces = 2)]
        public virtual string INVAMT_INMYR { get; set; }
        [JsonProperty("POM_CURRENCY_CODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_CURRENCY_CODE { get; set; }
        [JsonProperty("IM_INVOICE_TOTAL")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right, DecimalPlaces = 2)]
        public virtual decimal IM_INVOICE_TOTAL { get; set; }
        [JsonProperty("POM_BUYER_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_BUYER_NAME { get; set; }
        [JsonProperty("REMARK")]
        [Grid(IsVisible = true, Width = 140, IsSortable = false)]
        public virtual string REMARK { get; set; }
        [JsonProperty("IM_RESIDENT_TYPE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_RESIDENT_TYPE { get; set; }
        [JsonProperty("POM_PAYMENT_METHOD")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PAYMENT_METHOD { get; set; }

        [JsonProperty("ID_ANALYSIS_CODE1")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string ID_ANALYSIS_CODE1 { get; set; }
        #endregion


        [JsonProperty("IM_PAYMENT_TERM")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string IM_PAYMENT_TERM { get; set; }
        [JsonProperty("IM_S_COY_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string IM_S_COY_ID { get; set; }
        [JsonProperty("IM_INVOICE_INDEX")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string IM_INVOICE_INDEX { get; set; }
        [JsonProperty("IM_PO_INDEX")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string IM_PO_INDEX { get; set; }
        [JsonProperty("DEPT")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DEPT { get; set; }
        [JsonProperty("IM_PRINTED")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string IM_PRINTED { get; set; }
        [JsonProperty("IM_INVOICE_STATUS")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string IM_INVOICE_STATUS { get; set; }
        [JsonProperty("STATUS_DESC")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string STATUS_DESC { get; set; }

        [JsonProperty("IM_FM_APPROVED_DATE")]
        [Grid(IsVisible = false, Width = 140, DatetimeFormat ="DD/MM/YYYY")]
        public virtual DateTime IM_FM_APPROVED_DATE { get; set; }
        [JsonProperty("POM_BILLING_METHOD")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POM_BILLING_METHOD { get; set; }

        [JsonProperty("DOC_TYPE")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DOC_TYPE { get; set; }
        [JsonProperty("ROLE")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string ROLE { get; set; }



    }
    public class TrackingDetailHeader
    {
        #region display
        [JsonProperty("POM_B_ADDR_LINE1")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_B_ADDR_LINE1 { get; set; }
        [JsonProperty("POM_B_ADDR_LINE2")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_B_ADDR_LINE2 { get; set; }
        [JsonProperty("POM_B_ADDR_LINE3")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_B_ADDR_LINE3 { get; set; }
        [JsonProperty("POM_B_POSTCODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_B_POSTCODE { get; set; }
        [JsonProperty("POM_B_CITY")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_B_CITY { get; set; }
        [JsonProperty("POM_B_STATE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_B_STATE { get; set; }
        [JsonProperty("POM_B_COUNTRY")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_B_COUNTRY { get; set; }
        [JsonProperty("IM_YOUR_REF")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_YOUR_REF { get; set; }
        [JsonProperty("IM_OUR_REF")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_OUR_REF { get; set; }
        [JsonProperty("IM_S_COY_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_S_COY_NAME { get; set; }
        [JsonProperty("POM_PO_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PO_NO { get; set; }
        [JsonProperty("POM_PO_INDEX")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PO_INDEX { get; set; }
        [JsonProperty("POM_PAYMENT_TERM")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PAYMENT_TERM { get; set; }
        [JsonProperty("POM_PAYMENT_METHOD")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PAYMENT_METHOD { get; set; }
        [JsonProperty("POM_BUYER_PHONE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_BUYER_PHONE { get; set; }
        [JsonProperty("POM_CURRENCY_CODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_CURRENCY_CODE { get; set; }
        [JsonProperty("POM_SHIPMENT_TERM")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_SHIPMENT_TERM { get; set; }
        [JsonProperty("POM_SHIPMENT_MODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_SHIPMENT_MODE { get; set; }
        [JsonProperty("POM_BILLING_METHOD")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_BILLING_METHOD { get; set; }
        [JsonProperty("POM_S_ADDR_LINE1")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_ADDR_LINE1 { get; set; }
        [JsonProperty("POM_S_ADDR_LINE2")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_ADDR_LINE2 { get; set; }
        [JsonProperty("POM_S_ADDR_LINE3")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_ADDR_LINE3 { get; set; }
        [JsonProperty("POM_S_POSTCODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_POSTCODE { get; set; }
        [JsonProperty("POM_S_CITY")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_CITY { get; set; }
        [JsonProperty("POM_S_STATE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_STATE { get; set; }
        [JsonProperty("POM_S_COUNTRY")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_COUNTRY { get; set; }
        [JsonProperty("POM_S_PHONE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_PHONE { get; set; }
        [JsonProperty("POM_S_EMAIL")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_EMAIL { get; set; }
        [JsonProperty("CM_BUSINESS_REG_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CM_BUSINESS_REG_NO { get; set; }
        [JsonProperty("IM_REMARK")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_REMARK { get; set; }
        [JsonProperty("CM_COY_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CM_COY_NAME { get; set; }
        [JsonProperty("IM_PAYMENT_DATE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_PAYMENT_DATE { get; set; }
        [JsonProperty("IM_CREATED_ON")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_CREATED_ON { get; set; }
        [JsonProperty("IM_INVOICE_INDEX")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_INVOICE_INDEX { get; set; }
        [JsonProperty("IM_FINANCE_REMARKS")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string IM_FINANCE_REMARKS { get; set; }
        [JsonProperty("POM_DEL_CODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_DEL_CODE { get; set; }
        [JsonProperty("POM_VENDOR_CODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_VENDOR_CODE { get; set; }
        #endregion
    }
    public class TrackingDetailItem
    {
        #region display
        [JsonProperty("ID_PO_LINE")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
        public virtual string ID_PO_LINE { get; set; }
        [JsonProperty("FUNDTYPE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string FUNDTYPE { get; set; }
        [JsonProperty("PERSONCODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string PERSONCODE { get; set; }
        [JsonProperty("PROJECTCODE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string PROJECTCODE { get; set; }
        [JsonProperty("ID_PRODUCT_DESC")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string ID_PRODUCT_DESC { get; set; }
        [JsonProperty("ID_UOM")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string ID_UOM { get; set; }
        [JsonProperty("ID_RECEIVED_QTY")]
        [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right, DecimalPlaces = 0)]
        public virtual decimal ID_RECEIVED_QTY { get; set; }
        [JsonProperty("ID_UNIT_COST")]
        [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right, DecimalPlaces = 2)]
        public virtual decimal ID_UNIT_COST { get; set; }
        [JsonProperty("Total")]
        [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right, DecimalPlaces = 2)]
        public virtual decimal Total { get; set; }
        [JsonProperty("ID_GST")]
        [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right, DecimalPlaces = 2)]
        public virtual string ID_GST { get; set; }
        [JsonProperty("ID_WARRANTY_TERMS")]
        [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right, DecimalPlaces = 2)]
        public virtual string ID_WARRANTY_TERMS { get; set; }
        [JsonProperty("IM_SHIP_AMT")]
        [Grid(IsVisible = false, Width = 140, Alignment = ColumnsAlignment.Right, DecimalPlaces = 2)]
        public virtual string IM_SHIP_AMT { get; set; }
        #endregion

        [JsonProperty("FUNDTYPECODE")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string FUNDTYPECODE { get; set; }
    }

    public class FinanceApprovalFlow
    {
        #region display
        [JsonProperty("FA_SEQ")]
        [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right)]
        public virtual string FA_SEQ { get; set; }
        [JsonProperty("AO_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string AO_NAME { get; set; }
        [JsonProperty("AAO_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string AAO_NAME { get; set; }
        [JsonProperty("FA_APPROVAL_TYPE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string FA_APPROVAL_TYPE { get; set; }
        [JsonProperty("FA_ACTION_DATE")]
        [Grid(IsVisible = true, Width = 140,DatetimeFormat ="DD/MM/YYYY")]
        public virtual DateTime? FA_ACTION_DATE { get; set; }
        #endregion
        [JsonProperty("FA_AO_REMARK")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string FA_AO_REMARK { get; set; }
        [JsonProperty("AO_LIMIT")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string AO_LIMIT { get; set; }
        [JsonProperty("AAO_LIMIT")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string AAO_LIMIT { get; set; }
        [JsonProperty("FA_AGA_TYPE")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string FA_AGA_TYPE{ get; set; }

    }
    public class CNSummary
    {
        #region display
        [JsonProperty("CNM_CN_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CNM_CN_NO { get; set; }
        [JsonProperty("CNM_CN_B_COY_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CNM_CN_B_COY_ID { get; set; }
        [JsonProperty("CNM_CN_S_COY_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CNM_CN_S_COY_ID { get; set; }
        [JsonProperty("CNM_CREATED_DATE")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime CNM_CREATED_DATE { get; set; }
        [JsonProperty("UM_USER_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string UM_USER_NAME { get; set; }
        [JsonProperty("CNM_CN_STATUS")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CNM_CN_STATUS { get; set; }
        [JsonProperty("STATUS_DESC")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string STATUS_DESC { get; set; }
        [JsonProperty("AMOUNT")]
        [Grid(IsVisible = true, Width = 140,Alignment =ColumnsAlignment.Right,DecimalPlaces =00)]
        public virtual string AMOUNT { get; set; }
        #endregion

    }
    public class DNSummary
    {
        #region display
        [JsonProperty("DNM_DN_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string DNM_DN_NO { get; set; }
        [JsonProperty("DNM_DN_B_COY_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DNM_DN_B_COY_ID { get; set; }
        [JsonProperty("DNM_DN_S_COY_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DNM_DN_S_COY_ID { get; set; }

        [JsonProperty("DNM_CREATED_DATE")]
        [Grid(IsVisible = true, Width = 140,DatetimeFormat ="DD/MM/YYYY")]
        public virtual DateTime DNM_CREATED_DATE { get; set; }
        [JsonProperty("UM_USER_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string UM_USER_NAME { get; set; }
        [JsonProperty("DNM_DN_STATUS")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DNM_DN_STATUS { get; set; }
        [JsonProperty("STATUS_DESC")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string STATUS_DESC { get; set; }
        [JsonProperty("AMOUNT")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right, DecimalPlaces = 00)]
        public virtual string AMOUNT { get; set; }
        #endregion

    }
    public class IssueGRNDetailMap
    {
        #region display
        [JsonProperty("POD_Po_Line")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_Po_Line { get; set; }
        [JsonProperty("POD_B_Item_Code")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POD_B_Item_Code { get; set; }

        [JsonProperty("POD_Product_Desc")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POD_Product_Desc { get; set; }
        [JsonProperty("POD_UOM")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POD_UOM { get; set; }
        [JsonProperty("POD_Min_Pack_Qty")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_Min_Pack_Qty { get; set; }
        [JsonProperty("POD_Ordered_Qty")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_Ordered_Qty { get; set; }
        [JsonProperty("POD_Outstanding")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_Outstanding { get; set; }
        [JsonProperty("DOD_SHIPPED_QTY")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
        public virtual string DOD_SHIPPED_QTY { get; set; }
        [JsonProperty("GD_REJECTED_QTY")]
        [Grid(IsVisible = true, Width = 140, Alignment = ColumnsAlignment.Right)]
        public virtual string GD_REJECTED_QTY { get; set; }
        [JsonProperty("REMARK")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string REMARK { get; set; }
        #endregion
        [JsonProperty("POD_Vendor_Item_Code")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Vendor_Item_Code { get; set; }
        [JsonProperty("POD_CANCELLED_QTY")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_CANCELLED_QTY { get; set; }
        [JsonProperty("POM_PO_Index")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POM_PO_Index { get; set; }
        [JsonProperty("POM_PO_No")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POM_PO_No { get; set; }
        [JsonProperty("DOM_Created_Date")]
        [Grid(IsVisible = false, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime DOM_Created_Date { get; set; }
        [JsonProperty("POM_PO_Status")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POM_PO_Status { get; set; }
        [JsonProperty("POD_Product_Code")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Product_Code { get; set; }
        [JsonProperty("CM_Coy_Name")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CM_Coy_Name { get; set; }
        [JsonProperty("POD_Product_Code")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Product_Code_D { get; set; }
        [JsonProperty("POM_S_Coy_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POM_S_Coy_ID { get; set; }
        [JsonProperty("POD_Delivered_Qty")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Delivered_Qty { get; set; }
        [JsonProperty("POD_Received_Qty")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Received_Qty { get; set; }
        [JsonProperty("POD_Rejected_Qty")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Rejected_Qty { get; set; }
        [JsonProperty("POD_ETD")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_ETD { get; set; }
        [JsonProperty("POD_Min_Order_Qty")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Min_Order_Qty { get; set; }
        [JsonProperty("POD_Warranty_Terms")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POD_Warranty_Terms { get; set; }
    }
    public class InvoiceAttachment
    {
        [JsonProperty("CDA_ATTACH_INDEX")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CDA_ATTACH_INDEX { get; set; }
        [JsonProperty("DDA_DOC_NO")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DDA_DOC_NO { get; set; }
        [JsonProperty("CDA_HUB_FILENAME")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CDA_HUB_FILENAME { get; set; }
        [JsonProperty("CDA_ATTACH_FILENAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CDA_ATTACH_FILENAME { get; set; }
        [JsonProperty("CDA_FILESIZE")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CDA_FILESIZE { get; set; }

    }
}
