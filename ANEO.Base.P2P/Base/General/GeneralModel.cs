using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;
using Plexform.Base.Core.Filter;
using LOGIC.Shared.Collection;

namespace ANEO.Base.P2P.General.Model
{
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class MapADDRESS : Master.Map.address_mstr.MapADDRESS_MSTR
	{
		[JsonProperty("state")]
		[Grid(Width = 150)]
		public virtual string STATE { get; set; }
		[JsonProperty("country")]
		[Grid(Width = 150)]
		public virtual string COUNTRY { get; set; }
		[JsonProperty("fulladdress")]
		[Grid(Width = 600)]
		public virtual string FullAddress { get; set; }
	}

	public class ResultContainer 
	{
		public string StrMessage;
		public bool Status;

		public ResultContainer(string StrMessage, bool Status)
		{
			this.StrMessage = StrMessage;
			this.Status =  Status;
		}
	}
}
