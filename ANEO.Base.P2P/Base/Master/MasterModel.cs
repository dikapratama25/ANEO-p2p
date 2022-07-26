using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;
using System;

namespace ANEO.Base.P2P.Master.Model
{
	#region PR_MSTR
	public class MapListPR_MSTR
	{
		[JsonProperty("prm_pr_index")]
		[Grid(IsVisible = false)]
		public virtual long? PRM_PR_Index { get; set; }
		[JsonProperty("prm_pr_no")]
		[Grid(Width = 60)]
		public virtual string PRM_PR_NO { get; set; }
		[JsonProperty("prm_req_name")]
		[Grid(IsVisible = false)]
		public virtual string PRM_REQ_NAME { get; set; }
		[JsonProperty("prm_req_phone")]
		[Grid(IsVisible = false)]
		public virtual string PRM_REQ_PHONE { get; set; }
		[JsonProperty("prm_submit_date")]
		[Grid(Width = 120)]
		public virtual string PRM_SUBMIT_DATE { get; set; }
		[JsonProperty("prm_buyer_id")]
		[Grid(IsVisible = false)]
		public virtual string PRM_BUYER_ID { get; set; }
		[JsonProperty("prm_payment_type")]
		[Grid(IsVisible = false)]
		public virtual string PRM_PAYMENT_TYPE { get; set; }
		[JsonProperty("prm_currency_code")]
		[Grid(IsVisible = false)]
		public virtual string PRM_CURRENCY_CODE { get; set; }
		[JsonProperty("prm_gst")]
		[Grid(IsVisible = false)]
		public virtual decimal? PRM_GST { get; set; }
		[JsonProperty("prm_exchange_rate")]
		[Grid(IsVisible = false)]
		public virtual double? PRM_EXCHANGE_RATE { get; set; }
		[JsonProperty("prm_pr_status")]
		[Grid(IsVisible =false)]
		public virtual int? PRM_PR_STATUS { get; set; }
		[JsonProperty("prm_pr_cost")]
		[Grid(IsVisible = false)]
		public virtual decimal? PRM_PR_COST { get; set; }
		[JsonProperty("prm_quotation_no")]
		[Grid(IsVisible = false)]
		public virtual string PRM_QUOTATION_NO { get; set; }
		[JsonProperty("prm_pr_type")]
		[Grid(Width = 60)]
		public virtual string PRM_PR_TYPE { get; set; }

		[JsonProperty("prm_created_date")]
		public virtual string PRM_CREATED_DATE { get; set; }
		[JsonProperty("createddate")]
		[Grid(Width = 150)]
		public virtual string CreatedDate { get; set; }
		[JsonProperty("prm_pr_date")]
		[Grid(Width = 150)]
		public virtual string PRM_PR_DATE { get; set; }
		[JsonProperty("status_desc")]
		[Grid(Width = 60, StatusBadges = new string[] { "Submitted|success", "Draft|warning", "Converted to PO|info", "Void|Primary" })]
		public virtual string STATUS_DESC { get; set; }
		[JsonProperty("po_no")]
		[Grid(Width = 60)]
		public virtual string PO_NO { get; set; }
	}
	#endregion

