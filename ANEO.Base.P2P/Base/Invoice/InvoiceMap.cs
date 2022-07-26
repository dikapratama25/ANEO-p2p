using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;
using System;

namespace ANEO.Base.P2P.Invoice.Map
{
	#region INVOICE_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(ANEO.DTO.P2P.Master.invoice_mstr.INVOICE_MSTR))]
	public class MapINVOICE_MSTR : BaseMapId
	{
		[JsonProperty("im_invoice_index")]
		[Required]
		public virtual long? IM_INVOICE_INDEX { get; set; }
		[JsonProperty("im_invoice_no")]
		[MaxLength(150)]
		public virtual string IM_INVOICE_NO { get; set; }
		[JsonProperty("im_s_coy_id")]
		[MaxLength(60)]
		public virtual string IM_S_COY_ID { get; set; }
		[JsonProperty("im_s_coy_name")]
		[MaxLength(300)]
		public virtual string IM_S_COY_NAME { get; set; }
		[JsonProperty("im_po_index")]
		public virtual long? IM_PO_INDEX { get; set; }
		[JsonProperty("im_b_coy_id")]
		[MaxLength(60)]
		public virtual string IM_B_COY_ID { get; set; }
		[JsonProperty("im_payment_date")]
		public virtual System.DateTime? IM_PAYMENT_DATE { get; set; }
		[JsonProperty("im_remark")]
		[MaxLength(3000)]
		public virtual string IM_REMARK { get; set; }
		[JsonProperty("im_created_by")]
		[MaxLength(60)]
		public virtual string IM_CREATED_BY { get; set; }
		[JsonProperty("im_created_on")]
		public virtual System.DateTime? IM_CREATED_ON { get; set; }
		[JsonProperty("im_invoice_status")]
		public virtual int? IM_INVOICE_STATUS { get; set; }
		[JsonProperty("im_payment_no")]
		[MaxLength(120)]
		public virtual string IM_PAYMENT_NO { get; set; }
		[JsonProperty("im_your_ref")]
		[MaxLength(450)]
		public virtual string IM_YOUR_REF { get; set; }
		[JsonProperty("im_our_ref")]
		[MaxLength(150)]
		public virtual string IM_OUR_REF { get; set; }
		[JsonProperty("im_invoice_prefix")]
		[MaxLength(90)]
		public virtual string IM_INVOICE_PREFIX { get; set; }
		[JsonProperty("im_submittedby_fo")]
		[MaxLength(60)]
		public virtual string IM_SUBMITTEDBY_FO { get; set; }
		[JsonProperty("im_exchange_rate")]
		public virtual double? IM_EXCHANGE_RATE { get; set; }
		[JsonProperty("im_finance_remarks")]
		[MaxLength(3000)]
		public virtual string IM_FINANCE_REMARKS { get; set; }
		[JsonProperty("im_printed")]
		[MaxLength(3)]
		public virtual string IM_PRINTED { get; set; }
		[JsonProperty("im_folder")]
		public virtual int? IM_FOLDER { get; set; }
		[JsonProperty("im_fm_approved_date")]
		public virtual System.DateTime? IM_FM_APPROVED_DATE { get; set; }
		[JsonProperty("im_downloaded_date")]
		public virtual System.DateTime? IM_DOWNLOADED_DATE { get; set; }
		[JsonProperty("im_external_ind")]
		[MaxLength(3)]
		public virtual string IM_EXTERNAL_IND { get; set; }
		[JsonProperty("im_reference_no")]
		[MaxLength(150)]
		public virtual string IM_REFERENCE_NO { get; set; }
		[JsonProperty("im_invoice_total")]
		public virtual decimal? IM_INVOICE_TOTAL { get; set; }
		[JsonProperty("im_invoice_excl_gst")]
		public virtual decimal? IM_INVOICE_EXCL_GST { get; set; }
		[JsonProperty("im_invoice_gst")]
		public virtual decimal? IM_INVOICE_GST { get; set; }
		[JsonProperty("im_payment_term")]
		[MaxLength(30)]
		public virtual string IM_PAYMENT_TERM { get; set; }
		[JsonProperty("im_status_changed_by")]
		[MaxLength(60)]
		public virtual string IM_STATUS_CHANGED_BY { get; set; }
		[JsonProperty("im_status_changed_on")]
		public virtual System.DateTime? IM_STATUS_CHANGED_ON { get; set; }
		[JsonProperty("im_ship_amt")]
		public virtual decimal? IM_SHIP_AMT { get; set; }
		[JsonProperty("im_invoice_type")]
		[MaxLength(18)]
		public virtual string IM_INVOICE_TYPE { get; set; }
		[JsonProperty("im_doc_date")]
		public virtual System.DateTime? IM_DOC_DATE { get; set; }
		[JsonProperty("im_submit_date")]
		public virtual System.DateTime? IM_SUBMIT_DATE { get; set; }
		[JsonProperty("im_ipp_po")]
		[MaxLength(90)]
		public virtual string IM_IPP_PO { get; set; }
		[JsonProperty("im_addr_line1")]
		[MaxLength(765)]
		public virtual string IM_ADDR_LINE1 { get; set; }
		[JsonProperty("im_addr_line2")]
		[MaxLength(765)]
		public virtual string IM_ADDR_LINE2 { get; set; }
		[JsonProperty("im_addr_line3")]
		[MaxLength(765)]
		public virtual string IM_ADDR_LINE3 { get; set; }
		[JsonProperty("im_postcode")]
		[MaxLength(30)]
		public virtual string IM_POSTCODE { get; set; }
		[JsonProperty("im_city")]
		[MaxLength(150)]
		public virtual string IM_CITY { get; set; }
		[JsonProperty("im_state")]
		[MaxLength(30)]
		public virtual string IM_STATE { get; set; }
		[JsonProperty("im_country")]
		[MaxLength(30)]
		public virtual string IM_COUNTRY { get; set; }
		[JsonProperty("im_remarks")]
		[MaxLength(3000)]
		public virtual string IM_REMARKS { get; set; }
		[JsonProperty("im_late_reason")]
		[MaxLength(3000)]
		public virtual string IM_LATE_REASON { get; set; }
		[JsonProperty("im_currency_code")]
		[MaxLength(30)]
		public virtual string IM_CURRENCY_CODE { get; set; }
		[JsonProperty("im_withholding_tax")]
		public virtual int? IM_WITHHOLDING_TAX { get; set; }
		[JsonProperty("im_withholding_opt")]
		[MaxLength(3)]
		public virtual string IM_WITHHOLDING_OPT { get; set; }
		[JsonProperty("im_withholding_remarks")]
		[MaxLength(3000)]
		public virtual string IM_WITHHOLDING_REMARKS { get; set; }
		[JsonProperty("im_exchg_rate")]
		public virtual decimal? IM_EXCHG_RATE { get; set; }
		[JsonProperty("im_pymt_type_index")]
		public virtual long? IM_PYMT_TYPE_INDEX { get; set; }
		[JsonProperty("im_dept_index")]
		public virtual long? IM_DEPT_INDEX { get; set; }
		[JsonProperty("im_printed_ind")]
		[MaxLength(3)]
		public virtual string IM_PRINTED_IND { get; set; }
		[JsonProperty("im_cheque_no")]
		[MaxLength(60)]
		public virtual string IM_CHEQUE_NO { get; set; }
		[JsonProperty("im_due_date")]
		public virtual System.DateTime? IM_DUE_DATE { get; set; }
		[JsonProperty("im_prcs_sent")]
		public virtual System.DateTime? IM_PRCS_SENT { get; set; }
		[JsonProperty("im_prcs_sent_id")]
		[MaxLength(60)]
		public virtual string IM_PRCS_SENT_ID { get; set; }
		[JsonProperty("im_prcs_sent_upd_date")]
		public virtual System.DateTime? IM_PRCS_SENT_UPD_DATE { get; set; }
		[JsonProperty("im_prcs_recv")]
		public virtual System.DateTime? IM_PRCS_RECV { get; set; }
		[JsonProperty("im_prcs_recv_id")]
		[MaxLength(60)]
		public virtual string IM_PRCS_RECV_ID { get; set; }
		[JsonProperty("im_prcs_recv_upd_date")]
		public virtual System.DateTime? IM_PRCS_RECV_UPD_DATE { get; set; }
		[JsonProperty("im_bank_code")]
		[MaxLength(90)]
		public virtual string im_bank_code { get; set; }
		[JsonProperty("im_bank_acct")]
		[MaxLength(90)]
		public virtual string im_bank_acct { get; set; }
		[JsonProperty("im_remarks1")]
		[MaxLength(150)]
		public virtual string IM_REMARKS1 { get; set; }
		[JsonProperty("im_remarks2")]
		[MaxLength(150)]
		public virtual string IM_REMARKS2 { get; set; }
		[JsonProperty("im_remarks3")]
		[MaxLength(3000)]
		public virtual string IM_REMARKS3 { get; set; }
		[JsonProperty("im_route_to")]
		[MaxLength(60)]
		public virtual string IM_ROUTE_TO { get; set; }
		[JsonProperty("im_company_category")]
		[MaxLength(15)]
		public virtual string IM_COMPANY_CATEGORY { get; set; }
		[JsonProperty("im_ind1")]
		[MaxLength(3)]
		public virtual string IM_IND1 { get; set; }
		[JsonProperty("im_resident_type")]
		[MaxLength(3)]
		public virtual string IM_RESIDENT_TYPE { get; set; }
		[JsonProperty("im_receipt_no")]
		[MaxLength(150)]
		public virtual string IM_RECEIPT_NO { get; set; }
		[JsonProperty("im_receipt_date")]
		public virtual System.DateTime? IM_RECEIPT_DATE { get; set; }
		[JsonProperty("im_section")]
		[MaxLength(30)]
		public virtual string IM_SECTION { get; set; }
		[JsonProperty("im_additional_1")]
		[MaxLength(150)]
		public virtual string IM_ADDITIONAL_1 { get; set; }
		[JsonProperty("im_gst_invoice")]
		[MaxLength(3)]
		public virtual string IM_GST_INVOICE { get; set; }
	}
	#endregion

