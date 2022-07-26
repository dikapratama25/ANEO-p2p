using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using Plexform.Base;
using LOGIC.Base;
using System.Collections.Generic;

namespace ANEO.Base.P2P.DO.Map
{
	#region DO_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.do_mstr.DO_MSTR))]
	public class MapDO_MSTR : BaseMapId
	{
		[JsonProperty("dom_do_index")]
		[Required]
		public virtual long? DOM_DO_INDEX { get; set; }
		[JsonProperty("dom_do_no")]
		[MaxLength(150)]
		public virtual string DOM_DO_NO { get; set; }
		[JsonProperty("dom_s_coy_id")]
		[MaxLength(60)]
		public virtual string DOM_S_COY_ID { get; set; }
		[JsonProperty("dom_do_date")]
		public virtual System.DateTime? DOM_DO_DATE { get; set; }
		[JsonProperty("dom_s_ref_no")]
		[MaxLength(120)]
		public virtual string DOM_S_REF_NO { get; set; }
		[JsonProperty("dom_s_ref_date")]
		public virtual System.DateTime? DOM_S_REF_DATE { get; set; }
		[JsonProperty("dom_po_index")]
		public virtual long? DOM_PO_INDEX { get; set; }
		[JsonProperty("dom_waybill_no")]
		[MaxLength(90)]
		public virtual string DOM_WAYBILL_NO { get; set; }
		[JsonProperty("dom_freight_carrier")]
		[MaxLength(90)]
		public virtual string DOM_FREIGHT_CARRIER { get; set; }
		[JsonProperty("dom_freight_amt")]
		public virtual decimal? DOM_FREIGHT_AMT { get; set; }
		[JsonProperty("dom_do_remarks")]
		[MaxLength(3000)]
		public virtual string DOM_DO_REMARKS { get; set; }
		[JsonProperty("dom_do_status")]
		public virtual int? DOM_DO_STATUS { get; set; }
		[JsonProperty("dom_created_date")]
		public virtual System.DateTime? DOM_CREATED_DATE { get; set; }
		[JsonProperty("dom_created_by")]
		[MaxLength(150)]
		public virtual string DOM_CREATED_BY { get; set; }
		[JsonProperty("dom_noofcopy_printed")]
		public virtual short? DOM_NOOFCOPY_PRINTED { get; set; }
		[JsonProperty("dom_do_prefix")]
		[MaxLength(90)]
		public virtual string DOM_DO_PREFIX { get; set; }
		[JsonProperty("dom_d_addr_code")]
		[MaxLength(60)]
		public virtual string DOM_D_ADDR_CODE { get; set; }
		[JsonProperty("dom_d_addr_line1")]
		[MaxLength(150)]
		public virtual string DOM_D_ADDR_LINE1 { get; set; }
		[JsonProperty("dom_d_addr_line2")]
		[MaxLength(150)]
		public virtual string DOM_D_ADDR_LINE2 { get; set; }
		[JsonProperty("dom_d_addr_line3")]
		[MaxLength(150)]
		public virtual string DOM_D_ADDR_LINE3 { get; set; }
		[JsonProperty("dom_d_postcode")]
		[MaxLength(30)]
		public virtual string DOM_D_POSTCODE { get; set; }
		[JsonProperty("dom_d_city")]
		[MaxLength(90)]
		public virtual string DOM_D_CITY { get; set; }
		[JsonProperty("dom_d_state")]
		[MaxLength(60)]
		public virtual string DOM_D_STATE { get; set; }
		[JsonProperty("dom_d_country")]
		[MaxLength(30)]
		public virtual string DOM_D_COUNTRY { get; set; }
		[JsonProperty("dom_external_ind")]
		[MaxLength(3)]
		public virtual string DOM_EXTERNAL_IND { get; set; }
		[JsonProperty("dom_reference_no")]
		[MaxLength(150)]
		public virtual string DOM_REFERENCE_NO { get; set; }
	}
    #endregion

