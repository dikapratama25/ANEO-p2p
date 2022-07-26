using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.code_mstr
{
	#region CODE_MSTR
	[Table("code_mstr")]
	//[Audited]
	public class CODE_MSTR
	{
		[Key]
		[Required]
		public virtual long? CODE_INDEX { get; set; }
		[MaxLength(30), Required]
		public virtual string CODE_ABBR { get; set; }
		[MaxLength(150)]
		public virtual string CODE_DESC { get; set; }
		[MaxLength(90)]
		public virtual string CODE_VALUE { get; set; }
		[MaxLength(15), Required]
		public virtual string CODE_CATEGORY { get; set; }
		[MaxLength(3), Required]
		public virtual string CODE_DELETED { get; set; }
	}
	#endregion
}
