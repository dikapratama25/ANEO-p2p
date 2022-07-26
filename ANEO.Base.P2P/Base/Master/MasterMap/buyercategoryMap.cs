using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using LOGIC.Base;
using System.Collections.Generic;
using Plexform.Base;


namespace ANEO.Base.P2P.Master.Map.BuyerCategoryMap
{
    [Abp.AutoMapper.AutoMapTo(typeof(AgoraNEO.AgoraNEO.BuyerCat))]
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MapBuyerCat : BaseMapId
    {
        [JsonProperty("productcode")]
        [Grid(Width = 150)]
        public virtual string ProductCode { get; set; }
        [JsonProperty("VendorItemCode")]
        [Grid(Width = 150)]
        public virtual string VendorItemCode { get; set; }
        [JsonProperty("productdesc")]
        [Grid(Width = 150)]
        public virtual string ProductDesc { get; set; }
        [JsonProperty("currency")]
        [Grid(Width = 150)]
        public virtual string Currency { get; set; }
        [JsonProperty("txnprice")]
        [Grid(Width = 150, Alignment =ColumnsAlignment.Right, DecimalPlaces = 2 )]
        public virtual decimal TxnPrice { get; set; }
        [JsonProperty("pm_last_txn_s_coy_id")]
        [Grid(Width = 150)]
        public virtual string pm_last_txn_s_coy_id { get; set; }

    }
}
