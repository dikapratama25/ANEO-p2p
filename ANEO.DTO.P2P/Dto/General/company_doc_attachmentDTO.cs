using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Plexform.Base;
using Plexform.Audit;

namespace ANEO.DTO.P2P.Master.company_doc_attachment
{
	#region COMPANY_DOC_ATTACHMENT
	[Table("company_doc_attachment")]
	//[Audited]
	public class COMPANY_DOC_ATTACHMENT
	{
		[Key]
		[Required]
		public virtual long? CDA_ATTACH_INDEX { get; set; }
		[MaxLength(60)]
		public virtual string CDA_COY_ID { get; set; }
		[MaxLength(150)]
		public virtual string CDA_DOC_NO { get; set; }
		[MaxLength(30)]
		public virtual string CDA_DOC_TYPE { get; set; }
		[MaxLength(150)]
		public virtual string CDA_HUB_FILENAME { get; set; }
		[MaxLength(300)]
		public virtual string CDA_ATTACH_FILENAME { get; set; }

		public virtual decimal? CDA_FILESIZE { get; set; }
		[MaxLength(3)]
		public virtual string CDA_TYPE { get; set; }
		[MaxLength(3)]
		public virtual string CDA_STATUS { get; set; }
	}
	#endregion
}