    #region DO_DETAILS
    [Abp.AutoMapper.AutoMapTo(typeof(ANEO.DTO.P2P.Master.do_details.DO_DETAILS))]
	public class MapDO_DETAILS : BaseMapId
	{
		[JsonProperty("dod_s_coy_id")]
		[MaxLength(60), Required]
		public virtual string DOD_S_COY_ID { get; set; }
		[JsonProperty("dod_do_no")]
		[MaxLength(150), Required]
		public virtual string DOD_DO_NO { get; set; }
		[JsonProperty("dod_do_line")]
		[Required]
		public virtual int? DOD_DO_LINE { get; set; }
		[JsonProperty("dod_po_line")]
		public virtual int? DOD_PO_LINE { get; set; }
		[JsonProperty("dod_do_qty")]
		public virtual decimal? DOD_DO_QTY { get; set; }
		[JsonProperty("dod_shipped_qty")]
		public virtual decimal? DOD_SHIPPED_QTY { get; set; }
		[JsonProperty("dod_remarks")]
		[MaxLength(1200)]
		public virtual string DOD_REMARKS { get; set; }
		[JsonProperty("dod_do_lot_no")]
		public virtual int? DOD_DO_LOT_NO { get; set; }
	}
	#endregion

	#region COMPANY_DO_DOC_ATTACHMENT_TEMP
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.company_do_doc_attachment_temp.COMPANY_DO_DOC_ATTACHMENT_TEMP))]
	public class MapCOMPANY_DO_DOC_ATTACHMENT_TEMP : BaseMapId
	{
		[JsonProperty("cdda_attach_index")]
		[Required]
		public virtual long? CDDA_ATTACH_INDEX { get; set; }
		[JsonProperty("cdda_coy_id")]
		[MaxLength(60)]
		public virtual string CDDA_COY_ID { get; set; }
		[JsonProperty("cdda_doc_no")]
		[MaxLength(150)]
		public virtual string CDDA_DOC_NO { get; set; }
		[JsonProperty("cdda_po_line")]
		public virtual int? CDDA_PO_LINE { get; set; }
		[JsonProperty("cdda_item_code")]
		[MaxLength(300)]
		public virtual string CDDA_ITEM_CODE { get; set; }
		[JsonProperty("cdda_hub_filename")]
		[MaxLength(150)]
		public virtual string CDDA_HUB_FILENAME { get; set; }
		[JsonProperty("cdda_attach_filename")]
		[Grid(IsVisible = true, Width = 500)]
		[MaxLength(300)]
		public virtual string CDDA_ATTACH_FILENAME { get; set; }
		[JsonProperty("cdda_filesize")]
		public virtual decimal? CDDA_FILESIZE { get; set; }
		[JsonProperty("cdda_type")]
		[MaxLength(3)]
		public virtual string CDDA_TYPE { get; set; }
		[JsonProperty("cdda_status")]
		[MaxLength(3)]
		public virtual string CDDA_STATUS { get; set; }
		[JsonProperty("cdda_date")]
		public virtual System.DateTime? CDDA_DATE { get; set; }
		[JsonProperty("cdda_lot_index")]
		public virtual long? CDDA_LOT_INDEX { get; set; }
		[JsonProperty("cdda_line_no")]
		public virtual long? CDDA_LINE_NO { get; set; }
		
		// additional
		[JsonProperty("pathref")]
		public virtual string PathRef { get; set; }
		[JsonProperty("userid")]
		public virtual string UserID { get; set; }
	}
	#endregion

	public class MapPO
	{
		#region display
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

        public virtual double Tot { get; set; }
        [JsonProperty("Outs")]
        [Grid(IsVisible = true, Width = 140)]

        public virtual int Outs { get; set; }
		#endregion

		[JsonProperty("pom_po_index")]
		[Grid(IsVisible = false)]

		public virtual string POM_PO_INDEX { get; set; }
		[JsonProperty("pom_b_coy_id")]
		[Grid(IsVisible = false)]

		public virtual string POM_B_COY_ID { get; set; }
	}
    public class MapDOListing
    {
        [JsonProperty("DOM_DO_NO")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string DOM_DO_NO { get; set; }
        [JsonProperty("DOM_S_Ref_No")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string DOM_S_Ref_No { get; set; }
        [JsonProperty("DOM_Created_Date")]
        [Grid(IsVisible = true, Width = 140, DatetimeFormat = "DD/MM/YYYY")]
        public virtual DateTime DOM_Created_Date { get; set; }
        [JsonProperty("DOM_DO_Date")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string DOM_DO_Date { get; set; }
        [JsonProperty("POM_PO_No")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string POM_PO_No { get; set; }
        [JsonProperty("POM_PO_Date")]
        [Grid(IsVisible = true, Width = 150)]
        public virtual string POM_PO_Date { get; set; }
        [JsonProperty("CM_COY_NAME")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CM_COY_NAME { get; set; }
		[JsonProperty("Item_Code")]
		[Grid(IsVisible = true, Width = 180)]
		public virtual string Item_Code { get; set; }
		//[JsonProperty("DOD_SHIPPED_QTY_Ship")]
		//[Grid(IsVisible = true, Width = 100)]
		//public virtual double DOD_SHIPPED_QTY_Ship { get; set; }
		[JsonProperty("Status_Desc")]
		[Grid(IsVisible = true, Width = 140)]
		public virtual string Status_Desc { get; set; }

		// aditional
		[JsonProperty("POM_B_Coy_ID")]
		[Grid(IsVisible = false)]
		public virtual string POM_B_Coy_ID { get; set; }
		[JsonProperty("DOM_PO_Index")]
		[Grid(IsVisible = false)]
		public virtual string DOM_PO_Index { get; set; }
		[JsonProperty("DOM_D_ADDR_CODE")]
		[Grid(IsVisible = false)]
		public virtual string DOM_D_ADDR_CODE { get; set; }
	}

	public class MapDOSummary
	{
		[JsonProperty("date_created")]
		[Grid(IsVisible = true, DatetimeFormat = "DD/MM/YYYY")]
		public virtual DateTime date_created { get; set; }
		[JsonProperty("DOM_DO_NO")]
		[Grid(IsVisible = true)]

		public virtual string DOM_DO_NO { get; set; }
		[JsonProperty("DOM_Created_By")]
		[Grid(IsVisible = true)]
		public virtual string DOM_Created_By { get; set; }
		
	}

	#region PO_DETAILS
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.po_details.PO_DETAILS))]
	public class MapPO_DO_DETAILS : BaseMapId
	{
		[JsonProperty("pod_coy_id")]
		[MaxLength(60), Required]
		[Grid(IsVisible = false)]
		public virtual string POD_COY_ID { get; set; }
		[JsonProperty("pod_po_no")]
		[MaxLength(150), Required]
		[Grid(IsVisible = false)]
		public virtual string POD_PO_NO { get; set; }
		[JsonProperty("pod_po_line")]
		[Required]
		[Grid(IsVisible = true, Width = 50, IsSortable = false)]
		public virtual long? POD_PO_LINE { get; set; }
		[JsonProperty("pod_product_code")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string POD_PRODUCT_CODE { get; set; }
		[JsonProperty("pod_vendor_item_code")]
		[MaxLength(300)]
		[Grid(IsVisible = true, Width = 180, IsSortable = false)]
		public virtual string POD_VENDOR_ITEM_CODE { get; set; }
		[JsonProperty("pod_product_desc")]
		[MaxLength(1500)]
		[Grid(IsVisible = true, Width = 250)]
		public virtual string POD_PRODUCT_DESC { get; set; }
		[JsonProperty("pod_uom")]
		[MaxLength(60)]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual string POD_UOM { get; set; }
		[JsonProperty("pod_received_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_RECEIVED_QTY { get; set; }
		[JsonProperty("pod_rejected_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_REJECTED_QTY { get; set; }
		[JsonProperty("pod_delivered_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_DELIVERED_QTY { get; set; }
		[JsonProperty("pod_cancelled_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_CANCELLED_QTY { get; set; }
		[JsonProperty("pod_min_pack_qty")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual decimal? POD_MIN_PACK_QTY { get; set; }
		[JsonProperty("pod_min_order_qty")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual decimal? POD_MIN_ORDER_QTY { get; set; }
		[JsonProperty("pod_etd")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual int? POD_ETD { get; set; }
		[JsonProperty("pod_warranty_terms")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual int? POD_WARRANTY_TERMS { get; set; }
		[JsonProperty("pod_unit_cost")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_UNIT_COST { get; set; }
		[JsonProperty("pod_remark")]
		[MaxLength(1200)]
		[Grid(IsVisible = false)]
		public virtual string POD_REMARK { get; set; }
		[JsonProperty("pod_gst")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_GST { get; set; }
		[JsonProperty("pod_gst_rate")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string POD_GST_RATE { get; set; }
		[JsonProperty("pod_gst_input_tax_code")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string POD_GST_INPUT_TAX_CODE { get; set; }
		[JsonProperty("pod_tax_value")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_TAX_VALUE { get; set; }
		[JsonProperty("pod_pr_index")]
		[Grid(IsVisible = false)]
		public virtual long? POD_PR_INDEX { get; set; }
		[JsonProperty("pod_pr_line")]
		[Grid(IsVisible = false)]
		public virtual int? POD_PR_LINE { get; set; }
		[JsonProperty("pod_acct_index")]
		[Grid(IsVisible = false)]
		public virtual long? POD_ACCT_INDEX { get; set; }
		[JsonProperty("pod_product_type")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string POD_PRODUCT_TYPE { get; set; }
		[JsonProperty("pod_b_item_code")]
		[MaxLength(750)]
		[Grid(IsVisible = false)]
		public virtual string POD_B_ITEM_CODE { get; set; }
		[JsonProperty("pod_source")]
		[MaxLength(6)]
		[Grid(IsVisible = false)]
		public virtual string POD_SOURCE { get; set; }
		[JsonProperty("pod_d_addr_code")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_ADDR_CODE { get; set; }
		[JsonProperty("pod_d_addr_line1")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_ADDR_LINE1 { get; set; }
		[JsonProperty("pod_d_addr_line2")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_ADDR_LINE2 { get; set; }
		[JsonProperty("pod_d_addr_line3")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_ADDR_LINE3 { get; set; }
		[JsonProperty("pod_d_postcode")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_POSTCODE { get; set; }
		[JsonProperty("pod_d_city")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_CITY { get; set; }
		[JsonProperty("pod_d_state")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_STATE { get; set; }
		[JsonProperty("pod_d_country")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string POD_D_COUNTRY { get; set; }
		[JsonProperty("pod_b_category_code")]
		[MaxLength(300)]
		[Grid(IsVisible = false)]
		public virtual string POD_B_CATEGORY_CODE { get; set; }
		[JsonProperty("pod_b_gl_code")]
		[MaxLength(300)]
		[Grid(IsVisible = false)]
		public virtual string POD_B_GL_CODE { get; set; }
		[JsonProperty("pod_cd_group_index")]
		[Grid(IsVisible = false)]
		public virtual long? POD_CD_GROUP_INDEX { get; set; }
		[JsonProperty("pod_rfq_item_line")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string POD_RFQ_ITEM_LINE { get; set; }
		[JsonProperty("pod_asset_group")]
		[MaxLength(90)]
		[Grid(IsVisible = false)]
		public virtual string POD_ASSET_GROUP { get; set; }
		[JsonProperty("pod_asset_no")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string POD_ASSET_NO { get; set; }
		[JsonProperty("pod_curr_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_CURR_QTY { get; set; }
		[JsonProperty("pod_prev1_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_PREV1_QTY { get; set; }
		[JsonProperty("pod_prev2_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_PREV2_QTY { get; set; }
		[JsonProperty("pod_prev3_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_PREV3_QTY { get; set; }
		[JsonProperty("pod_prev_avg")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_PREV_AVG { get; set; }
		[JsonProperty("pod_next1_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_NEXT1_QTY { get; set; }
		[JsonProperty("pod_next2_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_NEXT2_QTY { get; set; }
		[JsonProperty("pod_next3_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_NEXT3_QTY { get; set; }
		[JsonProperty("pod_pur_spec_no")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string POD_PUR_SPEC_NO { get; set; }
		[JsonProperty("pod_spec1")]
		[MaxLength(768)]
		[Grid(IsVisible = false)]
		public virtual string POD_SPEC1 { get; set; }
		[JsonProperty("pod_spec2")]
		[MaxLength(768)]
		[Grid(IsVisible = false)]
		public virtual string POD_SPEC2 { get; set; }
		[JsonProperty("pod_spec3")]
		[MaxLength(768)]
		[Grid(IsVisible = false)]
		public virtual string POD_SPEC3 { get; set; }
		[JsonProperty("pod_lead_time")]
		[Grid(IsVisible = false)]
		public virtual int? POD_LEAD_TIME { get; set; }
		[JsonProperty("pod_manufacturer")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string POD_MANUFACTURER { get; set; }
		[JsonProperty("pod_item_type")]
		[MaxLength(6)]
		[Grid(IsVisible = false)]
		public virtual string POD_ITEM_TYPE { get; set; }
		[JsonProperty("pod_oversea")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string POD_OVERSEA { get; set; }
		[JsonProperty("pod_stock_on_hand_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_STOCK_ON_HAND_QTY { get; set; }
		[JsonProperty("pod_po_balance_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_PO_BALANCE_QTY { get; set; }
		[JsonProperty("pod_po_in_progress_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_PO_IN_PROGRESS_QTY { get; set; }
		[JsonProperty("pod_packing_type")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string POD_PACKING_TYPE { get; set; }
		[JsonProperty("pod_packing_qty")]
		[Grid(IsVisible = false)]
		public virtual decimal? POD_PACKING_QTY { get; set; }
		[JsonProperty("pod_gift")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string POD_GIFT { get; set; }
		[JsonProperty("pod_fund_type")]
		[MaxLength(300)]
		[Grid(IsVisible = false)]
		public virtual string POD_FUND_TYPE { get; set; }
		[JsonProperty("pod_person_code")]
		[MaxLength(300)]
		[Grid(IsVisible = false)]
		public virtual string POD_PERSON_CODE { get; set; }
		[JsonProperty("pod_project_code")]
		[MaxLength(300)]
		[Grid(IsVisible = false)]
		public virtual string POD_PROJECT_CODE { get; set; }
		[JsonProperty("pod_withholding_opt")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string POD_WITHHOLDING_OPT { get; set; }
		[JsonProperty("pod_withholding_tax")]
		[Grid(IsVisible = false)]
		public virtual int? POD_WITHHOLDING_TAX { get; set; }
		[JsonProperty("pod_withholding_remarks")]
		[MaxLength(3000)]
		[Grid(IsVisible = false)]
		public virtual string POD_WITHHOLDING_REMARKS { get; set; }
		[JsonProperty("pod_ordered_qty")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual decimal? POD_ORDERED_QTY { get; set; }

		// additional
		[JsonProperty("pod_outstanding")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual decimal? POD_Outstanding { get; set; }
		[JsonProperty("dod_shippped_qty_ship")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual decimal? DOD_SHIPPED_QTY_Ship { get; set; }
		[JsonProperty("dod_remarks")]
		[Grid(IsVisible = true, Width = 150, IsSortable = false)]
		public virtual string DOD_REMARKS { get; set; }
	}
	#endregion

	public class MapDOParameter
	{
		[JsonProperty("savetype")]
		public virtual string SaveType { get; set; }
		[JsonProperty("statustype")]
		public virtual string StatusType { get; set; }
		[JsonProperty("userid")]
		public virtual string UserID { get; set; }
		[JsonProperty("do_mstr")]
		public virtual MapDO_MSTR DO_MSTR { get; set; }
		[JsonProperty("po_do_details")]
		public virtual MapPO_DO_DETAILS PO_DO_DETAILS { get; set; }
		[JsonProperty("do_details")]
		public virtual List<MapDO_DETAILS> DO_DETAILS { get; set; }
		[JsonProperty("doc_attachments")]
		public virtual List<MapCOMPANY_DO_DOC_ATTACHMENT_TEMP> DOC_ATTACHMENTS { get; set; }
	}

}
