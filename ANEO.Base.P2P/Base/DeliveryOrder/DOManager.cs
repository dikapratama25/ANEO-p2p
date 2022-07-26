using Abp.Localization;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Threading.Tasks;
using Plexform;
using Plexform.Base;
using Plexform.Base.Core;
using ANEO.Base.P2P.DO.Map;
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.General.Map;
using ANEO.Base.P2P.General.Model;
using System.Data;
using System.Collections.Generic;
using AgoraNEO.AgoraNEO;

namespace ANEO.Base.P2P.DO
{
    public class DOManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public DOManager(
            Plexform.Base.Core.Entity.EntityManager entityManager,
            IWebHostEnvironment env,
            IAppFolders appFolders,
            IObjectMapper objectMapper,
            ILocalizationManager localizationManager,
            IExcelExporter excelExporter,
            RoleManager roleManager,
            UserManager userManager,
            TenantManager tenantManager
            )
            : base(env, appFolders, objectMapper, roleManager, userManager, tenantManager, excelExporter, localizationManager)
        {
            try
            {
                _connProcure = _appConfiguration["ConnectionStrings:eProcure"];
                _connSSO = _appConfiguration["ConnectionStrings:SSO"];
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
            }
        }

        public async Task<dynamic> GetOutStandingPOWithDAddress(GetDOListParameter input)
        {
            try
            {
                DeliveryOrder objDO = new DeliveryOrder();
                BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR> repo = new BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDO.GetOutStandingPOWithDAddress(input.userID, input.strPONo);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var resPO = repo.ExecuteQueryList<MapPO>(strSQL + strPagination);
                resPO.TotalCount = !string.IsNullOrEmpty(strPagination) ? repo.ExecuteQueryList<MapPO>(strSQL).TotalCount : resPO.TotalCount;

                return resPO;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetDOList(GetDOListParameter input)
        {
            try
            {
                DeliveryOrder objDO = new DeliveryOrder();
                BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR> repo = new BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDO.GetDO(input.userID, input.strDocType, input.strDocNo, input.strCreationDt, input.strSubmittedDt, input.strOurRef, input.strBuyerComp, input.strVenItem,input.strStatus);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var resDO = repo.ExecuteQueryList<MapDOListing>(strSQL + strPagination);
                resDO.TotalCount = !string.IsNullOrEmpty(strPagination) ? repo.ExecuteQueryList<MapDOListing>(strSQL).TotalCount : resDO.TotalCount;
                return resDO;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetPODetails(GetDOListParameter input)
        {
            try
            {
                DeliveryOrder objDO = new DeliveryOrder();
                BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR> repo = new BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                switch (input.strType)
                {
                    case "POHeader":
                        DataTable dt = objDO.GetPODetails(input.userID, input.strPONo, input.POIndex, input.AddrCode, input.strBCoyID, input.strType).ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }
                        else
                        {
                            return new ResultContainer(string.Format(L("NoData:{0}"), input.strType), false);
                        }
                    case "PODetails":
                        string strSQL = objDO.GetPODetails(input.userID, input.strPONo, input.POIndex, input.AddrCode, input.strBCoyID, input.strType).strSql;
                        string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                        var res = repo.ExecuteQueryList<MapPO_DO_DETAILS>(strSQL + strPagination);
                        return res;
                    default:
                        return new ResultContainer(string.Format(L("WrongType:{0}"), input.strType), false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetDODetails(GetDOListParameter input)
        {
            try
            {
                DataTable dt = new DataTable();
                string strSQL = string.Empty;
                DeliveryOrder objDO = new DeliveryOrder();
                BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR> repo = new BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                switch (input.strType)
                {
                    case "POHeader":
                        dt = objDO.ShowDOdetails(input.userID, input.strDONo, input.strPONo, input.POIndex, input.AddrCode, input.strBCoyID, input.strType).ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }
                        else
                        {
                            return new ResultContainer(string.Format(L("NoData:{0}"), input.strType), false);
                        }
                    case "PODetails":
                        strSQL = objDO.ShowDOdetails(input.userID, input.strDONo, input.strPONo, input.POIndex, input.AddrCode, input.strBCoyID, input.strType).strSql;
                        string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                        var resPO = repo.ExecuteQueryList<MapPO_DO_DETAILS>(strSQL + strPagination);
                        return resPO;
                    case "DODetails":
                        strSQL = objDO.ShowDOdetails(input.userID, input.strDONo, input.strPONo, input.POIndex, input.AddrCode, input.strBCoyID, input.strType).strSql;
                        var resDO = repo.ExecuteQueryList<MapDO_DETAILS>(strSQL);
                        return resDO;
                    default:
                        return new ResultContainer(string.Format(L("WrongType:{0}"), input.strType), false);
                }
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        public async Task<IEnumerable<MapDO_MSTR>> GetDODraftAvaibility(GetDOListParameter input)
        {
            try
            {
                BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR> repo = new BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = string.Format("SELECT DOM_DO_NO, DOM_DO_Index, DOM_D_ADDR_CODE FROM DO_MSTR WHERE DOM_DO_STATUS = '{0}' AND DOM_PO_INDEX = {1} AND DOM_D_ADDR_CODE = '{2}' ", (int)DOStatus.Draft, input.strIndex, Common.Parse(input.strDocNo));
                var resDO = repo.ExecuteQuery<MapDO_MSTR>(strSQL);
                return resDO;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetDOSummary(GetDOListParameter input)
        {
            try
            {
                DeliveryOrder objDO = new DeliveryOrder();
                BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR> repo = new BaseRepository<DTO.P2P.Master.do_mstr.DO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDO.GetDOSumm(input.userID, Convert.ToInt32(input.strIndex));
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var resDO = repo.ExecuteQueryList<MapDOSummary>(strSQL + strPagination);
                resDO.TotalCount = !string.IsNullOrEmpty(strPagination) ? repo.ExecuteQueryList<MapDOSummary>(strSQL).TotalCount : resDO.TotalCount;
                return resDO;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetTempDOAttachment(GetP2PListParameter input)
        {
            try
            {
                FileManagement objFM = new FileManagement();
                DeliveryOrder objDO = new DeliveryOrder();
                BaseRepository<DTO.P2P.Master.company_do_doc_attachment_temp.COMPANY_DO_DOC_ATTACHMENT_TEMP> repo = new BaseRepository<DTO.P2P.Master.company_do_doc_attachment_temp.COMPANY_DO_DOC_ATTACHMENT_TEMP>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strUploadPath = objFM.getSystemParam("DocAttachPath", "DO", null);
                string addressPath = _docVault + strUploadPath.Replace("\\", "/");

                string strSQL = objDO.getTempDOAttachment(input.userID, input.strCode, addressPath);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var resDO = repo.ExecuteQueryList<MapCOMPANY_DO_DOC_ATTACHMENT_TEMP>(strSQL + strPagination);
                resDO.TotalCount = !string.IsNullOrEmpty(strPagination) && resDO.TotalCount == input.MaxResultCount ? repo.ExecuteQueryList<MapCOMPANY_DO_DOC_ATTACHMENT_TEMP>(strSQL).TotalCount : resDO.TotalCount;
                return resDO;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> DeleteTempDOAttachment(MapCOMPANY_DO_DOC_ATTACHMENT_TEMP input)
        {
            try
            {
                bool res = false;
                FileManagement objFM = new FileManagement();
                DeliveryOrder objDO = new DeliveryOrder();

                objDO.deleteTempDOAttachment(input.UserID, (int)input.CDDA_ATTACH_INDEX, input.CDDA_DOC_NO, "H", input.CDDA_STATUS);
                res = true;
                return new ResultContainer(string.Format(L("SuccessfullyDeleted")), res);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> InsertDO(MapDOParameter input)
        {
            try
            {
                DeliveryOrder objDO = new DeliveryOrder();
                string strDONo = input.DO_MSTR.DOM_DO_NO ?? string.Empty;
                string strBCoyID = input.PO_DO_DETAILS.POD_COY_ID ?? string.Empty;
                string strMsg = "<ul type='disc'></ul>";
                string validationMessage = string.Empty;
                bool res = false;

                if (input.StatusType == "Submit")
                {
                    validationMessage = ValidateDO(input);
                    if (!string.IsNullOrEmpty(validationMessage))
                    {
                        return new ResultContainer(string.Format(validationMessage), res);
                    }
                }

                DataSet ds = BindDO(input);
                switch (input.SaveType)
                {
                    case "new":
                        res = objDO.DONew(input.UserID, ds, input.StatusType, ref strDONo, ref strMsg, false, null);
                        break;
                    case "edit":
                        res = objDO.DOEdit(input.UserID, ds, input.StatusType, strDONo, strBCoyID, ref strMsg, false, null);
                        break;
                }
                return new ResultContainer(string.Format(strDONo), res);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        #region MISC
        private DataSet BindDO(MapDOParameter input)
        {
            try
            {
                #region init
                DeliveryOrder objDO = new DeliveryOrder();
                AgoraNEO.AgoraNEO.EAD.DBCom objDB = new AgoraNEO.AgoraNEO.EAD.DBCom();
                objDO.Init();
                #endregion

                #region populate mstr
                DataRow dtr;
                dtr = objDO.dtDOMstr.NewRow();
                dtr["DOM_DO_Date"] = input.DO_MSTR.DOM_DO_DATE;
                dtr["DOM_S_Ref_No"] = input.DO_MSTR.DOM_S_REF_NO;
                dtr["DOM_S_REF_DATE"] = input.DO_MSTR.DOM_S_REF_DATE;
                dtr["DOM_PO_INDEX"] = input.DO_MSTR.DOM_PO_INDEX;
                dtr["DOM_D_Addr_Code"] = input.DO_MSTR.DOM_D_ADDR_CODE;

                dtr["POD_D_Addr_Line1"] = input.PO_DO_DETAILS.POD_D_ADDR_LINE1;
                dtr["POD_D_Addr_Line2"] = input.PO_DO_DETAILS.POD_D_ADDR_LINE2;
                dtr["POD_D_Addr_Line3"] = input.PO_DO_DETAILS.POD_D_ADDR_LINE3;
                dtr["POD_D_State"] = input.PO_DO_DETAILS.POD_D_STATE;
                dtr["POD_D_Country"] = input.PO_DO_DETAILS.POD_D_COUNTRY;
                dtr["POD_D_PostCode"] = input.PO_DO_DETAILS.POD_D_POSTCODE;
                dtr["POD_D_City"] = input.PO_DO_DETAILS.POD_D_CITY;
                dtr["POD_B_COY_ID"] = input.PO_DO_DETAILS.POD_COY_ID;
                dtr["POD_PO_NO"] = input.PO_DO_DETAILS.POD_PO_NO;

                dtr["DOM_WAYBILL_NO"] = input.DO_MSTR.DOM_WAYBILL_NO ?? string.Empty;
                dtr["DOM_FREIGHT_CARRIER"] = input.DO_MSTR.DOM_FREIGHT_CARRIER ?? string.Empty;
                dtr["DOM_FREIGHT_AMT"] = input.DO_MSTR.DOM_FREIGHT_AMT ?? 0;
                dtr["DOM_DO_REMARKS"] = input.DO_MSTR.DOM_DO_REMARKS ?? string.Empty;
                dtr["DOM_CREATED_DATE"] = input.DO_MSTR.DOM_CREATED_DATE ?? DateTime.Now;

                #region AttachmentID
                string docIn = string.Empty;
                if (input.DOC_ATTACHMENTS.Count > 0)
                {
                    foreach (MapCOMPANY_DO_DOC_ATTACHMENT_TEMP doc in input.DOC_ATTACHMENTS)
                    {
                        docIn += string.IsNullOrEmpty(docIn) ? "'" + doc.CDDA_DOC_NO + "'" : ",'" + doc.CDDA_DOC_NO + "'";
                    }
                }
                dtr["CDDA_DOC_NO"] = !string.IsNullOrEmpty(docIn) ? docIn : "''";
                #endregion
                #endregion
                objDO.dtDOMstr.Rows.Add(dtr);

                #region populate details
                DataRow dtrd;
                foreach (var detail in input.DO_DETAILS)
                {
                    dtrd = objDO.dtDODtls.NewRow();
                    dtrd["DOD_PO_LINE"] = detail.DOD_PO_LINE;
                    dtrd["DOD_DO_LINE"] = detail.DOD_DO_LINE;
                    dtrd["DOD_DO_QTY"] = detail.DOD_DO_QTY;

                    dtrd["DOD_SHIPPED_QTY"] = detail.DOD_SHIPPED_QTY;
                    dtrd["DOD_REMARKS"] = detail.DOD_REMARKS ?? string.Empty;
                    objDO.dtDODtls.Rows.Add(dtrd);
                }
                #endregion

                

                DataSet ds = new DataSet();
                ds.Tables.Add(objDO.dtDOMstr);
                ds.Tables.Add(objDO.dtDODtls);

                return ds;
            }
            catch (Exception ex)
            {

                Log.Error(nameof(DOManager), ex);
                throw ex;
            }
        }

        private string ValidateDO(MapDOParameter input)
        {
            if (string.IsNullOrEmpty(input.DO_MSTR.DOM_DO_NO))
            {
                return L("RequiredMessage", L("DOM_DO_NO"));
            }
            if (string.IsNullOrEmpty(input.DO_MSTR.DOM_S_REF_NO))
            {
                return L("RequiredMessage", L("DOM_S_Ref_No"));
            }
            if (string.IsNullOrEmpty(input.DO_MSTR.DOM_D_ADDR_CODE))
            {
                return L("RequiredMessage", L("POD_D_ADDR_CODE"));
            }
            if (string.IsNullOrEmpty(input.DO_MSTR.DOM_WAYBILL_NO))
            {
                return L("RequiredMessage", L("DOM_WAYBILL_NO"));
            }
            if (string.IsNullOrEmpty(input.DO_MSTR.DOM_FREIGHT_CARRIER))
            {
                return L("RequiredMessage", L("DOM_FREIGHT_CARRIER"));
            }
            if (string.IsNullOrEmpty(input.DO_MSTR.DOM_DO_REMARKS))
            {
                return L("RequiredMessage", L("DOM_DO_REMARKS"));
            }
            return string.Empty;
        }
        #endregion

    }
}
