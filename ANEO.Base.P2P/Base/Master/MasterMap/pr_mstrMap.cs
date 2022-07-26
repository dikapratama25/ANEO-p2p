using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.pr_mstr
{
	#region PR_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.pr_mstr.PR_MSTR))]
	public class MapPR_MSTR : BaseMapId
	{
		[JsonProperty("prm_pr_index")]
		[Required]
		public virtual long? PRM_PR_Index { get; set; }
		[JsonProperty("prm_pr_no")]
		[MaxLength(150)]
		public virtual string PRM_PR_NO { get; set; }
		[JsonProperty("prm_coy_id")]
		[MaxLength(60)]
		public virtual string PRM_COY_ID { get; set; }
		[JsonProperty("prm_req_name")]
		[MaxLength(150)]
		public virtual string PRM_REQ_NAME { get; set; }
		[JsonProperty("prm_req_phone")]
		[MaxLength(60)]
		public virtual string PRM_REQ_PHONE { get; set; }
		[JsonProperty("prm_pr_date")]
		public virtual System.DateTime? PRM_PR_DATE { get; set; }
		[JsonProperty("prm_created_date")]
		public virtual System.DateTime? PRM_CREATED_DATE { get; set; }
		[JsonProperty("prm_submit_date")]
		public virtual System.DateTime? PRM_SUBMIT_DATE { get; set; }
		[JsonProperty("prm_status_changed_by")]
		[MaxLength(60)]
		public virtual string PRM_STATUS_CHANGED_BY { get; set; }
		[JsonProperty("prm_status_changed_on")]
		public virtual System.DateTime? PRM_STATUS_CHANGED_ON { get; set; }
		[JsonProperty("prm_buyer_id")]
		[MaxLength(60)]
		public virtual string PRM_BUYER_ID { get; set; }
		[JsonProperty("prm_s_coy_id")]
		[MaxLength(60)]
		public virtual string PRM_S_COY_ID { get; set; }
		[JsonProperty("prm_s_attn")]
		[MaxLength(150)]
		public virtual string PRM_S_ATTN { get; set; }
		[JsonProperty("prm_s_coy_name")]
		[MaxLength(300)]
		public virtual string PRM_S_COY_NAME { get; set; }
		[JsonProperty("prm_s_addr_line1")]
		[MaxLength(150)]
		public virtual string PRM_S_ADDR_LINE1 { get; set; }
		[JsonProperty("prm_s_addr_line2")]
		[MaxLength(150)]
		public virtual string PRM_S_ADDR_LINE2 { get; set; }
		[JsonProperty("prm_s_addr_line3")]
		[MaxLength(150)]
		public virtual string PRM_S_ADDR_LINE3 { get; set; }
		[JsonProperty("prm_s_postcode")]
		[MaxLength(30)]
		public virtual string PRM_S_POSTCODE { get; set; }
		[JsonProperty("prm_s_city")]
		[MaxLength(90)]
		public virtual string PRM_S_CITY { get; set; }
		[JsonProperty("prm_s_state")]
		[MaxLength(60)]
		public virtual string PRM_S_STATE { get; set; }
		[JsonProperty("prm_s_country")]
		[MaxLength(60)]
		public virtual string PRM_S_COUNTRY { get; set; }
		[JsonProperty("prm_s_phone")]
		[MaxLength(60)]
		public virtual string PRM_S_PHONE { get; set; }
		[JsonProperty("prm_s_fax")]
		[MaxLength(60)]
		public virtual string PRM_S_FAX { get; set; }
		[JsonProperty("prm_s_email")]
		[MaxLength(180)]
		public virtual string PRM_S_EMAIL { get; set; }
		[JsonProperty("prm_freight_terms")]
		[MaxLength(60)]
		public virtual string PRM_FREIGHT_TERMS { get; set; }
		[JsonProperty("prm_payment_type")]
		[MaxLength(30)]
		public virtual string PRM_PAYMENT_TYPE { get; set; }
		[JsonProperty("prm_shipment_term")]
		[MaxLength(30)]
		public virtual string PRM_SHIPMENT_TERM { get; set; }
		[JsonProperty("prm_shipment_mode")]
		[MaxLength(30)]
		public virtual string PRM_SHIPMENT_MODE { get; set; }
		[JsonProperty("prm_currency_code")]
		[MaxLength(30)]
		public virtual string PRM_CURRENCY_CODE { get; set; }
		[JsonProperty("prm_gst")]
		public virtual decimal? PRM_GST { get; set; }
		[JsonProperty("prm_exchange_rate")]
		public virtual double? PRM_EXCHANGE_RATE { get; set; }
		[JsonProperty("prm_payment_term")]
		[MaxLength(30)]
		public virtual string PRM_PAYMENT_TERM { get; set; }
		[JsonProperty("prm_ship_via")]
		[MaxLength(90)]
		public virtual string PRM_SHIP_VIA { get; set; }
		[JsonProperty("prm_internal_remark")]
		[MaxLength(3000)]
		public virtual string PRM_INTERNAL_REMARK { get; set; }
		[JsonProperty("prm_external_remark")]
		[MaxLength(3000)]
		public virtual string PRM_EXTERNAL_REMARK { get; set; }
		[JsonProperty("prm_pr_status")]
		public virtual int? PRM_PR_STATUS { get; set; }
		[JsonProperty("prm_po_index")]
		public virtual long? PRM_PO_INDEX { get; set; }
		[JsonProperty("prm_archive_ind")]
		[MaxLength(3)]
		public virtual string PRM_ARCHIVE_IND { get; set; }
		[JsonProperty("prm_print_custom_fields")]
		[MaxLength(3)]
		public virtual string PRM_PRINT_CUSTOM_FIELDS { get; set; }
		[JsonProperty("prm_print_remark")]
		[MaxLength(3)]
		public virtual string PRM_PRINT_REMARK { get; set; }
		[JsonProperty("prm_pr_prefix")]
		[MaxLength(150)]
		public virtual string PRM_PR_PREFIX { get; set; }
		[JsonProperty("prm_b_addr_code")]
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_CODE { get; set; }
		[JsonProperty("prm_b_addr_line1")]
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_LINE1 { get; set; }
		[JsonProperty("prm_b_addr_line2")]
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_LINE2 { get; set; }
		[JsonProperty("prm_b_addr_line3")]
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_LINE3 { get; set; }
		[JsonProperty("prm_b_postcode")]
		[MaxLength(30)]
		public virtual string PRM_B_POSTCODE { get; set; }
		[JsonProperty("prm_b_state")]
		[MaxLength(60)]
		public virtual string PRM_B_STATE { get; set; }
		[JsonProperty("prm_b_city")]
		[MaxLength(90)]
		public virtual string PRM_B_CITY { get; set; }
		[JsonProperty("prm_b_country")]
		[MaxLength(60)]
		public virtual string PRM_B_COUNTRY { get; set; }
		[JsonProperty("prm_rfq_index")]
		public virtual long? PRM_RFQ_INDEX { get; set; }
		[JsonProperty("prm_dept_index")]
		public virtual long? PRM_DEPT_INDEX { get; set; }
		[JsonProperty("prm_dup_from")]
		[MaxLength(150)]
		public virtual string PRM_DUP_FROM { get; set; }
		[JsonProperty("prm_external_ind")]
		[MaxLength(3)]
		public virtual string PRM_EXTERNAL_IND { get; set; }
		[JsonProperty("prm_reference_no")]
		[MaxLength(150)]
		public virtual string PRM_REFERENCE_NO { get; set; }
		[JsonProperty("prm_consolidator")]
		[MaxLength(60)]
		public virtual string PRM_CONSOLIDATOR { get; set; }
		[JsonProperty("prm_pr_cost")]
		public virtual decimal? PRM_PR_COST { get; set; }
		[JsonProperty("prm_quotation_no")]
		[MaxLength(150)]
		public virtual string PRM_QUOTATION_NO { get; set; }
		[JsonProperty("prm_pr_type")]
		[MaxLength(6)]
		public virtual string PRM_PR_TYPE { get; set; }
		[JsonProperty("prm_urgent")]
		[MaxLength(3)]
		public virtual string PRM_URGENT { get; set; }
	}
	#endregion
}
