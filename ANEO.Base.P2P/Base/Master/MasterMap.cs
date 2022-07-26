using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map
{
	#region USERS_USRGRP
	public class MapUSERS_USRGRP : BaseMapId
	{
		[JsonProperty("uu_usrgrp_id")]
		public virtual string UU_USRGRP_ID { get; set; }
		[JsonProperty("uu_coy_id")]
		public virtual string UU_COY_ID { get; set; }
		[JsonProperty("uu_user_id")]
		public virtual string UU_USER_ID { get; set; }
		[JsonProperty("uu_app_pkg")]
		public virtual string UU_APP_PKG { get; set; }
		[JsonProperty("uu_mod_by")]
		public virtual string UU_MOD_BY { get; set; }
	}
	#endregion

	#region USER_GROUP_MSTR
	
	public class MapPR : BaseMapId
	{
		[JsonProperty("PRM_PR_No")]
		[MaxLength(90)]
		public virtual string PRNo { get; set; }
		[JsonProperty("prm_pr_type")]
		[MaxLength(300)]
		public virtual string PRType { get; set; }
	}
	#endregion
}