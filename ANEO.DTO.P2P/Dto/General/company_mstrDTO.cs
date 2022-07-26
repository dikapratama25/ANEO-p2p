using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.company_mstr
{
	#region COMPANY_MSTR
	[Table("company_mstr")]
	//[Audited]
	public class COMPANY_MSTR
	{
		[Key]
		[MaxLength(60), Required]
		public virtual string CM_COY_ID { get; set; }
		[MaxLength(300), Required]
		public virtual string CM_COY_NAME { get; set; }
		[MaxLength(765)]
		public virtual string CM_COY_LONG_NAME { get; set; }
		[MaxLength(90)]
		public virtual string CM_COY_TYPE { get; set; }
		[MaxLength(60)]
		public virtual string CM_PARENT_COY_ID { get; set; }
		[MaxLength(90)]
		public virtual string CM_ACCT_NO { get; set; }
		[MaxLength(300)]
		public virtual string CM_BANK { get; set; }
		[MaxLength(90)]
		public virtual string CM_BRANCH { get; set; }
		[MaxLength(765)]
		public virtual string CM_ADDR_LINE1 { get; set; }
		[MaxLength(765)]
		public virtual string CM_ADDR_LINE2 { get; set; }
		[MaxLength(765)]
		public virtual string CM_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string CM_POSTCODE { get; set; }
		[MaxLength(150)]
		public virtual string CM_CITY { get; set; }
		[MaxLength(30)]
		public virtual string CM_STATE { get; set; }
		[MaxLength(30)]
		public virtual string CM_COUNTRY { get; set; }
		[MaxLength(150)]
		public virtual string CM_PHONE { get; set; }
		[MaxLength(150)]
		public virtual string CM_FAX { get; set; }
		[MaxLength(150)]
		public virtual string CM_EMAIL { get; set; }
		[MaxLength(150)]
		public virtual string CM_COY_LOGO { get; set; }
		[MaxLength(150)]
		public virtual string CM_WEBSITE { get; set; }
		[MaxLength(150)]
		public virtual string CM_BUSINESS_REG_NO { get; set; }
		[MaxLength(12)]
		public virtual string CM_YEAR_REG { get; set; }
		[MaxLength(150)]
		public virtual string CM_TAX_REG_NO { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CM_LAST_DATE { get; set; }
		[MaxLength(30)]
		public virtual string CM_PAYMENT_TERM { get; set; }
		[MaxLength(30)]
		public virtual string CM_PAYMENT_METHOD { get; set; }
		[MaxLength(300)]
		public virtual string CM_ACTUAL_TERMSANDCONDFILE { get; set; }
		[MaxLength(300)]
		public virtual string CM_HUB_TERMSANDCONDFILE { get; set; }

		public virtual int? CM_PWD_DURATION { get; set; }
		[MaxLength(3)]
		public virtual string CM_TAX_CALC_BY { get; set; }
		[MaxLength(30)]
		public virtual string CM_CURRENCY_CODE { get; set; }
		[MaxLength(3), Required]
		public virtual string CM_BCM_SET { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CM_BUDGET_FROM_DATE { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CM_BUDGET_TO_DATE { get; set; }
		[MaxLength(3)]
		public virtual string CM_RFQ_OPTION { get; set; }
		[MaxLength(150)]
		public virtual string CM_LICENCE_PACKAGE { get; set; }

		public virtual int? CM_LICENSE_USERS { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CM_SUB_START_DT { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CM_SUB_END_DT { get; set; }

		public virtual int? CM_LICENSE_PRODUCTS { get; set; }
		[MaxLength(3), Required]
		public virtual string CM_FINDEPT_MODE { get; set; }
		[MaxLength(3), Required]
		public virtual string CM_PRIV_LABELING { get; set; }
		[MaxLength(60)]
		public virtual string CM_SKINS_ID { get; set; }
		[MaxLength(3), Required]
		public virtual string CM_TRAINING { get; set; }
		[MaxLength(3), Required]
		public virtual string CM_STATUS { get; set; }
		[MaxLength(3), Required]
		public virtual string CM_DELETED { get; set; }
		[MaxLength(60)]
		public virtual string CM_MOD_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CM_MOD_DT { get; set; }
		[MaxLength(60)]
		public virtual string CM_ENT_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CM_ENT_DT { get; set; }

		public virtual int? CM_SKU { get; set; }

		public virtual int? CM_TRANS_NO { get; set; }
		[MaxLength(300)]
		public virtual string CM_CONTACT { get; set; }

		public virtual int? CM_REPORT_USERS { get; set; }
		[MaxLength(3)]
		public virtual string CM_INV_APPR { get; set; }
		[MaxLength(3)]
		public virtual string CM_MULTI_PO { get; set; }
		[MaxLength(3)]
		public virtual string CM_BA_CANCEL { get; set; }
		[MaxLength(30)]
		public virtual string CM_PAIDCAPITAL_CURRENCY_CODE { get; set; }

		public virtual decimal? CM_PAIDCAPITAL { get; set; }
		[MaxLength(30)]
		public virtual string CM_OWNERSHIP1 { get; set; }
		[MaxLength(150)]
		public virtual string CM_OWNERSHIP2 { get; set; }
		[MaxLength(30)]
		public virtual string CM_BUSINESS_NATURE { get; set; }
		[MaxLength(60)]
		public virtual string CM_COMMODITY { get; set; }
		[MaxLength(150)]
		public virtual string CM_REGORGCODE { get; set; }
		[MaxLength(300)]
		public virtual string CM_BANK_NAME { get; set; }
		[MaxLength(3)]
		public virtual string CM_CONTR_PR_SETTING { get; set; }
		[MaxLength(60)]
		public virtual string CM_CONTR_PR_PO_OWNER_ID { get; set; }
		[MaxLength(6)]
		public virtual string CM_NCONTR_PR_SETTING { get; set; }
		[MaxLength(3)]
		public virtual string CM_GRN_CONTROL { get; set; }
		[MaxLength(3)]
		public virtual string CM_FFPO_CONTROL { get; set; }
		[MaxLength(3)]
		public virtual string CM_DISPLAY_ACCT { get; set; }
		[MaxLength(15)]
		public virtual string CM_ACTIVATE_STOCK { get; set; }
		[MaxLength(3)]
		public virtual string CM_URGENT_STOCK_EMAIL { get; set; }
		[MaxLength(3)]
		public virtual string CM_REJECT_STOCK_EMAIL { get; set; }
		[MaxLength(3)]
		public virtual string CM_SAFETY_STOCK_EMAIL { get; set; }
		[MaxLength(3)]
		public virtual string CM_REORDER_STOCK_EMAIL { get; set; }
		[MaxLength(3)]
		public virtual string CM_MAXIMUM_STOCK_EMAIL { get; set; }
		[MaxLength(3)]
		public virtual string CM_LOCATION_STOCK { get; set; }

		public virtual decimal? CM_SMART_PAY { get; set; }
		[MaxLength(3)]
		public virtual string CM_RESIDENT { get; set; }
	}
	#endregion
}
