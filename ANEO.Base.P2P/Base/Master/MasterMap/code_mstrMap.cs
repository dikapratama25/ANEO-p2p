using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.code_mstr
{
	#region CODE_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.code_mstr.CODE_MSTR))]
	public class MapCODE_MSTR : BaseMapId
	{
		[JsonProperty("code_index")]
		[Required]
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
	}
	#endregion
}
