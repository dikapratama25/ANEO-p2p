using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.company_param
{
	#region COMPANY_PARAM
	[Table("company_param")]
	//[Audited]
	public class COMPANY_PARAM
	{
		[Key]
		[Required]
		public virtual int? CP_INDEX { get; set; }
		[MaxLength(60)]
		public virtual string CP_COY_ID { get; set; }
		[MaxLength(60), Required]
		public virtual string CP_PARAM_NAME { get; set; }
		[MaxLength(150)]
		public virtual string CP_PARAM_VALUE { get; set; }
		[MaxLength(45)]
		public virtual string CP_PARAM_TYPE { get; set; }
		[MaxLength(30)]
		public virtual string CP_APP_PKG { get; set; }
	}
	#endregion
}
