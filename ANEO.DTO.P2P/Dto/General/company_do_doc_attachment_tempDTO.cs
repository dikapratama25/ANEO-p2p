using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.company_do_doc_attachment_temp
{
	#region COMPANY_DO_DOC_ATTACHMENT_TEMP
	[Table("company_do_doc_attachment_temp")]
	//[Audited]
	public class COMPANY_DO_DOC_ATTACHMENT_TEMP
	{
		[Key]
		[Required]
		public virtual long? CDDA_ATTACH_INDEX { get; set; }
		[MaxLength(60)]
		public virtual string CDDA_COY_ID { get; set; }
		[MaxLength(150)]
		public virtual string CDDA_DOC_NO { get; set; }

		public virtual int? CDDA_PO_LINE { get; set; }
		[MaxLength(300)]
		public virtual string CDDA_ITEM_CODE { get; set; }
		[MaxLength(150)]
		public virtual string CDDA_HUB_FILENAME { get; set; }
		[MaxLength(300)]
		public virtual string CDDA_ATTACH_FILENAME { get; set; }

		public virtual decimal? CDDA_FILESIZE { get; set; }
		[MaxLength(3)]
		public virtual string CDDA_TYPE { get; set; }
		[MaxLength(3)]
		public virtual string CDDA_STATUS { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? CDDA_DATE { get; set; }

		public virtual long? CDDA_LOT_INDEX { get; set; }

		public virtual long? CDDA_LINE_NO { get; set; }
	}
	#endregion
}
