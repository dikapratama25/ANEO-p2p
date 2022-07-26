using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.product_mstr
{
	#region PRODUCT_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.product_mstr.PRODUCT_MSTR))]
	public class MapPRODUCT_MSTR : BaseMapId
	{
		[JsonProperty("pm_product_index")]
		[Required]
		public virtual long? PM_PRODUCT_INDEX { get; set; }
		[JsonProperty("pm_s_coy_id")]
		[MaxLength(60)]
		public virtual string PM_S_COY_ID { get; set; }
		[JsonProperty("pm_product_code")]
		[MaxLength(60)]
		public virtual string PM_PRODUCT_CODE { get; set; }
		[JsonProperty("pm_category_name")]
		[MaxLength(60)]
		public virtual string PM_CATEGORY_NAME { get; set; }
		[JsonProperty("pm_vendor_item_code")]
		[MaxLength(300)]
		public virtual string PM_VENDOR_ITEM_CODE { get; set; }
		[JsonProperty("pm_product_desc")]
		[MaxLength(1500)]
		public virtual string PM_PRODUCT_DESC { get; set; }
		[JsonProperty("pm_uom")]
		[MaxLength(60)]
		public virtual string PM_UOM { get; set; }
		[JsonProperty("pm_unit_cost")]
		public virtual decimal? PM_UNIT_COST { get; set; }
		[JsonProperty("pm_gst_code")]
		[MaxLength(30)]
		public virtual string PM_GST_CODE { get; set; }
		[JsonProperty("pm_tax_perc")]
		[MaxLength(15)]
		public virtual string PM_TAX_PERC { get; set; }
		[JsonProperty("pm_product_image")]
		[MaxLength(150)]
		public virtual string PM_PRODUCT_IMAGE { get; set; }
		[JsonProperty("pm_currency_code")]
		[MaxLength(30)]
		public virtual string PM_CURRENCY_CODE { get; set; }
		[JsonProperty("pm_product_brand")]
		[MaxLength(768)]
		public virtual string PM_PRODUCT_BRAND { get; set; }
		[JsonProperty("pm_product_model")]
		[MaxLength(768)]
		public virtual string PM_PRODUCT_MODEL { get; set; }
		[JsonProperty("pm_product_type")]
		[MaxLength(30)]
		public virtual string PM_PRODUCT_TYPE { get; set; }
		[JsonProperty("pm_mod_by")]
		[MaxLength(60)]
		public virtual string PM_MOD_BY { get; set; }
		[JsonProperty("pm_mod_dt")]
		public virtual System.DateTime? PM_MOD_DT { get; set; }
		[JsonProperty("pm_ent_by")]
		[MaxLength(60)]
		public virtual string PM_ENT_BY { get; set; }
		[JsonProperty("pm_ent_dt")]
		public virtual System.DateTime? PM_ENT_DT { get; set; }
		[JsonProperty("pm_deleted")]
		[MaxLength(3)]
		public virtual string PM_DELETED { get; set; }
		[JsonProperty("pm_ref_no")]
		[MaxLength(768)]
		public virtual string PM_REF_NO { get; set; }
		[JsonProperty("pm_long_desc")]
		[MaxLength(12000)]
		public virtual string PM_LONG_DESC { get; set; }
		[JsonProperty("pm_acct_code")]
		[MaxLength(90)]
		public virtual string PM_ACCT_CODE { get; set; }
		[JsonProperty("pm_safe_qty")]
		public virtual decimal? PM_SAFE_QTY { get; set; }
		[JsonProperty("pm_ord_min_qty")]
		public virtual decimal? PM_ORD_MIN_QTY { get; set; }
		[JsonProperty("pm_ord_max_qty")]
		public virtual decimal? PM_ORD_MAX_QTY { get; set; }
		[JsonProperty("pm_draw_no")]
		[MaxLength(150)]
		public virtual string PM_DRAW_NO { get; set; }
		[JsonProperty("pm_vers_no")]
		[MaxLength(150)]
		public virtual string PM_VERS_NO { get; set; }
		[JsonProperty("pm_gross_weight")]
		[MaxLength(150)]
		public virtual string PM_GROSS_WEIGHT { get; set; }
		[JsonProperty("pm_net_weight")]
		[MaxLength(150)]
		public virtual string PM_NET_WEIGHT { get; set; }
		[JsonProperty("pm_lenght")]
		[MaxLength(150)]
		public virtual string PM_LENGHT { get; set; }
		[JsonProperty("pm_width")]
		[MaxLength(150)]
		public virtual string PM_WIDTH { get; set; }
		[JsonProperty("pm_height")]
		[MaxLength(150)]
		public virtual string PM_HEIGHT { get; set; }
		[JsonProperty("pm_volume")]
		[MaxLength(150)]
		public virtual string PM_VOLUME { get; set; }
		[JsonProperty("pm_color_info")]
		[MaxLength(768)]
		public virtual string PM_COLOR_INFO { get; set; }
		[JsonProperty("pm_hsc_code")]
		[MaxLength(768)]
		public virtual string PM_HSC_CODE { get; set; }
		[JsonProperty("pm_rec_spec")]
		[MaxLength(768)]
		public virtual string PM_REC_SPEC { get; set; }
		[JsonProperty("pm_packing_req")]
		[MaxLength(768)]
		public virtual string PM_PACKING_REQ { get; set; }
		[JsonProperty("pm_remarks")]
		[MaxLength(9000)]
		public virtual string PM_REMARKS { get; set; }
		[JsonProperty("pm_product_for")]
		[MaxLength(3)]
		public virtual string PM_PRODUCT_FOR { get; set; }
		[JsonProperty("pm_prefer_s_coy_id")]
		[MaxLength(60)]
		public virtual string PM_PREFER_S_COY_ID { get; set; }
		[JsonProperty("pm_1st_s_coy_id")]
		[MaxLength(60)]
		public virtual string PM_1ST_S_COY_ID { get; set; }
		[JsonProperty("pm_2nd_s_coy_id")]
		[MaxLength(60)]
		public virtual string PM_2ND_S_COY_ID { get; set; }
		[JsonProperty("pm_3rd_s_coy_id")]
		[MaxLength(60)]
		public virtual string PM_3RD_S_COY_ID { get; set; }
		[JsonProperty("pm_last_txn_price")]
		public virtual decimal? PM_LAST_TXN_PRICE { get; set; }
		[JsonProperty("pm_last_txn_price_curr")]
		[MaxLength(30)]
		public virtual string PM_LAST_TXN_PRICE_CURR { get; set; }
		[JsonProperty("pm_last_txn_tax")]
		public virtual decimal? PM_LAST_TXN_TAX { get; set; }
		[JsonProperty("pm_last_txn_s_coy_id")]
		[MaxLength(60)]
		public virtual string PM_LAST_TXN_S_COY_ID { get; set; }
		[JsonProperty("pm_tax_id")]
		public virtual int? PM_TAX_ID { get; set; }
		[JsonProperty("pm_prefer_s_coy_id_tax_id")]
		public virtual int? PM_PREFER_S_COY_ID_TAX_ID { get; set; }
		[JsonProperty("pm_1st_s_coy_id_tax_id")]
		public virtual int? PM_1ST_S_COY_ID_TAX_ID { get; set; }
		[JsonProperty("pm_2nd_s_coy_id_tax_id")]
		public virtual int? PM_2ND_S_COY_ID_TAX_ID { get; set; }
		[JsonProperty("pm_3rd_s_coy_id_tax_id")]
		public virtual int? PM_3RD_S_COY_ID_TAX_ID { get; set; }
		[JsonProperty("pm_remark")]
		[MaxLength(1200)]
		public virtual string PM_REMARK { get; set; }
		[JsonProperty("pm_item_type")]
		[MaxLength(6)]
		public virtual string PM_ITEM_TYPE { get; set; }
		[JsonProperty("pm_iqc_ind")]
		[MaxLength(3)]
		public virtual string PM_IQC_IND { get; set; }
		[JsonProperty("pm_max_inv_qty")]
		public virtual decimal? PM_MAX_INV_QTY { get; set; }
		[JsonProperty("pm_manufacturer")]
		[MaxLength(150)]
		public virtual string PM_MANUFACTURER { get; set; }
		[JsonProperty("pm_cat_code")]
		[MaxLength(300)]
		public virtual string PM_CAT_CODE { get; set; }
		[JsonProperty("pm_reorder_qty")]
		public virtual decimal? PM_REORDER_QTY { get; set; }
		[JsonProperty("pm_budget_price")]
		public virtual decimal? PM_BUDGET_PRICE { get; set; }
		[JsonProperty("pm_previous_budget_price")]
		public virtual decimal? PM_PREVIOUS_BUDGET_PRICE { get; set; }
		[JsonProperty("pm_iqc_type")]
		[MaxLength(15)]
		public virtual string PM_IQC_TYPE { get; set; }
		[JsonProperty("pm_eoq")]
		[MaxLength(150)]
		public virtual string PM_EOQ { get; set; }
		[JsonProperty("pm_ratio")]
		[MaxLength(150)]
		public virtual string PM_RATIO { get; set; }
		[JsonProperty("pm_oversea")]
		[MaxLength(3)]
		public virtual string PM_OVERSEA { get; set; }
		[JsonProperty("pm_partial_cd")]
		[MaxLength(3)]
		public virtual string PM_PARTIAL_CD { get; set; }
		[JsonProperty("pm_spec1")]
		[MaxLength(768)]
		public virtual string PM_SPEC1 { get; set; }
		[JsonProperty("pm_spec2")]
		[MaxLength(768)]
		public virtual string PM_SPEC2 { get; set; }
		[JsonProperty("pm_spec3")]
		[MaxLength(768)]
		public virtual string PM_SPEC3 { get; set; }
		[JsonProperty("pm_packing_type")]
		[MaxLength(30)]
		public virtual string PM_PACKING_TYPE { get; set; }
		[JsonProperty("pm_packing_qty")]
		public virtual decimal? PM_PACKING_QTY { get; set; }
		[JsonProperty("pm_manufacturer2")]
		[MaxLength(150)]
		public virtual string PM_MANUFACTURER2 { get; set; }
		[JsonProperty("pm_manufacturer3")]
		[MaxLength(150)]
		public virtual string PM_MANUFACTURER3 { get; set; }
		[JsonProperty("pm_section")]
		[MaxLength(150)]
		public virtual string PM_SECTION { get; set; }
		[JsonProperty("pm_location")]
		[MaxLength(150)]
		public virtual string PM_LOCATION { get; set; }
		[JsonProperty("pm_new_item_code")]
		[MaxLength(60)]
		public virtual string PM_NEW_ITEM_CODE { get; set; }
	}
	#endregion
}
