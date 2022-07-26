using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.pr_mstr
{
	#region PR_MSTR
	[Table("pr_mstr")]
	//[Audited]
	public class PR_MSTR
	{
		[Key]
		[Required]
		public virtual long? PRM_PR_Index { get; set; }
		[MaxLength(150), Required]
		public virtual string PRM_PR_NO { get; set; }
		[MaxLength(60), Required]
		public virtual string PRM_COY_ID { get; set; }
		[MaxLength(150)]
		public virtual string PRM_REQ_NAME { get; set; }
		[MaxLength(60)]
		public virtual string PRM_REQ_PHONE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PRM_PR_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PRM_CREATED_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PRM_SUBMIT_DATE { get; set; }
		[MaxLength(60)]
		public virtual string PRM_STATUS_CHANGED_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PRM_STATUS_CHANGED_ON { get; set; }
		[MaxLength(60)]
		public virtual string PRM_BUYER_ID { get; set; }
		[MaxLength(60)]
		public virtual string PRM_S_COY_ID { get; set; }
		[MaxLength(150)]
		public virtual string PRM_S_ATTN { get; set; }
		[MaxLength(300)]
		public virtual string PRM_S_COY_NAME { get; set; }
		[MaxLength(150)]
		public virtual string PRM_S_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string PRM_S_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string PRM_S_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string PRM_S_POSTCODE { get; set; }
		[MaxLength(90)]
		public virtual string PRM_S_CITY { get; set; }
		[MaxLength(60)]
		public virtual string PRM_S_STATE { get; set; }
		[MaxLength(60)]
		public virtual string PRM_S_COUNTRY { get; set; }
		[MaxLength(60)]
		public virtual string PRM_S_PHONE { get; set; }
		[MaxLength(60)]
		public virtual string PRM_S_FAX { get; set; }
		[MaxLength(180)]
		public virtual string PRM_S_EMAIL { get; set; }
		[MaxLength(60)]
		public virtual string PRM_FREIGHT_TERMS { get; set; }
		[MaxLength(30)]
		public virtual string PRM_PAYMENT_TYPE { get; set; }
		[MaxLength(30)]
		public virtual string PRM_SHIPMENT_TERM { get; set; }
		[MaxLength(30)]
		public virtual string PRM_SHIPMENT_MODE { get; set; }
		[MaxLength(30)]
		public virtual string PRM_CURRENCY_CODE { get; set; }

		public virtual decimal? PRM_GST { get; set; }

		public virtual double? PRM_EXCHANGE_RATE { get; set; }
		[MaxLength(30)]
		public virtual string PRM_PAYMENT_TERM { get; set; }
		[MaxLength(90)]
		public virtual string PRM_SHIP_VIA { get; set; }
		[MaxLength(3000)]
		public virtual string PRM_INTERNAL_REMARK { get; set; }
		[MaxLength(3000)]
		public virtual string PRM_EXTERNAL_REMARK { get; set; }
		[Required]
		public virtual int? PRM_PR_STATUS { get; set; }

		public virtual long? PRM_PO_INDEX { get; set; }
		[MaxLength(3)]
		public virtual string PRM_ARCHIVE_IND { get; set; }
		[MaxLength(3)]
		public virtual string PRM_PRINT_CUSTOM_FIELDS { get; set; }
		[MaxLength(3)]
		public virtual string PRM_PRINT_REMARK { get; set; }
		[MaxLength(150), Required]
		public virtual string PRM_PR_PREFIX { get; set; }
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_CODE { get; set; }
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string PRM_B_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string PRM_B_POSTCODE { get; set; }
		[MaxLength(60)]
		public virtual string PRM_B_STATE { get; set; }
		[MaxLength(90)]
		public virtual string PRM_B_CITY { get; set; }
		[MaxLength(60)]
		public virtual string PRM_B_COUNTRY { get; set; }

		public virtual long? PRM_RFQ_INDEX { get; set; }

		public virtual long? PRM_DEPT_INDEX { get; set; }
		[MaxLength(150)]
		public virtual string PRM_DUP_FROM { get; set; }
		[MaxLength(3)]
		public virtual string PRM_EXTERNAL_IND { get; set; }
		[MaxLength(150)]
		public virtual string PRM_REFERENCE_NO { get; set; }
		[MaxLength(60)]
		public virtual string PRM_CONSOLIDATOR { get; set; }

		public virtual decimal? PRM_PR_COST { get; set; }
		[MaxLength(150)]
		public virtual string PRM_QUOTATION_NO { get; set; }
		[MaxLength(6)]
		public virtual string PRM_PR_TYPE { get; set; }
		[MaxLength(3)]
		public virtual string PRM_URGENT { get; set; }
	}
	#endregion
}
