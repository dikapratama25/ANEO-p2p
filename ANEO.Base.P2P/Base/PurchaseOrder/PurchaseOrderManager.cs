using Abp.Localization;
using Abp.ObjectMapping;
using Abp.UI;
using Abp.Web.Models;
using LOGIC.Shared.Collection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Controller;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
using System.Transactions;
using Plexform.DTO.Core.Location;
using Plexform.DTO.Core.General;
using System.Web;
using Abp.Runtime.Security;
using System.Linq;
using Plexform.Base.Core.General.Model;
using Plexform.Base.Core.General.Repo;
using Newtonsoft.Json.Linq;
using Abp.IdentityFramework;
using Plexform;
using Plexform.Base;
using Plexform.Base.Core;
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.Master.Model;
using System.Data;
using ANEO.Base.P2P.Base.PurchaseOrder;
using ANEO.Base.P2P.General.Model;

namespace ANEO.Base.P2P.PurchaseOrder
{ 
    public class PurchaseOrderManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public PurchaseOrderManager(
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
                Log.Error(nameof(PurchaseOrderManager), ex);
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
        public enum POStatus
        {
            Draft  = 0, 
            NewPO  = 1, 
            Open = 2 , 
            Accepted= 3 ,
            Rejected = 4,
            Cancelled = 5,
            Close = 6,
            Submitted = 7,
            PendingApproval = 8,
            Approved = 9,
            RejectedBy = 10,
            HeldBy = 11,
            Void = 12, 
            CancelledBy = 13
        }

        #endregion

        #region PO
        public async Task<dynamic> getPoList(GetPOListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder objPR = new AgoraNEO.AgoraNEO.PurchaseOrder();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                AgoraNEO.AgoraNEO.Users objUsr = new AgoraNEO.AgoraNEO.Users();
                input.companyID = objUsr.getCompanyID(input.userID);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                string strSQL = objPR.VIEW_POList(input.userID, input.companyID, input.strPOStatus, input.strFulfilment, input.strSide,input.strVenName, input.strPONo, input.dtStartDate, input.dtEndDate, input.strBuyerConName, input.strBuyerStatus, input.strItemCode, input.strPOType);
                var res = repo.ExecuteQueryList<MapPO_MSTR>(strSQL + strPagination);

                var totalCount = repo.ExecuteQueryList<MapPO_MSTR>(strSQL);
                res.TotalCount = totalCount.TotalCount;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getPODetail(GetPOListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder objPR = new AgoraNEO.AgoraNEO.PurchaseOrder();
                AgoraNEO.AgoraNEO.POValue objPO = new AgoraNEO.AgoraNEO.POValue();
                objPO.PO_Number = input.strPONo;
                objPO.buyer_coy = input.companyID;
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.get_PODetail(objPO, input.strSide, true);
                var res = repo.ExecuteQuery<MapPO_DETAILS>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> getlineitem(string userID, string companyID, string PO_No, string side, bool blnPreview, string strBCoyId,  bool blnShowAddr = true)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder objPR = new AgoraNEO.AgoraNEO.PurchaseOrder();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getlineitem(userID, companyID, PO_No, side, blnPreview, strBCoyId, blnShowAddr);
                var res = repo.ExecuteQueryList<mapPO_DetailLine>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getAppFlowPO(long intPRIndex, string companyID, string strFor)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                BaseRepository<DTO.P2P.Master.approval_grp_ao.APPROVAL_GRP_AO> repo = new BaseRepository<DTO.P2P.Master.approval_grp_ao.APPROVAL_GRP_AO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getApprFlowPO(intPRIndex, companyID, strFor);
                var res = repo.ExecuteQueryList<MapApprovalOrderListPO>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetPOForApprDetails(string userID, string companyID, string PO_No, string  PRIndex)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder_AO objPO = new AgoraNEO.AgoraNEO.PurchaseOrder_AO();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL= objPO.GetPOForApprDetails(companyID, PO_No, PRIndex);
                var res = repo.ExecuteQueryList<mapPO_DetailLine>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> get_CRView(string userID, string companyID, string po_no, string cr_no, string side, string bcom_id, string cr_status = "")
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder objPR = new AgoraNEO.AgoraNEO.PurchaseOrder();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.get_CRView(po_no, cr_no, side, bcom_id, userID, companyID, cr_status);
                var res = repo.ExecuteQuery<MapPO_MSTR>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> get_docitem(string strPONo, string side, string b_com_id, string companyID)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder objPR = new AgoraNEO.AgoraNEO.PurchaseOrder();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.get_docitem(strPONo, side, b_com_id, companyID);
                var res = repo.ExecuteQueryList<mapPO_Detailitem>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getApprFlow(long intPRIndex, string strCoyId, string strFor = "")
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getApprFlow(intPRIndex, strCoyId, strFor);
                var res = repo.ExecuteQuery<MapPO_MSTR>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getPOListForApproval(GetPOListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder_AO  objPO = new AgoraNEO.AgoraNEO.PurchaseOrder_AO();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                AgoraNEO.AgoraNEO.Users objUsr = new AgoraNEO.AgoraNEO.Users();
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                input.companyID = objUsr.getCompanyID(input.userID);
                string strSQL = objPO.getPOListForApproval(input.userID, input.companyID, input.strPONo, input.strVenName, input.dtStartDate, input.dtEndDate, input.strReliefOn,input.strAction , input.strPOStatus , "", "", "strIncludeHold").strSql ;
                var res = repo.ExecuteQueryList<MapPO_MSTR>(strSQL + strPagination);
                var totalCount = repo.ExecuteQueryList<MapPO_MSTR>(strSQL);
                res.TotalCount = totalCount.TotalCount;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic>ApprovePO(mapApprovedPO input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder_AO objPO = new AgoraNEO.AgoraNEO.PurchaseOrder_AO();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                DataSet ds = PopulatePODataSetApproval(input);
               var res = objPO.ApprovePO(input.userID, input.companyID, input.strPONo, input.strPOIndex, input.currentseq, input.blnhighestlevel, input.strAORemark, input.strBuyer, false, input.Approvaltype, input.strCoyID, ds);
                return new ResultContainer(string.Format(res), true);

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic>AcceptPO(mapAcceptPO input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder_Vendor objPO = new AgoraNEO.AgoraNEO.PurchaseOrder_Vendor();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                DataSet ds = POAcceptanceDataset(input);
                var res = objPO.update_POStatus(ds, input.userID, input.strCoyID,  input.companyID);
                return new ResultContainer(string.Format(res), true);
            }
            catch(Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> RejectPO(mapAcceptPO input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder_Vendor objPO = new AgoraNEO.AgoraNEO.PurchaseOrder_Vendor();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                DataSet ds = PORejectDataset(input);
                var res = objPO.update_POStatus(ds, input.userID, input.companyID);
                return new ResultContainer(string.Format(res), true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> AcknowledgePO(GetPOListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder_Vendor objPO = new AgoraNEO.AgoraNEO.PurchaseOrder_Vendor();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                AgoraNEO.AgoraNEO.Users objUsr = new AgoraNEO.AgoraNEO.Users();
                input.companyID = objUsr.getCompanyID(input.userID);
                string strSQL = objPO.getPOForAck(input.companyID);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var res = repo.ExecuteQueryList<MapPO_MSTR>(strSQL + strPagination);
                var totalCount = repo.ExecuteQueryList<MapPO_MSTR>(strSQL);
                res.TotalCount = totalCount.TotalCount;
                return res;


            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }



        public async Task<dynamic> getPoAttachment(string strPONo, string strCoyId)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder objPR = new AgoraNEO.AgoraNEO.PurchaseOrder();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getPoAttachment(strPONo, strCoyId);
                var res = repo.ExecuteQuery<mapDocAttachment>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> update_POStatus(GetPOListParameter input)
        {
            try
            {

                AgoraNEO.AgoraNEO.PurchaseOrder_Vendor objPo = new AgoraNEO.AgoraNEO.PurchaseOrder_Vendor();
                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                DataSet ds = new DataSet();
                DataTable POstatus = new DataTable();
                DataRow dtr;
                var status = AgoraNEO.AgoraNEO.POStatus_new.Accepted;
                string strMsg = "";

                POstatus.Columns.Add("status", Type.GetType("System.String"));
                POstatus.Columns.Add("datakey", Type.GetType("System.String"));
                POstatus.Columns.Add("BCoyID", Type.GetType("System.String"));
                POstatus.Columns.Add("remark", Type.GetType("System.String"));
                dtr = POstatus.NewRow();
                dtr["status"] = status;
                dtr["datakey"] = input.strPONo;
                dtr["BCoyID"] = input.companyID;
                dtr["remark"] = "remark";
                POstatus.Rows.Add(dtr);
                ds.Tables.Add(POstatus);
                strMsg = objPo.update_POStatus(ds, input.userID,"", input.companyID);

                return strMsg;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> SubmitPO(MapPO_DETAILS input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseOrder objPR = new AgoraNEO.AgoraNEO.PurchaseOrder();
                AgoraNEO.AgoraNEO.PurchaseOrder_Buyer objPO1 = new AgoraNEO.AgoraNEO.PurchaseOrder_Buyer();
                AgoraNEO.AgoraNEO.PR objPR2 = new AgoraNEO.AgoraNEO.PR();
                AgoraNEO.AgoraNEO.EAD.DBCom objDB = new AgoraNEO.AgoraNEO.EAD.DBCom();

                BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR> repo = new BaseRepository<DTO.P2P.Master.po_mstr.PO_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                if(input.ApprovalOrders == null)
                {

                    DataSet dsPO = PopulatePODataSet(input);
                    DataSet dsapplist = objPR2.getAppovalList(input.UserID, input.CompanyID, "A", Convert.ToDouble(input.POM_PO_COST), "PO", true).ds;
                    if(dsapplist.Tables[0].Rows.Count ==0)
                    {
                        return new ResultContainer(string.Format("There is no approval list available for this PR because the sequence of approving officers do not have the approval limit to approve it."), false);
                    }
                    string strInvAppr = "";
                    strInvAppr = objDB.GetVal("SELECT CM_INV_APPR FROM COMPANY_MSTR WHERE CM_COY_ID = '" + input.CompanyID + "'");
                    if (strInvAppr == "Y")
                    {
                       if (objDB.Exist("SELECT '*' FROM USER_MSTR " + "INNER JOIN COMPANY_DEPT_MSTR ON CDM_DEPT_CODE = UM_DEPT_ID AND CDM_COY_ID = UM_COY_ID " + "INNER JOIN APPROVAL_GRP_MSTR ON AGM_GRP_INDEX = CDM_APPROVAL_GRP_INDEX WHERE UM_USER_ID ='" + input.UserID + "' " + "AND UM_COY_ID = '" + input.CompanyID + "'") == 0)
                       {
                            //strMsg += "<li><ul type='disc'></ul></li>";
                            return new ResultContainer(string.Format("There is no Invoice Approval List for your department. Please contact the administrator."), false);
                        }
                    }
                    string strPO_No = objDB.GetVal("SELECT IFNULL(CAST(GROUP_CONCAT(CONCAT(CONCAT(\"'\", PRD_CONVERT_TO_DOC),\"'\")) AS CHAR(2000)),'') AS PRD_CONVERT_TO_DOC FROM PR_DETAILS WHERE PRD_COY_ID = '" + input.CompanyID + "' AND PRD_CONVERT_TO_DOC = '" + input.POM_PO_NO + "'");
                    string strPR_Index = objDB.GetVal("SELECT IFNULL(CAST(GROUP_CONCAT(CONCAT(CONCAT(\"'\",PRM_PR_INDEX),\"'\")) AS CHAR(2000)),'') AS PRM_PR_INDEX FROM PR_DETAILS, PR_MSTR WHERE PRM_COY_ID = PRD_COY_ID AND PRM_PR_NO = PRD_PR_NO AND PRD_COY_ID = '" + input.CompanyID + "' AND (PRD_CONVERT_TO_DOC IN (" + strPO_No + "))");
                    string strGrp_Index = objDB.GetVal("SELECT IFNULL(CAST(GROUP_CONCAT(CONCAT(CONCAT(\"'\",PRA_APPROVAL_GRP_INDEX),\"'\")) AS CHAR(2000)),'') AS PRA_APPROVAL_GRP_INDEX FROM PR_APPROVAL WHERE PRA_FOR = 'PR' AND PRA_PR_INDEX IN (" + strPR_Index + ")");
                    string strDept_Code = objDB.GetVal("SELECT IFNULL(CAST(GROUP_CONCAT(CONCAT(CONCAT(\"'\",AGM_DEPT_CODE),\"'\")) AS CHAR(2000)),'') AS AGM_DEPT_CODE FROM APPROVAL_GRP_MSTR WHERE AGM_DEPT_CODE IS NOT NULL AND AGM_DEPT_CODE <> '' AND AGM_GRP_INDEX IN (" + strGrp_Index + ")");

                    DataTable dt = objPO1.getPOApprFlow(input.UserID, input.CompanyID, true, ref strDept_Code);
                    bool CheckApprB4 = true;
                    if (dt.Rows.Count == 0)
                    {
                        CheckApprB4 = false;
                    }
                    if (input.POM_PO_NO == "To Be Allocated By System" && CheckApprB4)
                    {
                        string strNewPO = "";
                        int intMsg = objPO1.insertPO(input.UserID, input.CompanyID, dsPO, ref strNewPO, false);
                        return new ResultContainer(strNewPO, true);
                    }
                    else
                    {
                        objPO1.updatePO(input.UserID , input.CompanyID,dsPO, false);
                    }

                }
                else
                {
                    DataRow dtr;
                    int m = 0;
                    DataTable dtAO = new DataTable();
                    dtAO.Columns.Add("poid", Type.GetType("System.String"));
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
                            dtr["poid"] = input.POM_PO_NO;
                            dtr["AO"] = item.AO;
                            dtr["AAO"] = (!string.IsNullOrEmpty(item.AAO)) ? item.AAO : string.Empty;
                            dtr["GrpIndex"] = item.GrpIndex;
                            dtr["Relief"] = item.Relief;

                            switch (item.Type)
                            {
                                case "Approval":
                                    dtr["Type"] = "1";
                                    m = m + 1;
                                    break;
                                case "Endorsement":
                                    dtr["Type"] = "2";
                                    m = m + 1;
                                    break;
                            }
                            dtr["seq"] = m;
                            if (dtr["Type"].ToString() != "0")
                            {
                                dtr["Seq"] = m;
                                dtAO.Rows.Add(dtr);
                            }

                        }
                    }
                    string strSQL = objPR.SubmitPO(input.UserID, dtAO, input.CompanyID, input.POM_PO_NO);
                }
                // objPO1.updatePO(input.UserID,input.CompanyID,ds,false);
                //var res = repo.ExecuteQuery<MapPO_MSTR>(strSQL);
                return new ResultContainer(string.Format(input.POM_PO_NO), true);

            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderManager), ex);
                throw ex;
            }
        }
        #endregion
        private DataSet PopulatePODataSet(MapPO_DETAILS input)
        {
            DataTable dtMaster = new DataTable();
            DataSet dsPO;
            dtMaster.Columns.Add("PONo", Type.GetType("System.String"));
            dtMaster.Columns.Add("VendorID", Type.GetType("System.String"));
            dtMaster.Columns.Add("Attn", Type.GetType("System.String"));
            dtMaster.Columns.Add("PaymentType", Type.GetType("System.String"));
            dtMaster.Columns.Add("ShipmentTerm", Type.GetType("System.String"));
            dtMaster.Columns.Add("ShipmentMode", Type.GetType("System.String"));
            dtMaster.Columns.Add("CurrencyCode", Type.GetType("System.String"));
            dtMaster.Columns.Add("ExchangeRate", Type.GetType("System.Double"));
            dtMaster.Columns.Add("PaymentTerm", Type.GetType("System.String"));
            dtMaster.Columns.Add("ShipVia", Type.GetType("System.String"));
            dtMaster.Columns.Add("InternalRemark", Type.GetType("System.String"));
            dtMaster.Columns.Add("ExternalRemark", Type.GetType("System.String"));
            dtMaster.Columns.Add("Urgent", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrCode", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrLine1", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrLine2", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrLine3", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrPostCode", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrState", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrCity", Type.GetType("System.String"));
            dtMaster.Columns.Add("BillAddrCountry", Type.GetType("System.String"));
            dtMaster.Columns.Add("PrintCustom", Type.GetType("System.String"));
            dtMaster.Columns.Add("PrintRemark", Type.GetType("System.String"));
            dtMaster.Columns.Add("ShipAmt", Type.GetType("System.String"));
            dtMaster.Columns.Add("RfqIndex", Type.GetType("System.String"));
            dtMaster.Columns.Add("QuoNo", Type.GetType("System.String"));
            dtMaster.Columns.Add("POM_EXCHANGE_RATE", Type.GetType("System.Double"));
            dtMaster.Columns.Add("BillingMethod", Type.GetType("System.String"));
            dtMaster.Columns.Add("POCost", Type.GetType("System.Double"));
            DataRow drw = dtMaster.NewRow();
            drw["PONo"] = input.POM_PO_NO;
            drw["VendorID"] = input.POM_S_COY_ID;
            drw["Attn"] = input.POM_S_ATTN;
            drw["PaymentType"] = input.POM_PAYMENT_METHOD;
            drw["ShipmentTerm"] = input.POM_SHIPMENT_TERM;
            drw["ShipmentMode"] = input.POM_SHIPMENT_MODE;
            drw["CurrencyCode"] = input.POM_CURRENCY_CODE;
            drw["ExchangeRate"] = 1;
            drw["PaymentTerm"] = input.POM_PAYMENT_TERM;
            drw["ShipVia"] = input.POM_SHIP_VIA == null ? "" : input.POM_SHIP_VIA;
            drw["InternalRemark"] = input.POM_INTERNAL_REMARK;
            drw["ExternalRemark"] = input.POM_EXTERNAL_REMARK;
            drw["Urgent"] = input.POM_URGENT;
            drw["BillAddrCode"] = input.POM_B_ADDR_CODE;
            drw["BillAddrLine1"] = input.POM_B_ADDR_LINE1;
            drw["BillAddrLine2"] = input.POM_B_ADDR_LINE2;
            drw["BillAddrLine3"] = input.POM_B_ADDR_LINE3;
            drw["BillAddrPostCode"] = input.POM_B_POSTCODE;
            drw["BillAddrState"] = input.POM_B_STATE;
            drw["BillAddrCity"] = input.POM_B_CITY;
            drw["BillAddrCountry"] = input.POM_B_COUNTRY;
            drw["PrintCustom"] = input.POM_PRINT_CUSTOM_FIELDS;
            drw["PrintRemark"] = input.POM_PRINT_REMARK;
            drw["ShipAmt"] = input.POM_SHIP_AMT == null ? 0 : input.POM_SHIP_AMT;
            drw["PrintCustom"] = input.POM_PRINT_CUSTOM_FIELDS;
            drw["QuoNo"] = "";
            drw["RfqIndex"] = "NULL";
            drw["POCost"] = 0;
            DataTable dtDetails = new DataTable();
            DataSet ds = new DataSet();
            dtDetails.Columns.Add("Line", Type.GetType("System.Int32"));
            dtDetails.Columns.Add("ProductCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("VendorItemCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("TaxCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("ProductDesc", Type.GetType("System.String"));
            dtDetails.Columns.Add("UOM", Type.GetType("System.String"));
            dtDetails.Columns.Add("Qty", Type.GetType("System.Double"));
            dtDetails.Columns.Add("UnitCost", Type.GetType("System.Double"));
            dtDetails.Columns.Add("ETD", Type.GetType("System.Int32"));
            dtDetails.Columns.Add("Remark", Type.GetType("System.String"));
            dtDetails.Columns.Add("GST", Type.GetType("System.String"));
            dtDetails.Columns.Add("SelectedGST", Type.GetType("System.String"));
            dtDetails.Columns.Add("GSTTaxAmount", Type.GetType("System.Double"));
            dtDetails.Columns.Add("DeliveryAddr", Type.GetType("System.String"));
            dtDetails.Columns.Add("AcctIndex", Type.GetType("System.String"));
            dtDetails.Columns.Add("ProductType", Type.GetType("System.String"));
            dtDetails.Columns.Add("Source", Type.GetType("System.String"));
            dtDetails.Columns.Add("TAXID", Type.GetType("System.String"));
            dtDetails.Columns.Add("MOQ", Type.GetType("System.String"));
            dtDetails.Columns.Add("MPQ", Type.GetType("System.String"));
            dtDetails.Columns.Add("CDGroup", Type.GetType("System.String"));
            dtDetails.Columns.Add("POD_RFQ_ITEM_LINE", Type.GetType("System.String"));
            dtDetails.Columns.Add("GSTTaxCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("ItemCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("WarrantyTerms", Type.GetType("System.Int32"));
            dtDetails.Columns.Add("DeliveryAddress", Type.GetType("System.String"));
            dtDetails.Columns.Add("CategoryCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("GLCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("RfqQty", Type.GetType("System.Int32"));
            dtDetails.Columns.Add("QtyTolerance", Type.GetType("System.Int32"));
            dtDetails.Columns.Add("SupplierCompanyId", Type.GetType("System.String"));
            dtDetails.Columns.Add("AssetGroup", Type.GetType("System.String"));
            dtDetails.Columns.Add("AssetGroupNo", Type.GetType("System.String"));
            dtDetails.Columns.Add("Gift", Type.GetType("System.String"));
            dtDetails.Columns.Add("pod_fund_type", Type.GetType("System.String"));
            dtDetails.Columns.Add("pod_person_code", Type.GetType("System.String"));
            dtDetails.Columns.Add("pod_project_code", Type.GetType("System.String"));

            DataRow dtrd;
            dtrd = dtDetails.NewRow();

            float decItemPrice = 0;

            for (int i = 0; i < input.detailline.Count; i++)
            {
                dtrd["Line"] = input.detailline[i].POD_PO_LINE;
                dtrd["ProductCode"] = input.detailline[i].POD_B_CATEGORY_CODE;
                dtrd["VendorItemCode"] = input.detailline[i].POD_VENDOR_ITEM_CODE;
                dtrd["ProductDesc"] = input.detailline[i].POD_PRODUCT_DESC;
                dtrd["UOM"] = input.detailline[i].POD_UOM;
                dtrd["MOQ"] = input.detailline[i].POD_MIN_ORDER_QTY;
                dtrd["GLCode"] = input.detailline[i].POD_B_GL_CODE;
                dtrd["MPQ"] = input.detailline[i].POD_MIN_PACK_QTY;
                dtrd["ItemCode"] = input.detailline[i].POD_VENDOR_ITEM_CODE;
                dtrd["Qty"] = input.detailline[i].POD_ORDERED_QTY;
                dtrd["UnitCost"] = input.detailline[i].POD_UNIT_COST;
                dtrd["GST"] = input.detailline[i].GST_RATE;
                dtrd["GSTTaxCode"] = input.detailline[i].POD_GST_INPUT_TAX_CODE;
                dtrd["GSTTaxAmount"] = input.detailline[i].POD_TAX_VALUE;
                dtrd["Remark"] = input.detailline[i].POD_REMARK;
                dtrd["Source"] = "PC";
                dtrd["CategoryCode"] = input.detailline[i].POD_B_CATEGORY_CODE;
                dtrd["Gift"] = input.detailline[i].POD_GIFT;
                dtrd["pod_fund_type"] = input.detailline[i].POD_FUND_TYPE ;
                dtrd["pod_person_code"] = input.detailline[i].POD_PERSON_CODE;
                dtrd["pod_project_code"] = input.detailline[i].POD_PROJECT_CODE;
                dtrd["WarrantyTerms"] = input.detailline[i].POD_WARRANTY_TERMS;
                dtrd["DeliveryAddr"] = input.detailline[i].POD_D_ADDR_CODE;

            }
            dtMaster.Rows.Add(drw);
            dtDetails.Rows.Add(dtrd);
            ds.Tables.Add(dtMaster);
            ds.Tables.Add(dtDetails);
            return ds; 
        }

       
        private DataSet POAcceptanceDataset(mapAcceptPO input)
        {

            DataTable POstatus = new DataTable();
            DataSet ds = new DataSet();
            DataRow dtrd;
            var status = AgoraNEO.AgoraNEO.POStatus_new.Accepted;
            POstatus.Columns.Add("status", Type.GetType("System.Int32"));
            POstatus.Columns.Add("datakey", Type.GetType("System.String"));
            POstatus.Columns.Add("BCoyID", Type.GetType("System.String"));
            POstatus.Columns.Add("remark", Type.GetType("System.String"));
            dtrd = POstatus.NewRow();
            dtrd["status"] = status;
            dtrd["datakey"] = input.strPONo;
            dtrd["BCoyID"] = input.companyID;
            dtrd["remark"] = "remark";
            POstatus.Rows.Add(dtrd);
            ds.Tables.Add(POstatus);
            return ds;


        }
        private DataSet PORejectDataset(mapAcceptPO input)
        {

            DataTable POstatus = new DataTable();
            DataSet ds = new DataSet();
            DataRow dtrd;
            var status = AgoraNEO.AgoraNEO.POStatus_new.Rejected;
            POstatus.Columns.Add("status", Type.GetType("System.String"));
            POstatus.Columns.Add("datakey", Type.GetType("System.String"));
            POstatus.Columns.Add("BCoyID", Type.GetType("System.String"));
            POstatus.Columns.Add("remark", Type.GetType("System.String"));
            dtrd = POstatus.NewRow();
            dtrd["status"] = status;
            dtrd["datakey"] = input.strPONo;
            dtrd["BCoyID"] = input.companyID;
            dtrd["remark"] = "remark";
            POstatus.Rows.Add(dtrd);
            ds.Tables.Add(POstatus);
            return ds;


        }
        private DataSet PopulatePODataSetApproval(mapApprovedPO input)
        {
            
            DataTable dtDetails = new DataTable();
            DataSet ds = new DataSet();
            dtDetails.Columns.Add("PONo", Type.GetType("System.String"));
            dtDetails.Columns.Add("Line", Type.GetType("System.Int32"));
            dtDetails.Columns.Add("ProductCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("VendorItemCode", Type.GetType("System.String"));
            dtDetails.Columns.Add("ProductDesc", Type.GetType("System.String"));
            dtDetails.Columns.Add("ETD", Type.GetType("System.Int32"));
      

            DataRow dtrd;
            dtrd = dtDetails.NewRow();
            TimeSpan diffDay;
           // float decItemPrice = 0;

            for (int i = 0; i < input.detailline.Count; i++)
            {
                dtrd["PONo"] = input.strPONo;
                dtrd["Line"] = input.detailline[i].POD_PO_LINE;
                dtrd["ProductCode"] = input.detailline[i].POD_PRODUCT_CODE;
                dtrd["VendorItemCode"] = input.detailline[i].POD_VENDOR_ITEM_CODE;
                dtrd["ProductDesc"] = input.detailline[i].POD_PRODUCT_DESC;
                dtrd["ETD"] = input.detailline[i].POD_ETD;


            }
            //dtMaster.Rows.Add(drw);
            dtDetails.Rows.Add(dtrd);
            //ds.Tables.Add(dtMaster);
            ds.Tables.Add(dtDetails);
            return ds;
        }
    }
}
