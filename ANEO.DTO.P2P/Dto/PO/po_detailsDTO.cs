using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.po_details
{
	#region PO_DETAILS
	[Table("po_details")]
	//[Audited]
	public class PO_DETAILS
	{
		[Key]
		[MaxLength(60), Required]
		public virtual string POD_COY_ID { get; set; }
		[Key]
		[MaxLength(150), Required]
		public virtual string POD_PO_NO { get; set; }
		[Key]
		[Required]
		public virtual long? POD_PO_LINE { get; set; }
		[MaxLength(60), Required]
		public virtual string POD_PRODUCT_CODE { get; set; }
		[MaxLength(300)]
		public virtual string POD_VENDOR_ITEM_CODE { get; set; }
		[MaxLength(1500)]
		public virtual string POD_PRODUCT_DESC { get; set; }
		[MaxLength(60)]
		public virtual string POD_UOM { get; set; }
		[Required]
		public virtual decimal? POD_ORDERED_QTY { get; set; }
		[Required]
		public virtual decimal? POD_RECEIVED_QTY { get; set; }
		[Required]
		public virtual decimal? POD_REJECTED_QTY { get; set; }
		[Required]
		public virtual decimal? POD_DELIVERED_QTY { get; set; }
		[Required]
		public virtual decimal? POD_CANCELLED_QTY { get; set; }

		public virtual decimal? POD_MIN_PACK_QTY { get; set; }

		public virtual decimal? POD_MIN_ORDER_QTY { get; set; }

		public virtual int? POD_ETD { get; set; }

		public virtual int? POD_WARRANTY_TERMS { get; set; }

		public virtual decimal? POD_UNIT_COST { get; set; }
		[MaxLength(1200)]
		public virtual string POD_REMARK { get; set; }

		public virtual decimal? POD_GST { get; set; }
		[MaxLength(30)]
		public virtual string POD_GST_RATE { get; set; }
		[MaxLength(60)]
		public virtual string POD_GST_INPUT_TAX_CODE { get; set; }

		public virtual decimal? POD_TAX_VALUE { get; set; }

		public virtual long? POD_PR_INDEX { get; set; }

		public virtual int? POD_PR_LINE { get; set; }

		public virtual long? POD_ACCT_INDEX { get; set; }
		[MaxLength(30)]
		public virtual string POD_PRODUCT_TYPE { get; set; }
		[MaxLength(750)]
		public virtual string POD_B_ITEM_CODE { get; set; }
		[MaxLength(6)]
		public virtual string POD_SOURCE { get; set; }
		[MaxLength(60)]
		public virtual string POD_D_ADDR_CODE { get; set; }
		[MaxLength(150)]
		public virtual string POD_D_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string POD_D_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string POD_D_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string POD_D_POSTCODE { get; set; }
		[MaxLength(60)]
		public virtual string POD_D_CITY { get; set; }
		[MaxLength(60)]
		public virtual string POD_D_STATE { get; set; }
		[MaxLength(60)]
		public virtual string POD_D_COUNTRY { get; set; }
		[MaxLength(300)]
		public virtual string POD_B_CATEGORY_CODE { get; set; }
		[MaxLength(300)]
		public virtual string POD_B_GL_CODE { get; set; }

		public virtual long? POD_CD_GROUP_INDEX { get; set; }
		[MaxLength(30)]
		public virtual string POD_RFQ_ITEM_LINE { get; set; }
		[MaxLength(90)]
		public virtual string POD_ASSET_GROUP { get; set; }
		[MaxLength(30)]
		public virtual string POD_ASSET_NO { get; set; }

		public virtual decimal? POD_CURR_QTY { get; set; }

		public virtual decimal? POD_PREV1_QTY { get; set; }

		public virtual decimal? POD_PREV2_QTY { get; set; }

		public virtual decimal? POD_PREV3_QTY { get; set; }

		public virtual decimal? POD_PREV_AVG { get; set; }

		public virtual decimal? POD_NEXT1_QTY { get; set; }

		public virtual decimal? POD_NEXT2_QTY { get; set; }

		public virtual decimal? POD_NEXT3_QTY { get; set; }
		[MaxLength(150)]
		public virtual string POD_PUR_SPEC_NO { get; set; }
		[MaxLength(768)]
		public virtual string POD_SPEC1 { get; set; }
		[MaxLength(768)]
		public virtual string POD_SPEC2 { get; set; }
		[MaxLength(768)]
		public virtual string POD_SPEC3 { get; set; }

		public virtual int? POD_LEAD_TIME { get; set; }
		[MaxLength(150)]
		public virtual string POD_MANUFACTURER { get; set; }
		[MaxLength(6)]
		public virtual string POD_ITEM_TYPE { get; set; }
		[MaxLength(3)]
		public virtual string POD_OVERSEA { get; set; }

		public virtual decimal? POD_STOCK_ON_HAND_QTY { get; set; }

		public virtual decimal? POD_PO_BALANCE_QTY { get; set; }

		public virtual decimal? POD_PO_IN_PROGRESS_QTY { get; set; }
		[MaxLength(30)]
		public virtual string POD_PACKING_TYPE { get; set; }

		public virtual decimal? POD_PACKING_QTY { get; set; }
		[MaxLength(3)]
		public virtual string POD_GIFT { get; set; }
		[MaxLength(300)]
		public virtual string POD_FUND_TYPE { get; set; }
		[MaxLength(300)]
		public virtual string POD_PERSON_CODE { get; set; }
		[MaxLength(300)]
		public virtual string POD_PROJECT_CODE { get; set; }
		[MaxLength(3)]
		public virtual string POD_WITHHOLDING_OPT { get; set; }

		public virtual int? POD_WITHHOLDING_TAX { get; set; }
		[MaxLength(3000)]
		public virtual string POD_WITHHOLDING_REMARKS { get; set; }
	}
	#endregion
}