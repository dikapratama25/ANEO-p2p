using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.invoice_mstr
{
	#region INVOICE_MSTR
	[Table("invoice_mstr")]
	//[Audited]
	public class INVOICE_MSTR
	{
		[Key]
		[Required]
		public virtual long? IM_INVOICE_INDEX { get; set; }
		[MaxLength(150)]
		public virtual string IM_INVOICE_NO { get; set; }
		[MaxLength(60)]
		public virtual string IM_S_COY_ID { get; set; }
		[MaxLength(300)]
		public virtual string IM_S_COY_NAME { get; set; }

		public virtual long? IM_PO_INDEX { get; set; }
		[MaxLength(60)]
		public virtual string IM_B_COY_ID { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_PAYMENT_DATE { get; set; }
		[MaxLength(3000)]
		public virtual string IM_REMARK { get; set; }
		[MaxLength(60)]
		public virtual string IM_CREATED_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_CREATED_ON { get; set; }

		public virtual int? IM_INVOICE_STATUS { get; set; }
		[MaxLength(120)]
		public virtual string IM_PAYMENT_NO { get; set; }
		[MaxLength(450)]
		public virtual string IM_YOUR_REF { get; set; }
		[MaxLength(150)]
		public virtual string IM_OUR_REF { get; set; }
		[MaxLength(90)]
		public virtual string IM_INVOICE_PREFIX { get; set; }
		[MaxLength(60)]
		public virtual string IM_SUBMITTEDBY_FO { get; set; }

		public virtual double? IM_EXCHANGE_RATE { get; set; }
		[MaxLength(3000)]
		public virtual string IM_FINANCE_REMARKS { get; set; }
		[MaxLength(3)]
		public virtual string IM_PRINTED { get; set; }

		public virtual int? IM_FOLDER { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_FM_APPROVED_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_DOWNLOADED_DATE { get; set; }
		[MaxLength(3)]
		public virtual string IM_EXTERNAL_IND { get; set; }
		[MaxLength(150)]
		public virtual string IM_REFERENCE_NO { get; set; }

		public virtual decimal? IM_INVOICE_TOTAL { get; set; }

		public virtual decimal? IM_INVOICE_EXCL_GST { get; set; }

		public virtual decimal? IM_INVOICE_GST { get; set; }
		[MaxLength(30)]
		public virtual string IM_PAYMENT_TERM { get; set; }
		[MaxLength(60)]
		public virtual string IM_STATUS_CHANGED_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_STATUS_CHANGED_ON { get; set; }

		public virtual decimal? IM_SHIP_AMT { get; set; }
		[MaxLength(18)]
		public virtual string IM_INVOICE_TYPE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_DOC_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_SUBMIT_DATE { get; set; }
		[MaxLength(90)]
		public virtual string IM_IPP_PO { get; set; }
		[MaxLength(765)]
		public virtual string IM_ADDR_LINE1 { get; set; }
		[MaxLength(765)]
		public virtual string IM_ADDR_LINE2 { get; set; }
		[MaxLength(765)]
		public virtual string IM_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string IM_POSTCODE { get; set; }
		[MaxLength(150)]
		public virtual string IM_CITY { get; set; }
		[MaxLength(30)]
		public virtual string IM_STATE { get; set; }
		[MaxLength(30)]
		public virtual string IM_COUNTRY { get; set; }
		[MaxLength(3000)]
		public virtual string IM_REMARKS { get; set; }
		[MaxLength(3000)]
		public virtual string IM_LATE_REASON { get; set; }
		[MaxLength(30)]
		public virtual string IM_CURRENCY_CODE { get; set; }

		public virtual int? IM_WITHHOLDING_TAX { get; set; }
		[MaxLength(3)]
		public virtual string IM_WITHHOLDING_OPT { get; set; }
		[MaxLength(3000)]
		public virtual string IM_WITHHOLDING_REMARKS { get; set; }

		public virtual decimal? IM_EXCHG_RATE { get; set; }

		public virtual long? IM_PYMT_TYPE_INDEX { get; set; }

		public virtual long? IM_DEPT_INDEX { get; set; }
		[MaxLength(3)]
		public virtual string IM_PRINTED_IND { get; set; }
		[MaxLength(60)]
		public virtual string IM_CHEQUE_NO { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_DUE_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_PRCS_SENT { get; set; }
		[MaxLength(60)]
		public virtual string IM_PRCS_SENT_ID { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_PRCS_SENT_UPD_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_PRCS_RECV { get; set; }
		[MaxLength(60)]
		public virtual string IM_PRCS_RECV_ID { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_PRCS_RECV_UPD_DATE { get; set; }
		[MaxLength(90)]
		public virtual string im_bank_code { get; set; }
		[MaxLength(90)]
		public virtual string im_bank_acct { get; set; }
		[MaxLength(150)]
		public virtual string IM_REMARKS1 { get; set; }
		[MaxLength(150)]
		public virtual string IM_REMARKS2 { get; set; }
		[MaxLength(3000)]
		public virtual string IM_REMARKS3 { get; set; }
		[MaxLength(60)]
		public virtual string IM_ROUTE_TO { get; set; }
		[MaxLength(15)]
		public virtual string IM_COMPANY_CATEGORY { get; set; }
		[MaxLength(3)]
		public virtual string IM_IND1 { get; set; }
		[MaxLength(3)]
		public virtual string IM_RESIDENT_TYPE { get; set; }
		[MaxLength(150)]
		public virtual string IM_RECEIPT_NO { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? IM_RECEIPT_DATE { get; set; }
		[MaxLength(30)]
		public virtual string IM_SECTION { get; set; }
		[MaxLength(150)]
		public virtual string IM_ADDITIONAL_1 { get; set; }
		[MaxLength(3)]
		public virtual string IM_GST_INVOICE { get; set; }
	}
	#endregion
}