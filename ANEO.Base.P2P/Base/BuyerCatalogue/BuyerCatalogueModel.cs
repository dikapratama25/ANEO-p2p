using Newtonsoft.Json;
using Plexform.Base;

namespace ANEO.Base.P2P.BuyerCatalogue.Model
{
	[Abp.AutoMapper.AutoMapTo(typeof(AgoraNEO.AgoraNEO.BuyerCat))]
	[JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
	public class BuyerCatModel : BaseMapId
	{
		public virtual string UserID { get; set; }
		[JsonProperty("CompanyID")]
		public virtual string CompanyID { get; set; }
		[JsonProperty("pCatIndex")]
		public virtual string pCatIndex { get; set; }
		[JsonProperty("pItemCode")]
		public virtual string pItemCode { get; set; }
		[JsonProperty("pItemName")]
		public virtual string pItemName { get; set; }
		[JsonProperty("pGroup")]
		public bool pGroup { get; set; }
		[JsonProperty("pItemType")]
		public virtual string pItemType { get; set; }
		[JsonProperty("pComType")]
		public virtual string pComType { get; set; }
		[JsonProperty("strVendorName")]
		public virtual string strVendorName { get; set; }
	}
}
