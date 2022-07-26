using Abp.Localization;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Linq;
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
using ANEO.Base.P2P.Tracking.Map;
using AgoraNEO.AgoraNEO;
using LOGIC.Shared.Collection;

namespace ANEO.Base.P2P.Tracking
{
    public class TrackingManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public TrackingManager(
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
                Log.Error(nameof(TrackingManager), ex);
            }
        }

        public async Task<dynamic> GetAvailableCurrencyList()
        {
            try
            {
                var obj = new AgoraNEO.AgoraNEO.AppDataProvider();
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var strSql = (string)obj.GetMasterCodeByStatus(AgoraNEO.AgoraNEO.CodeTable.Currency, "N", true);
                var data = repo.ExecuteQueryList<dynamic>(strSql);
                return data;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetFundType(string CompanyId, string DeptCode)
        {
            try
            {
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var strSQL = "SELECT AC_ANALYSIS_CODE, CONCAT(CONCAT(IFNULL(AC_ANALYSIS_CODE, ''),' : '), IFNULL(AC_ANALYSIS_CODE_DESC, '')) AS AC_ANALYSIS_CODE_DESC "
                        + "FROM analysis_code "
                        + "WHERE AC_B_COY_ID ='" + CompanyId + "' AND AC_DEPT_CODE = '" + DeptCode + "' AND AC_STATUS = 'O' "
                        + "ORDER BY AC_ANALYSIS_CODE ";
                var data = repo.ExecuteQueryList<dynamic>(strSQL);
                return data;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetFinanceApprovalRemark(int invoiceIndex)
        {
            try
            {
                AgoraNEO.AgoraNEO.Tracking objTrac = new AgoraNEO.AgoraNEO.Tracking();
                BaseRepository<dynamic> repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var strlSQL = objTrac.getFinanceApprRemarks(invoiceIndex);
                var res = repo.ExecuteQueryList<dynamic>(strlSQL);
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> populateGridINV(TrackingParameter input)
        {
            try
            {


                AgoraNEO.AgoraNEO.Tracking objTrac = new AgoraNEO.AgoraNEO.Tracking();
                if (input.companyID == "1234")
                {
                    input.companyID = "pamb";
                }
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objTrac.getInvoiceTracking_NoDocMatch(input.userID, input.companyID, input.strDocNo, input.strVenName, "", "", input.strStatus, input.strIPPStatus, input.strInvFrom, input.strDocType, "", "", true, input.strCurr, input.strFundType, input.strCompResident, input.strAmountFrom, input.strAmountTo, input.strDueDate, input.strPaymentMode);
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : (input.Filter != "" && input.Filter != null) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                strSQL += (input.Sorting != null && input.Sorting != "") ? $" ORDER BY {input.Sorting} " : " ORDER BY POM_PO_Date Desc ";
                var res = repo.ExecuteQueryList<TrackingMap>(strSQL);
                var resWithPagination = repo.ExecuteQuery<TrackingMap>(strSQL + strPagination).ToList();
                if (resWithPagination.Count > 0)
                {
                    for (int index = 0; index < resWithPagination.Count(); index++)
                    {
                        var remark = (ListResultContainer<dynamic>)await GetFinanceApprovalRemark(int.Parse(resWithPagination[index].IM_INVOICE_INDEX));

                        resWithPagination[index].REMARK = remark != null ? remark.Items.First().FA_AO_REMARK : "";

                        if (resWithPagination[index].DOC_TYPE == "IPP")
                        {
                            switch (resWithPagination[index].IM_INVOICE_TYPE)
                            {
                                case "INV":
                                    {
                                        resWithPagination[index].IM_INVOICE_TYPE = "Invoice";
                                        break;
                                    }
                                case "BILL":
                                    {
                                        resWithPagination[index].IM_INVOICE_TYPE = "Bill";
                                        break;
                                    }
                                case "CN":
                                    {
                                        resWithPagination[index].IM_INVOICE_TYPE = "Credit Note";
                                        break;
                                    }
                                case "DN":
                                    {
                                        resWithPagination[index].IM_INVOICE_TYPE = "Debit Note";
                                        break;
                                    }
                            }
                        }
                        else
                        {
                            resWithPagination[index].IM_INVOICE_TYPE = "Invoice";
                        }


                    }
                }
                resWithPagination = (input.Filter != "" && input.Filter != null) ? resWithPagination.Where(FilterGridINV(input.Filter)).ToList() : resWithPagination;
                int totalCount = (input.Filter != null && input.Filter != "") ? resWithPagination.Count() : res.TotalCount;
                string role = findRole(input.userID, input.companyID);
                return new ListResultContainer<dynamic>(resWithPagination, res.Columns, totalCount) {
                    HistoryName = role,
                };

            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }

            Func<TrackingMap, bool> FilterGridINV(string searchFilter)
            {
                var isNumber = decimal.TryParse(searchFilter, out decimal result);

                return invoices =>
                        searchFilter != null && searchFilter != "" && invoices.IM_INVOICE_NO != null && invoices.IM_INVOICE_NO.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.IM_INVOICE_TYPE != null && invoices.IM_INVOICE_TYPE.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.POM_S_COY_NAME != null && invoices.POM_S_COY_NAME.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.INVAMT_INMYR != null && invoices.INVAMT_INMYR.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.POM_CURRENCY_CODE != null && invoices.POM_CURRENCY_CODE.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && isNumber && invoices.IM_INVOICE_TOTAL == result ||
                        searchFilter != null && searchFilter != "" && invoices.REMARK != null && invoices.REMARK.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.IM_RESIDENT_TYPE != null && invoices.IM_RESIDENT_TYPE.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.POM_PAYMENT_METHOD != null && invoices.POM_PAYMENT_METHOD.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.ID_ANALYSIS_CODE1 != null && invoices.ID_ANALYSIS_CODE1.Contains(searchFilter);
            }

        }

        public async Task<dynamic> getFinanceApprFlow(TrackingSaveParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Tracking objTrac = new AgoraNEO.AgoraNEO.Tracking();
                AgoraNEO.AgoraNEO.EAD.DBCom objDB = new AgoraNEO.AgoraNEO.EAD.DBCom();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objTrac.getFinanceApprFlow(input.companyID, input.IM_INVOICE_NO, input.IM_S_COY_ID);
                var res = repo.ExecuteQueryList<FinanceApprovalFlow>(strSQL);
                var items = repo.ExecuteQuery<FinanceApprovalFlow>(strSQL);
                string str = "SELECT IM_INVOICE_TOTAL FROM INVOICE_MSTR WHERE IM_Invoice_No= '" + input.IM_INVOICE_NO + "'";
                str += " AND IM_S_COY_ID='" + input.IM_S_COY_ID + "'";
                DataSet tDS = objDB.FillDs(str);
                decimal dblInvoiceAmount = 0;
                if (tDS.Tables[0].Rows.Count > 0)
                {
                    dblInvoiceAmount = (decimal)tDS.Tables[0].Rows[0]["IM_INVOICE_TOTAL"];
                }
                foreach (var item in items)
                {
                    item.FA_ACTION_DATE = item.FA_ACTION_DATE > DateTime.MinValue ? item.FA_ACTION_DATE : null;

                    if (item.FA_AGA_TYPE == "FO" && Convert.ToDecimal(dblInvoiceAmount) < Convert.ToDecimal(Common.parseNull(item.AO_LIMIT, 0)))
                    {
                        item.FA_APPROVAL_TYPE = "N/A";
                    }
                    else
                    {
                        item.FA_APPROVAL_TYPE = "Approval";
                    }
                }
                res.Items = items;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> populateInvDetail(TrackingSaveParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Invoice objinv = new AgoraNEO.AgoraNEO.Invoice();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                DataSet res = objinv.inv_detail(input.IM_INVOICE_NO, input.IM_S_COY_ID);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> renderCnSummary(TrackingSaveParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.CreditNote objCn = new AgoraNEO.AgoraNEO.CreditNote();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objCn.getInvRelatedCN(input.IM_INVOICE_NO, input.IM_S_COY_ID);
                var res = repo.ExecuteQueryList<CNSummary>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> renderDnSummary(TrackingSaveParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.DebitNote objDn = new AgoraNEO.AgoraNEO.DebitNote();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objDn.getInvRelatedDN(input.IM_INVOICE_NO, input.IM_S_COY_ID);
                var res = repo.ExecuteQueryList<DNSummary>(strSQL);
                string role = findRole(input.userID, input.companyID);
                res.HistoryName = role;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> populateInvDetailHeader(TrackingSaveParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Invoice objinv = new AgoraNEO.AgoraNEO.Invoice();
                AgoraNEO.AgoraNEO.InvValue a = new AgoraNEO.AgoraNEO.InvValue();
                a.doc_num = null;
                a.Inv_no = input.IM_INVOICE_NO;
                a.Vcom_id = input.IM_S_COY_ID;
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var strSQL = objinv.get_invmstr(a);
                var res = repo.ExecuteQuery<TrackingDetailHeader>(strSQL);
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getInvAttachmentString(TrackingSaveParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Invoice objinv = new AgoraNEO.AgoraNEO.Invoice();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var strSQL = objinv.getInvAttachmentString(input.IM_INVOICE_NO,input.IM_S_COY_ID);
                var res = repo.ExecuteQueryList<InvoiceAttachment>(strSQL);
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> saveGridInv(TrackingParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.GRN objDO = new AgoraNEO.AgoraNEO.GRN();
                AgoraNEO.AgoraNEO.Tracking objTrac = new AgoraNEO.AgoraNEO.Tracking();
                bool blnValid = false;
                string strmsg = "";
                #region populate From Grid
                DataTable dtItem = new DataTable();
                dtItem.Columns.Add("DocType", Type.GetType("System.String"));
                dtItem.Columns.Add("InvIndex", Type.GetType("System.Int32"));
                dtItem.Columns.Add("InvNo", Type.GetType("System.String"));
                dtItem.Columns.Add("PoIndex", Type.GetType("System.String"));
                dtItem.Columns.Add("Vendor", Type.GetType("System.String"));
                dtItem.Columns.Add("FinRemark", Type.GetType("System.String"));
                dtItem.Columns.Add("InvStatus", Type.GetType("System.Int32"));
                dtItem.Columns.Add("Submitted", Type.GetType("System.String"));
                dtItem.Columns.Add("AppDate", Type.GetType("System.String"));
                dtItem.Columns.Add("PayTerm", Type.GetType("System.String"));
                dtItem.Columns.Add("BillMethod", Type.GetType("System.String"));
                dtItem.Columns.Add("Contract", Type.GetType("System.String"));
                DataRow dtr;
                AgoraNEO.AgoraNEO.CreditNote objCn = new AgoraNEO.AgoraNEO.CreditNote();
                string strInv = "";
                string strInvFail = "";
                string strInvFailAck = "";
                string invListFailAck = "";

                if (input.blnFMMassAppr)
                {
                    foreach (var drItem in input.listSave)
                    {
                        dtr = dtItem.NewRow();
                        dtr["DocType"] = drItem.DOC_TYPE;
                        if (dtr["DocType"].ToString() == "EPROC")
                        {
                            dtr["InvNo"] = drItem.IM_INVOICE_NO;
                            strInv += dtr["InvNo"] + ",";
                            dtr["InvIndex"] = drItem.IM_INVOICE_INDEX;
                            dtr["PoIndex"] = drItem.IM_PO_INDEX;
                            dtr["Vendor"] = drItem.IM_S_COY_ID;
                            dtr["FinRemark"] = drItem.REMARK == null ? "" : drItem.REMARK;
                            dtr["InvStatus"] = 0;
                            dtr["Submitted"] = "";
                            dtr["AppDate"] = "";
                            dtr["PayTerm"] = "";
                            dtr["BillMethod"] = drItem.POM_BILLING_METHOD;
                            dtr["Contract"] = "";

                            if (input.strType == "2")
                            {
                                dtr["Submitted"] = input.userID;
                                dtr["InvStatus"] = invStatus.PendingAppr;
                            }
                            else
                            {
                                dtr["AppDate"] = DateTime.Now;
                                dtr["InvStatus"] = invStatus.Approved;
                            }
                        }
                        dtItem.Rows.Add(dtr);
                    }
                }
                else
                {
                    bool bln;
                    foreach (var dgItem in input.listSave)
                    {
                        if ((dgItem.REMARK != "" && dgItem.REMARK != null) || (input.strType == "2" && dgItem.REMARK == null))
                        {
                            dtr = dtItem.NewRow();
                            dtr["DocType"] = dgItem.DOC_TYPE;
                            bln = true;
                            if (dtr["DocType"].ToString() == "EPROC")
                            {
                                dtr["InvNo"] = dgItem.IM_INVOICE_NO;
                                if (objCn.chkInvPendingAckCN(dtr["InvNo"].ToString(), dgItem.IM_S_COY_ID) == true)
                                {
                                    bln = false;
                                    if (strInvFailAck == "")
                                    {
                                        strInvFailAck += dtr["InvNo"];
                                    }
                                    else
                                    {
                                        strInvFailAck += "," + dtr["InvNo"];
                                    }
                                }
                                else
                                {
                                    if (input.strType != "4" || (input.strType == "4" && !invStatus.Paid.Equals(dgItem.IM_INVOICE_STATUS)))
                                    {
                                        bln = true;
                                        strInv += dtr["InvNo"] + ",";
                                    }
                                    else
                                    {
                                        bln = false;
                                        strInvFailAck += dtr["InvNo"] + ",";
                                    }
                                }
                                dtr["InvIndex"] = dgItem.IM_INVOICE_INDEX;
                                dtr["PoIndex"] = dgItem.IM_PO_INDEX;
                                dtr["Vendor"] = dgItem.IM_S_COY_ID;
                                dtr["FinRemark"] = dgItem.REMARK == null ? "" : dgItem.REMARK;
                                dtr["InvStatus"] = 0;
                                dtr["Submitted"] = "";
                                dtr["AppDate"] = "";
                                dtr["PayTerm"] = "";
                                dtr["BillMethod"] = dgItem.POM_BILLING_METHOD;
                                dtr["Contract"] = dgItem.DEPT;
                                switch (input.strType)
                                {
                                    case "1":
                                        //dtr["PayTerm"] = "";
                                        break;
                                    case "2":
                                        dtr["Submitted"] = input.userID;
                                        dtr["InvStatus"] = invStatus.PendingAppr;
                                        break;
                                    case "3":
                                        dtr["AppDate"] = DateTime.Now;
                                        dtr["InvStatus"] = invStatus.Approved;
                                        break;
                                    case "4":
                                        dtr["InvStatus"] = invStatus.Paid;
                                        dtr["PayTerm"] = "4";
                                        break;
                                    default:
                                        break;
                                }
                            }
                            if (bln)
                            {
                                if (dtr["DocType"].ToString() == "EPROC")
                                {
                                    if (input.strType == "2" || input.strType == "3" || input.strType == "4")
                                    {
                                        bool blnHighestLevel = true;
                                        string strMsg;
                                        if (input.strInvAppr2 == "N")
                                        {
                                            strMsg = objTrac.ApproveInvoice(input.userID, input.companyID, Common.Parse(dtr["InvNo"].ToString()), Common.Parse(dtr["Vendor"].ToString()), input.strType == "2" ? "FO" : "FM", dtr["FinRemark"].ToString(), true, ref blnHighestLevel, true); ;
                                        }
                                        else
                                        {
                                            strMsg = objTrac.ApproveInvoice(input.userID, input.companyID, Common.Parse(dtr["InvNo"].ToString()), Common.Parse(dtr["Vendor"].ToString()), input.strType == "2" ? "FO" : "FM", dtr["FinRemark"].ToString(), false, ref blnHighestLevel, true); ;

                                        }
                                        if (strMsg != null)
                                        {
                                            return ("", strMsg);
                                        }
                                        else
                                        {
                                            input.blnSend = false;
                                        }
                                        if (blnHighestLevel)
                                        {
                                            DataTable dtItemInv = new DataTable();
                                            dtItemInv.Columns.Add("InvNo", Type.GetType("System.String"));
                                            dtItemInv.Columns.Add("PoIndex", Type.GetType("System.String"));
                                            dtItemInv.Columns.Add("Vendor", Type.GetType("System.String"));
                                            dtItemInv.Columns.Add("FinRemark", Type.GetType("System.String"));
                                            dtItemInv.Columns.Add("InvStatus", Type.GetType("System.Int32"));
                                            dtItemInv.Columns.Add("Submitted", Type.GetType("System.String"));
                                            dtItemInv.Columns.Add("AppDate", Type.GetType("System.String"));
                                            dtItemInv.Columns.Add("PayTerm", Type.GetType("System.String"));
                                            dtItemInv.Columns.Add("BillMethod", Type.GetType("System.String"));
                                            DataRow dtrInv;
                                            bool blnSendInv;
                                            dtrInv = dtItemInv.NewRow();
                                            dtrInv["InvNo"] = dtr["InvNo"];
                                            dtrInv["PoIndex"] = dtr["PoIndex"];
                                            dtrInv["Vendor"] = dtr["Vendor"];
                                            dtrInv["FinRemark"] = dtr["FinRemark"] == null ? "" : dtr["FinRemark"];
                                            dtrInv["InvStatus"] = 0;
                                            dtrInv["Submitted"] = "";
                                            dtrInv["AppDate"] = "";
                                            dtrInv["PayTerm"] = "";
                                            dtrInv["BillMethod"] = dtr["BillMethod"];
                                            dtrInv["AppDate"] = DateTime.Now;
                                            dtrInv["InvStatus"] = invStatus.Approved;
                                            input.blnSend = false;
                                            dtItemInv.Rows.Add(dtrInv);
                                            objTrac.updateInvoice(input.userID, input.companyID, dtItemInv, input.blnSend);
                                        }
                                        DataTable dtItemInv2 = new DataTable();
                                        dtItemInv2.Columns.Add("InvNo", Type.GetType("System.String"));
                                        dtItemInv2.Columns.Add("PoIndex", Type.GetType("System.String"));
                                        dtItemInv2.Columns.Add("Vendor", Type.GetType("System.String"));
                                        dtItemInv2.Columns.Add("FinRemark", Type.GetType("System.String"));
                                        dtItemInv2.Columns.Add("InvStatus", Type.GetType("System.Int32"));
                                        dtItemInv2.Columns.Add("Submitted", Type.GetType("System.String"));
                                        dtItemInv2.Columns.Add("AppDate", Type.GetType("System.String"));
                                        dtItemInv2.Columns.Add("PayTerm", Type.GetType("System.String"));
                                        dtItemInv2.Columns.Add("BillMethod", Type.GetType("System.String"));
                                        DataRow dtrInv2;
                                        dtrInv2 = dtItemInv2.NewRow();
                                        dtrInv2["InvNo"] = dtr["InvNo"];
                                        dtrInv2["PoIndex"] = dtr["PoIndex"];
                                        dtrInv2["Vendor"] = dtr["Vendor"];
                                        dtrInv2["FinRemark"] = dtr["FinRemark"];
                                        dtrInv2["InvStatus"] = dtr["InvStatus"];
                                        dtrInv2["Submitted"] = dtr["Submitted"];
                                        dtrInv2["AppDate"] = dtr["AppDate"];
                                        dtrInv2["PayTerm"] = dtr["PayTerm"];
                                        dtrInv2["BillMethod"] = dtr["BillMethod"];

                                        dtItemInv2.Rows.Add(dtrInv2);
                                        objTrac.updateInvoice(input.userID, input.companyID, dtItemInv2, input.blnSend);
                                    }
                                    if (input.strType == "1")
                                    {
                                        objTrac.updateAppRemark(Convert.ToInt32(dtr["InvIndex"]), dtr["FinRemark"].ToString());
                                    }
                                }
                                if (dtr["DocType"].ToString() == "IPP")
                                {
                                    string strRemark = "";
                                    if (input.strType == "1")
                                    {
                                        strRemark = dtr["FinRemark"].ToString();
                                    }
                                    else
                                    {
                                        if (input.strType == "2")
                                        {
                                            strRemark = FormatAORemark(input.userID, input.companyID, "verify", dtr["PoIndex"].ToString());
                                        }
                                        else
                                        {
                                            strRemark = FormatAORemark(input.userID, input.companyID, "approve", dtr["PoIndex"].ToString());
                                        }
                                        strRemark = strRemark + dtr["FinRemark"].ToString();
                                    }
                                    AgoraNEO.AgoraNEO.IPPMain objippmain = new AgoraNEO.AgoraNEO.IPPMain();
                                    string intApprGrpIndex;
                                    AgoraNEO.AgoraNEO.EAD.DBCom objDb = new AgoraNEO.AgoraNEO.EAD.DBCom();
                                    int i;
                                    DataSet dsApprIPPDetails = new DataSet();
                                    string strBillInvApprBy, strDocOwner;
                                    AgoraNEO.AgoraNEO.Users objUsers = new AgoraNEO.AgoraNEO.Users();
                                    bool blnIPPO;
                                    intApprGrpIndex = objDb.GetVal("SELECT DISTINCT FA_APPROVAL_GRP_INDEX FROM finance_approval WHERE FA_INVOICE_INDEX = '" + dgItem.IM_INVOICE_INDEX + "' ");
                                    dsApprIPPDetails = objippmain.getApprIPPDetail(input.userID, input.companyID, dgItem.IM_INVOICE_NO, dgItem.IM_INVOICE_INDEX, Common.Parse(input.companyID));
                                    strDocOwner = objDb.GetVal("SELECT im_created_by FROM invoice_mstr WHERE im_invoice_index = '" + dgItem.IM_INVOICE_INDEX + "' ");
                                    blnIPPO = objUsers.checkUserFixedRole(input.userID, input.companyID, "'IPP Officer'", strDocOwner);
                                    if (objippmain.checkDept(input.userID, input.companyID) == false)
                                    {
                                        strInvFail = "error Message 00046";
                                        return strInvFail;
                                    }
                                    if (input.strType == "2")
                                    {
                                        for (i = 0; i < dsApprIPPDetails.Tables[0].Rows.Count - 1; i++)
                                        {
                                            if (dsApprIPPDetails.Tables[0].Rows[i]["id_pay_for"].ToString().ToUpper() != input.companyID.ToUpper())
                                            {
                                                string strCountry = objDb.GetVal("SELECT ic_country FROM ipp_company WHERE ic_other_b_coy_code = '" + dsApprIPPDetails.Tables[0].Rows[i]["id_pay_for"] + "'");
                                                if (dsApprIPPDetails.Tables[0].Rows[i]["id_dr_exchange_rate"].ToString() is null && strCountry.ToUpper() != "MY")
                                                {
                                                    strInvFail = "Invoice " + dgItem.IM_INVOICE_NO + " required Exchange Rate for line item.";
                                                    break;
                                                }
                                            }
                                            else if (dsApprIPPDetails.Tables[0].Rows[i]["id_pay_for"].ToString().ToUpper() == "HLISB")
                                            {
                                                objTrac.updateHLISBCurrency(dsApprIPPDetails.Tables[0].Rows[i]["ID_Invoice_No"].ToString(), Convert.ToInt32(dsApprIPPDetails.Tables[0].Rows[i]["id_invoice_line"]), Convert.ToInt32(dsApprIPPDetails.Tables[0].Rows[i]["id_s_coy_id"]));

                                            }
                                        }
                                    }
                                    if (input.strType == "3" || input.strType == "2")
                                    {
                                        if (input.listSave.Count != 0)
                                        {

                                        }
                                    }
                                    if (input.strType == "1")
                                    {
                                        objTrac.updateAppRemark(Convert.ToInt32(dgItem.IM_INVOICE_INDEX), dtr["FinRemark"].ToString());
                                    }

                                }
                            }
                        }
                    }
                }
                if (strInv == "")
                {
                    return ("No one Invoice Saved / Verified", "success");
                }
                return (strInv, strInvFailAck, "success");
                #endregion
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> RejectInvoice(RejectInvoiceParameter Input)
        {
            try
            {
                var objTracking = new AgoraNEO.AgoraNEO.Tracking();
                var result = objTracking.RejectInvoice( Input.UserID,
                                                    Input.InvoiceNumber,
                                                    Input.VendorName,
                                                    Input.Remarks);
                if(result == null)
                {
                    return new KeyValuePair<string, string>("Success", $"Invoice number {Input.InvoiceNumber} has been rejected.");
                }
                else
                {
                    return new KeyValuePair<string, string>("Failed", result);
                }
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetInvoiceDetail(string InvoiceNO, string VendorCompID)
        {
            try
            {
                var objInv = new AgoraNEO.AgoraNEO.Invoice();
                var ds = objInv.inv_detail(InvoiceNO, VendorCompID);
                var data = new List<Dictionary<string, string>>();
                var index = 0;
                foreach (DataTable dataTable in ds.Tables)
                {
                    foreach (DataRow dataRow in dataTable.AsEnumerable())
                    {
                        data.Add(new Dictionary<string, string>());
                        for (int iter = 0; iter < dataRow.ItemArray.Count(); iter++)
                        {
                            data[index].Add(dataTable.Columns[iter].ColumnName,
                                    dataRow[dataTable.Columns[iter].ColumnName].ToString());
                        }
                        index++;
                    }
                }
                return data;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetInvoiceDetailString(string InvoiceNO, string VendorCompID)
        {
            try
            {
                var objInv = new AgoraNEO.AgoraNEO.Invoice();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                string strSQL = objInv.inv_detail_string(InvoiceNO, VendorCompID);
                var res = repo.ExecuteQueryList<TrackingDetailItem>(strSQL);
                var items = repo.ExecuteQuery<TrackingDetailItem>(strSQL);
                foreach(TrackingDetailItem item in items)
                {
                    item.Total = item.ID_UNIT_COST * item.ID_RECEIVED_QTY;
                }
                res.Items = items;
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> saveGridDetail(TrackingGridSaveParameter input)
        {
            try
            {
                var objInv = new AgoraNEO.AgoraNEO.Tracking();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                ArrayList news = new ArrayList(input.aryFundType.ToArray());
                ArrayList ary = new ArrayList(input.aryPTaxCode);
                objInv.updateAppRemark(Convert.ToInt32(input.strInvIndex),input.strRemark,0,"" , ary,false,news);
                return "success";
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> saveInvDetail(TrackingSaveParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Tracking objTrac = new AgoraNEO.AgoraNEO.Tracking();
                string strMsg, strMsg2;
                AgoraNEO.AgoraNEO.CreditNote objCn = new AgoraNEO.AgoraNEO.CreditNote();
                bool blnHighestLevel ;
                string role = findRole(input.userID, input.companyID);

                if (role == "4")
                {
                    blnHighestLevel = false;
                    role = "FO";
                    strMsg = objTrac.ApproveInvoice(input.userID, input.companyID, input.IM_INVOICE_NO, input.IM_S_COY_ID, role, input.REMARK, true,ref blnHighestLevel, true,false, false);
                }
                else
                {
                    blnHighestLevel = true;
                    role = "FM";
                    strMsg = objTrac.ApproveInvoice(input.userID, input.companyID, input.IM_INVOICE_NO, input.IM_S_COY_ID, role, input.REMARK, false,ref blnHighestLevel, true,false, false);
                }
                if (strMsg != "" && strMsg != null)
                {
                    return (strMsg,"error");
                }
                if (blnHighestLevel)
                {
                    DataTable dtItemInv = new DataTable();
                    dtItemInv.Columns.Add("InvNo", Type.GetType("System.String"));
                    dtItemInv.Columns.Add("PoIndex", Type.GetType("System.String"));
                    dtItemInv.Columns.Add("Vendor", Type.GetType("System.String"));
                    dtItemInv.Columns.Add("FinRemark", Type.GetType("System.String"));
                    dtItemInv.Columns.Add("InvStatus", Type.GetType("System.Int32"));
                    dtItemInv.Columns.Add("Submitted", Type.GetType("System.String"));
                    dtItemInv.Columns.Add("AppDate", Type.GetType("System.String"));
                    dtItemInv.Columns.Add("PayTerm", Type.GetType("System.String"));
                    dtItemInv.Columns.Add("BillMethod", Type.GetType("System.String"));
                    DataRow dtrInv;
                    bool blnSendInv;
                    dtrInv = dtItemInv.NewRow();
                    dtrInv["InvNo"] = input.IM_INVOICE_NO;
                    dtrInv["PoIndex"] = input.IM_PO_INDEX;
                    dtrInv["Vendor"] = input.IM_S_COY_ID;
                    dtrInv["FinRemark"] = input.REMARK;
                    dtrInv["InvStatus"] = 0;
                    dtrInv["Submitted"] = "";
                    dtrInv["AppDate"] = "";
                    dtrInv["PayTerm"] = "";
                    dtrInv["BillMethod"] = input.POM_BILLING_METHOD;
                    dtrInv["AppDate"] = DateTime.Now;
                    dtrInv["InvStatus"] = invStatus.Approved;
                    input.blnSend = false;
                    dtItemInv.Rows.Add(dtrInv);
                    objTrac.updateInvoice(input.userID, input.companyID, dtItemInv, input.blnSend);
                }
                return (input.IM_INVOICE_NO ,"","success");
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                throw ex;
            }
        }
        
        private string FormatAORemark(string userId,string companyID,string inject,string index)
        {
            AgoraNEO.AgoraNEO.EAD.DBCom objDb = new AgoraNEO.AgoraNEO.EAD.DBCom();
            string strRemark ="", strTempRemark, strUserName;
            AgoraNEO.AgoraNEO.Users objUsers = new AgoraNEO.AgoraNEO.Users();
            AgoraNEO.AgoraNEO.User objUser = new AgoraNEO.AgoraNEO.User();
            strTempRemark = "";

            string seq = "0";
            seq = objDb.GetVal("Select DISTINCT agfo_seq  From approval_grp_fo, finance_approval  Where FA_INVOICE_INDEX = '" + index + "' And FA_APPROVAL_GRP_INDEX = agfo_grp_index  And(agfo_fo = '" + userId + "' or agfo_a_fo = '" + userId + "') ");

            switch (inject)
            {
                case "approve": strRemark = "Approved " + strTempRemark + " : ";break;
                case "reject": strRemark = "Rejected " + strTempRemark + " : ";break;
                case "verify":
                    if (seq == "1")
                    {
                        strRemark = "Verified" + strTempRemark + " : ";
                    }
                    else
                    {
                        strRemark = "Fin Approval" + strTempRemark + " : ";
                    }break;
                default:
                    break;
            }
            return strRemark;
        }
        private string findRole(string userID,string companyID)
        {
            string role = "";
            string strFO = "'Finance Officer'";
            string strFM = "'Finance Manaer'";
            AgoraNEO.AgoraNEO.Users objUsers = new AgoraNEO.AgoraNEO.Users();
            bool blnFO = objUsers.checkUserFixedRole(userID, companyID ,strFO);
            bool blnFM = objUsers.checkUserFixedRole(userID, companyID ,strFO);
            if (blnFO && blnFO)
            {
                role = "4";
            }else if(!blnFO && blnFM)
            {
                role = "3";
            }else if(blnFO && !blnFM)
            {
                role = "2";
            }
            else
            {
                role = "1";
            }
            return role;
        }
    }
}
