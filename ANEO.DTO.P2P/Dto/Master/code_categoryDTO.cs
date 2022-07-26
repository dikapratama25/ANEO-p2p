using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.code_category
{
	#region CODE_CATEGORY
	[Table("code_category")]
	//[Audited]
	public class CODE_CATEGORY
	{
		[Key]
		[Required]
		public virtual int? CC_INDEX { get; set; }
		[MaxLength(15), Required]
		public virtual string CC_CODE { get; set; }
		[MaxLength(150)]
		public virtual string CC_DESC { get; set; }
		[MaxLength(30)]
		public virtual string CC_DEFAULT_CODE { get; set; }
		[MaxLength(3), Required]
		public virtual string CC_COY_DEFAULT { get; set; }
		[MaxLength(3), Required]
		public virtual string CC_USER_DEFAULT { get; set; }
		[MaxLength(150)]
		public virtual string CC_REMARK { get; set; }
	}
	#endregion
}
