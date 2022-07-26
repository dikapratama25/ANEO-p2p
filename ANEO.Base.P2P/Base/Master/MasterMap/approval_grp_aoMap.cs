using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.MasterMap.approval_grp_ao
{
	#region APPROVAL_GRP_AO
	[Abp.AutoMapper.AutoMapTo(typeof(ANEO.DTO.P2P.Master.approval_grp_ao.APPROVAL_GRP_AO))]
	public class MapAPPROVAL_GRP_AO : BaseMapId
	{
		[JsonProperty("aga_grp_index")]
		[Required]
		public virtual long? AGA_GRP_INDEX { get; set; }
		[JsonProperty("aga_seq")]
		[Required]
		public virtual int? AGA_SEQ { get; set; }
		[JsonProperty("aga_ao")]
		[MaxLength(60)]
		public virtual string AGA_AO { get; set; }
		[JsonProperty("aga_a_ao")]
		[MaxLength(60)]
		public virtual string AGA_A_AO { get; set; }
		[JsonProperty("aga_relief_ind")]
		[MaxLength(3)]
		public virtual string AGA_RELIEF_IND { get; set; }
		[JsonProperty("aga_branch_code")]
		[MaxLength(30)]
		public virtual string aga_branch_code { get; set; }
		[JsonProperty("aga_cc_code")]
		[MaxLength(90)]
		public virtual string aga_cc_code { get; set; }
	}
	#endregion
}
