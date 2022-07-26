using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.po_mstr
{
	#region PO_MSTR
	[Table("po_mstr")]
	//[Audited]
	public class PO_MSTR
	{
		[Key]
		[Required]
		public virtual long? POM_PO_INDEX { get; set; }
		[MaxLength(150), Required]
		public virtual string POM_PO_NO { get; set; }
		[MaxLength(60), Required]
		public virtual string POM_B_COY_ID { get; set; }
		[MaxLength(60)]
		public virtual string POM_BUYER_ID { get; set; }
		[MaxLength(180)]
		public virtual string POM_BUYER_NAME { get; set; }
		[MaxLength(150)]
		public virtual string POM_BUYER_PHONE { get; set; }
		[MaxLength(150)]
		public virtual string POM_BUYER_FAX { get; set; }
		[MaxLength(60)]
		public virtual string POM_S_COY_ID { get; set; }
		[MaxLength(300)]
		public virtual string POM_S_COY_NAME { get; set; }
		[MaxLength(150)]
		public virtual string POM_S_ATTN { get; set; }
		[MaxLength(3000)]
		public virtual string POM_S_REMARK { get; set; }
		[MaxLength(150)]
		public virtual string POM_S_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string POM_S_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string POM_S_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string POM_S_POSTCODE { get; set; }
		[MaxLength(90)]
		public virtual string POM_S_CITY { get; set; }
		[MaxLength(60)]
		public virtual string POM_S_STATE { get; set; }
		[MaxLength(60)]
		public virtual string POM_S_COUNTRY { get; set; }
		[MaxLength(150)]
		public virtual string POM_S_PHONE { get; set; }
		[MaxLength(150)]
		public virtual string POM_S_FAX { get; set; }
		[MaxLength(180)]
		public virtual string POM_S_EMAIL { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? POM_PO_DATE { get; set; }
		[MaxLength(60)]
		public virtual string POM_FREIGHT_TERMS { get; set; }
		[MaxLength(90)]
		public virtual string POM_PAYMENT_TERM { get; set; }
		[MaxLength(90)]
		public virtual string POM_PAYMENT_METHOD { get; set; }
		[MaxLength(90)]
		public virtual string POM_SHIPMENT_MODE { get; set; }
		[MaxLength(90)]
		public virtual string POM_SHIPMENT_TERM { get; set; }
		[MaxLength(30)]
		public virtual string POM_CURRENCY_CODE { get; set; }

		public virtual double? POM_EXCHANGE_RATE { get; set; }
		[MaxLength(60)]
		public virtual string POM_PAYMENT_TERM_CODE { get; set; }
		[MaxLength(90)]
		public virtual string POM_SHIP_VIA { get; set; }

		public virtual int? POM_PO_STATUS { get; set; }
		[MaxLength(60)]
		public virtual string POM_STATUS_CHANGED_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? POM_STATUS_CHANGED_ON { get; set; }
		[MaxLength(3000)]
		public virtual string POM_EXTERNAL_REMARK { get; set; }
		[MaxLength(150)]
		public virtual string POM_CREATED_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? POM_CREATED_DATE { get; set; }

		public virtual decimal? POM_PO_COST { get; set; }
		[MaxLength(15)]
		public virtual string POM_BILLING_METHOD { get; set; }
		[MaxLength(90)]
		public virtual string POM_PO_PREFIX { get; set; }
		[MaxLength(60)]
		public virtual string POM_B_ADDR_CODE { get; set; }
		[MaxLength(150)]
		public virtual string POM_B_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string POM_B_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string POM_B_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string POM_B_POSTCODE { get; set; }
		[MaxLength(90)]
		public virtual string POM_B_CITY { get; set; }
		[MaxLength(60)]
		public virtual string POM_B_STATE { get; set; }
		[MaxLength(60)]
		public virtual string POM_B_COUNTRY { get; set; }

		public virtual int? POM_FULFILMENT { get; set; }

		public virtual int? POM_DEPT_INDEX { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? POM_ACCEPTED_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? POM_DOWNLOADED_DATE { get; set; }
		[MaxLength(3)]
		public virtual string POM_ARCHIVE_IND { get; set; }
		[MaxLength(150)]
		public virtual string POM_TERMANDCOND { get; set; }
		[MaxLength(150)]
		public virtual string POM_REFERENCE_NO { get; set; }
		[MaxLength(3)]
		public virtual string POM_EXTERNAL_IND { get; set; }
		[MaxLength(3000)]
		public virtual string POM_INTERNAL_REMARK { get; set; }
		[MaxLength(3)]
		public virtual string POM_PRINT_CUSTOM_FIELDS { get; set; }
		[MaxLength(3)]
		public virtual string POM_PRINT_REMARK { get; set; }

		public virtual long? POM_RFQ_INDEX { get; set; }
		[MaxLength(150)]
		public virtual string POM_QUOTATION_NO { get; set; }
		[MaxLength(150)]
		public virtual string POM_DUP_FROM { get; set; }

		public virtual decimal? POM_SHIP_AMT { get; set; }

		public virtual decimal? POM_ACC_SHIP_AMT { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? POM_SUBMIT_DATE { get; set; }
		[MaxLength(3)]
		public virtual string POM_URGENT { get; set; }
		[MaxLength(3)]
		public virtual string POM_PO_TYPE { get; set; }
		[MaxLength(60)]
		public virtual string POM_DEL_CODE { get; set; }
		[MaxLength(300)]
		public virtual string POM_VENDOR_CODE { get; set; }
	}
	#endregion
}