	#region USER_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.user_mstr.USER_MSTR))]
	public class MapUSER_MSTR : BaseMapId
	{
		[JsonProperty("um_auto_no")]
		[Required]
		public virtual long? UM_AUTO_NO { get; set; }
		[JsonProperty("um_user_id")]
		[MaxLength(60), Required]
		public virtual string UM_USER_ID { get; set; }
		[JsonProperty("um_deleted")]
		[MaxLength(3), Required]
		public virtual string UM_DELETED { get; set; }
		[JsonProperty("um_coy_id")]
		[MaxLength(60), Required]
		public virtual string UM_COY_ID { get; set; }
		[JsonProperty("um_password")]
		public virtual byte[] UM_PASSWORD { get; set; }
		[JsonProperty("um_password_new")]
		[MaxLength(300)]
		public virtual string UM_PASSWORD_NEW { get; set; }
		[JsonProperty("um_user_name")]
		[MaxLength(300)]
		public virtual string UM_USER_NAME { get; set; }
		[JsonProperty("um_dept_id")]
		[MaxLength(30)]
		public virtual string UM_DEPT_ID { get; set; }
		[JsonProperty("um_email")]
		[MaxLength(300)]
		public virtual string UM_EMAIL { get; set; }
		[JsonProperty("um_app_limit")]
		public virtual decimal? UM_APP_LIMIT { get; set; }
		[JsonProperty("um_po_app_limit")]
		public virtual decimal? UM_PO_APP_LIMIT { get; set; }
		[JsonProperty("um_designation")]
		[MaxLength(150)]
		public virtual string UM_DESIGNATION { get; set; }
		[JsonProperty("um_tel_no")]
		[MaxLength(150)]
		public virtual string UM_TEL_NO { get; set; }
		[JsonProperty("um_fax_no")]
		[MaxLength(150)]
		public virtual string UM_FAX_NO { get; set; }
		[JsonProperty("um_user_suspend_ind")]
		public virtual decimal? UM_USER_SUSPEND_IND { get; set; }
		[JsonProperty("um_password_last_changed")]
		public virtual System.DateTime? UM_PASSWORD_LAST_CHANGED { get; set; }
		[JsonProperty("um_new_password_ind")]
		[MaxLength(3)]
		public virtual string UM_NEW_PASSWORD_IND { get; set; }
		[JsonProperty("um_next_expire_dt")]
		public virtual System.DateTime? UM_NEXT_EXPIRE_DT { get; set; }
		[JsonProperty("um_last_login_dt")]
		public virtual System.DateTime? UM_LAST_LOGIN_DT { get; set; }
		[JsonProperty("um_question")]
		public virtual decimal? UM_QUESTION { get; set; }
		[JsonProperty("um_answer")]
		[MaxLength(450)]
		public virtual string UM_ANSWER { get; set; }
		[JsonProperty("um_mass_app")]
		[MaxLength(3)]
		public virtual string UM_MASS_APP { get; set; }
		[JsonProperty("um_status")]
		[MaxLength(3)]
		public virtual string UM_STATUS { get; set; }
		[JsonProperty("um_mod_by")]
		[MaxLength(60)]
		public virtual string UM_MOD_BY { get; set; }
		[JsonProperty("um_mod_dt")]
		public virtual System.DateTime? UM_MOD_DT { get; set; }
		[JsonProperty("um_ent_by")]
		[MaxLength(60)]
		public virtual string UM_ENT_BY { get; set; }
		[JsonProperty("um_ent_date")]
		public virtual System.DateTime? UM_ENT_DATE { get; set; }
		[JsonProperty("um_record_count")]
		public virtual int? UM_RECORD_COUNT { get; set; }
		[JsonProperty("um_email_cc")]
		[MaxLength(3000)]
		public virtual string UM_EMAIL_CC { get; set; }
		[JsonProperty("um_invoice_app_limit")]
		public virtual decimal? UM_INVOICE_APP_LIMIT { get; set; }
		[JsonProperty("um_invoice_mass_app")]
		[MaxLength(3)]
		public virtual string UM_INVOICE_MASS_APP { get; set; }
		[JsonProperty("um_mrs_mass_app")]
		[MaxLength(3)]
		public virtual string UM_MRS_MASS_APP { get; set; }
		[JsonProperty("um_stk_type_spot")]
		[MaxLength(3)]
		public virtual string UM_STK_TYPE_SPOT { get; set; }
		[JsonProperty("um_stk_type_stock")]
		[MaxLength(3)]
		public virtual string UM_STK_TYPE_STOCK { get; set; }
		[JsonProperty("um_stk_type_mro")]
		[MaxLength(3)]
		public virtual string UM_STK_TYPE_MRO { get; set; }
		[JsonProperty("um_policy_agree_date")]
		public virtual System.DateTime? UM_POLICY_AGREE_DATE { get; set; }
		[JsonProperty("um_staff_claim_email")]
		[MaxLength(3)]
		public virtual string UM_STAFF_CLAIM_EMAIL { get; set; }
	}
	#endregion

	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class MapCodeCategory : Map.code_mstr.MapCODE_MSTR 
	{
		[JsonProperty("cc_default_code")]
		[MaxLength(30)]
		public virtual string CC_DEFAULT_CODE { get; set; }
	}

}
