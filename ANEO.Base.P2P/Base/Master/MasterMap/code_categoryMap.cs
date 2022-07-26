using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.code_category
{
	#region CODE_CATEGORY
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.code_category.CODE_CATEGORY))]
	public class MapCODE_CATEGORY : BaseMapId
	{
		[JsonProperty("cc_index")]
		[Required]
		public virtual int? CC_INDEX { get; set; }
		[JsonProperty("cc_code")]
		[MaxLength(15)]
		public virtual string CC_CODE { get; set; }
		[JsonProperty("cc_desc")]
		[MaxLength(150)]
		public virtual string CC_DESC { get; set; }
		[JsonProperty("cc_default_code")]
		[MaxLength(30)]
		public virtual string CC_DEFAULT_CODE { get; set; }
		[JsonProperty("cc_coy_default")]
		[MaxLength(3)]
		public virtual string CC_COY_DEFAULT { get; set; }
		[JsonProperty("cc_user_default")]
		[MaxLength(3)]
		public virtual string CC_USER_DEFAULT { get; set; }
		[JsonProperty("cc_remark")]
		[MaxLength(150)]
		public virtual string CC_REMARK { get; set; }
	}
	#endregion
}
