using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.product_mstr
{
	#region PRODUCT_MSTR
	[Table("product_mstr")]
	//[Audited]
	public class PRODUCT_MSTR
	{
		[Key]
		[Required]
		public virtual long? PM_PRODUCT_INDEX { get; set; }
		[MaxLength(60), Required]
		public virtual string PM_S_COY_ID { get; set; }
		[MaxLength(60), Required]
		public virtual string PM_PRODUCT_CODE { get; set; }
		[MaxLength(60)]
		public virtual string PM_CATEGORY_NAME { get; set; }
		[MaxLength(300)]
		public virtual string PM_VENDOR_ITEM_CODE { get; set; }
		[MaxLength(1500)]
		public virtual string PM_PRODUCT_DESC { get; set; }
		[MaxLength(60)]
		public virtual string PM_UOM { get; set; }

		public virtual decimal? PM_UNIT_COST { get; set; }
		[MaxLength(30)]
		public virtual string PM_GST_CODE { get; set; }
		[MaxLength(15)]
		public virtual string PM_TAX_PERC { get; set; }
		[MaxLength(150)]
		public virtual string PM_PRODUCT_IMAGE { get; set; }
		[MaxLength(30)]
		public virtual string PM_CURRENCY_CODE { get; set; }
		[MaxLength(768)]
		public virtual string PM_PRODUCT_BRAND { get; set; }
		[MaxLength(768)]
		public virtual string PM_PRODUCT_MODEL { get; set; }
		[MaxLength(30)]
		public virtual string PM_PRODUCT_TYPE { get; set; }
		[MaxLength(60)]
		public virtual string PM_MOD_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PM_MOD_DT { get; set; }
		[MaxLength(60)]
		public virtual string PM_ENT_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PM_ENT_DT { get; set; }
		[MaxLength(3)]
		public virtual string PM_DELETED { get; set; }
		[MaxLength(768)]
		public virtual string PM_REF_NO { get; set; }
		[MaxLength(12000)]
		public virtual string PM_LONG_DESC { get; set; }
		[MaxLength(90)]
		public virtual string PM_ACCT_CODE { get; set; }

		public virtual decimal? PM_SAFE_QTY { get; set; }

		public virtual decimal? PM_ORD_MIN_QTY { get; set; }

		public virtual decimal? PM_ORD_MAX_QTY { get; set; }
		[MaxLength(150)]
		public virtual string PM_DRAW_NO { get; set; }
		[MaxLength(150)]
		public virtual string PM_VERS_NO { get; set; }
		[MaxLength(150)]
		public virtual string PM_GROSS_WEIGHT { get; set; }
		[MaxLength(150)]
		public virtual string PM_NET_WEIGHT { get; set; }
		[MaxLength(150)]
		public virtual string PM_LENGHT { get; set; }
		[MaxLength(150)]
		public virtual string PM_WIDTH { get; set; }
		[MaxLength(150)]
		public virtual string PM_HEIGHT { get; set; }
		[MaxLength(150)]
		public virtual string PM_VOLUME { get; set; }
		[MaxLength(768)]
		public virtual string PM_COLOR_INFO { get; set; }
		[MaxLength(768)]
		public virtual string PM_HSC_CODE { get; set; }
		[MaxLength(768)]
		public virtual string PM_REC_SPEC { get; set; }
		[MaxLength(768)]
		public virtual string PM_PACKING_REQ { get; set; }
		[MaxLength(9000)]
		public virtual string PM_REMARKS { get; set; }
		[MaxLength(3)]
		public virtual string PM_PRODUCT_FOR { get; set; }
		[MaxLength(60)]
		public virtual string PM_PREFER_S_COY_ID { get; set; }
		[MaxLength(60)]
		public virtual string PM_1ST_S_COY_ID { get; set; }
		[MaxLength(60)]
		public virtual string PM_2ND_S_COY_ID { get; set; }
		[MaxLength(60)]
		public virtual string PM_3RD_S_COY_ID { get; set; }

		public virtual decimal? PM_LAST_TXN_PRICE { get; set; }
		[MaxLength(30)]
		public virtual string PM_LAST_TXN_PRICE_CURR { get; set; }

		public virtual decimal? PM_LAST_TXN_TAX { get; set; }
		[MaxLength(60)]
		public virtual string PM_LAST_TXN_S_COY_ID { get; set; }

		public virtual int? PM_TAX_ID { get; set; }

		public virtual int? PM_PREFER_S_COY_ID_TAX_ID { get; set; }

		public virtual int? PM_1ST_S_COY_ID_TAX_ID { get; set; }

		public virtual int? PM_2ND_S_COY_ID_TAX_ID { get; set; }

		public virtual int? PM_3RD_S_COY_ID_TAX_ID { get; set; }
		[MaxLength(1200)]
		public virtual string PM_REMARK { get; set; }
		[MaxLength(6), Required]
		public virtual string PM_ITEM_TYPE { get; set; }
		[MaxLength(3), Required]
		public virtual string PM_IQC_IND { get; set; }

		public virtual decimal? PM_MAX_INV_QTY { get; set; }
		[MaxLength(150)]
		public virtual string PM_MANUFACTURER { get; set; }
		[MaxLength(300)]
		public virtual string PM_CAT_CODE { get; set; }

		public virtual decimal? PM_REORDER_QTY { get; set; }

		public virtual decimal? PM_BUDGET_PRICE { get; set; }

		public virtual decimal? PM_PREVIOUS_BUDGET_PRICE { get; set; }
		[MaxLength(15)]
		public virtual string PM_IQC_TYPE { get; set; }
		[MaxLength(150)]
		public virtual string PM_EOQ { get; set; }
		[MaxLength(150)]
		public virtual string PM_RATIO { get; set; }
		[MaxLength(3)]
		public virtual string PM_OVERSEA { get; set; }
		[MaxLength(3)]
		public virtual string PM_PARTIAL_CD { get; set; }
		[MaxLength(768)]
		public virtual string PM_SPEC1 { get; set; }
		[MaxLength(768)]
		public virtual string PM_SPEC2 { get; set; }
		[MaxLength(768)]
		public virtual string PM_SPEC3 { get; set; }
		[MaxLength(30)]
		public virtual string PM_PACKING_TYPE { get; set; }

		public virtual decimal? PM_PACKING_QTY { get; set; }
		[MaxLength(150)]
		public virtual string PM_MANUFACTURER2 { get; set; }
		[MaxLength(150)]
		public virtual string PM_MANUFACTURER3 { get; set; }
		[MaxLength(150)]
		public virtual string PM_SECTION { get; set; }
		[MaxLength(150)]
		public virtual string PM_LOCATION { get; set; }
		[MaxLength(60)]
		public virtual string PM_NEW_ITEM_CODE { get; set; }

		[MaxLength(60)]
		public virtual string CT_NAME { get; set; }
	}
	#endregion
}
