using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Plexform.Base;
using System.Collections.Generic;
using LOGIC.Base;


namespace ANEO.Base.P2P.GRN.Map
{
    public class GRNMap
    {
        [JsonProperty("POM_PO_No")]
        [Grid(IsVisible = true, Width = 140)]

        public virtual string POM_PO_No { get; set; }
        [JsonProperty("CM_COY_NAME")]
        [Grid(IsVisible = true, Width = 140)]

        public virtual string CM_COY_NAME { get; set; }
        [JsonProperty("Due_Date")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat ="DD/MM/YYYY")]
        public virtual DateTime Due_Date { get; set; }
        [JsonProperty("POD_D_ADDR_CODE")]
        [Grid(IsVisible = true, Width = 140)]

        public virtual string POD_D_ADDR_CODE { get; set; }
        [JsonProperty("Tot")]
        [Grid(IsVisible = true, Width = 140)]

        public virtual string Tot { get; set; }
        [JsonProperty("Outs")]
        [Grid(IsVisible = true, Width = 140)]

        public virtual int Outs { get; set; }
       
    }
    public class IssueGRNMap
    {
        [JsonProperty("DOM_DO_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string DOM_DO_NO { get; set; }

        [JsonProperty("DOM_DO_INDEX")]
        [Grid(IsVisible = false, Width = 140,Alignment =ColumnsAlignment.Right)]
        public virtual string DOM_DO_INDEX { get; set; }

        [JsonProperty("DOM_S_Ref_No")]
        [Grid(IsVisible = true, Width = 140)]

        public virtual string DOM_S_Ref_No { get; set; }
        [JsonProperty("DOM_Created_Date")]
        [Grid(IsVisible = false, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime DOM_Created_Date { get; set; }
        [JsonProperty("DOM_DO_Date")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]

        public virtual DateTime DOM_DO_Date { get; set; }

        [JsonProperty("POM_PO_No")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PO_No { get; set; }
        [JsonProperty("POM_PO_Date")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime POM_PO_Date { get; set; }
        [JsonProperty("CM_COY_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CM_COY_NAME { get; set; }
        [JsonProperty("DOM_S_COY_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DOM_S_COY_ID { get; set; }

    }
    public class IssueGRNSummaryMap
    {
        #region display
        [JsonProperty("GM_CREATED_DATE")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime GM_CREATED_DATE { get; set; }
        [JsonProperty("GM_Date_Received")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime GM_Date_Received { get; set; }
        [JsonProperty("GM_GRN_No")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string GM_GRN_No { get; set; }
        [JsonProperty("UM_USER_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string UM_USER_NAME { get; set; }
        #endregion

        [JsonProperty("GM_CREATED_BY")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string GM_CREATED_BY { get; set; }
        [JsonProperty("GM_GRN_No")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DOM_DO_INDEX { get; set; }
        [JsonProperty("DOM_DO_INDEX")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DOM_S_Ref_No { get; set; }
        [JsonProperty("GM_DO_INDEX")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string GM_DO_INDEX { get; set; }
        [JsonProperty("DOM_DO_NO")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DOM_DO_NO { get; set; }
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
    public class DOAttachment
    {
        [JsonProperty("CDDA_ATTACH_INDEX")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CDDA_ATTACH_INDEX { get; set; }
        [JsonProperty("CDDA_DOC_NO")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CDDA_DOC_NO { get; set; }
        [JsonProperty("CDDA_HUB_FILENAME")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string CDDA_HUB_FILENAME { get; set; }
        [JsonProperty("CDDA_ATTACH_FILENAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CDDA_ATTACH_FILENAME { get; set; }
        [JsonProperty("CDDA_FILESIZE")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CDDA_FILESIZE { get; set; }

        // additional
        [JsonProperty("pathref")]
        public virtual string PathRef { get; set; }
    }
    public class GRNList
    {
        #region display
        [JsonProperty("POM_PO_No")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PO_No { get; set; }
        [JsonProperty("POM_PO_DATE")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime POM_PO_DATE { get; set; }
        [JsonProperty("DOM_DO_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string DOM_DO_NO { get; set; }
        [JsonProperty("DOM_DO_DATE")]
        [Grid(IsVisible = true, Width = 140,DatetimeFormat ="DD/MM/YYYY")]
        public virtual DateTime DOM_DO_DATE { get; set; }
        [JsonProperty("GM_GRN_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string GM_GRN_NO { get; set; }
        [JsonProperty("GM_CREATED_DATE")]
        [Grid(IsVisible = true, Width = 140,DatetimeFormat ="DD/MM/YYYY")]
        public virtual DateTime GM_CREATED_DATE { get; set; }
        [JsonProperty("GM_DATE_RECEIVED")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime GM_DATE_RECEIVED { get; set; }
        [JsonProperty("POM_S_COY_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_S_COY_NAME { get; set; }
        [JsonProperty("Accepted_By")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string Accepted_By { get; set; }
        [JsonProperty("Status_Desc")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string Status_Desc { get; set; }

        #endregion  
        [JsonProperty("GM_LEVEL2_USER")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string GM_LEVEL2_USER { get; set; }
        [JsonProperty("GM_GRN_INDEX")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string GM_GRN_INDEX { get; set; }
        [JsonProperty("DOM_DO_Index")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DOM_DO_Index { get; set; }
        [JsonProperty("DOM_PO_Index")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string DOM_PO_Index { get; set; }
        [JsonProperty("GM_GRN_STATUS")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string GM_GRN_STATUS { get; set; }
        [JsonProperty("POM_S_Coy_ID")]
        [Grid(IsVisible = false, Width = 140)]
        public virtual string POM_S_Coy_ID { get; set; }
        
    }
}
