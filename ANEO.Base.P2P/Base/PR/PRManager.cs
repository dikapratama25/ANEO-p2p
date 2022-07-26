using Abp.Localization;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Threading.Tasks;
using System.Linq;
using Plexform;
using Plexform.Base;
using Plexform.Base.Core;
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.General.Map;
using ANEO.Base.P2P.PR.Map;
using ANEO.Base.P2P.General.Model;
using System.Data;
using System.Collections.Generic;
using AgoraNEO;
using System.Collections;
using LOGIC.Shared.Collection;
using Microsoft.AspNetCore.Hosting;

namespace ANEO.Base.P2P.PR
{
    public class PRManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;
        public PRManager(
            IWebHostEnvironment env,
            IAppFolders appFolders,
            IObjectMapper objectMapper,
            ILocalizationManager localizationManager,
            IExcelExporter excelExporter,
            RoleManager roleManager,
            UserManager userManager,
            TenantManager tenantManager)
            : base(env, appFolders, objectMapper, roleManager, userManager, tenantManager, excelExporter, localizationManager)
        {
            try
            {
                _connProcure = _appConfiguration["ConnectionStrings:eProcure"];
                _connSSO = _appConfiguration["ConnectionStrings:SSO"];
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
            }
        }

        #region PR
        public async Task<dynamic> GetPRDetailHead(GetPRListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS> repo = new BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getPRDetailHead(input.strPRNo, input.companyID);
                var res = repo.ExecuteQueryList<mapPRMasterDetailHead>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetPRDetailBody(GetPRListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS> repo = new BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getPRDetailBody(input.strPRNo);
                var res = repo.ExecuteQueryList<mapPRMasterDetailBody>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetPRDetailFoot(string intPRIndex)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS> repo = new BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getPRDetailFoot(intPRIndex);
                var res = repo.ExecuteQueryList<mapPRMasterDetailFoot>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetAllPR(GetPRListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPurchaseRequest2 = new AgoraNEO.AgoraNEO.PurchaseReq2();
                var repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                input.strPRNo ??= input.Filter;

                string strSQL = objPurchaseRequest2.SearchPRList(input.userID, input.companyID, input.strPRNo, input.strItemCode, input.dteDateFr, input.dteDateTo, input.strRole, input.strBuyer, input.strStatus, input.strPRType, input.strStatus2);
                var res = repo.ExecuteQueryList<Master.Model.MapListPR_MSTR>(strSQL + strPagination);

                int totalCount = (repo.ExecuteQueryList<Master.Model.MapListPR_MSTR>(strSQL)).TotalCount;
                res.TotalCount = totalCount;

                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> SavePR(MapPRMaster input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                bool result = false;
                DataSet ds = BindPR(input);
                string strPRNo = string.Empty;
                if (ds != null)
                {
                    int res = 0;
                    switch (input.Type)
                    {
                        case "new":
                            res = objPR.insertPR(input.UserID, input.CompanyID, ds, ref strPRNo, input.AttachmentID, input.NonFTN);
                            result = true;
                            break;
                        case "mod":
                            objPR.updatePR(input.UserID, input.CompanyID, ds, input.NonFTN);
                            strPRNo = input.PRNo;
                            result = true;
                            break;
                    }
                }
                
                return new ResultContainer(string.Format(strPRNo), result);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> SubmitPR(MapPRMaster input)
        {
            try
            {
                int intMsg = input.SaveMode;
                string strPRNo = input.PRNo ?? string.Empty;

                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                AgoraNEO.AgoraNEO.Admin objAdmin = new AgoraNEO.AgoraNEO.Admin();
                AgoraNEO.AgoraNEO.UserRoles objUserRole = new AgoraNEO.AgoraNEO.UserRoles();
                AgoraNEO.AgoraNEO.DeliveryOrder objDO = new AgoraNEO.AgoraNEO.DeliveryOrder();
                AgoraNEO.AgoraNEO.AppGlobals appGlobals = new AgoraNEO.AgoraNEO.AppGlobals();
                if (input.ApprovalOrders == null)
                {
                    DataSet ds = BindPR(input);
                    DataSet dsapplist = objPR.getAppovalList(input.UserID, input.CompanyID, "A", input.PRCost, "PR", true).ds;
                    if (dsapplist.Tables[0].Rows.Count == 0)
                    {
                        return new ResultContainer(string.Format("There is no approval list available for this PR because the sequence of approving officers do not have the approval limit to approve it."), false);
                    }
                    bool blnGRNCtrl = objAdmin.withGRNCtrl(input.CompanyID);
                    string strFixRole = objUserRole.get_UserFixedRole(input.UserID, input.CompanyID);
                    if (strFixRole.IndexOf("Store Keeper") != -1)
                    {
                        DataSet dsOVendor = objDO.GetDO2(input.UserID, input.CompanyID, "", "");
                        for (int i = 0; i < dsOVendor.Tables[0].Rows.Count - 1; i++)
                        {
                            if (objDO.ChkOustdGRN(dsOVendor.Tables[0].Rows[i]["DOM_S_COY_ID"].ToString(), Convert.ToInt32(dsOVendor.Tables[0].Rows[i]["DO_DAYS"])))
                            {
                                return new ResultContainer(string.Format("Your access to submit PR is denied due to your account still has outstanding GRN pending your action." +
                                    "Please raise GRN Accept if you had received the physical delivery or services, else create GRN Reject if you had not received any physical delivery or services from the vendors." +
                                    "Please save your PR as draft, and create GRN Accept or Reject to obtain the access to submit PR for approval."), false);
                            }
                        }
                    }

                    DataTable dt = objPR.getPRApprFlow(input.UserID, input.CompanyID, false);
                    bool CheckApprB4 = true;
                    if (dt.Rows.Count == 0 && input.Mode == "cc")
                    {
                        CheckApprB4 = false;
                    }

                    string validationMessage = ValidatePR(input);
                    if (input.PRNo == "To Be Allocated By System" && CheckApprB4)
                    {
                        if (string.IsNullOrEmpty(validationMessage))
                        {
                            intMsg = objPR.insertPR(input.UserID, input.CompanyID, ds, ref strPRNo, input.AttachmentID, input.NonFTN);
                            return new ResultContainer(strPRNo, true);
                        }
                        else
                        {
                            return new ResultContainer(validationMessage, false);
                        }
                        
                    }
                    else if (!string.IsNullOrEmpty(input.PRNo) && CheckApprB4)
                    {
                        dt = objPR.getPRApprFlow(input.UserID, input.CompanyID, false);
                        if (dt.Rows.Count == 0 && input.Mode == "cc")
                        {
                            return new ResultContainer(string.Format("There is no Approval Flow defined for you."), false);
                        }
                        else
                        {
                            if (string.IsNullOrEmpty(validationMessage))
                            {
                                objPR.updatePR(input.UserID, input.CompanyID, ds, input.NonFTN);
                                intMsg = Convert.ToInt32(AgoraNEO.AgoraNEO.WheelMsgNum.Save);
                                strPRNo = input.PRNo;
                                return new ResultContainer(string.Format(strPRNo), true);
                            }
                            else
                            {
                                return new ResultContainer(validationMessage, false);
                            }
                            
                        }
                    }
                    else
                    {
                        return new ResultContainer(string.Format("Either no approval found or PR is not non-contract"), false);
                    }
                }
                else
                {
                    switch (intMsg)
                    {

                        case (int)WheelMsgNum.Save:
                            {
                                DataRow dtr;
                                int i = 0;
                                DataTable dtAO = new DataTable();
                                dtAO.Columns.Add("prid", Type.GetType("System.String"));
                                dtAO.Columns.Add("AO", Type.GetType("System.String"));
                                dtAO.Columns.Add("AAO", Type.GetType("System.String"));
                                dtAO.Columns.Add("Seq", Type.GetType("System.Int32"));
                                dtAO.Columns.Add("Type", Type.GetType("System.String"));
                                dtAO.Columns.Add("GrpIndex", Type.GetType("System.String"));
                                dtAO.Columns.Add("Relief", Type.GetType("System.String"));
                                if (input.ApprovalOrders != null)
                                {
                                    foreach (var item in input.ApprovalOrders)
                                    {
                                        dtr = dtAO.NewRow();
                                        dtr["prid"] = input.PRNo;
                                        dtr["AO"] = item.AO;
                                        dtr["AAO"] = (!string.IsNullOrEmpty(item.AAO)) ? item.AAO : string.Empty;
                                        dtr["GrpIndex"] = item.GrpIndex;
                                        dtr["Relief"] = item.Relief;

                                        switch (item.Type)
                                        {
                                            case "None":
                                                dtr["Type"] = "0";
                                                break;
                                            case "Approval":
                                                dtr["Type"] = "1";
                                                i = i + 1;
                                                break;
                                            case "Endorsement":
                                                dtr["Type"] = "2";
                                                i = i + 1;
                                                break;
                                        }
                                        dtr["seq"] = i;
                                        if (dtr["Type"].ToString() != "0")
                                        {
                                            dtr["Seq"] = i;
                                            dtAO.Rows.Add(dtr);
                                        }
                                    }
                                    intMsg = objPR.submitPR(input.PRNo, input.CompanyID, Convert.ToInt32(AgoraNEO.AgoraNEO.PRStatus.Submitted).ToString(), null, dtAO, 1.ToString(), "true", false);
                                    return new ResultContainer(string.Format(strPRNo), true);
                                }
                            }
                            break;
                    }
                }
                return new ResultContainer(string.Format("FailedToSave"), false);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> ApprovePR(mapApprovedPR input)
        {
            try
            {
                string remark = FormatAORemark(input.strAction, input.ApprType);
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var res = objPR.ApprovePR(input.CompanyID, input.UserID, input.prno, input.PRIndex, input.seq, input.blnhighestlevel, null, remark, input.buyer, false, input.ApprType, "", "APP");
                return new ResultContainer(string.Format(res), true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }



        }

        public async Task<dynamic> RejectPR(mapRejectPR input)
        {
            try
            {
                string remark = FormatAORemark(input.strAction, input.ApprType);
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var res = objPR.RejectPR(input.CompanyID, input.prno, input.PRIndex, input.seq, remark, input.UserID, false);
                return new ResultContainer(string.Format(res), true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }



        }
        private string FormatAORemark(string strAction, string AppType)
        {
            try
            {
                string strRemark = "";
                string strTempRemark = "";
                string strUserName = "";

                switch (strAction)
                {
                    case "approve":
                        if (AppType == "1")
                        {
                            strRemark = "Approved";
                        }
                        else
                        {
                            strRemark = "Endorsed";
                        }
                        break;
                    case "reject":
                        strRemark = "Rejected";
                        break;
                    case "hold":
                        strRemark = "Held";
                        break;
                }
                return strRemark;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetApprovallist(GetAOListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                var repo = new BaseRepository<DTO.P2P.Master.approval_grp_ao.APPROVAL_GRP_AO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objPR.getAppovalListstr(input.userID, input.companyID, input.Approvaltype, input.dblPRTotal, input.strType, input.blnEnterpriseVersion, input.strDept);
                var res = repo.ExecuteQueryList<MapApprovallist>(strSQL);
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetPRItem(GetP2PListParameter input)
        {
            try
            {
                string strSQL = string.Empty;
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var repo = new BaseRepository<DTO.P2P.Master.product_mstr.PRODUCT_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                AgoraNEO.AgoraNEO.ShoppingCart objShopping = new AgoraNEO.AgoraNEO.ShoppingCart();
                DataTable dt;

                switch (input.strType)
                {
                    case "BuyerCat":
                        if (!string.IsNullOrEmpty(input.strCode))
                        {
                            string[] typeList = input.strCode.Split(",");
                            foreach (var type in typeList)
                            {
                                strSQL += !string.IsNullOrEmpty(strSQL) ? " UNION " : string.Empty;
                                strSQL += objShopping.getPRItemList(input.companyID, input.strType, type, string.Empty, string.Empty, null, null, null, null, null, true).strSql;
                            }
                            var resBC = repo.ExecuteQueryList<MapPRMasterDetail>(strSQL + strPagination);
                            resBC.TotalCount = repo.ExecuteQueryList<MapPRMasterDetail>(strSQL).TotalCount;
                            return resBC;
                        }
                        break;
                    case "PRHeader":
                        dt = objShopping.getPRItemList(input.companyID, "PR", null, input.strPR, "0", null, null, null, null, null, false).ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }
                        break;
                    case "PRDetailItem":
                        strSQL += objShopping.getPRItemList(input.companyID, "PR", null, input.strPR, "1", null, null, null, null, null, true).strSql;
                        var resPR = repo.ExecuteQueryList<MapPRMasterDetail>(strSQL + strPagination);
                        resPR.TotalCount = !string.IsNullOrEmpty(strPagination) ? repo.ExecuteQueryList<MapPRMasterDetail>(strSQL).TotalCount : resPR.TotalCount;
                        return resPR;
                    case "PRCustomField":
                        dt = objShopping.getPRItemList(input.companyID, "PR", null, input.strPR, "2", null, null, null, null, null, false).ds.Tables[0];
                        if (dt.Rows.Count > 0)
                        {
                            return dt;
                        }
                        break;
                }
                return null;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetBCMListByUserNew(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.BudgetControl objBudget = new AgoraNEO.AgoraNEO.BudgetControl();

                string strSQL = objBudget.getBCMListByUserNew(input.userID, input.companyID, input.strCode, string.Empty, true).strSql;
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var repo = new BaseRepository<DTO.P2P.Master.analysis_code.ANALYSIS_CODE>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var res = repo.ExecuteQueryList<BCMListByUserNewMap>(strSQL + strPagination);
                res.TotalCount = !string.IsNullOrEmpty(strPagination) ? repo.ExecuteQueryList<BCMListByUserNewMap>(strSQL).TotalCount : res.TotalCount;
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetAnalysisCode(GetPRListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.IPP objAnalysisCode = new AgoraNEO.AgoraNEO.IPP();

                string strAnalysisCode = input.Filter != null && input.Filter != "" ? "" : (input.sAnalysisCode ?? string.Empty);
                string strAnalysisDesc = input.Filter != null && input.Filter != "" ? "" : (input.sAnalysisDesc ?? string.Empty);
                string strStatus = input.strStatus;

                string strSQL = objAnalysisCode.GetAnalysisCode(input.companyID, ref strAnalysisCode, ref strAnalysisDesc, input.strItemCode, ref strStatus, "eProcure").strSql;
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var repo = new BaseRepository<DTO.P2P.Master.analysis_code.ANALYSIS_CODE>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var res = repo.ExecuteQueryList<Master.Map.analysis_code.MapANALYSIS_CODE>(strSQL + strPagination);

                if (input.Filter != "" && input.Filter != null)
                {
                 
                    var filteredRepo = repo.ExecuteQuery<dynamic>(strSQL)
                       .Where(analysisCode => analysisCode.AC_ANALYSIS_CODE == input.Filter || analysisCode.AC_ANALYSIS_CODE_DESC == input.Filter).ToList();
                    return new ListResultContainer<Master.Map.analysis_code.MapANALYSIS_CODE>(filteredRepo, res.Columns, filteredRepo.Count())
                    {
                        HistoryName = res.HistoryName
                    };
                }
                else
                {
                    res.TotalCount = (!string.IsNullOrEmpty(strPagination)) ? repo.ExecuteQueryList<Master.Map.analysis_code.MapANALYSIS_CODE>(strSQL).TotalCount : res.TotalCount;
                    return res;
                }
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<ResultContainer> DeletePR(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();

                bool res = objPR.deletePR(input.userID, input.companyID, input.strPR);
                return new ResultContainer(string.Empty, res);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<ResultContainer> CancelPR(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();

                string msg = objPR.CancelPR(input.userID, input.strPR, input.strIndex, 0, input.strRemark);
                return new ResultContainer(msg, msg.Contains("Error") ? false : true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<ResultContainer> DuplicatePR(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();

                string msg = objPR.DuplicatePR(input.userID, input.strPR, input.strIndex);
                return new ResultContainer(msg, msg.Contains("created") ? true : false);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetPRDetail(GetPRListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS> repo = new BaseRepository<DTO.P2P.Master.pr_details.PR_DETAILS>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.get_PR(input.companyID, input.strPRNo, input.sProductCode, input.sProductIndex, input.sProductDesc);
                var res = repo.ExecuteQueryList<MapPRMasterDetail>(strSQL);
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }
        #endregion

        public async Task<dynamic> PRListForConvertPO(GetPRListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                AgoraNEO.AgoraNEO.Users objUSR = new AgoraNEO.AgoraNEO.Users();
                input.companyID = objUSR.getCompanyID(input.userID);
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                ArrayList array = null;
                if (input.pItemType != null)
                {
                    array = new ArrayList();
                    var arrayList = input.pItemType.Split(',');
                    for (int i = 0; i < arrayList.Length; i++)
                    {
                        array.Add(arrayList[i]);
                    }
                }

                string strSQL = objPR.PRListForConvertPO(input.strPRNo, input.userID, input.companyID, input.dteDateFr, input.dteDateTo, input.strRole, input.strBuyer, array, input.pComType);
                var res = repo.ExecuteQueryList<MapConvertPRtoPO>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> CreatePO(string userID, string companyID, string strPRNo, string pPRIndex, string pPRLine, string sProductIndex)
        {
            try
            {
                string msg = string.Empty;
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                msg = objPR.PRNoCheck(companyID, strPRNo);
                if (msg == "")
                {
                    string[] pquery = new string[1];
                    string strPO = objPR.CreatePO(companyID, userID, strPRNo, long.Parse(pPRIndex), "", ref pquery, userID, pPRLine, false);
                    msg = objPR.runQuery(ref pquery, strPO);
                    return new ResultContainer(string.Format(msg), true);
                }
                else
                {
                    return new ResultContainer(string.Format(msg), true);

                }
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }


        #region MISC
        private DataSet BindPR(MapPRMaster input)
        {
            try
            {
                #region init
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                AgoraNEO.AgoraNEO.Admin objAdmin = new AgoraNEO.AgoraNEO.Admin();
                AgoraNEO.AgoraNEO.EAD.DBCom objDB = new AgoraNEO.AgoraNEO.EAD.DBCom();
                objPR.Init();
                #endregion

                #region populate mstr
                DataRow dtr;
                dtr = objPR.dtMaster.NewRow();
                dtr["PRNo"] = input.PRNo;
                dtr["ReqName"] = input.ReqName ?? string.Empty;
                dtr["ReqPhone"] = input.ReqPhone ?? string.Empty;
                dtr["PRSEmail"] = input.PRSEmail ?? string.Empty;
                dtr["Attn"] = input.Attn ?? string.Empty;
                dtr["InternalRemark"] = input.InternalRemark ?? string.Empty;
                dtr["ExternalRemark"] = input.ExternalRemark ?? string.Empty;
                dtr["PrintCustom"] = input.PrintCustom ?? 1.ToString();
                dtr["PrintRemark"] = input.PrintRemark ?? 1.ToString();
                dtr["Urgent"] = input.Urgent ?? 0.ToString();
                // Set Both ShipmentTerm, ShipmentMode to 99 (Default)
                dtr["ShipmentTerm"] = string.Format("99");
                dtr["ShipmentMode"] = string.Format("99");
                dtr["PRType"] = input.PRType ?? string.Empty;
                dtr["PRCost"] = input.PRCost;
                objPR.dtMaster.Rows.Add(dtr);
                #endregion

                #region populate address
                DataSet dsBilling;
                DataView dvwBilling;
                dsBilling = objAdmin.PopulateAddr(input.UserID, input.CompanyID, "B", objAdmin.user_Default_Add(input.UserID, input.CompanyID, "B"), "", "").dsAddr;
                dvwBilling = dsBilling.Tables[0].DefaultView;
                foreach (DataRowView x in dvwBilling)
                {
                    dtr["BillAddrLine1"] = (!string.IsNullOrEmpty(input.BillAddrLine1)) ? input.BillAddrLine1 : (x.Row["AM_ADDR_LINE1"] != null && x.Row["AM_ADDR_LINE1"] != DBNull.Value ? x.Row["AM_ADDR_LINE1"].ToString() : string.Empty);
                    dtr["BillAddrLine2"] = (!string.IsNullOrEmpty(input.BillAddrLine2)) ? input.BillAddrLine2 : (x.Row["AM_ADDR_LINE2"] != null && x.Row["AM_ADDR_LINE2"] != DBNull.Value ? x.Row["AM_ADDR_LINE2"].ToString() : string.Empty);
                    dtr["BillAddrLine3"] = (!string.IsNullOrEmpty(input.BillAddrLine3)) ? input.BillAddrLine3 : (x.Row["AM_ADDR_LINE3"] != null && x.Row["AM_ADDR_LINE3"] != DBNull.Value ? x.Row["AM_ADDR_LINE3"].ToString() : string.Empty);
                    dtr["BillAddrPostCode"] = (!string.IsNullOrEmpty(input.BillAddrPostCode)) ? input.BillAddrPostCode : (x.Row["AM_POSTCODE"] != null && x.Row["AM_POSTCODE"] != DBNull.Value ? x.Row["AM_POSTCODE"].ToString() : string.Empty);
                    dtr["BillAddrState"] = (!string.IsNullOrEmpty(input.BillAddrState)) ? input.BillAddrState : (x.Row["AM_CITY"] != null && x.Row["AM_CITY"] != DBNull.Value ? x.Row["AM_CITY"].ToString() : string.Empty);
                    dtr["BillAddrCity"] = (!string.IsNullOrEmpty(input.BillAddrCity)) ? input.BillAddrCity : (x.Row["AM_COUNTRY"] != null && x.Row["AM_COUNTRY"] != DBNull.Value ? x.Row["AM_COUNTRY"].ToString() : string.Empty);
                    dtr["BillAddrCountry"] = (!string.IsNullOrEmpty(input.BillAddrCountry)) ? input.BillAddrCountry : (x.Row["AM_COUNTRY"] != null && x.Row["AM_COUNTRY"] != DBNull.Value ? x.Row["AM_COUNTRY"].ToString() : string.Empty); ;
                }
                dtr["BillAddrCode"] = (!string.IsNullOrEmpty(input.BillAddrCode)) ? input.BillAddrCode : objAdmin.user_Default_Add(input.UserID, input.CompanyID, string.Format("B"));
                #endregion

                #region populate details
                TimeSpan diffDay;
                DataRow dtrd;
                int i = 1;
                foreach (var detail in input.Details)
                {
                    dtrd = objPR.dtDetails.NewRow();

                    dtrd["Line"] = (detail.Line > 0) ? detail.Line : i;
                    detail.Line = (int)dtrd["Line"];

                    dtrd["ProductCode"] = detail.ProductCode ?? string.Empty;
                    dtrd["VendorItemCode"] = detail.VendorItemCode ?? string.Empty;
                    dtrd["ProductDesc"] = detail.ProductDesc ?? string.Empty;
                    dtrd["Qty"] = detail.Qty;

                    DataTable dt = objDB.FillDt(string.Format("SELECT CT_ID FROM COMMODITY_TYPE WHERE CT_NAME = '{0}'", detail.Commodity));
                    dtrd["Commodity"] = (dt.Rows.Count > 0 ? dt.Rows[0].ItemArray[0] : 0);

                    dtrd["UOM"] = detail.UOM ?? string.Empty;
                    dtrd["Currency"] = detail.Currency ?? string.Empty;
                    dtrd["UnitCost"] = detail.UnitCost;
                    dtrd["GST"] = detail.GST.ToString();
                    dtrd["GSTRate"] = detail.GSTRate ?? string.Empty;
                    dtrd["GSTTaxCode"] = detail.GstTaxCode ?? string.Empty; // GSTTaxCode
                    dtrd["DeliveryAddr"] = detail.DeliveryAddr ?? string.Empty;
                    diffDay = detail.Est.Subtract(DateTime.Today);
                    dtrd["ETD"] = Math.Abs(diffDay.Days); //detail.ETD;
                    dtrd["WarrantyTerms"] = detail.WarrantyTerms;
                    dtrd["Remark"] = detail.Remark ?? string.Empty;
                    dtrd["Source"] = detail.Source ?? string.Empty;
                    dtrd["VendorID"] = detail.VendorID;
                    dtrd["GLCode"] = detail.GLCode ?? string.Empty;
                    dtrd["CategoryCode"] = detail.CategoryCode ?? string.Empty;
                    dtrd["CDGroup"] = detail.CDGroup ?? string.Empty;
                    dtrd["AcctIndex"] = detail.AcctIndex ?? string.Empty;
                    dtrd["AssetGroup"] = detail.AssetGroup ?? string.Empty;
                    dtrd["Gift"] = detail.Gift ?? string.Empty;
                    dtrd["FundType"] = detail.FundType ?? string.Empty;
                    dtrd["PersonCode"] = detail.PersonCode ?? string.Empty;
                    dtrd["ProjectCode"] = detail.ProjectCode ?? string.Empty;

                    objPR.dtDetails.Rows.Add(dtrd);
                    i++;
                }
                #endregion

                DataSet ds = new DataSet();
                ds.Tables.Add(objPR.dtMaster);
                ds.Tables.Add(objPR.dtDetails);

                #region PR_CUSTOM_FIELD_MSTR
                DataView dvwCus;
                dvwCus = objAdmin.getCustomField(input.CompanyID, string.Empty);
                if (dvwCus != null)
                {
                    for (i = 0; i < dvwCus.Count; i++)
                    {
                        dtr = objPR.dtCustomMaster.NewRow();
                        dtr["FieldNo"] = dvwCus.Table.Rows[i]["CF_FIELD_NO"] ?? string.Empty;
                        dtr["FieldName"] = dvwCus.Table.Rows[i]["CF_FIELD_NAME"] ?? string.Empty;
                        objPR.dtCustomMaster.Rows.Add(dtr);
                    }
                }
                ds.Tables.Add(objPR.dtCustomMaster);
                #endregion

                #region PR_CUSTOM_FIELD_DETAILS
                if (dvwCus != null)
                {
                    for (i = 0; i < dvwCus.Count; i++)
                    {
                        foreach (var detail in input.Details)
                        {
                            dtr = objPR.dtCustomDetails.NewRow();
                            dtr["Line"] = detail.Line;
                            dtr["FieldNo"] = dvwCus.Table.Rows[i]["CF_FIELD_NO"] ?? string.Empty;
                            dtr["FieldValue"] = detail.FieldValue ?? string.Empty;
                            objPR.dtCustomDetails.Rows.Add(dtr);
                        }
                    }
                }
                ds.Tables.Add(objPR.dtCustomDetails);
                #endregion

                #region AttachmentID
                foreach (var item in input.FileAttachments)
                {
                    string docNo = string.Format("'{0}'", item.CDA_DOC_NO);
                    input.AttachmentID += string.IsNullOrEmpty(input.AttachmentID) ? docNo : ", " + docNo;
                }
                #endregion

                return ds;
            }
            catch (Exception ex)
            {

                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }

        private string ValidatePR(MapPRMaster input)
        {
            //if (string.IsNullOrEmpty(input.Attn))
            //{
            //    return L("RequiredMessage", L("Attention"));
            //}
            if (string.IsNullOrEmpty(input.ReqName))
            {
                return L("RequiredMessage", L("RequesterName"));
            }
            //if (string.IsNullOrEmpty(input.ReqPhone))
            //{
            //    return L("RequiredMessage", L("RequesterPhone"));
            //}
            if (string.IsNullOrEmpty(input.PRSEmail))
            {
                return L("RequiredMessage", L("RequesterEmail"));
            }
            //if (string.IsNullOrEmpty(input.InternalRemark))
            //{
            //    return L("RequiredMessage", L("InternalRemark"));
            //}
            //if (string.IsNullOrEmpty(input.ExternalRemark))
            //{
            //    return L("RequiredMessage", L("ExternalRemarks"));
            //}
            if (string.IsNullOrEmpty(input.PrintCustom))
            {
                return L("RequiredMessage", "Print Custom");
            }
            if (string.IsNullOrEmpty(input.PrintRemark))
            {
                return L("RequiredMessage", "Print Remark");
            }
            if (string.IsNullOrEmpty(input.Urgent))
            {
                return L("RequiredMessage", L("Urgent"));
            }
            if (input.Details.Count == 0)
            {
                return L("RequiredMessage", L("PRItem"));
            }
            foreach (var detail in input.Details)
            {
                if (string.IsNullOrEmpty(detail.VendorItemCode))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("VendorItemCode")));
                }
                if (string.IsNullOrEmpty(detail.Commodity))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("Commodity")));
                }
                if (string.IsNullOrEmpty(detail.UOM))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("UOM")));
                }
                if (string.IsNullOrEmpty(detail.Currency))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("Currency")));
                }
                if (string.IsNullOrEmpty(detail.DeliveryAddr))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("DeliveryAddress")));
                }
                if (string.IsNullOrEmpty(detail.AcctIndex))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("VendorItemCodeDesc")));
                }
                if (string.IsNullOrEmpty(detail.FundType))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("FUNDTYPE")));
                }
                if (string.IsNullOrEmpty(detail.PersonCode))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("PERSONCODEDESC")));
                }
                if (string.IsNullOrEmpty(detail.ProjectCode))
                {
                    return L("RequiredMessage", L("ItemLine", detail.Line, L("PROJECTCODEDESC")));
                }
                if (detail.Qty <= 0)
                {
                    return L("ItemLine", detail.Line, L("QTY")) + L("RangeInvalidMessage", "0.00", "999999.99");
                }
            }
            return string.Empty;
        }

        #endregion
        public async Task<dynamic> GetApprovalOrder(GetAOListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                var repo = new BaseRepository<DTO.P2P.Master.approval_grp_ao.APPROVAL_GRP_AO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strsql = objPR.getAOList(input.GrpIndex, input.userID, input.companyID, input.strType);

                var res = repo.ExecuteQueryList<MapApprovalOrder>(strsql);

                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRManager), ex);
                throw ex;
            }
        }


        #region enum 
        public enum WheelMsgNum
        {
            Save = 1,
            NotSave = 2,
            Delete = 3,
            NotDelete = 4,
            Duplicate = 5,
        }

        public enum PRStatus
        {
            Draft = 1,
            Submitted = 2,
            PendingApproval = 3,
            Approved = 4,
            ConvertedToPO = 5,
            CancelledBy = 6,
            HeldBy = 7,
            RejectedBy = 8,
            Void = 9
        }
        #endregion

    }

}
