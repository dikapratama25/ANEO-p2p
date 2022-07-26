using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.user_group_mstr
{
	#region USER_GROUP_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.user_group_mstr.USER_GROUP_MSTR))]
	public class MapUSER_GROUP_MSTR : BaseMapId
	{
		[JsonProperty("ugm_usrgrp_id")]
		[MaxLength(90)]
		public virtual string ID { get; set; }
		[JsonProperty("ugm_usrgrp_name")]
		[MaxLength(300)]
		public virtual string UserGroupName { get; set; }
	}
    #endregion
}
