using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ANEO.DTO.P2P.Master.BuyerCategory_mstr
{
	#region BUYER_CATALOGUE_ITEMS
	[Table("buyer_catalogue_items")]
	//[Audited]
	public class BUYER_CATALOGUE_ITEMS
	{
		[Key]
		[Required]
		public virtual long? BCI_ITEM_INDEX { get; set; }
		[Required]
		public virtual long? BCU_CAT_INDEX { get; set; }
		[MaxLength(60), Required]
		public virtual string BCU_PRODUCT_CODE { get; set; }
		[MaxLength(6), Required]
		public virtual string BCU_SOURCE { get; set; }
		[MaxLength(60)]
		public virtual string BCU_S_COY_ID { get; set; }

		public virtual long? BCU_CD_GROUP_INDEX { get; set; }
		[MaxLength(60)]
		public virtual string BCU_ENT_BY { get; set; }
		[Column(TypeName = "datetime")]
		public virtual System.DateTime? BCU_ENT_DATETIME { get; set; }
	}
	#endregion

}
