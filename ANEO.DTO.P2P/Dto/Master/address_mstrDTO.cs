using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Master.address_mstr
{
	#region ADDRESS_MSTR
	[Table("address_mstr")]
	//[Audited]
	public class ADDRESS_MSTR
	{
		[Key]
		[Required]
		public virtual long? AM_ADDR_INDEX { get; set; }
		[MaxLength(60), Required]
		public virtual string AM_COY_ID { get; set; }
		[MaxLength(60), Required]
		public virtual string AM_ADDR_CODE { get; set; }
		[MaxLength(150), Required]
		public virtual string AM_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string AM_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string AM_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string AM_POSTCODE { get; set; }
		[MaxLength(60)]
		public virtual string AM_CITY { get; set; }
		[MaxLength(30)]
		public virtual string AM_STATE { get; set; }
		[MaxLength(30), Required]
		public virtual string AM_COUNTRY { get; set; }
		[MaxLength(3), Required]
		public virtual string AM_ADDR_TYPE { get; set; }
	}
	#endregion
}
