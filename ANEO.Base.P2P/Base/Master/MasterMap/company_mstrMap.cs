using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.company_mstr
{
	#region COMPANY_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.company_mstr.COMPANY_MSTR))]
	public class MapCOMPANY_MSTR : BaseMapId
	{
		[JsonProperty("cm_coy_id")]
		[MaxLength(60), Required]
		public virtual string CM_COY_ID { get; set; }
		[JsonProperty("cm_coy_name")]
		[MaxLength(300)]
		public virtual string CM_COY_NAME { get; set; }
		[JsonProperty("cm_coy_long_name")]
		[MaxLength(765)]
		public virtual string CM_COY_LONG_NAME { get; set; }
		[JsonProperty("cm_coy_type")]
		[MaxLength(90)]
		public virtual string CM_COY_TYPE { get; set; }
		[JsonProperty("cm_parent_coy_id")]
		[MaxLength(60)]
		public virtual string CM_PARENT_COY_ID { get; set; }
		[JsonProperty("cm_acct_no")]
		[MaxLength(90)]
		public virtual string CM_ACCT_NO { get; set; }
		[JsonProperty("cm_bank")]
		[MaxLength(300)]
		public virtual string CM_BANK { get; set; }
		[JsonProperty("cm_branch")]
		[MaxLength(90)]
		public virtual string CM_BRANCH { get; set; }
		[JsonProperty("cm_addr_line1")]
		[MaxLength(765)]
		public virtual string CM_ADDR_LINE1 { get; set; }
		[JsonProperty("cm_addr_line2")]
		[MaxLength(765)]
		public virtual string CM_ADDR_LINE2 { get; set; }
		[JsonProperty("cm_addr_line3")]
		[MaxLength(765)]
		public virtual string CM_ADDR_LINE3 { get; set; }
		[JsonProperty("cm_postcode")]
		[MaxLength(30)]
		public virtual string CM_POSTCODE { get; set; }
		[JsonProperty("cm_city")]
		[MaxLength(150)]
		public virtual string CM_CITY { get; set; }
		[JsonProperty("cm_state")]
		[MaxLength(30)]
		public virtual string CM_STATE { get; set; }
		[JsonProperty("cm_country")]
		[MaxLength(30)]
		public virtual string CM_COUNTRY { get; set; }
		[JsonProperty("cm_phone")]
		[MaxLength(150)]
		public virtual string CM_PHONE { get; set; }
		[JsonProperty("cm_fax")]
		[MaxLength(150)]
		public virtual string CM_FAX { get; set; }
		[JsonProperty("cm_email")]
		[MaxLength(150)]
		public virtual string CM_EMAIL { get; set; }
		[JsonProperty("cm_coy_logo")]
		[MaxLength(150)]
		public virtual string CM_COY_LOGO { get; set; }
		[JsonProperty("cm_website")]
		[MaxLength(150)]
		public virtual string CM_WEBSITE { get; set; }
		[JsonProperty("cm_business_reg_no")]
		[MaxLength(150)]
		public virtual string CM_BUSINESS_REG_NO { get; set; }
		[JsonProperty("cm_year_reg")]
		[MaxLength(12)]
		public virtual string CM_YEAR_REG { get; set; }
		[JsonProperty("cm_tax_reg_no")]
		[MaxLength(150)]
		public virtual string CM_TAX_REG_NO { get; set; }
		[JsonProperty("cm_last_date")]
		public virtual System.DateTime? CM_LAST_DATE { get; set; }
		[JsonProperty("cm_payment_term")]
		[MaxLength(30)]
		public virtual string CM_PAYMENT_TERM { get; set; }
		[JsonProperty("cm_payment_method")]
		[MaxLength(30)]
		public virtual string CM_PAYMENT_METHOD { get; set; }
		[JsonProperty("cm_actual_termsandcondfile")]
		[MaxLength(300)]
		public virtual string CM_ACTUAL_TERMSANDCONDFILE { get; set; }
		[JsonProperty("cm_hub_termsandcondfile")]
		[MaxLength(300)]
		public virtual string CM_HUB_TERMSANDCONDFILE { get; set; }
		[JsonProperty("cm_pwd_duration")]
		public virtual int? CM_PWD_DURATION { get; set; }
		[JsonProperty("cm_tax_calc_by")]
		[MaxLength(3)]
		public virtual string CM_TAX_CALC_BY { get; set; }
		[JsonProperty("cm_currency_code")]
		[MaxLength(30)]
		public virtual string CM_CURRENCY_CODE { get; set; }
		[JsonProperty("cm_bcm_set")]
		[MaxLength(3)]
		public virtual string CM_BCM_SET { get; set; }
		[JsonProperty("cm_budget_from_date")]
		public virtual System.DateTime? CM_BUDGET_FROM_DATE { get; set; }
		[JsonProperty("cm_budget_to_date")]
		public virtual System.DateTime? CM_BUDGET_TO_DATE { get; set; }
		[JsonProperty("cm_rfq_option")]
		[MaxLength(3)]
		public virtual string CM_RFQ_OPTION { get; set; }
		[JsonProperty("cm_licence_package")]
		[MaxLength(150)]
		public virtual string CM_LICENCE_PACKAGE { get; set; }
		[JsonProperty("cm_license_users")]
		public virtual int? CM_LICENSE_USERS { get; set; }
		[JsonProperty("cm_sub_start_dt")]
		public virtual System.DateTime? CM_SUB_START_DT { get; set; }
		[JsonProperty("cm_sub_end_dt")]
		public virtual System.DateTime? CM_SUB_END_DT { get; set; }
		[JsonProperty("cm_license_products")]
		public virtual int? CM_LICENSE_PRODUCTS { get; set; }
		[JsonProperty("cm_findept_mode")]
		[MaxLength(3)]
		public virtual string CM_FINDEPT_MODE { get; set; }
		[JsonProperty("cm_priv_labeling")]
		[MaxLength(3)]
		public virtual string CM_PRIV_LABELING { get; set; }
		[JsonProperty("cm_skins_id")]
		[MaxLength(60)]
		public virtual string CM_SKINS_ID { get; set; }
		[JsonProperty("cm_training")]
		[MaxLength(3)]
		public virtual string CM_TRAINING { get; set; }
		[JsonProperty("cm_status")]
		[MaxLength(3)]
		public virtual string CM_STATUS { get; set; }
		[JsonProperty("cm_deleted")]
		[MaxLength(3)]
		public virtual string CM_DELETED { get; set; }
		[JsonProperty("cm_mod_by")]
		[MaxLength(60)]
		public virtual string CM_MOD_BY { get; set; }
		[JsonProperty("cm_mod_dt")]
		public virtual System.DateTime? CM_MOD_DT { get; set; }
		[JsonProperty("cm_ent_by")]
		[MaxLength(60)]
		public virtual string CM_ENT_BY { get; set; }
		[JsonProperty("cm_ent_dt")]
		public virtual System.DateTime? CM_ENT_DT { get; set; }
		[JsonProperty("cm_sku")]
		public virtual int? CM_SKU { get; set; }
		[JsonProperty("cm_trans_no")]
		public virtual int? CM_TRANS_NO { get; set; }
		[JsonProperty("cm_contact")]
		[MaxLength(300)]
		public virtual string CM_CONTACT { get; set; }
		[JsonProperty("cm_report_users")]
		public virtual int? CM_REPORT_USERS { get; set; }
		[JsonProperty("cm_inv_appr")]
		[MaxLength(3)]
		public virtual string CM_INV_APPR { get; set; }
		[JsonProperty("cm_multi_po")]
		[MaxLength(3)]
		public virtual string CM_MULTI_PO { get; set; }
		[JsonProperty("cm_ba_cancel")]
		[MaxLength(3)]
		public virtual string CM_BA_CANCEL { get; set; }
		[JsonProperty("cm_paidcapital_currency_code")]
		[MaxLength(30)]
		public virtual string CM_PAIDCAPITAL_CURRENCY_CODE { get; set; }
		[JsonProperty("cm_paidcapital")]
		public virtual decimal? CM_PAIDCAPITAL { get; set; }
		[JsonProperty("cm_ownership1")]
		[MaxLength(30)]
		public virtual string CM_OWNERSHIP1 { get; set; }
		[JsonProperty("cm_ownership2")]
		[MaxLength(150)]
		public virtual string CM_OWNERSHIP2 { get; set; }
		[JsonProperty("cm_business_nature")]
		[MaxLength(30)]
		public virtual string CM_BUSINESS_NATURE { get; set; }
		[JsonProperty("cm_commodity")]
		[MaxLength(60)]
		public virtual string CM_COMMODITY { get; set; }
		[JsonProperty("cm_regorgcode")]
		[MaxLength(150)]
		public virtual string CM_REGORGCODE { get; set; }
		[JsonProperty("cm_bank_name")]
		[MaxLength(300)]
		public virtual string CM_BANK_NAME { get; set; }
		[JsonProperty("cm_contr_pr_setting")]
		[MaxLength(3)]
		public virtual string CM_CONTR_PR_SETTING { get; set; }
		[JsonProperty("cm_contr_pr_po_owner_id")]
		[MaxLength(60)]
		public virtual string CM_CONTR_PR_PO_OWNER_ID { get; set; }
		[JsonProperty("cm_ncontr_pr_setting")]
		[MaxLength(6)]
		public virtual string CM_NCONTR_PR_SETTING { get; set; }
		[JsonProperty("cm_grn_control")]
		[MaxLength(3)]
		public virtual string CM_GRN_CONTROL { get; set; }
		[JsonProperty("cm_ffpo_control")]
		[MaxLength(3)]
		public virtual string CM_FFPO_CONTROL { get; set; }
		[JsonProperty("cm_display_acct")]
		[MaxLength(3)]
		public virtual string CM_DISPLAY_ACCT { get; set; }
		[JsonProperty("cm_activate_stock")]
		[MaxLength(15)]
		public virtual string CM_ACTIVATE_STOCK { get; set; }
		[JsonProperty("cm_urgent_stock_email")]
		[MaxLength(3)]
		public virtual string CM_URGENT_STOCK_EMAIL { get; set; }
		[JsonProperty("cm_reject_stock_email")]
		[MaxLength(3)]
		public virtual string CM_REJECT_STOCK_EMAIL { get; set; }
		[JsonProperty("cm_safety_stock_email")]
		[MaxLength(3)]
		public virtual string CM_SAFETY_STOCK_EMAIL { get; set; }
		[JsonProperty("cm_reorder_stock_email")]
		[MaxLength(3)]
		public virtual string CM_REORDER_STOCK_EMAIL { get; set; }
		[JsonProperty("cm_maximum_stock_email")]
		[MaxLength(3)]
		public virtual string CM_MAXIMUM_STOCK_EMAIL { get; set; }
		[JsonProperty("cm_location_stock")]
		[MaxLength(3)]
		public virtual string CM_LOCATION_STOCK { get; set; }
		[JsonProperty("cm_smart_pay")]
		public virtual decimal? CM_SMART_PAY { get; set; }
		[JsonProperty("cm_resident")]
		[MaxLength(3)]
		public virtual string CM_RESIDENT { get; set; }
	}
	#endregion
}