	public class MapIssueInvoice
    {
		[JsonProperty("POM_BILLING_METHOD")]
		[Grid]
		public virtual string POM_BILLING_METHOD { get; set; }

		[JsonProperty("POM_PO_NO")]
		[Grid]
		public virtual string POM_PO_NO { get; set; }
		
		[JsonProperty("DO_Number")]
		[Grid]
		public virtual string DO_Number { get; set; }

		[JsonProperty("GRN_Number")]
		[Grid]
		public virtual string GRN_Number { get; set; }

		[JsonProperty("CM_COY_NAME")]
		[Grid]
		public virtual string CM_COY_NAME { get; set; }

		[JsonProperty("POM_CURRENCY_CODE")]
		[Grid]
		public virtual string POM_CURRENCY_CODE { get; set; }

		[JsonProperty("POM_B_COY_ID")]
		[Grid(IsVisible = false)]
		public virtual string POM_B_COY_ID { get; set; }

		[JsonProperty("POM_PO_INDEX")]
		[Grid(IsVisible = false)]
		public virtual string POM_PO_INDEX { get; set; }

		[JsonProperty("Amount")]
		[Grid]
		public virtual string Amount { get; set; }
    }

	public class MapInvoiceListing
    {
		[JsonProperty("IM_INVOICE_NO")]
		[Grid]
		public virtual string IM_INVOICE_NO { get; set; }

