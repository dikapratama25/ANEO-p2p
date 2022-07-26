using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;

namespace ANEO.Base.P2P.Master.Map.address_mstr
{
	#region ADDRESS_MSTR
	[Abp.AutoMapper.AutoMapTo(typeof(ANEO.DTO.P2P.Master.address_mstr.ADDRESS_MSTR))]
	public class MapADDRESS_MSTR : BaseMapId
	{
		[JsonProperty("am_addr_index")]
		[Required]
		[Grid(IsVisible = false)]
		public virtual long? AM_ADDR_INDEX { get; set; }
		[JsonProperty("am_coy_id")]
		[MaxLength(60)]
		[Grid(IsVisible = false)]
		public virtual string AM_COY_ID { get; set; }
		[JsonProperty("am_addr_code")]
		[MaxLength(60)]
		[Grid(Width = 150)]
		public virtual string AM_ADDR_CODE { get; set; }
		[JsonProperty("am_addr_line1")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string AM_ADDR_LINE1 { get; set; }
		[JsonProperty("am_addr_line2")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string AM_ADDR_LINE2 { get; set; }
		[JsonProperty("am_addr_line3")]
		[MaxLength(150)]
		[Grid(IsVisible = false)]
		public virtual string AM_ADDR_LINE3 { get; set; }
		[JsonProperty("am_postcode")]
		[MaxLength(30)]
		[Grid(Width = 150)]
		public virtual string AM_POSTCODE { get; set; }
		[JsonProperty("am_city")]
		[MaxLength(60)]
		[Grid(Width = 150)]
		public virtual string AM_CITY { get; set; }
		[JsonProperty("am_state")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string AM_STATE { get; set; }
		[JsonProperty("am_country")]
		[MaxLength(30)]
		[Grid(IsVisible = false)]
		public virtual string AM_COUNTRY { get; set; }
		[JsonProperty("am_addr_type")]
		[MaxLength(3)]
		[Grid(IsVisible = false)]
		public virtual string AM_ADDR_TYPE { get; set; }
	}
	#endregion
}
