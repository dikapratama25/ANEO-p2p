using System;
using LOGIC.Shared.Collection;
using System.Collections.Generic;
using Plexform.Base;
using Newtonsoft.Json;
using System.Data;
using AgoraNEO.AgoraNEO;
using System.Collections;

namespace ANEO.Base.P2P.Filter
{
    public class GetMasterCode : GetListParameter
    {
        public string BizRegID { get; set; }
        public string Affiliate { get; set; }
        public string Campaign { get; set; }
        public byte Category { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public class GetBuyerCatListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string pCatIndex { get; set; }
        public string pComType { get; set; }
        public string pName { get; set; }
        public string strItemCode { get; set; }
        public string dteDateFr { get; set; }
        public string dteDateTo { get; set; }
        public string strRole { get; set; }
        public string strBuyer { get; set; }
        public string strStatus { get; set; }
        public string strPRType { get; set; }
        public string strStatus2 { get; set; }
        public string userID { get; set; }
        public string CompanyID { get; set; }
        public  string pItemType { get; set; }

    }

    public class GetP2PListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }
        public string strType { get; set; }
        public string strValue { get; set; }
        public string strCode { get; set; }
        public string strCity { get; set; }
        public string strState { get; set; }
        public string strName { get; set; }
        public string strModule { get; set; }
        public string strProdCode { get; set; }
        public string strVendorID { get; set; }
        public int intRow { get; set; }
        public string strApprovalType { get; set; }
        public string pItemCode { get; set; }
        public double dblPRTotal { get; set; }
        public string strDept { get; set; }
        public string strPR { get; set; }
        public string status { get; set; }
        public long strIndex { get; set; }
        public string strRemark { get; set; }
    }
    public class GetDOListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string strDocType { get; set; }
        public string strDocNo { get; set; }
        public string strDONo { get; set; }
        public string strPONo { get; set; }
        public int  POIndex { get; set; }
        public string AddrCode { get; set; }
        public string strBCoyID { get; set; }

        public string strCreationDt { get; set; }
        public string strSubmittedDt { get; set; }
        public string strOurRef { get; set; }
        public string strBuyerComp { get; set; }
        public string strVenItem { get; set; }
        public string strStatus { get; set; }
        public string strType { get; set; }
        public string strIndex { get; set; }
    }
    public class GetGRNListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }
        public string strDONo { get; set; }
        public string strPONo { get; set; }
        public int strDOIdx { get; set; }
        public int strPOIdx { get; set; }
        public string strSCoyID { get; set; }
        public List<GRNDetailList> dataRemark { get; set; }
    }
    public class GetGRNParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }
        public string strDocType { get; set; }
        public string strNo { get; set; }
        public string strCreationDt { get; set; }
        public string strVendorName { get; set; }
        public string strStatus { get; set; }
        public string strGRNType { get; set; }
        public List<GRNDetailList> dataRemark { get; set; }
    }
    public class GRNDetailList
    {
        public string POD_Po_Line { get; set; }
        public string POD_B_Item_Code { get; set; }
        public string POD_Product_Desc { get; set; }
        public string POD_UOM { get; set; }
        public string POD_Min_Pack_Qty { get; set; }
        public string POD_Ordered_Qty { get; set; }
        public string POD_Outstanding { get; set; }
        public string DOD_SHIPPED_QTY { get; set; }
        public string GD_REJECTED_QTY { get; set; }
        public string REMARK { get; set; }
    }
    public class TrackingParameter : global::Plexform.Dto.PagedSortedAndFilteredInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }
        public string strDocNo { get; set; }
        public string strVenName { get; set; }
        public string strStatus { get; set; }
        public string strIPPStatus { get; set; }
        public string strInvFrom { get; set; }
        public string strDocType { get; set; }
        public string strCurr { get; set; }
        public string strFundType { get; set; }
        public string strCompResident { get; set; }
        public string strAmountFrom { get; set; }
        public string strAmountTo { get; set; }
        public string strDueDate { get; set; }
        public string strPaymentMode { get; set; }
        public List<TrackingSaveParameter> listSave { get; set; }
        public bool blnFMMassAppr { get; set; }
        public string strType { get; set; }
        public string strInvAppr2 { get; set; }
        public bool blnSend { get; set; }
    }
    public class TrackingSaveParameter : TrackingParameter
    {
        public string DEPT { get; set; }
        public string DOC_TYPE { get; set; }
        public string ID_ANALYSIS_CODE1 { get; set; }
        public DateTime IM_FM_APPROVED_DATE { get; set; }
        public string IM_INVOICE_INDEX { get; set; }
        public string IM_INVOICE_NO { get; set; }
        public string IM_INVOICE_STATUS { get; set; }
        public string IM_INVOICE_TOTAL { get; set; }
        public string IM_INVOICE_TYPE { get; set; }
        public string IM_PAYMENT_DATE { get; set; }
        public string IM_PAYMENT_TERM { get; set; }
        public string IM_PO_INDEX { get; set; }
        public string IM_PRINTED { get; set; }
        public string IM_RESIDENT_TYPE { get; set; }
        public string IM_S_COY_ID { get; set; }
        public string INVAMT_INMYR { get; set; }
        public string POM_BILLING_METHOD { get; set; }
        public string POM_BUYER_NAME { get; set; }
        public string POM_CURRENCY_CODE { get; set; }
        public string POM_PAYMENT_METHOD { get; set; }
        public string POM_S_COY_NAME { get; set; }
        public string REMARK { get; set; }
        public string STATUS_DESC { get; set; }

    }
    public class TrackingGridSaveParameter
    {
        public string strInvIndex { get; set; }
        public string strRemark { get; set; }
        public List<FundtypeDescCode> aryFundType { get; set; }
        public List<TaxDescCode> aryPTaxCode { get; set; }

    }
    public class FundtypeDescCode
    {
        public string FUNDTYPECODE { get; set; }
        public string FUNDTYPE { get; set; }
    }
    public class TaxDescCode
    {
        public string TAX { get; set; }
        public string TAXCODE { get; set; }
    }
    public class GetPRListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }
        public string strPRNo { get; set; }
        public string strItemCode { get; set; }
        public string dteDateFr { get; set; }
        public string dteDateTo { get; set; }
        public string strRole { get; set; }
        public string strBuyer { get; set; }
        public string strStatus { get; set; }
        public string strPRType { get; set; }
        public string strStatus2 { get; set; }
        public string strPR { get; set; }
        public string sProductCode { get; set; }
        public string sProductIndex { get; set; }
        public string sProductDesc { get; set; }
        public string sAnalysisCode { get; set; }
        public string sAnalysisDesc { get; set; }
        public string pComType { get; set; }
        public string pItemType { get; set; }
        public string pPRLine { get; set; }
        public string pPRIndex { get; set; }
        public string Filter { get; set; }
    }
   

    public class GetApprovalListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }

        public int GrpIndex { get; set; }

        public string strType { get; set; }


    }
    public class GetAOListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }

        public int GrpIndex { get; set; }

        public string strType { get; set;  }

        public string Approvaltype { get; set; }

        public double dblPRTotal { get; set; }
        public string strDept { get; set; }

        public string strBuyer { get; set; }
        public string strPONo { get; set; }
        public string strAORemark { get; set;  }
        public string strPOIndex { get; set; }
        public string strCoyID { get; set; }
        public Boolean blnEnterpriseVersion { get; set; }


    }
    public class GetPOListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string userID { get; set; }
        public string companyID { get; set; }
        public string strPOStatus { get; set; }
        public string strFulfilment { get; set; }
        public string strSide { get; set; }
        public string strVenName { get; set; }
        public string strPONo { get; set; }
        public string dtStartDate { get; set; }
        public string  dtEndDate { get; set; }
        public string  strBuyerConName { get; set; }
        public string strBuyerStatus { get; set; }
        public string strItemCode { get; set; }
        public string strPOType { get; set; }
        public string strReliefOn { get; set;  }
      
        public string strAction { get; set; }

    } 
    public class GetCodeTableListParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public AgoraNEO.AgoraNEO.CodeTable pCodeTableEnum { get; set; }
        public string pStatus { get; set; }
    }
    #region map prparam    
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class MapGetPRListParameter : BaseMapId
    {
        [JsonProperty("userID")]
        public virtual string userID { get; set; }
        [JsonProperty("companyID")]
        public virtual string companyID { get; set; }
        [JsonProperty("strPRNo")]
        public virtual string strPRNo { get; set; }
        [JsonProperty("sProductIndex")]
        public virtual string sProductIndex { get; set; }
        [JsonProperty("pPRLine")]
        public virtual string pPRLine { get; set; }
        [JsonProperty("pPRIndex")]
        public virtual string pPRIndex { get; set; }
    }
    #endregion

    public class GetItemsParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        //public string strProductIndex { get; set; }
        //public string strProductCode { get; set; }
        //public string strVendorItemCode { get; set; }
        //public string strProductDesc { get; set; }
        //public string strDeleted { get; set; }
        //public string strName { get; set; }
        //public string strUOM { get; set; }
        public string userID { get; set; }
        public string companyID { get; set; }

        public string strCoyId { get; set; }
        public string strItemType { get; set; }
        public string strBCItemIdx { get; set; }
        public string strCode { get; set; }
        public string strName { get; set; }
        public string strComType { get; set; }
        public string strDel { get; set; }

        public ArrayList pItemType { get; set; }

        public string strBCIdx { get; set; }
        public string strVendorItemCode { get; set; }
        public string strDesc { get; set; }
        public ArrayList aryItemType { get; set; }
        //public string aryItemType { get; set; }
    }

    public class GetTempImageParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string strIndex { get; set; }
    }

    public class GetFileParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string companyID { get; set; }
        public string strFileName { get; set; }
        public EnumDownLoadType pEnumDownloadType { get; set; }
        public string strDocType { get; set; }
        public EnumUploadFrom pEnumUploadFrom { get; set; }
        public string strCoy { get; set; }
        public string strConnStr { get; set; }
    }

    public class GetDirectParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string sFolder { get; set; }
        public string sFileName { get; set; }
        public string sGet { get; set; }
    }

    public class GetDeleteAttBuyerParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public int intIndex { get; set; }
        public string strPrdCode { get; set; }
        public string strType { get; set; }
    }

    public class Get1ColumnParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string pTable { get; set; }
        public string pFieldName { get; set; }
        public string pCondition { get; set; }
    }

    public class GetValParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string pSQL { get; set; }
    }

    public class GetExistParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string pstrSQL { get; set; }
    }

    public class GetSingleProductParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string itemcode { get; set; }
    }

    public class GetFillGLCodeParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string companyID { get; set; }
        public string pDropDownList { get; set; }
        public string strConn { get; set; }
    }

    public class GetBIMParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public DataSet dsProduct { get; set; }
        public string strMode { get; set; }
        public string strImageIndex { get; set; }
        public string strNewProductCode { get; set; }
        public string OldVendor { get; set; }
        public string OldVendorItemCode { get; set; }
        public string OldItemName { get; set; }
        public string strUpload { get; set; }

        public DataView pDropDownList { get; set; }
        public string strConn { get; set; }
        public string strCode { get; set; } //2805
        public bool blnTemp { get; set; } // false
        public string strItemId { get; set; } //2805
        public string strIndex { get; set; } //
        public string strSessionID { get; set; } //"0fchkkvnbksrvqga04kdyjwm"
    }

    public class GetInsert2AryParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public static void pQuerys(GetInsert2ArrayParameter PQuerys)
        {
            PQuerys = new GetInsert2ArrayParameter();
            PQuerys.pQuery = "";
        }

        public static void pQuerys(ref GetInsert2ArrayParameter PQuerys)
        {
            PQuerys = new GetInsert2ArrayParameter();
            PQuerys.pQuery = "";
        }

        public class GetInsert2ArrayParameter
        {
            public string pQuery { get; set; }
            public string pstrSQL { get; set; }
        }
    }

    public class GetInvoiceValueParamaeter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string UserID { get; set; }
        public string PONumber { get; set; }
        public string GRNNumber { get; set; }
        public string DONumber { get; set; }
        public string BuyerCompanyID { get; set; }
    }

    public class GetIssuedGRNParameter : global::Plexform.Dto.PagedSortedAndFilteredInputDto
    {
        public string UserID { get; set; }
        public string PONumber { get; set; }
        public string GRNNumber { get; set; }
        public string DONumber { get; set; }
        public string CompanyName { get; set; }
    }

    public class GetInvoicesParameter : global::Plexform.Dto.PagedSortedAndFilteredInputDto
    {
        public string UserID { get; set; }
        public string BuyerCompanyID { get; set; }
        public string InvoiceNumber { get; set; }
        public string InvoiceStatus { get; set; }
    }

    public struct RejectInvoiceParameter
    {
        public string UserID { get; set; }
        public string InvoiceNumber { get; set; }
        public string VendorName { get; set; }
        public string Remarks { get; set; }
    }

    public class GetUnInvoiceGRNParameter : global::Plexform.Dto.PagedAndSortedInputDto
    {
        public string UserID { get; set; }
        public int PurchaseOrderIndex { get; set; }
        public string GRNNo { get; set; }
        public string BuyerCompID { get; set; }
    }



    public class InvoiceCreationParameter
    {
        public string UserID { get; set; }
        public string CompanyID { get; set; }
        public string CompResident { get; set; }
        public string Document { get; set; }
        public string Reference { get; set; }
        public string Remark { get; set; }
        public string Amount { get; set; }
        public string B_Com_Id { get; set; }
        public string InvStatus { get; set; }
        public string BillMeth { get; set; }
        public string PoNo { get; set; }
        public string GrnNo { get; set; }
        public string DoNo { get; set; }
        public string PayDay { get; set; }
        public string Tax { get; set; }
        public string ShipAmt { get; set; }
        public string POM_PO_INDEX { get; set; }
        public string GST_REG { get; set; }
        public string DOC_INDEX { get; set; }
        public string DOC_NO { get; set; }
    }



}