		[JsonProperty("IM_CREATED_ON")]
		[Grid(DatetimeFormat = "DD/MM/YYYY")]
		public virtual DateTime IM_CREATED_ON { get; set;  }

		[JsonProperty("POM_PO_NO")]
		[Grid]
		public virtual string POM_PO_NO { get; set; }

		[JsonProperty("CM_COY_NAME")]
		[Grid]
		public virtual string CM_COY_NAME { get; set; }

		[JsonProperty("POM_CURRENCY_CODE")]
		[Grid]
		public virtual string POM_CURRENCY_CODE { get; set;  }

		[JsonProperty("IM_INVOICE_TOTAL")]
		[Grid]
		public virtual string IM_INVOICE_TOTAL { get; set; }

		[JsonProperty("STATUS_DESC")]
		[Grid]
		public virtual string STATUS_DESC { get; set; }
	}

	public class MapUnInvoiceGRNLine
	{
		#region Displayed
		[JsonProperty("POD_PO_LINE")]
		[Grid(IsVisible = true)]
		public virtual string POD_PO_LINE { get; set; }

		[JsonProperty("POD_PRODUCT_DESC")]
		[Grid(IsVisible = true)]
		public virtual string POD_PRODUCT_DESC { get; set; }

		[JsonProperty("POD_UOM")]
		[Grid(IsVisible = true)]
		public virtual string POD_UOM { get; set; }

