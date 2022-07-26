using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.approval_grp_ao
{
	#region APPROVAL_GRP_AO
	[Table("approval_grp_ao")]
	//[Audited]
	public class APPROVAL_GRP_AO
	{
		[Key]
		[Required]
		public virtual long? AGA_GRP_INDEX { get; set; }
		[Key]
		[Required]
		public virtual int? AGA_SEQ { get; set; }
		[MaxLength(60), Required]
		public virtual string AGA_AO { get; set; }
		[MaxLength(60)]
		public virtual string AGA_A_AO { get; set; }
		[MaxLength(3)]
		public virtual string AGA_RELIEF_IND { get; set; }
		[MaxLength(30)]
		public virtual string aga_branch_code { get; set; }
		[MaxLength(90)]
		public virtual string aga_cc_code { get; set; }
	}
	#endregion
}