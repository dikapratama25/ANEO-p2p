using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ANEO.DTO.P2P.Master.pr_details
{
	#region PR_DETAILS
	[Table("pr_details")]
	//[Audited]
	public class PR_DETAILS
	{
		[Key]
		[MaxLength(150), Required]
		public virtual string PRD_PR_NO { get; set; }
		[Key]
		[MaxLength(60), Required]
		public virtual string PRD_COY_ID { get; set; }
		[Key]
		[Required]
		public virtual int? PRD_PR_LINE { get; set; }
		[Required]
		public virtual long? PRD_PR_LINE_INDEX { get; set; }
		[MaxLength(60)]
		public virtual string PRD_PRODUCT_CODE { get; set; }
		[MaxLength(300)]
		public virtual string PRD_VENDOR_ITEM_CODE { get; set; }
		[MaxLength(1500)]
		public virtual string PRD_PRODUCT_DESC { get; set; }
		[MaxLength(60)]
		public virtual string PRD_UOM { get; set; }

		public virtual decimal? PRD_ORDERED_QTY { get; set; }

		public virtual decimal? PRD_UNIT_COST { get; set; }

		public virtual int? PRD_ETD { get; set; }

		public virtual int? PRD_WARRANTY_TERMS { get; set; }

		public virtual decimal? PRD_MIN_ORDER_QTY { get; set; }

		public virtual decimal? PRD_MIN_PACK_QTY { get; set; }
		[MaxLength(1200)]
		public virtual string PRD_REMARK { get; set; }

		public virtual decimal? PRD_GST { get; set; }
		[MaxLength(30)]
		public virtual string PRD_GST_RATE { get; set; }
		[MaxLength(60)]
		public virtual string PRD_GST_INPUT_TAX_CODE { get; set; }
		[MaxLength(60)]
		public virtual string PRD_D_ADDR_CODE { get; set; }
		[MaxLength(150)]
		public virtual string PRD_D_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string PRD_D_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string PRD_D_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string PRD_D_POSTCODE { get; set; }
		[MaxLength(60)]
		public virtual string PRD_D_CITY { get; set; }
		[MaxLength(60)]
		public virtual string PRD_D_STATE { get; set; }
		[MaxLength(60)]
		public virtual string PRD_D_COUNTRY { get; set; }

		public virtual long? PRD_ACCT_INDEX { get; set; }
		[MaxLength(30)]
		public virtual string PRD_PRODUCT_TYPE { get; set; }
		[MaxLength(750)]
		public virtual string PRD_B_ITEM_CODE { get; set; }
		[MaxLength(6)]
		public virtual string PRD_SOURCE { get; set; }

		public virtual long? PRD_CD_GROUP_INDEX { get; set; }

		public virtual decimal? PRD_RFQ_QTY { get; set; }

		public virtual decimal? PRD_QTY_TOLERANCE { get; set; }
		[MaxLength(300)]
		public virtual string PRD_B_CATEGORY_CODE { get; set; }
		[MaxLength(300)]
		public virtual string PRD_B_GL_CODE { get; set; }
		[MaxLength(60)]
		public virtual string PRD_S_COY_ID { get; set; }
		[MaxLength(75)]
		public virtual string PRD_B_TAX_CODE { get; set; }
		[MaxLength(30)]
		public virtual string PRD_CURRENCY_CODE { get; set; }

		public virtual int? PRD_CT_ID { get; set; }
		[MaxLength(12)]
		public virtual string PRD_CONVERT_TO_IND { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PRD_CONVERT_TO_DATE { get; set; }
		[MaxLength(150)]
		public virtual string PRD_CONVERT_TO_DOC { get; set; }
		[MaxLength(60)]
		public virtual string PRD_CONVERT_BY_ID { get; set; }
		[MaxLength(90)]
		public virtual string PRD_ASSET_GROUP { get; set; }
		[MaxLength(30)]
		public virtual string PRD_ASSET_NO { get; set; }
		[MaxLength(30)]
		public virtual string PRD_DEL_CODE { get; set; }
		[MaxLength(6)]
		public virtual string PRD_ITEM_TYPE { get; set; }

		public virtual int? PRD_LEAD_TIME { get; set; }
		[MaxLength(3)]
		public virtual string PRD_OVERSEA { get; set; }
		[MaxLength(3)]
		public virtual string PRD_GIFT { get; set; }
		[MaxLength(300)]
		public virtual string PRD_FUND_TYPE { get; set; }
		[MaxLength(300)]
		public virtual string PRD_PERSON_CODE { get; set; }
		[MaxLength(300)]
		public virtual string PRD_PROJECT_CODE { get; set; }
	}
	#endregion
}
