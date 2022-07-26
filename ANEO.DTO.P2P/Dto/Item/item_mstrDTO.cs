using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ANEO.DTO.P2P.Dto.Master
{
    #region items_mstrDTO
    [Table("items_mstrDTO")]
    public class items_mstrDTO
    {
        [Key]
        [Required]
        public virtual string PA_PRODUCT_INDEX { get; set; }
        [MaxLength(60)]
        public virtual string BCU_CAT_INDEX { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_CODE { get; set; }
        [MaxLength(100)]
        public virtual string PM_VENDOR_ITEM_CODE { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_DESC { get; set; }
        [MaxLength(60)]
        public virtual string CT_NAME { get; set; }
        [MaxLength(60)]
        public virtual string PM_UOM { get; set; }
        [MaxLength(60)]
        public virtual string PM_DELETED { get; set; }
    }
    #endregion

    #region item_mstrDTO
    [Table("item_mstrDTO")]
    public class item_mstrDTO
    {
        [Key]
        [Required]
        public virtual string PA_ATTACH_INDEX { get; set; }
        [MaxLength(60), Required]
        public virtual string PA_TYPE { get; set; }
        [MaxLength(100), Required]
        public virtual string PA_HUB_FILENAME { get; set; }
        [MaxLength(60), Required]
        public virtual string PA_SOURCE { get; set; }
        [MaxLength(60), Required]
        public virtual string PA_STATUS { get; set; }
        [MaxLength(100)]
        public virtual string PA_ATTACH_FILENAME { get; set; }
        [MaxLength(60)]
        public virtual string PA_FILESIZE { get; set; }
        [MaxLength(60)]
        public virtual string PA_DATE { get; set; }
        [MaxLength(60)]
        public virtual string PA_PRODUCT_CODE { get; set; }
    }
    #endregion

    #region BIM_mstrDTO
    [Table("BIM_mstrDTO")]
    public class BIM_mstrDTO
    {
        [Key]
        [Required]
        public virtual string SP_PARAM_VALUE { get; set; }
        [MaxLength(60), Required]
        public virtual string SP_PARAM_NAME { get; set; }
        [MaxLength(60)]
        public virtual string PM_S_COY_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_CODE { get; set; }
        [MaxLength(60)]
        public virtual string PM_VENDOR_ITEM_CODE { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_DESC { get; set; }
        [MaxLength(60)]
        public virtual string PM_REF_NO { get; set; }
        [MaxLength(60)]
        public virtual string PM_LONG_DESC { get; set; }
        [MaxLength(60)]
        public virtual string PM_CATEGORY_NAME { get; set; }
        [MaxLength(60)]
        public virtual string PM_ACCT_CODE { get; set; }

        [MaxLength(60), Required]
        public virtual string PM_UOM { get; set; }
        [MaxLength(60)]
        public virtual string PM_SAFE_QTY { get; set; }
        [MaxLength(60)]
        public virtual string PM_ORD_MIN_QTY { get; set; }
        [MaxLength(60)]
        public virtual string PM_ORD_MAX_QTY { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_BRAND { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_MODEL { get; set; }
        [MaxLength(60)]
        public virtual string PM_DRAW_NO { get; set; }
        [MaxLength(60)]
        public virtual string PM_VERS_NO { get; set; }
        [MaxLength(60)]
        public virtual string PM_GROSS_WEIGHT { get; set; }
        [MaxLength(60), Required]
        public virtual string PM_NET_WEIGHT { get; set; }

        [MaxLength(60)]
        public virtual string PM_LENGHT { get; set; }
        [MaxLength(60)]
        public virtual string PM_WIDTH { get; set; }
        [MaxLength(60)]
        public virtual string PM_HEIGHT { get; set; }
        [MaxLength(60)]
        public virtual string PM_VOLUME { get; set; }
        [MaxLength(60)]
        public virtual string PM_COLOR_INFO { get; set; }
        [MaxLength(60)]
        public virtual string PM_HSC_CODE { get; set; }
        [MaxLength(60)]
        public virtual string PM_PACKING_REQ { get; set; }
        [MaxLength(60)]
        public virtual string PM_REMARKS { get; set; }
        [MaxLength(60), Required]
        public virtual string PM_PREFER_S_COY_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_1ST_S_COY_ID { get; set; }

        [MaxLength(60)]
        public virtual string PM_2ND_S_COY_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_3RD_S_COY_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_DELETED { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_FOR { get; set; }
        [MaxLength(60)]
        public virtual string PM_ENT_BY { get; set; }
        [MaxLength(60)]
        public virtual string PM_ENT_DT { get; set; }
        [MaxLength(60)]
        public virtual string PM_PREFER_S_COY_ID_TAX_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_1ST_S_COY_ID_TAX_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_2ND_S_COY_ID_TAX_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_3RD_S_COY_ID_TAX_ID { get; set; }
        [MaxLength(60)]
        public virtual string PM_ITEM_TYPE { get; set; }
        [MaxLength(60)]
        public virtual string PM_IQC_IND { get; set; }
        [MaxLength(60)]
        public virtual string PM_MAX_INV_QTY { get; set; }
        [MaxLength(60)]
        public virtual string PM_MANUFACTURER { get; set; }
        [MaxLength(60)]
        public virtual string PM_CAT_CODE { get; set; }
        [MaxLength(60)]
        public string PV_PRODUCT_INDEX { get; set; }
        [MaxLength(60)]
        public string PV_VENDOR_TYPE { get; set; }
        [MaxLength(60)]
        public string PV_LEAD_TIME { get; set; }
        [MaxLength(60)]
        public string PV_VENDOR_CODE { get; set; }
        [MaxLength(60)]
        public string PV_ENT_BY { get; set; }
        [MaxLength(60)]
        public string PV_ENT_DATETIME { get; set; }
        [MaxLength(100)]
        public virtual string PA_ATTACH_FILENAME { get; set; }
        [MaxLength(60)]
        public virtual string PA_PRODUCT_CODE { get; set; }
        [MaxLength(60), Required]
        public virtual string PA_TYPE { get; set; }
        [MaxLength(100), Required]
        public virtual string PA_HUB_FILENAME { get; set; }
        [MaxLength(60)]
        public virtual string PA_FILESIZE { get; set; }
        [MaxLength(60), Required]
        public virtual string PA_STATUS { get; set; }
        [MaxLength(60), Required]
        public virtual string PA_SOURCE { get; set; }
        [MaxLength(60), Required]
        public virtual string PA_ATTACH_INDEX { get; set; }
        [MaxLength(60)]
        public virtual string PM_PRODUCT_IMAGE { get; set; }
        [MaxLength(60)]
        public virtual string IM_COY_ID { get; set; }
        [MaxLength(60)]
        public virtual string IM_ITEM_CODE { get; set; }
        [MaxLength(60)]
        public virtual string IM_INVENTORY_INDEX { get; set; }
        [MaxLength(60)]
        public virtual string IM_INVENTORY_NAME { get; set; }
        [MaxLength(60)]
        public virtual string IM_IQC_IND { get; set; }
        [MaxLength(60)]
        public virtual string ID_INVENTORY_INDEX { get; set; }
        [MaxLength(60)]
        public virtual string BCM_B_COY_ID { get; set; }
        [MaxLength(60)]
        public virtual string BCM_CAT_INDEX { get; set; }
        [MaxLength(60)]
        public virtual string BCU_PRODUCT_CODE { get; set; }
        [MaxLength(60)]
        public virtual string BCM_GRP_DESC { get; set; }
        [MaxLength(60)]
        public virtual string BCU_ENT_DATETIME { get; set; }
        [MaxLength(60)]
        public virtual string BCU_ENT_BY { get; set; }
        [MaxLength(60)]
        public virtual string BCU_S_COY_ID { get; set; }
        [MaxLength(60)]
        public virtual string BCU_SOURCE { get; set; }
        [MaxLength(60)]
        public virtual string BCU_CAT_INDEX { get; set; }
        [MaxLength(60)]
        public virtual string PV_MOD_DATETIME { get; set; }
        [MaxLength(60)]
        public virtual string PV_MOD_BY { get; set; }
        [MaxLength(60)]
        public virtual string PM_MOD_DT { get; set; }
    }
    #endregion
    #region COMPANY_B_CATEGORY_CODE 
    [Table("company_b_category_code")]
    //[Audited]
    public class COMPANY_B_CATEGORY_CODE
    {
        [Key]
        [MaxLength(60), Required]
        public virtual string CBC_B_COY_ID { get; set; }
        [Key]
        [MaxLength(300), Required]
        public virtual string CBC_B_CATEGORY_CODE { get; set; }
    }
    #endregion

}
