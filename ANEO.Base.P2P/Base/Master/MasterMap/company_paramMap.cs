using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.company_param
{
	#region COMPANY_PARAM
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.company_param.COMPANY_PARAM))]
	public class MapCOMPANY_PARAM : BaseMapId
	{
		[JsonProperty("cp_index")]
		[Required]
		public virtual int? CP_INDEX { get; set; }
		[JsonProperty("cp_coy_id")]
		[MaxLength(60)]
		public virtual string CP_COY_ID { get; set; }
		[JsonProperty("cp_param_name")]
		[MaxLength(60)]
		public virtual string CP_PARAM_NAME { get; set; }
		[JsonProperty("cp_param_value")]
		[MaxLength(150)]
		public virtual string CP_PARAM_VALUE { get; set; }
		[JsonProperty("cp_param_type")]
		[MaxLength(45)]
		public virtual string CP_PARAM_TYPE { get; set; }
		[JsonProperty("cp_app_pkg")]
		[MaxLength(30)]
		public virtual string CP_APP_PKG { get; set; }
	}
	#endregion
}
