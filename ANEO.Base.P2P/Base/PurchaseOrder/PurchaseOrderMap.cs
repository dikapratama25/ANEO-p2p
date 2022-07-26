using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;
using System;
using ANEO.Base.P2P.General.Map;

namespace ANEO.Base.P2P.Base.PurchaseOrder
{
    #region PO_MSTR
    public class MapPO_MSTR 
    {
        #region display
        [JsonProperty("pom_po_no")]
        [MaxLength(150), Grid(IsVisible = true, Width = 90)]
        public virtual string POM_PO_NO { get; set; }
        [JsonProperty("pom_created_date")]
        [MaxLength(150), Grid(IsVisible = true, Width = 100, DatetimeFormat = "DD/MM/YYYY")]
        public virtual System.DateTime? POM_CREATED_DATE { get; set; }
        [JsonProperty("pom_po_date")]
        [MaxLength(150), Grid(IsVisible = true, Width = 100, DatetimeFormat = "DD/MM/YYYY")]
        public virtual System.DateTime? POM_PO_DATE { get; set; }
        [JsonProperty("pom_s_coy_name")]
        [MaxLength(300), Grid(IsVisible = true, Width = 130)]
        public virtual string POM_S_COY_NAME { get; set; }
        [JsonProperty("pom_accepted_date")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual System.DateTime? POM_ACCEPTED_DATE { get; set; }
        [JsonProperty("status_desc")]
        [Grid(IsVisible = true, Width = 80)]
        public virtual string STATUS_DESC { get; set; }
        [JsonProperty("remark1")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual string Remark1 { get; set; }
        [JsonProperty("pr_no")]
        [Grid(IsVisible = true, Width = 90)]
        public virtual string PR_NO { get; set; }
        #endregion

        [JsonProperty("pom_po_index")]
        [Required]
        public virtual long? POM_PO_INDEX { get; set; }
        [JsonProperty("pom_b_coy_id")]
        [MaxLength(60)]
        public virtual string POM_B_COY_ID { get; set; }
        [JsonProperty("pom_buyer_id")]
        [MaxLength(60)]
        public virtual string POM_BUYER_ID { get; set; }
        [JsonProperty("pom_buyer_name")]
        [MaxLength(180)]
        public virtual string POM_BUYER_NAME { get; set; }
        [JsonProperty("pom_buyer_phone")]
        [MaxLength(150)]
        public virtual string POM_BUYER_PHONE { get; set; }
        [JsonProperty("pom_buyer_fax")]
        [MaxLength(150)]
        public virtual string POM_BUYER_FAX { get; set; }
        [JsonProperty("pom_s_coy_id")]
        [MaxLength(60)]
        public virtual string POM_S_COY_ID { get; set; }

        [JsonProperty("pom_s_attn")]
        [MaxLength(150)]
        public virtual string POM_S_ATTN { get; set; }
        [JsonProperty("pom_s_remark")]
        [MaxLength(3000)]
        public virtual string POM_S_REMARK { get; set; }
        [JsonProperty("pom_s_addr_line1")]
        [MaxLength(150)]
        public virtual string POM_S_ADDR_LINE1 { get; set; }
        [JsonProperty("pom_s_addr_line2")]
        [MaxLength(150)]
        public virtual string POM_S_ADDR_LINE2 { get; set; }
        [JsonProperty("pom_s_addr_line3")]
        [MaxLength(150)]
        public virtual string POM_S_ADDR_LINE3 { get; set; }
        [JsonProperty("pom_s_postcode")]
        [MaxLength(30)]
        public virtual string POM_S_POSTCODE { get; set; }
        [JsonProperty("pom_s_city")]
        [MaxLength(90)]
        public virtual string POM_S_CITY { get; set; }
        [JsonProperty("pom_s_state")]
        [MaxLength(60)]
        public virtual string POM_S_STATE { get; set; }
        [JsonProperty("pom_s_country")]
        [MaxLength(60)]
        public virtual string POM_S_COUNTRY { get; set; }
        [JsonProperty("pom_s_phone")]
        [MaxLength(150)]
        public virtual string POM_S_PHONE { get; set; }
        [JsonProperty("pom_s_fax")]
        [MaxLength(150)]
        public virtual string POM_S_FAX { get; set; }
        [JsonProperty("pom_s_email")]
        [MaxLength(180)]
        public virtual string POM_S_EMAIL { get; set; }

        [JsonProperty("pom_freight_terms")]
        [MaxLength(60)]
        public virtual string POM_FREIGHT_TERMS { get; set; }
        [JsonProperty("pom_payment_term")]
        [MaxLength(90)]
        public virtual string POM_PAYMENT_TERM { get; set; }
        [JsonProperty("pom_payment_method")]
        [MaxLength(90)]
        public virtual string POM_PAYMENT_METHOD { get; set; }
        [JsonProperty("pom_shipment_mode")]
        [MaxLength(90)]
        public virtual string POM_SHIPMENT_MODE { get; set; }
        [JsonProperty("pom_shipment_term")]
        [MaxLength(90)]
        public virtual string POM_SHIPMENT_TERM { get; set; }
        [JsonProperty("pom_currency_code")]
        [MaxLength(30)]
        public virtual string POM_CURRENCY_CODE { get; set; }
        [JsonProperty("pom_exchange_rate")]
        public virtual double? POM_EXCHANGE_RATE { get; set; }
        [JsonProperty("pom_payment_term_code")]
        [MaxLength(60)]
        public virtual string POM_PAYMENT_TERM_CODE { get; set; }
        [JsonProperty("pom_ship_via")]
        [MaxLength(90)]
        public virtual string POM_SHIP_VIA { get; set; }

        [JsonProperty("pom_status_changed_by")]
        [MaxLength(60)]
        public virtual string POM_STATUS_CHANGED_BY { get; set; }
        [JsonProperty("pom_status_changed_on")]
        public virtual System.DateTime? POM_STATUS_CHANGED_ON { get; set; }
        [JsonProperty("pom_external_remark")]
        [MaxLength(3000)]
        public virtual string POM_EXTERNAL_REMARK { get; set; }
        [JsonProperty("pom_created_by")]
        [MaxLength(150)]
        public virtual string POM_CREATED_BY { get; set; }

        [JsonProperty("pom_po_cost")]
        public virtual decimal? POM_PO_COST { get; set; }
        [JsonProperty("pom_billing_method")]
        [MaxLength(15)]
        public virtual string POM_BILLING_METHOD { get; set; }
        [JsonProperty("pom_po_prefix")]
        [MaxLength(90)]
        public virtual string POM_PO_PREFIX { get; set; }
        [JsonProperty("pom_b_addr_code")]
        [MaxLength(60)]
        public virtual string POM_B_ADDR_CODE { get; set; }
        [JsonProperty("pom_b_addr_line1")]
        [MaxLength(150)]
        public virtual string POM_B_ADDR_LINE1 { get; set; }
        [JsonProperty("pom_b_addr_line2")]
        [MaxLength(150)]
        public virtual string POM_B_ADDR_LINE2 { get; set; }
        [JsonProperty("pom_b_addr_line3")]
        [MaxLength(150)]
        public virtual string POM_B_ADDR_LINE3 { get; set; }
        [JsonProperty("pom_b_postcode")]
        [MaxLength(30)]
        public virtual string POM_B_POSTCODE { get; set; }
        [JsonProperty("pom_b_city")]
        [MaxLength(90)]
        public virtual string POM_B_CITY { get; set; }
        [JsonProperty("pom_b_state")]
        [MaxLength(60)]
        public virtual string POM_B_STATE { get; set; }
        [JsonProperty("pom_b_country")]
        [MaxLength(60)]
        public virtual string POM_B_COUNTRY { get; set; }

        [JsonProperty("pom_dept_index")]
        public virtual int? POM_DEPT_INDEX { get; set; }

        [JsonProperty("pom_downloaded_date")]
        public virtual System.DateTime? POM_DOWNLOADED_DATE { get; set; }
        [JsonProperty("pom_archive_ind")]
        [MaxLength(3)]
        public virtual string POM_ARCHIVE_IND { get; set; }
        [JsonProperty("pom_termandcond")]
        [MaxLength(150)]
        public virtual string POM_TERMANDCOND { get; set; }
        [JsonProperty("pom_reference_no")]
        [MaxLength(150)]
        public virtual string POM_REFERENCE_NO { get; set; }
        [JsonProperty("pom_external_ind")]
        [MaxLength(3)]
        public virtual string POM_EXTERNAL_IND { get; set; }
        [JsonProperty("pom_internal_remark")]
        [MaxLength(3000)]
        public virtual string POM_INTERNAL_REMARK { get; set; }
        [JsonProperty("pom_print_custom_fields")]
        [MaxLength(3)]
        public virtual string POM_PRINT_CUSTOM_FIELDS { get; set; }
        [JsonProperty("pom_print_remark")]
        [MaxLength(3)]
        public virtual string POM_PRINT_REMARK { get; set; }
        [JsonProperty("pom_rfq_index")]
        public virtual long? POM_RFQ_INDEX { get; set; }
        [JsonProperty("pom_quotation_no")]
        [MaxLength(150)]
        public virtual string POM_QUOTATION_NO { get; set; }
        [JsonProperty("pom_dup_from")]
        [MaxLength(150)]
        public virtual string POM_DUP_FROM { get; set; }
        [JsonProperty("pom_ship_amt")]
        public virtual decimal? POM_SHIP_AMT { get; set; }
        [JsonProperty("pom_acc_ship_amt")]
        public virtual decimal? POM_ACC_SHIP_AMT { get; set; }
        [JsonProperty("pom_submit_date")]
        public virtual System.DateTime? POM_SUBMIT_DATE { get; set; }
        [JsonProperty("pom_urgent")]
        [MaxLength(3)]
        public virtual string POM_URGENT { get; set; }
        [JsonProperty("pom_po_type")]
        [MaxLength(3)]
        public virtual string POM_PO_TYPE { get; set; }
        [JsonProperty("pom_del_code")]
        [MaxLength(60)]
        public virtual string POM_DEL_CODE { get; set; }
        [JsonProperty("pom_vendor_code")]
        [MaxLength(300)]
        public virtual string POM_VENDOR_CODE { get; set; }
    

    }
    #endregion

    public class MapPOApproval
    {
        #region display
        [JsonProperty("pom_po_no")]
        [MaxLength(150), Grid(IsVisible = true, Width = 90)]
        public virtual string POM_PO_NO { get; set; }
        [JsonProperty("pom_created_date")]
        [MaxLength(150), Grid(IsVisible = true, Width = 100)]
        public virtual System.DateTime? POM_CREATED_DATE { get; set; }

        [JsonProperty("pom_s_coy_name")]
        [MaxLength(300), Grid(IsVisible = true, Width = 130)]
        public virtual string POM_S_COY_NAME { get; set; }
        [JsonProperty("pom_accepted_date")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual System.DateTime? POM_ACCEPTED_DATE { get; set; }
        [JsonProperty("status_desc")]
        [Grid(IsVisible = true, Width = 80)]
        public virtual string STATUS_DESC { get; set; }
        [JsonProperty("remark1")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual string Remark1 { get; set; }
        




    }



    #region PO_DETAILS
    public class MapPO_DETAILS : MapGeneral
    {
        #region PO Master
        [JsonProperty("po_status")]
        public virtual string PO_STATUS { get; set; }
        [JsonProperty("pom_po_index")]
        public virtual long? POM_PO_INDEX { get; set; }
        [JsonProperty("pom_po_no")]
        [MaxLength(150)]
        public virtual string POM_PO_NO { get; set; }
        [JsonProperty("pom_b_coy_id")]
        [MaxLength(60)]
        public virtual string POM_B_COY_ID { get; set; }
        [JsonProperty("pom_buyer_id")]
        [MaxLength(60)]
        public virtual string POM_BUYER_ID { get; set; }
        [JsonProperty("pom_buyer_name")]
        [MaxLength(180)]
        public virtual string POM_BUYER_NAME { get; set; }
        [JsonProperty("pom_buyer_phone")]
        [MaxLength(150)]
        public virtual string POM_BUYER_PHONE { get; set; }
        [JsonProperty("pom_buyer_fax")]
        [MaxLength(150)]
        public virtual string POM_BUYER_FAX { get; set; }
        [JsonProperty("pom_s_coy_id")]
        [MaxLength(60)]
        public virtual string POM_S_COY_ID { get; set; }
        [JsonProperty("pom_s_coy_name")]
        [MaxLength(300)]
        public virtual string POM_S_COY_NAME { get; set; }
        [JsonProperty("pom_s_attn")]
        [MaxLength(150)]
        public virtual string POM_S_ATTN { get; set; }
        [JsonProperty("pom_s_remark")]
        [MaxLength(3000)]
        public virtual string POM_S_REMARK { get; set; }
        [JsonProperty("pom_s_addr_line1")]
        [MaxLength(150)]
        public virtual string POM_S_ADDR_LINE1 { get; set; }
        [JsonProperty("pom_s_addr_line2")]
        [MaxLength(150)]
        public virtual string POM_S_ADDR_LINE2 { get; set; }
        [JsonProperty("pom_s_addr_line3")]
        [MaxLength(150)]
        public virtual string POM_S_ADDR_LINE3 { get; set; }
        [JsonProperty("pom_s_postcode")]
        [MaxLength(30)]
        public virtual string POM_S_POSTCODE { get; set; }
        [JsonProperty("pom_s_city")]
        [MaxLength(90)]
        public virtual string POM_S_CITY { get; set; }
        [JsonProperty("pom_s_state")]
        [MaxLength(60)]
        public virtual string POM_S_STATE { get; set; }
        [JsonProperty("pom_s_country")]
        [MaxLength(60)]
        public virtual string POM_S_COUNTRY { get; set; }
        [JsonProperty("pom_s_phone")]
        [MaxLength(150)]
        public virtual string POM_S_PHONE { get; set; }
        [JsonProperty("pom_s_fax")]
        [MaxLength(150)]
        public virtual string POM_S_FAX { get; set; }
        [JsonProperty("pom_s_email")]
        [MaxLength(180)]
        public virtual string POM_S_EMAIL { get; set; }
        [JsonProperty("pom_po_date")]
        public virtual System.DateTime? POM_PO_DATE { get; set; }
        [JsonProperty("pom_freight_terms")]
        [MaxLength(60)]
        public virtual string POM_FREIGHT_TERMS { get; set; }
        [JsonProperty("pom_payment_term")]
        [MaxLength(90)]
        public virtual string POM_PAYMENT_TERM { get; set; }
        [JsonProperty("pom_payment_method")]
        [MaxLength(90)]
        public virtual string POM_PAYMENT_METHOD { get; set; }
        [JsonProperty("pom_shipment_mode")]
        [MaxLength(90)]
        public virtual string POM_SHIPMENT_MODE { get; set; }
        [JsonProperty("pom_shipment_term")]
        [MaxLength(90)]
        public virtual string POM_SHIPMENT_TERM { get; set; }
        [JsonProperty("pom_currency_code")]
        [MaxLength(30)]
        public virtual string POM_CURRENCY_CODE { get; set; }
        [JsonProperty("pom_exchange_rate")]
        public virtual double? POM_EXCHANGE_RATE { get; set; }
        [JsonProperty("pom_payment_term_code")]
        [MaxLength(60)]
        public virtual string POM_PAYMENT_TERM_CODE { get; set; }
        [JsonProperty("pom_ship_via")]
        [MaxLength(90)]
        public virtual string POM_SHIP_VIA { get; set; }
        [JsonProperty("pom_po_status")]
        public virtual int? POM_PO_STATUS { get; set; }
        [JsonProperty("pom_status_changed_by")]
        [MaxLength(60)]
        public virtual string POM_STATUS_CHANGED_BY { get; set; }
        [JsonProperty("pom_status_changed_on")]
        public virtual System.DateTime? POM_STATUS_CHANGED_ON { get; set; }
        [JsonProperty("pom_external_remark")]
        [MaxLength(3000)]
        public virtual string POM_EXTERNAL_REMARK { get; set; }
        [JsonProperty("pom_created_by")]
        [MaxLength(150)]
        public virtual string POM_CREATED_BY { get; set; }
        [JsonProperty("pom_created_date")]
        public virtual System.DateTime? POM_CREATED_DATE { get; set; }
        [JsonProperty("pom_po_cost")]
        public virtual decimal? POM_PO_COST { get; set; }
        [JsonProperty("pom_billing_method")]
        [MaxLength(15)]
        public virtual string POM_BILLING_METHOD { get; set; }
        [JsonProperty("pom_po_prefix")]
        [MaxLength(90)]
        public virtual string POM_PO_PREFIX { get; set; }
        [JsonProperty("pom_b_addr_code")]
        [MaxLength(60)]
        public virtual string POM_B_ADDR_CODE { get; set; }
        [JsonProperty("pom_b_addr_line1")]
        [MaxLength(150)]
        public virtual string POM_B_ADDR_LINE1 { get; set; }
        [JsonProperty("pom_b_addr_line2")]
        [MaxLength(150)]
        public virtual string POM_B_ADDR_LINE2 { get; set; }
        [JsonProperty("pom_b_addr_line3")]
        [MaxLength(150)]
        public virtual string POM_B_ADDR_LINE3 { get; set; }
        [JsonProperty("pom_b_postcode")]
        [MaxLength(30)]
        public virtual string POM_B_POSTCODE { get; set; }
        [JsonProperty("pom_b_city")]
        [MaxLength(90)]
        public virtual string POM_B_CITY { get; set; }
        [JsonProperty("pom_b_state")]
        [MaxLength(60)]
        public virtual string POM_B_STATE { get; set; }
        [JsonProperty("pom_b_country")]
        [MaxLength(60)]
        public virtual string POM_B_COUNTRY { get; set; }
        [JsonProperty("pom_fulfilment")]
        public virtual int? POM_FULFILMENT { get; set; }
        [JsonProperty("pom_dept_index")]
        public virtual int? POM_DEPT_INDEX { get; set; }
        [JsonProperty("pom_accepted_date")]
        public virtual System.DateTime? POM_ACCEPTED_DATE { get; set; }
        [JsonProperty("pom_downloaded_date")]
        public virtual System.DateTime? POM_DOWNLOADED_DATE { get; set; }
        [JsonProperty("pom_archive_ind")]
        [MaxLength(3)]
        public virtual string POM_ARCHIVE_IND { get; set; }
        [JsonProperty("pom_termandcond")]
        [MaxLength(150)]
        public virtual string POM_TERMANDCOND { get; set; }
        [JsonProperty("pom_reference_no")]
        [MaxLength(150)]
        public virtual string POM_REFERENCE_NO { get; set; }
        [JsonProperty("pom_external_ind")]
        [MaxLength(3)]
        public virtual string POM_EXTERNAL_IND { get; set; }
        [JsonProperty("pom_internal_remark")]
        [MaxLength(3000)]
        public virtual string POM_INTERNAL_REMARK { get; set; }
        [JsonProperty("pom_print_custom_fields")]
        [MaxLength(3)]
        public virtual string POM_PRINT_CUSTOM_FIELDS { get; set; }
        [JsonProperty("pom_print_remark")]
        [MaxLength(3)]
        public virtual string POM_PRINT_REMARK { get; set; }
        [JsonProperty("pom_rfq_index")]
        public virtual long? POM_RFQ_INDEX { get; set; }
        [JsonProperty("pom_quotation_no")]
        [MaxLength(150)]
        public virtual string POM_QUOTATION_NO { get; set; }
        [JsonProperty("pom_dup_from")]
        [MaxLength(150)]
        public virtual string POM_DUP_FROM { get; set; }
        [JsonProperty("pom_ship_amt")]
        public virtual decimal? POM_SHIP_AMT { get; set; }
        [JsonProperty("pom_acc_ship_amt")]
        public virtual decimal? POM_ACC_SHIP_AMT { get; set; }
        [JsonProperty("pom_submit_date")]
        public virtual System.DateTime? POM_SUBMIT_DATE { get; set; }
        [JsonProperty("pom_urgent")]
        [MaxLength(3)]
        public virtual string POM_URGENT { get; set; }
        [JsonProperty("pom_po_type")]
        [MaxLength(3)]
        public virtual string POM_PO_TYPE { get; set; }
        [JsonProperty("pom_del_code")]
        [MaxLength(60)]
        public virtual string POM_DEL_CODE { get; set; }
        [JsonProperty("pom_vendor_code")]
        [MaxLength(300)]
        public virtual string POM_VENDOR_CODE { get; set; }
        #endregion

        #region UserMaster
        [JsonProperty("um_auto_no")]
        public virtual long? UM_AUTO_NO { get; set; }
        [JsonProperty("um_user_id")]
        [MaxLength(60)]
        public virtual string UM_USER_ID { get; set; }
        [JsonProperty("um_deleted")]
        [MaxLength(3)]
        public virtual string UM_DELETED { get; set; }
        [JsonProperty("um_coy_id")]
        [MaxLength(60)]
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
        public virtual short? UM_RECORD_COUNT { get; set; }
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
        #endregion

        #region Company Master
        [JsonProperty("code_index")]
        [Grid(IsVisible = false)]
        public virtual long? CODE_INDEX { get; set; }
        [JsonProperty("code_abbr")]
        [MaxLength(30)]
        [Grid(IsVisible = false)]
        public virtual string CODE_ABBR { get; set; }
        [JsonProperty("code_desc")]
        [MaxLength(150)]
        public virtual string CODE_DESC { get; set; }
        [JsonProperty("code_value")]
        [MaxLength(90)]
        public virtual string CODE_VALUE { get; set; }
        [JsonProperty("code_category")]
        [MaxLength(15)]
        [Grid(IsVisible = false)]
        public virtual string CODE_CATEGORY { get; set; }
        [JsonProperty("code_deleted")]
        [MaxLength(3)]
        [Grid(IsVisible = false)]
        public virtual string CODE_DELETED { get; set; }
        #endregion

        #region Company Delivery Term
        [JsonProperty("cdt_del_index")]
        public virtual long? CDT_DEL_INDEX { get; set; }
        [JsonProperty("cdt_coy_id")]
        [MaxLength(60)]
        public virtual string CDT_COY_ID { get; set; }
        [JsonProperty("cdt_del_code")]
        [MaxLength(30)]
        public virtual string CDT_DEL_CODE { get; set; }
        [JsonProperty("cdt_del_name")]
        [MaxLength(150)]
        public virtual string CDT_DEL_NAME { get; set; }
        [JsonProperty("cdt_del_grnfactor")]
        public virtual decimal? CDT_DEL_GRNFACTOR { get; set; }
        [JsonProperty("cdt_del_oversea")]
        [MaxLength(3)]
        public virtual string CDT_DEL_OVERSEA { get; set; }
        [JsonProperty("cdt_deleted")]
        [MaxLength(3)]
        public virtual string CDT_DELETED { get; set; }
        [JsonProperty("cdt_ent_by")]
        [MaxLength(150)]
        public virtual string CDT_ENT_BY { get; set; }
        [JsonProperty("cdt_ent_dt")]
        public virtual System.DateTime? CDT_ENT_DT { get; set; }
        [JsonProperty("cdt_mod_by")]
        [MaxLength(150)]
        public virtual string CDT_MOD_BY { get; set; }
        [JsonProperty("cdt_mod_dt")]
        public virtual System.DateTime? CDT_MOD_DT { get; set; }
        #endregion

        #region approvalorder 
        [JsonProperty("approvalorders")]
        public virtual List<MapApprovalOrderPO> ApprovalOrders { get; set; }
        #endregion

        [JsonProperty("fileattachments")]
        public virtual List<Master.Map.company_doc_attachment.MapFileAttachment> FileAttachments { get; set; }
        [JsonProperty("detailline")]
        public virtual List<mapPO_DetailLine> detailline { get; set; }


    }
    public class mapPO_DetailLine
    {
        #region Display
        [JsonProperty("pod_po_line")]
        [Grid(IsVisible = true, Width = 70, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_PO_LINE { get; set; }
        [JsonProperty("pod_gift")]
        [Grid(IsVisible = true, Width = 90)]
        public virtual string POD_GIFT { get; set; }
        [JsonProperty("fundtype")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string FUNDTYPE { get; set; }
        [JsonProperty("personcodedesc")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string PERSONCODEDESC { get; set; }
        [JsonProperty("projectcodedesc")]
        [Grid(IsVisible = true, Width = 160)]
        public virtual string PROJECTCODEDESC { get; set; }
        [JsonProperty("pod_vendor_item_code")]
        [Grid(IsVisible = true, Width = 120)]
        public virtual string POD_VENDOR_ITEM_CODE { get; set; }
        [JsonProperty("gl_codedesc")]
        [Grid(IsVisible = true, Width = 180)]
        public virtual string gl_codedesc { get; set; }
        [JsonProperty("POD_B_GL_CODE")]
        public virtual string POD_B_GL_CODE { get; set; }
        [JsonProperty("pod_b_category_code")]
        public virtual string POD_B_CATEGORY_CODE { get; set; }
        [JsonProperty("asset_code")]
        public virtual string ASSET_CODE { get; set; }
        [JsonProperty("pod_product_desc")]
        [Grid(IsVisible = true, Width = 130)]
        public virtual string POD_PRODUCT_DESC { get; set; }
        [JsonProperty("pod_product_code")]
        [Grid(IsVisible = true, Width = 130)]
         public virtual string POD_PRODUCT_CODE{ get; set; }
        [JsonProperty("pod_uom")]
        [Grid(IsVisible = true, Width = 120)]
        public virtual string POD_UOM { get; set; }
        [JsonProperty("pod_unit_cost")]
        [Grid(IsVisible = true, Width = 120, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_UNIT_COST { get; set; }
        [JsonProperty("gst_rate")]
        [Grid(IsVisible = true, Width = 120)]
        public virtual string GST_RATE { get; set; }
        [JsonProperty("pod_tax_value")]
        [Grid(IsVisible = true, Width = 120, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_TAX_VALUE { get; set; }
        [JsonProperty("pod_gst_input_tax_code")]
        [Grid(IsVisible = true, Width = 190)]
        public virtual string POD_GST_INPUT_TAX_CODE { get; set; }
        [JsonProperty("pod_min_pack_qty")]
        [Grid(IsVisible = true, Width = 120, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_MIN_PACK_QTY { get; set; }
        [JsonProperty("pod_project_code")]
        public virtual string POD_PROJECT_CODE { get; set; }
        [JsonProperty("pod_person_code")]
        public virtual string POD_PERSON_CODE { get; set; }
        [JsonProperty("pod_fund_type")]
        public virtual string POD_FUND_TYPE { get; set; }
        [JsonProperty("pod_warranty_terms")]
        [Grid(IsVisible = true, Width = 180, Alignment = ColumnsAlignment.Right)]
        public virtual int POD_WARRANTY_TERMS { get; set; }
        [JsonProperty("POD_D_ADDR_CODE")]
        [Grid(IsVisible = true, Width = 180, Alignment = ColumnsAlignment.Right)]
        public virtual string  POD_D_ADDR_CODE { get; set; }
        [JsonProperty("pod_min_order_qty")]
        [Grid(IsVisible = true, Width = 180, Alignment = ColumnsAlignment.Right)]
        public virtual int POD_MIN_ORDER_QTY { get; set; }
        [JsonProperty("pod_etd")]
        public virtual int POD_ETD { get; set; }
        [JsonProperty("pod_ordered_qty")]
        [Grid(IsVisible = true, Width = 120, Alignment = ColumnsAlignment.Right)]
        public virtual int POD_ORDERED_QTY { get; set; }
        [JsonProperty("pod_pr_line")]
        [Grid(IsVisible = true, Width = 120, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_PR_LINE { get; set; }
        [JsonProperty("pod_received_qty")]
        [Grid(IsVisible = true, Width = 120, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_RECEIVED_QTY { get; set; }
        [JsonProperty("pod_rejected_qty")]
        [Grid(IsVisible = true, Width = 120, Alignment = ColumnsAlignment.Right)]
        public virtual string POD_REJECTED_QTY { get; set; }
        [JsonProperty("pod_remark")]
        [Grid(IsVisible = true, Width = 160)]
        public virtual string POD_REMARK { get; set; }
        #endregion

    }
    public class mapAcceptPO
    {
        [JsonProperty("userID")]
        public string userID { get; set; }
        [JsonProperty("strBuyer")]
        public string strBuyer { get; set; }
        [JsonProperty("currentseq")]
        public int currentseq { get; set; }
        [JsonProperty("companyID")]
        public string companyID { get; set; }
        [JsonProperty("strPOStatus")]
        public string strPOStatus { get; set; }
        [JsonProperty("strVenName")]
        public string strVenName { get; set; }
        [JsonProperty("strPONo")]
        public string strPONo { get; set; }
        [JsonProperty("strPOType")]
        public string strPOType { get; set; }
        [JsonProperty("strReliefOn")]
        public string strReliefOn { get; set; }
        [JsonProperty("strAORemark")]
        public string strAORemark { get; set; }
        [JsonProperty("Approvaltype")]
        public string Approvaltype { get; set; }
        [JsonProperty("strPOIndex")]
        public long strPOIndex { get; set; }
        [JsonProperty("strCoyID")]
        public string strCoyID { get; set; }
       

    }
    public class mapApprovedPO
    {
        [JsonProperty("userID")]
        public string userID { get; set; }
        [JsonProperty("strBuyer")]
        public string strBuyer { get; set; }
        [JsonProperty("currentseq")]
        public int  currentseq { get; set; }
        [JsonProperty("companyID")]
        public string companyID { get; set; }
        [JsonProperty("strPOStatus")]
        public string strPOStatus { get; set; }
        [JsonProperty("strFulfilment")]
        public string strFulfilment { get; set; }
        [JsonProperty("strSide")]
        public string strSide { get; set; }
        [JsonProperty("strVenName")]
        public string strVenName { get; set; }
        [JsonProperty("strPONo")]
        public string strPONo { get; set; }
        [JsonProperty("dtStarDate")]
        public string dtStarDate { get; set; }
        [JsonProperty("dtEndDate")]
        public string dtEndDate { get; set; }
        [JsonProperty("strBuyerConName")]
        public string strBuyerConName { get; set; }
        [JsonProperty("strBuyerStatus")]
        public string strBuyerStatus { get; set; }
        [JsonProperty("strItemCode")]
        public string strItemCode { get; set; }
        [JsonProperty("strPOType")]
        public string strPOType { get; set; }
        [JsonProperty("strReliefOn")]
        public string strReliefOn { get; set; }
        [JsonProperty("strAORemark")]
        public string strAORemark { get; set; }
        [JsonProperty("Approvaltype")]
        public string Approvaltype { get; set; }
        [JsonProperty("strPOIndex")]
        public long strPOIndex { get; set; }
        [JsonProperty("strCoyID")]
        public string strCoyID { get; set; }
        [JsonProperty("blnhighestlevel")]
        public Boolean blnhighestlevel { get; set; }

        public virtual List<mapPO_DetailLine> detailline { get; set; }

    }
    public class mapPO_Detailitem
    {
        #region Display
        [JsonProperty("dom_do_no")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string DOM_DO_NO { get; set; }
        [JsonProperty("creationdate")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string CREATIONDATE { get; set; }
        [JsonProperty("submitondate")]
        [Grid(IsVisible = true, Width = 140)]
        public virtual string SUBMITIONDATE { get; set; }
        [JsonProperty("do_created_by")]
        [Grid(IsVisible = true, Width = 160)]
        public virtual string DO_CREATED_BY { get; set; }
        [JsonProperty("gm_grn_no")]
        [Grid(IsVisible = true, Width = 160)]
        public virtual string GM_GRN_NO { get; set; }
        [JsonProperty("gm_created_date")]
        [Grid(IsVisible = true, Width = 160)]
        public virtual string GM_CREATED_DATE { get; set; }
        [JsonProperty("gm_date_received")]
        [Grid(IsVisible = true, Width = 180)]
        public virtual string GM_DATE_RECEIVED { get; set; }
        [JsonProperty("gm1_created_by")]
        [Grid(IsVisible = true, Width = 160)]
        public virtual string GM1_CREATED_BY { get; set; }
        #endregion
    }

    public class mapDocAttachment
    {
        #region Display
        [JsonProperty("cda_attach_filename")]
        public virtual string CDA_ATTACH_FILENAME { get; set; }
        [JsonProperty("cda_type")]
        public virtual string CDA_TYPE { get; set; }
        [JsonProperty("cda_hub_filename")]
        public virtual string CDA_HUB_FILENAME { get; set; }

        #endregion
    }
    public class MapApprovalOrderListPO
    {
        [JsonProperty("pra_seq")]
        [Grid(IsVisible = true, Width = 50)]
        public virtual string PRA_SEQ { get; set; }
        [JsonProperty("ao_name")]
        [Grid(IsVisible = true, Width = 80)]
        public virtual string AO_NAME { get; set; }
        [JsonProperty("aao_name")]
        [Grid(IsVisible = true, Width = 80)]
        public virtual string AAO_NAME { get; set; }
        [JsonProperty("type")]
        [Grid(IsVisible = true, Width = 70)]
        public virtual string Type { get; set; }
        [JsonProperty("pra_action_date")]
        [Grid(IsVisible = true, Width = 80)]
        public virtual string PRA_ACTION_DATE { get; set; }
        [JsonProperty("pra_ao_remark")]
        [Grid(IsVisible = true, Width = 80)]
        public virtual string PRA_AO_REMARK { get; set; }
        [JsonProperty("pra_pr_index")]
        [Grid(IsVisible = false)]
        public virtual string PRA_PR_INDEX { get; set; }
        [JsonProperty("pra_ao")]
        [Grid(IsVisible = false)]
        public virtual string PRA_AO { get; set; }
        [JsonProperty("pra_a_ao")]
        [Grid(IsVisible = false)]
        public virtual string PRA_A_AO { get; set; }
        [JsonProperty("pra_active_ao")]
        [Grid(IsVisible = false)]
        public virtual string PRA_ACTIVE_AO { get; set; }
        [JsonProperty("pra_ao_action")]
        [Grid(IsVisible = false)]
        public virtual string PRA_AO_ACTION { get; set; }
        [JsonProperty("pra_approval_grp_index")]
        [Grid(IsVisible = false)]
        public virtual string PRA_APPROVAL_GRP_INDEX { get; set; }
        [JsonProperty("pra_on_behalfof")]
        [Grid(IsVisible = false)]
        public virtual string PRA_ON_BEHALFOF { get; set; }
        [JsonProperty("pra_relief_ind")]
        [Grid(IsVisible = false)]
        public virtual string PRA_RELIEF_IND { get; set; }
        [JsonProperty("pra_for")]
        [Grid(IsVisible = false)]
        public virtual string PRA_FOR { get; set; }
        [JsonProperty("ao_limit")]
        [Grid(IsVisible = false)]
        public virtual string AO_LIMIT { get; set; }
        [JsonProperty("aao_limit")]
        [Grid(IsVisible = false)]
        public virtual string AAO_LIMIT { get; set; }
    }
    public class MapApprovalOrderPO
    {
        [JsonProperty("prid")]
        public virtual string Prid { get; set; }
        [JsonProperty("ao")]
        public virtual string AO { get; set; }
        [JsonProperty("aao")]
        public virtual string AAO { get; set; }
        [JsonProperty("seq")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual string Seq { get; set; }
        [JsonProperty("AO_NAME")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual string AO_NAME { get; set; }
        [JsonProperty("AAO_NAME")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual string AAO_NAME { get; set; }
        [JsonProperty("type")]
        [Grid(IsVisible = true, Width = 100)]
        public virtual string Type { get; set; }
        [JsonProperty("grpindex")]
        public virtual int GrpIndex { get; set; }
        [JsonProperty("relief")]
        public virtual string Relief { get; set; }
        [JsonProperty("strType")]
        public virtual string strType { get; set; }

    }

    #endregion
    #endregion
}
