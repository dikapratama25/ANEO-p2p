using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.company_doc_attachment
{
	#region COMPANY_DOC_ATTACHMENT
	[Abp.AutoMapper.AutoMapTo(typeof(DTO.P2P.Master.company_doc_attachment.COMPANY_DOC_ATTACHMENT))]
	public class MapCOMPANY_DOC_ATTACHMENT : BaseMapId
	{
		[JsonProperty("cda_attach_index")]
		[Grid(IsVisible = false)]
		[Required]
		public virtual long? CDA_ATTACH_INDEX { get; set; }
		[JsonProperty("cda_coy_id")]
		[Grid(IsVisible = false)]
		[MaxLength(60)]
		public virtual string CDA_COY_ID { get; set; }
		[JsonProperty("cda_doc_no")]
		[Grid(IsVisible = false)]
		[MaxLength(150)]
		public virtual string CDA_DOC_NO { get; set; }
		[JsonProperty("cda_doc_type")]
		[Grid(IsVisible = false)]
		[MaxLength(30)]
		public virtual string CDA_DOC_TYPE { get; set; }
		[JsonProperty("cda_hub_filename")]
		[Grid(IsVisible = false)]
		[MaxLength(150)]
		public virtual string CDA_HUB_FILENAME { get; set; }
		[JsonProperty("cda_attach_filename")]
		[Grid(Width = 150)]
		[MaxLength(300)]
		public virtual string CDA_ATTACH_FILENAME { get; set; }
		[JsonProperty("cda_filesize")]
		[Grid(IsVisible = false)]
		public virtual decimal? CDA_FILESIZE { get; set; }
		[JsonProperty("cda_type")]
		[Grid(IsVisible = false)]
		[MaxLength(3)]
		public virtual string CDA_TYPE { get; set; }
		[JsonProperty("cda_status")]
		[Grid(IsVisible = false)]
		[MaxLength(3)]
		public virtual string CDA_STATUS { get; set; }
	}

	public class MapFileAttachment : MapCOMPANY_DOC_ATTACHMENT
	{
		[JsonProperty("userid")]
		[Grid(IsVisible = false)]
		[Required]
		public virtual string UserID { get; set; }
		[JsonProperty("type")]
		[Grid(IsVisible = false)]
		public virtual string Type { get; set; }
		[JsonProperty("pathref")]
		public virtual string PathRef { get; set; }
		[JsonProperty("lineno")]
		public virtual int LineNo { get; set; }
	}
	#endregion
}