using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.user_group_mstr
{
	#region USER_GROUP_MSTR
	[Table("user_group_mstr")]
	//[Audited]
	public class USER_GROUP_MSTR
	{
		[Key]
		[Required]
		public virtual long? UGM_AUTO_NO { get; set; }
		[MaxLength(90), Required]
		public virtual string UGM_USRGRP_ID { get; set; }
		[MaxLength(300), Required]
		public virtual string UGM_USRGRP_NAME { get; set; }
		[MaxLength(90)]
		public virtual string UGM_FIXED_ROLE { get; set; }
		[MaxLength(90)]
		public virtual string UGM_TYPE { get; set; }
		[MaxLength(3), Required]
		public virtual string UGM_DELETED { get; set; }
		[MaxLength(30)]
		public virtual string UGM_ENT_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UGM_ENT_DT { get; set; }
		[MaxLength(30)]
		public virtual string UGM_MOD_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? UGM_MOD_DT { get; set; }
		[MaxLength(30), Required]
		public virtual string UGM_APP_PKG { get; set; }
	}
	#endregion
}
