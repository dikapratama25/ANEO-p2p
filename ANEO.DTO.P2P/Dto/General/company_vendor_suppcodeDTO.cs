using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Dto.Master.company_vendor_suppcode
{
	#region COMPANY_VENDOR_SUPPCODE
	[Table("company_vendor_suppcode")]
	//[Audited]
	public class COMPANY_VENDOR_SUPPCODE
	{
		[Key]
		[MaxLength(60), Required]
		public virtual string CVS_B_COY_ID { get; set; }
		[Key]
		[MaxLength(60), Required]
		public virtual string CVS_S_COY_ID { get; set; }
		[Key]
		[MaxLength(60), Required]
		public virtual string CVS_SUPP_CODE { get; set; }
		[MaxLength(60)]
		public virtual string CVS_DELIVERY_TERM { get; set; }
		[MaxLength(60)]
		public virtual string CVS_CURR { get; set; }
	}
	#endregion

}
