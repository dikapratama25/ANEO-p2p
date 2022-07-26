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
using ANEO.Base.P2P.Master.Map;
using ANEO.Base.P2P.General.Model;
using System.Data;
using System.Collections.Generic;
using AgoraNEO;
using System.Collections;
using ANEO.Base.P2P.GRN.Map;

namespace ANEO.Base.P2P.GRN
{
    public class GRNManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public GRNManager(
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
                Log.Error(nameof(GRNManager), ex);
            }
        }

        public async Task<dynamic> getVendorItemCode(string companyID, string strPONo, string strBCoyID, string strDONo, string strVendorCode)
        {
            try
            {
                AgoraNEO.AgoraNEO.DeliveryOrder objDO = new AgoraNEO.AgoraNEO.DeliveryOrder();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDO.getVendorItemCode(companyID, strPONo, strBCoyID, strDONo, strVendorCode);
                var res = repo.ExecuteQueryList<Map.GRNMap>(strSQL);

                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> populateIssueGrn(GetGRNListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objDO = new AgoraNEO.AgoraNEO.GRN();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDO.populateDataIssueGrn(input.userID, input.companyID, input.strDONo, input.strPONo);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var res = repo.ExecuteQueryList<IssueGRNMap>(strSQL + strPagination);
                int totalCount = (repo.ExecuteQueryList<IssueGRNMap>(strSQL)).TotalCount;
                res.TotalCount = totalCount;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getPOListForOutsDO(GetGRNListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objDO = new AgoraNEO.AgoraNEO.GRN();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                bool blnValid = false;
                string strmsg = "";
                DataSet ds = objDO.getPOListForOutsDO(input.userID, input.companyID, input.strPONo, ref blnValid, ref strmsg);
                return ds;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> populateDOAttachment(GetGRNListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement objFM = new AgoraNEO.AgoraNEO.FileManagement();
                AgoraNEO.AgoraNEO.GRN objGRN = new AgoraNEO.AgoraNEO.GRN();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strUploadPath = objFM.getSystemParam("DocAttachPath", "DO", null);
                string addressPath = _docVault + strUploadPath.Replace("\\", "/");
                string strSQL = objGRN.getDOAttachment(input.strDONo, addressPath);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var res = repo.ExecuteQueryList<DOAttachment>(strSQL + strPagination);
                int totalCount = (repo.ExecuteQueryList<DOAttachment>(strSQL)).TotalCount;
                res.TotalCount = totalCount;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> populateDetailIssueGrn(GetGRNListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objDO = new AgoraNEO.AgoraNEO.GRN();
                AgoraNEO.AgoraNEO.Inventory objInv = new AgoraNEO.AgoraNEO.Inventory();
                bool blnValid = false;
                string strmsg = "";
                DataSet ds = objDO.getPOListForOutsDO(input.userID, input.companyID, input.strPONo, ref blnValid, ref strmsg);
                input.strPOIdx = Convert.ToInt32(ds.Tables[0].Rows[0]["poM_PO_Index"]);
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDO.ShowDOdetails(input.companyID, input.strDONo, input.strDOIdx, input.strPOIdx);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var res = repo.ExecuteQueryList<IssueGRNDetailMap>(strSQL + strPagination);

                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> populateDetailIssueGrnSumm(GetGRNListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objDO = new AgoraNEO.AgoraNEO.GRN();
                AgoraNEO.AgoraNEO.Inventory objInv = new AgoraNEO.AgoraNEO.Inventory();
                bool blnValid = false;
                string strmsg = "";
                DataSet ds = objDO.getPOListForOutsDO(input.userID, input.companyID, input.strPONo, ref blnValid, ref strmsg);
                input.strPOIdx = Convert.ToInt32(ds.Tables[0].Rows[0]["poM_PO_Index"]);
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDO.GetGRNSumm(input.companyID, input.strPOIdx, "");
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var res = repo.ExecuteQueryList<IssueGRNSummaryMap>(strSQL + strPagination);
                int totalCount = (repo.ExecuteQueryList<IssueGRNSummaryMap>(strSQL)).TotalCount;
                res.TotalCount = totalCount;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> submitGRNIssue(GetGRNListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objDO = new AgoraNEO.AgoraNEO.GRN();
                AgoraNEO.AgoraNEO.Inventory objInv = new AgoraNEO.AgoraNEO.Inventory();
                bool blnValid = false;
                string strmsg = "";
                DataSet dsx = objDO.getPOListForOutsDO(input.userID, input.companyID, input.strPONo, ref blnValid, ref strmsg);
                input.strPOIdx = Convert.ToInt32(dsx.Tables[0].Rows[0]["poM_PO_Index"]);
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                #region populate GRN
                DataSet strSQLs = objDO.GetGRNSumms(input.companyID, input.strPOIdx, "");


                #endregion
                #region submited from .vb
                string PONo, DONo, strNewGRNno;
                int POIdx, DOIdx, intToRecord;
                DataSet dsGRN, dsCheck;
                PONo = input.strPONo;
                POIdx = input.strPOIdx;
                DONo = input.strDONo;
                DOIdx = input.strDOIdx;
                strNewGRNno = "";
                DataSet ds = new DataSet();
                DataTable dtGrnMstr = new DataTable();
                dtGrnMstr.Columns.Add("SCoyID", Type.GetType("System.String"));
                dtGrnMstr.Columns.Add("PONo", Type.GetType("System.String"));
                dtGrnMstr.Columns.Add("DONo", Type.GetType("System.String"));
                dtGrnMstr.Columns.Add("GRNNo", Type.GetType("System.String"));
                dtGrnMstr.Columns.Add("POIndex", Type.GetType("System.Double"));
                dtGrnMstr.Columns.Add("DOIndex", Type.GetType("System.Double"));
                dtGrnMstr.Columns.Add("GRNIndex", Type.GetType("System.Double"));
                dtGrnMstr.Columns.Add("GRNReceivedDt", Type.GetType("System.DateTime"));
                DataRow dtr;
                dtr = dtGrnMstr.NewRow();
                dtr["SCoyID"] = input.strSCoyID;
                dtr["PONo"] = PONo;
                dtr["DONo"] = DONo;
                dtr["GRNNo"] = strSQLs.Tables[0].Rows.Count == 0 ? "" : strSQLs.Tables[0].Rows[0]["GM_GRN_No"];
                dtr["DOIndex"] = input.strDOIdx;
                dtr["POIndex"] = input.strPOIdx;
                dtr["GRNIndex"] = 0;
                dtr["GRNReceivedDt"] = strSQLs.Tables[0].Rows.Count == 0 ? DateTime.Now : strSQLs.Tables[0].Rows[0]["GM_Date_Received"];
                dtGrnMstr.Rows.Add(dtr);
                ds.Tables.Add(dtGrnMstr);
                #endregion

                #region BindGRN
                DataSet grnDetail = objDO.ShowDOdetailsSet(input.companyID, input.strDONo, input.strDOIdx, input.strPOIdx);
                DataRow dtrDet;
                DataTable dtGrnDtls = new DataTable();
                dtGrnDtls.Columns.Add("PO_LINE", Type.GetType("System.String"));
                dtGrnDtls.Columns.Add("Received_Qty", Type.GetType("System.Double"));
                dtGrnDtls.Columns.Add("Rejected_Qty", Type.GetType("System.Double"));
                dtGrnDtls.Columns.Add("REMARKS", Type.GetType("System.String"));
                for (int i = 0; i < input.dataRemark.Count; i++)
                {
                    dtrDet = dtGrnDtls.NewRow();
                    if (input.dataRemark[i].REMARK == "" || input.dataRemark[i].REMARK == null)
                    {
                        return ("Line No : " + input.dataRemark[i].POD_Po_Line + " Remark is required. ", "failed");
                    }
                    if (Convert.ToDecimal(input.dataRemark[i].GD_REJECTED_QTY) > Convert.ToDecimal(input.dataRemark[i].DOD_SHIPPED_QTY))
                    {
                        return ("Line No : "+ input.dataRemark[i].POD_Po_Line + " Reject Quantity is over limit.", "failed");
                    }
                    dtrDet["REMARKS"] = input.dataRemark[i].REMARK;
                    dtrDet["PO_LINE"] = input.dataRemark[i].POD_Po_Line;
                    dtrDet["Received_Qty"] = input.dataRemark[i].DOD_SHIPPED_QTY;
                    dtrDet["Rejected_Qty"] = input.dataRemark[i].GD_REJECTED_QTY;
                    dtGrnDtls.Rows.Add(dtrDet);
                }
              
                ds.Tables.Add(dtGrnDtls);

                string LocDesc = "",subLocDesc="";
                objInv.GetDefaultLocationDesc(input.userID,input.companyID,ref LocDesc,ref subLocDesc);
                ArrayList arySetLocation = new ArrayList();
                arySetLocation.Add(new string[]{ "", "", "", "", "", "", "", "", "" });
                if (objDO.GRNSubmit(input.userID,input.companyID,ds,ref strNewGRNno,null,false,arySetLocation))
                {
                    return ("GRN Number "+ strNewGRNno+ " has been successfully created for DO No " + input.strDONo ,"success");

                }
                else
                {
                    if (strNewGRNno == "exist1")
                    {
                        return ("GRN Number already exist","failed");

                    }
                    else
                    {
                        return ("GRN Number "+ strNewGRNno+ " has been successfully","failed");

                    }

                }

                #endregion
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> populateGRN(GetGRNParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objGrn = new AgoraNEO.AgoraNEO.GRN();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objGrn.GetGRN(input.userID, input.companyID, input.strDocType, input.strNo, input.strCreationDt, input.strVendorName, input.strStatus, input.strGRNType);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var res = repo.ExecuteQueryList<GRNList>(strSQL + strPagination);
                int totalCount = (repo.ExecuteQueryList<GRNList>(strSQL)).TotalCount;
                res.TotalCount = totalCount;
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetGRNHistory(GetGRNParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objGrn = new AgoraNEO.AgoraNEO.GRN();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                DataSet res = objGrn.GetGRNHistory(input.strNo,input.companyID);
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetGRNHistoryString(GetGRNParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objGrn = new AgoraNEO.AgoraNEO.GRN();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objGrn.GetGRNHistoryString(input.strNo, input.companyID);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var res = repo.ExecuteQueryList<IssueGRNDetailMap>(strSQL + strPagination);

                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNManager), ex);
                throw ex;
            }
        }
    }
}
