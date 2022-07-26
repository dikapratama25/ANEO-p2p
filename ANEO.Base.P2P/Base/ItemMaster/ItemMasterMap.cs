using LOGIC.Base;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ANEO.Base.P2P.Base.ItemMaster
{
    public class mapGetItems
    {
        #region Display
        [JsonProperty("PM_PRODUCT_INDEX")]
        //[Grid(Width = 150)]
        [Grid(IsVisible =false)]
        public string PM_PRODUCT_INDEX { get; set; }

        [JsonProperty("BCU_CAT_INDEX")]
        //[Grid(Width = 150)]
        [Grid(IsVisible = false)]
        public string BCU_CAT_INDEX { get; set; }

        [JsonProperty("PM_PRODUCT_CODE")]
        //[Grid(Width = 150)]
        [Grid(IsVisible = false)]
        public string PM_PRODUCT_CODE { get; set; }

        [JsonProperty("PM_VENDOR_ITEM_CODE")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150 , Alignment = ColumnsAlignment.Center)]
        public string PM_VENDOR_ITEM_CODE { get; set; }

        [JsonProperty("PM_PRODUCT_DESC")]
        [Grid(Width = 150, Alignment = ColumnsAlignment.Center)]
        public string PM_PRODUCT_DESC { get; set; }

        [JsonProperty("CT_NAME")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150, Alignment = ColumnsAlignment.Center)]
        public string CT_NAME { get; set; }
        
        [JsonProperty("PM_UOM")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150, Alignment = ColumnsAlignment.Center )]
        public string PM_UOM { get; set; }
        
        [JsonProperty("PM_DELETED")]
        [Grid(Width = 150)]
        public string PM_DELETED { get; set; }

        //[JsonProperty("BCU_CAT_INDEX")]
        //[Grid(IsVisible = false)]
        //public string Item_Code { get; set; }
        //[JsonProperty("PM_VENDOR_ITEM_CODE")]
        //[Grid(IsVisible = false)]
        //public string Item_Name { get; set; }
        //[JsonProperty("PM_PRODUCT_DESC")]
        //[Grid(IsVisible = false)]
        //public string Commodity_Type { get; set; }
        //[JsonProperty("PM_CATEGORY_NAME")]
        //[Grid(IsVisible = false)]
        //public string UOM { get; set; }
        //[JsonProperty("PM_DELETED")]
        //[Grid(IsVisible = false)]
        //public string Status { get; set; }
        #endregion
    }

    public class mapGetTempImage
    {
        #region Display
        [JsonProperty("PA_ATTACH_INDEX")]
        [Grid(Width = 150)]
        public string PA_ATTACH_INDEX { get; set; }
        [JsonProperty("PA_TYPE")]
        [Grid(Width = 150)]
        public string PA_TYPE { get; set; }
        [JsonProperty("PA_HUB_FILENAME")]
        [Grid(IsVisible = false)]
        public string PA_HUB_FILENAME { get; set; }
        [JsonProperty("PA_SOURCE")]
        [Grid(Width = 150)]
        public string PA_SOURCE { get; set; }
        [JsonProperty("PA_STATUS")]
        [Grid(Width = 150)]
        public string PA_STATUS { get; set; }
        [JsonProperty("PA_ATTACH_FILENAME")]
        [Grid(IsVisible = false)]
        public string PA_ATTACH_FILENAME { get; set; }
        [JsonProperty("PA_FILESIZE")]
        [Grid(IsVisible = false)]
        public string PA_FILESIZE { get; set; }

        [JsonProperty("PA_DATE")]
        [Grid(IsVisible = false)]
        public string PA_DATE { get; set; }
        [JsonProperty("PA_PRODUCT_CODE")]
        [Grid(IsVisible = false)]
        public string PA_PRODUCT_CODE { get; set; }
        #endregion
    }
    public class mapCategory
    { 
    
            [JsonProperty("cbc_b_coy_id")]
            public virtual string CBC_B_COY_ID { get; set; }
            [JsonProperty("cbc_b_category_code")]
            public virtual string CBC_B_CATEGORY_CODE { get; set; }
        
    }
    public class mapGetFileExist
    {
        [JsonProperty("FileExist")]
        [Grid(IsVisible = false)]
        public bool FileExist { get; set; }
    }

    public class mapBIM
    {
        [JsonProperty("SP_PARAM_VALUE")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string SP_PARAM_VALUE { get; set; }
        [JsonProperty("SP_PARAM_NAME")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string SP_PARAM_NAME { get; set; }
        [JsonProperty("PM_S_COY_ID")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_S_COY_ID { get; set; }
        [JsonProperty("PM_PRODUCT_CODE")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_PRODUCT_CODE { get; set; }
        [JsonProperty("PM_VENDOR_ITEM_CODE")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_VENDOR_ITEM_CODE { get; set; }
        [JsonProperty("PM_PRODUCT_DESC")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_PRODUCT_DESC { get; set; }
        [JsonProperty("PM_REF_NO")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_REF_NO { get; set; }
        [JsonProperty("PM_LONG_DESC")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_LONG_DESC { get; set; }
        [JsonProperty("PM_CATEGORY_NAME")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_CATEGORY_NAME { get; set; }
        [JsonProperty("PM_ACCT_CODE")]
        //[Grid(IsVisible = false)]
        [Grid(Width = 150)]
        public string PM_ACCT_CODE { get; set; }
        [JsonProperty("PM_UOM")]
        [Grid(IsVisible = false)]
        public string PM_UOM { get; set; }
        [JsonProperty("PM_SAFE_QTY")]
        [Grid(IsVisible = false)]
        public string PM_SAFE_QTY { get; set; }
        [JsonProperty("PM_ORD_MIN_QTY")]
        [Grid(IsVisible = false)]
        public string PM_ORD_MIN_QTY { get; set; }
        [JsonProperty("PM_ORD_MAX_QTY")]
        [Grid(IsVisible = false)]
        public string PM_ORD_MAX_QTY { get; set; }
        [JsonProperty("PM_PRODUCT_BRAND")]
        [Grid(IsVisible = false)]
        public string PM_PRODUCT_BRAND { get; set; }
        [JsonProperty("PM_PRODUCT_MODEL")]
        [Grid(IsVisible = false)]
        public string PM_PRODUCT_MODEL { get; set; }
        [JsonProperty("PM_DRAW_NO")]
        [Grid(IsVisible = false)]
        public string PM_DRAW_NO { get; set; }
        [JsonProperty("PM_VERS_NO")]
        [Grid(IsVisible = false)]
        public string PM_VERS_NO { get; set; }
        [JsonProperty("PM_GROSS_WEIGHT")]
        [Grid(IsVisible = false)]
        public string PM_GROSS_WEIGHT { get; set; }
        [JsonProperty("PM_NET_WEIGHT")]
        [Grid(IsVisible = false)]
        public string PM_NET_WEIGHT { get; set; }
        [JsonProperty("PM_LENGHT")]
        [Grid(IsVisible = false)]
        public string PM_LENGHT { get; set; }
        [JsonProperty("PM_WIDTH")]
        [Grid(IsVisible = false)]
        public string PM_WIDTH { get; set; }
        [JsonProperty("PM_HEIGHT")]
        [Grid(IsVisible = false)]
        public string PM_HEIGHT { get; set; }
        [JsonProperty("PM_VOLUME")]
        [Grid(IsVisible = false)]
        public string PM_VOLUME { get; set; }
        [JsonProperty("PM_COLOR_INFO")]
        [Grid(IsVisible = false)]
        public string PM_COLOR_INFO { get; set; }
        [JsonProperty("PM_HSC_CODE")]
        [Grid(IsVisible = false)]
        public string PM_HSC_CODE { get; set; }
        [JsonProperty("PM_PACKING_REQ")]
        [Grid(IsVisible = false)]
        public string PM_PACKING_REQ { get; set; }
        [JsonProperty("PM_REMARKS")]
        [Grid(IsVisible = false)]
        public string PM_REMARKS { get; set; }
        [JsonProperty("PM_PREFER_S_COY_ID")]
        [Grid(IsVisible = false)]
        public string PM_PREFER_S_COY_ID { get; set; }
        [JsonProperty("PM_1ST_S_COY_ID")]
        [Grid(IsVisible = false)]
        public string PM_1ST_S_COY_ID { get; set; }
        [JsonProperty("PM_2ND_S_COY_ID")]
        [Grid(IsVisible = false)]
        public string PM_2ND_S_COY_ID { get; set; }
        [JsonProperty("PM_3RD_S_COY_ID")]
        [Grid(IsVisible = false)]
        public string PM_3RD_S_COY_ID { get; set; }
        [JsonProperty("PM_DELETED")]
        [Grid(IsVisible = false)]
        public string PM_DELETED { get; set; }
        [JsonProperty("PM_PRODUCT_FOR")]
        [Grid(IsVisible = false)]
        public string PM_PRODUCT_FOR { get; set; }
        [JsonProperty("PM_ENT_BY")]
        [Grid(IsVisible = false)]
        public string PM_ENT_BY { get; set; }
        [JsonProperty("PM_ENT_DT")]
        [Grid(IsVisible = false)]
        public string PM_ENT_DT { get; set; }
        [JsonProperty("PM_PREFER_S_COY_ID_TAX_ID")]
        [Grid(IsVisible = false)]
        public string PM_PREFER_S_COY_ID_TAX_ID { get; set; }
        [JsonProperty("PM_1ST_S_COY_ID_TAX_ID")]
        [Grid(IsVisible = false)]
        public string PM_1ST_S_COY_ID_TAX_ID { get; set; }
        [JsonProperty("PM_2ND_S_COY_ID_TAX_ID")]
        [Grid(IsVisible = false)]
        public string PM_2ND_S_COY_ID_TAX_ID { get; set; }
        [JsonProperty("PM_3RD_S_COY_ID_TAX_ID")]
        [Grid(IsVisible = false)]
        public string PM_3RD_S_COY_ID_TAX_ID { get; set; }
        [JsonProperty("PM_ITEM_TYPE")]
        [Grid(IsVisible = false)]
        public string PM_ITEM_TYPE { get; set; }
        [JsonProperty("PM_IQC_IND")]
        [Grid(IsVisible = false)]
        public string PM_IQC_IND { get; set; }
        [JsonProperty("PM_MAX_INV_QTY")]
        [Grid(IsVisible = false)]
        public string PM_MAX_INV_QTY { get; set; }
        [JsonProperty("PM_MANUFACTURER")]
        [Grid(IsVisible = false)]
        public string PM_MANUFACTURER { get; set; }
        [JsonProperty("PM_CAT_CODE")]
        [Grid(IsVisible = false)]
        public string PM_CAT_CODE { get; set; }

        [JsonProperty("PV_PRODUCT_INDEX")]
        [Grid(IsVisible = false)]
        public string PV_PRODUCT_INDEX { get; set; }
        [JsonProperty("PV_VENDOR_TYPE")]
        [Grid(IsVisible = false)]
        public string PV_VENDOR_TYPE { get; set; }
        [JsonProperty("PV_LEAD_TIME")]
        [Grid(IsVisible = false)]
        public string PV_LEAD_TIME { get; set; }
        [JsonProperty("PV_VENDOR_CODE")]
        [Grid(IsVisible = false)]
        public string PV_VENDOR_CODE { get; set; }
        [JsonProperty("PV_ENT_BY")]
        [Grid(IsVisible = false)]
        public string PV_ENT_BY { get; set; }
        [JsonProperty("PV_ENT_DATETIME")]
        [Grid(IsVisible = false)]
        public string PV_ENT_DATETIME { get; set; }
        [JsonProperty("PA_ATTACH_FILENAME")]
        [Grid(IsVisible = false)]
        public string PA_ATTACH_FILENAME { get; set; }
        [JsonProperty("PA_PRODUCT_CODE")]
        [Grid(IsVisible = false)]
        public string PA_PRODUCT_CODE { get; set; }
        [JsonProperty("PA_TYPE")]
        [Grid(Width = 150)]
        public string PA_TYPE { get; set; }
        [JsonProperty("PA_HUB_FILENAME")]
        [Grid(IsVisible = false)]
        public string PA_HUB_FILENAME { get; set; }
        [JsonProperty("PA_FILESIZE")]
        [Grid(IsVisible = false)]
        public string PA_FILESIZE { get; set; }
        [JsonProperty("PA_STATUS")]
        [Grid(Width = 150)]
        public string PA_STATUS { get; set; }
        [JsonProperty("PA_SOURCE")]
        [Grid(Width = 150)]
        public string PA_SOURCE { get; set; }
        [JsonProperty("PA_ATTACH_INDEX")]
        [Grid(Width = 150)]
        public string PA_ATTACH_INDEX { get; set; }
        [JsonProperty("PM_PRODUCT_IMAGE")]
        [Grid(Width = 150)]
        public string PM_PRODUCT_IMAGE { get; set; }
        [JsonProperty("IM_COY_ID")]
        [Grid(Width = 150)]
        public string IM_COY_ID { get; set; }
        [JsonProperty("IM_ITEM_CODE")]
        [Grid(Width = 150)]
        public string IM_ITEM_CODE { get; set; }
        [JsonProperty("IM_INVENTORY_INDEX")]
        [Grid(Width = 150)]
        public string IM_INVENTORY_INDEX { get; set; }
        [JsonProperty("IM_INVENTORY_NAME")]
        [Grid(Width = 150)]
        public string IM_INVENTORY_NAME { get; set; }
        [JsonProperty("IM_IQC_IND")]
        [Grid(Width = 150)]
        public string IM_IQC_IND { get; set; }
        [JsonProperty("ID_INVENTORY_INDEX")]
        [Grid(Width = 150)]
        public string ID_INVENTORY_INDEX { get; set; }
        [JsonProperty("BCM_B_COY_ID")]
        [Grid(Width = 150)]
        public string BCM_B_COY_ID { get; set; }
        [JsonProperty("BCM_CAT_INDEX")]
        [Grid(Width = 150)]
        public string BCM_CAT_INDEX { get; set; }
        [JsonProperty("BCU_PRODUCT_CODE")]
        [Grid(Width = 150)]
        public string BCU_PRODUCT_CODE { get; set; }
        [JsonProperty("BCM_GRP_DESC")]
        [Grid(Width = 150)]
        public string BCM_GRP_DESC { get; set; }
        [JsonProperty("BCU_ENT_DATETIME")]
        [Grid(Width = 150)]
        public string BCU_ENT_DATETIME { get; set; }
        [JsonProperty("BCU_ENT_BY")]
        [Grid(Width = 150)]
        public string BCU_ENT_BY { get; set; }
        [JsonProperty("BCU_S_COY_ID")]
        [Grid(Width = 150)]
        public string BCU_S_COY_ID { get; set; }
        [JsonProperty("BCU_SOURCE")]
        [Grid(Width = 150)]
        public string BCU_SOURCE { get; set; }
        [JsonProperty("BCU_CAT_INDEX")]
        [Grid(Width = 150)]
        public string BCU_CAT_INDEX { get; set; }
        [JsonProperty("PV_MOD_DATETIME")]
        [Grid(Width = 150)]
        public string PV_MOD_DATETIME { get; set; }
        [JsonProperty("PV_MOD_BY")]
        [Grid(Width = 150)]
        public string PV_MOD_BY { get; set; }
        [JsonProperty("PM_MOD_DT")]
        [Grid(Width = 150)]
        public string PM_MOD_DT { get; set; }
    }

    public class MapFillGLCode
    {
        [JsonProperty("CBG_B_GL_CODE")]
        public virtual string CBG_B_GL_CODE { get; set; }
        [JsonProperty("CBG_B_GL_DESC")]
        public virtual string CBG_B_GL_DESC { get; set; }
    }

    public class MapItemDetailMaster
    {
        [JsonProperty("itemcode")]
        public virtual string itemcode { get; set; }
        //[JsonProperty("item_code")]
        //public virtual string item_code { get; set; }
        [JsonProperty("item_name")]
        public virtual string item_name { get; set; }
        [JsonProperty("chkSpot")]
        public virtual bool chkSpot { get; set; }
        [JsonProperty("chkStock")]
        public virtual bool chkStock { get; set; }
        [JsonProperty("chkMRO")]
        public virtual bool chkMRO { get; set; }
        [JsonProperty("ext_remarks")]
        public virtual string ext_remarks { get; set; }
        [JsonProperty("ext_remarks")]
        public virtual string ext_remarks1 { get; set; }
        [JsonProperty("CommodityType")]
        public virtual string CommodityType { get; set; }
        [JsonProperty("ref_no")]
        public virtual string ref_no { get; set; }
        [JsonProperty("AccountCode")]
        public virtual string AccountCode { get; set; }
        [JsonProperty("CategoryCode")]
        public virtual string CategoryCode { get; set; }
        [JsonProperty("radio")]
        public virtual bool radio { get; set; }
        [JsonProperty("UOM")]
        public virtual string UOM { get; set; }
        [JsonProperty("isActive")]
        public virtual bool isActive { get; set; }
        [JsonProperty("Min_OrderQty")]
        public virtual double Min_OrderQty { get; set; }
        [JsonProperty("Max_OrderQty")]
        public virtual double Max_OrderQty { get; set; }
        [JsonProperty("Min_Inventory")]
        public virtual double Min_Inventory { get; set; }
        [JsonProperty("Max_Inventory")]
        public virtual double Max_Inventory { get; set; }
        [JsonProperty("id_Brand")]
        public virtual string id_Brand { get; set; }
        [JsonProperty("DrawingNumber")]
        public virtual string DrawingNumber { get; set; }
        [JsonProperty("GrossWeight")]
        public virtual double GrossWeight { get; set; }
        [JsonProperty("id_length")]
        public virtual string id_length { get; set; }
        [JsonProperty("PackingSpecification")]
        public virtual string PackingSpecification { get; set; }
        //[JsonProperty("details")]
        //public virtual List<MapPRMasterDetail> Details { get; set; }
        //[JsonProperty("approvalorders")]
        //public virtual List<MapApprovalOrder> ApprovalOrders { get; set; }
        //[JsonProperty("PictAttachment")]
        //public virtual List<Master.Map.company_doc_attachment.MapFileAttachment> PictAttachment { get; set; }
        [JsonProperty("PictAttachment")]
        public virtual string PictAttachment { get; set; }
        [JsonProperty("FileAttachment")]
        public virtual List<Master.Map.company_doc_attachment.MapFileAttachment> FileAttachment { get; set; }
        [JsonProperty("ColorInfo")]
        public virtual string ColorInfo { get; set; }
        [JsonProperty("HSCode")]
        public virtual string HSCode { get; set; }
        [JsonProperty("ManufacturerName")]
        public virtual string ManufacturerName { get; set; }
        [JsonProperty("id_model")]
        public virtual string id_model { get; set; }
        [JsonProperty("NetWeight")]
        public virtual double NetWeight { get; set; }
        [JsonProperty("VersionNo")]
        public virtual string VersionNo { get; set; }
        [JsonProperty("id_width")]
        public virtual string id_width { get; set; }
        [JsonProperty("id_volume")]
        public virtual string id_volume { get; set; }
        [JsonProperty("id_height")]
        public virtual string id_height { get; set; }
        [JsonProperty("PrefVend_UseType")]
        public virtual string PrefVend_UseType { get; set; }
        [JsonProperty("PrefVend_OrderLead")]
        public virtual string PrefVend_OrderLead { get; set; }
        [JsonProperty("PrefVend_VenItemCode")]
        public virtual string PrefVend_VenItemCode { get; set; }
        [JsonProperty("First_UseType")]
        public virtual string First_UseType { get; set; }
        [JsonProperty("First_OrderLead")]
        public virtual string First_OrderLead { get; set; }
        [JsonProperty("First_VenItemCode")]
        public virtual string First_VenItemCode { get; set; }
        [JsonProperty("Second_UseType")]
        public virtual string Second_UseType { get; set; }
        [JsonProperty("Second_OrderLead")]
        public virtual string Second_OrderLead { get; set; }
        [JsonProperty("Second_VenItemCode")]
        public virtual string Second_VenItemCode { get; set; }
        [JsonProperty("Third_UseType")]
        public virtual string Third_UseType { get; set; }
        [JsonProperty("Third_OrderLead")]
        public virtual string Third_OrderLead { get; set; }
        [JsonProperty("Third_VenItemCode")]
        public virtual string Third_VenItemCode { get; set; }
        [JsonProperty("type")]
        public virtual string Type { get; set; }
    }
}