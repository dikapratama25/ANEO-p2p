using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.company_vendor_suppcodeMap
{
    #region COMPANY_VENDOR_SUPPCODE
    [Abp.AutoMapper.AutoMapTo(typeof(AgoraNEO.AgoraNEO.Admin_Ext))]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MapCOMPANY_VENDOR_SUPPCODE
    {
        [JsonProperty("cvs_b_coy_id")]
        [MaxLength(60), Required]
        public virtual string CVS_B_COY_ID { get; set; }
        [JsonProperty("cvs_s_coy_id")]
        [MaxLength(60), Required]
        public virtual string CVS_S_COY_ID { get; set; }
        [JsonProperty("cvs_supp_code")]
        [MaxLength(60), Required]
        public virtual string CVS_SUPP_CODE { get; set; }
        [JsonProperty("cvs_delivery_term")]
        [MaxLength(60)]
        public virtual string CVS_DELIVERY_TERM { get; set; }
        [JsonProperty("cvs_curr")]
        [MaxLength(60)]
        public virtual string CVS_CURR { get; set; }
        [JsonProperty("strvendorid")]
        public virtual string StrVendorID { get; set; }
        [JsonProperty("arylist")]
        public virtual System.Collections.ArrayList AryList { get; set; }
        [JsonProperty("companyid")]
        public virtual string CompanyID { get; set; }
    }
    #endregion
}