		[JsonProperty("QTY")]
		[Grid(IsVisible = true)]
		public virtual string QTY { get; set; }

		[JsonProperty("POD_UNIT_COST")]
		[Grid(IsVisible = true)]
		public virtual string POD_UNIT_COST { get; set; }

		[JsonProperty("Subtotal")]
		[Grid(IsVisible = true, DecimalPlaces = 2)]
		public virtual string Subtotal { get; set; }

		[JsonProperty("GST_RATE")]
		[Grid(IsVisible = true)]
		public virtual string GST_RATE { get; set; }

		[JsonProperty("SSTAmount")]
		[Grid(IsVisible = true, DecimalPlaces = 1)]
		public virtual string SSTAmount { get; set; }

		[JsonProperty("POD_GST")]
		[Grid(IsVisible = false)]
		public virtual string POD_GST { get; set; }

		[JsonProperty("POD_WARRANTY_TERMS")]
		[Grid(IsVisible = true)]
		public virtual string POD_WARRANTY_TERMS { get; set; }

		#endregion

		[JsonProperty("ASSET_CODE")]
		[Grid(IsVisible = false)]
		public virtual string ASSET_CODE { get; set; }

		[JsonProperty("POD_ACCT_INDEX")]
		[Grid(IsVisible = false)]
		public virtual string POD_ACCT_INDEX { get; set; }

		[JsonProperty("POD_B_CATEGORY_CODE")]
		[Grid(IsVisible = false)]
		public virtual string POD_B_CATEGORY_CODE { get; set; }
		[JsonProperty("POD_B_GL_CODE")]
		[Grid(IsVisible = false)]
		public virtual string POD_B_GL_CODE { get; set; }

		[JsonProperty("POD_B_ITEM_CODE")]
		[Grid(IsVisible = false)]
		public virtual string POD_B_ITEM_CODE { get; set; }
		[JsonProperty("POD_FUND_TYPE")]
		[Grid(IsVisible = false)]
		public virtual string POD_FUND_TYPE { get; set; }

		[JsonProperty("POD_GIFT")]
		[Grid(IsVisible = false)]
		public virtual string POD_GIFT { get; set; }

		[JsonProperty("POD_GST_INPUT_TAX_CODE")]
		[Grid(IsVisible = false)]
		public virtual string POD_GST_INPUT_TAX_CODE { get; set; }

		[JsonProperty("POD_ORDERED_QTY")]
		[Grid(IsVisible = false)]
		public virtual string POD_ORDERED_QTY { get; set; }
		[JsonProperty("POD_PERSON_CODE")]
		[Grid(IsVisible = false)]
		public virtual string POD_PERSON_CODE { get; set; }

		[JsonProperty("POD_PROJECT_CODE")]
		[Grid(IsVisible = false)]
		public virtual string POD_PROJECT_CODE { get; set; }
		[JsonProperty("POD_PR_INDEX")]
		[Grid(IsVisible = false)]
		public virtual string POD_PR_INDEX { get; set; }

		[JsonProperty("POD_PR_LINE")]
		[Grid(IsVisible = false)]
		public virtual string POD_PR_LINE { get; set; }
		[JsonProperty("POD_TAX_VALUE")]
		[Grid(IsVisible = false)]
		public virtual string POD_TAX_VALUE { get; set; }

		[JsonProperty("POM_PO_INDEX")]
		[Grid(IsVisible = false)]
		public virtual string POM_PO_INDEX { get; set; }
	}


}
