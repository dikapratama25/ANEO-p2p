/*----- RFQMap.cs -----*/
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;
using ANEO.Base.P2P.General.Map;


namespace ANEO.Base.P2P.RFQ.Map
{
	#region RFQ_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(ANEO.DTO.P2P.Master.rfq_mstr.RFQ_MSTR))]
	public class MapRFQ_MSTR : MapGeneral
	{
		[JsonProperty("strPRNo")]
		[Required]
		public virtual string strPRNo { get; set; }
		[JsonProperty("strVendor ")]
		[MaxLength(60)]
		public virtual string strVendor { get; set; }
		[JsonProperty("strUserID")]
		[MaxLength(120)]
		public virtual string strUserID { get; set; }
		[JsonProperty("strPRIndex")]
		[MaxLength(120)]
		public virtual long strPRIndex { get; set; }
		[JsonProperty("strItemLine")]
		[MaxLength(300)]
		public virtual string strItemLine { get; set; }
		[JsonProperty("PRList")]
		[MaxLength(300)]
		public System.Collections.ArrayList  PRList {get; set;}
		
	}
	#endregion
}