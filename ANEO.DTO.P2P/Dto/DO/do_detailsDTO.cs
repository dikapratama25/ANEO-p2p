using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.do_details
{
	#region DO_DETAILS
	[Table("do_details")]
	//[Audited]
	public class DO_DETAILS
	{
		[Key]
		[MaxLength(60), Required]
		public virtual string DOD_S_COY_ID { get; set; }
		[Key]
		[MaxLength(150), Required]
		public virtual string DOD_DO_NO { get; set; }
		[Key]
		[Required]
		public virtual int? DOD_DO_LINE { get; set; }
		[Required]
		public virtual int? DOD_PO_LINE { get; set; }
		[Required]
		public virtual decimal? DOD_DO_QTY { get; set; }

		public virtual decimal? DOD_SHIPPED_QTY { get; set; }
		[MaxLength(1200)]
		public virtual string DOD_REMARKS { get; set; }

		public virtual int? DOD_DO_LOT_NO { get; set; }
	}
	#endregion
}
