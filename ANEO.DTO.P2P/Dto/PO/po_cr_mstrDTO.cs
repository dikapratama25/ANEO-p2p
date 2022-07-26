using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ANEO.DTO.P2P.Dto.Master
{
	#region PO_CR_MSTR
	[Table("po_cr_mstr")]
	//[Audited]
	public class PO_CR_MSTR
	{
		[Key]
		[MaxLength(150), Required]
		public virtual string PCM_CR_NO { get; set; }
		[Key]
		[MaxLength(60), Required]
		public virtual string PCM_B_COY_ID { get; set; }
		[MaxLength(30)]
		public virtual string PCM_S_COY_ID { get; set; }

		public virtual int? PCM_PO_INDEX { get; set; }

		public virtual int? PCM_CR_STATUS { get; set; }
		[MaxLength(60)]
		public virtual string PCM_REQ_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? PCM_REQ_DATE { get; set; }
		[MaxLength(3000)]
		public virtual string PCM_CR_REMARKS { get; set; }
	}
	#endregion
}
