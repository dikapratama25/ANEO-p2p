using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.do_mstr
{
	#region DO_MSTR
	[Table("do_mstr")]
	//[Audited]
	public class DO_MSTR
	{
		[Key]
		[Required]
		public virtual long? DOM_DO_INDEX { get; set; }
		[MaxLength(150), Required]
		public virtual string DOM_DO_NO { get; set; }
		[MaxLength(60), Required]
		public virtual string DOM_S_COY_ID { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? DOM_DO_DATE { get; set; }
		[MaxLength(120)]
		public virtual string DOM_S_REF_NO { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? DOM_S_REF_DATE { get; set; }

		public virtual long? DOM_PO_INDEX { get; set; }
		[MaxLength(90)]
		public virtual string DOM_WAYBILL_NO { get; set; }
		[MaxLength(90)]
		public virtual string DOM_FREIGHT_CARRIER { get; set; }

		public virtual decimal? DOM_FREIGHT_AMT { get; set; }
		[MaxLength(3000)]
		public virtual string DOM_DO_REMARKS { get; set; }

		public virtual int? DOM_DO_STATUS { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? DOM_CREATED_DATE { get; set; }
		[MaxLength(150)]
		public virtual string DOM_CREATED_BY { get; set; }

		public virtual short? DOM_NOOFCOPY_PRINTED { get; set; }
		[MaxLength(90)]
		public virtual string DOM_DO_PREFIX { get; set; }
		[MaxLength(60)]
		public virtual string DOM_D_ADDR_CODE { get; set; }
		[MaxLength(150)]
		public virtual string DOM_D_ADDR_LINE1 { get; set; }
		[MaxLength(150)]
		public virtual string DOM_D_ADDR_LINE2 { get; set; }
		[MaxLength(150)]
		public virtual string DOM_D_ADDR_LINE3 { get; set; }
		[MaxLength(30)]
		public virtual string DOM_D_POSTCODE { get; set; }
		[MaxLength(90)]
		public virtual string DOM_D_CITY { get; set; }
		[MaxLength(60)]
		public virtual string DOM_D_STATE { get; set; }
		[MaxLength(30)]
		public virtual string DOM_D_COUNTRY { get; set; }
		[MaxLength(3)]
		public virtual string DOM_EXTERNAL_IND { get; set; }
		[MaxLength(150)]
		public virtual string DOM_REFERENCE_NO { get; set; }
	}
	#endregion
}
