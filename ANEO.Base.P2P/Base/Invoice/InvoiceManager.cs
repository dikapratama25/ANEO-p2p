using Abp.ObjectMapping;
using Abp.Web.Models;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Threading.Tasks;
using Abp.Localization;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Threading.Tasks;
using System.Collections;
using Plexform;
using Plexform.Base;
using Plexform.Base.Core;
using ANEO.Base.P2P.Master;
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.General.Map;
using ANEO.Base.P2P.Master.Map;
using ANEO.Base.P2P.General.Model;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Linq.Expressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using LOGIC.Shared.Collection;
using LOGIC.Base;
using Microsoft.AspNetCore.Http;

namespace ANEO.Base.P2P.Invoice
{
    public class InvoiceManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public InvoiceManager(
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
                Log.Error(nameof(InvoiceManager), ex);
            }
        }

        public async Task<dynamic> GetGRNPrice(string userID, string grnNumber, string buyerCompanyID, int pOID)
        {
            AgoraNEO.AgoraNEO.Invoice objInv = new AgoraNEO.AgoraNEO.Invoice();
            return objInv.to_price_format(objInv.get_grnprice(userID, "", buyerCompanyID, pOID, grnNumber));
        }

        public async Task<dynamic> GetAllIssueInvoiceItem(GetIssuedGRNParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Invoice objInv = new AgoraNEO.AgoraNEO.Invoice();
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = string.Empty;
                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : (input.Filter != null && input.Filter != string.Empty) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}",  input.MaxResultCount, input.SkipCount);

                strSQL = $"SELECT * FROM ({objInv.get_unInvItemEn(input.UserID, input.PONumber, input.CompanyName)}) AS IssuedGRNs";
                strSQL += (input.DONumber != null & input.DONumber != "") || (input.GRNNumber != null & input.GRNNumber != "") ? $" WHERE " : "";
                strSQL += (input.DONumber != null & input.DONumber != "") ? $" DO_Number = '{input.DONumber}'" : "";
                strSQL += (input.DONumber != null & input.DONumber != "") && (input.GRNNumber != null & input.GRNNumber != "") ? $" AND " : "";
                strSQL += (input.GRNNumber != null & input.GRNNumber != "") ? $"  GRN_Number = '{input.GRNNumber}'" : "";
                strSQL += (input.Sorting != null & input.Sorting != "") ? (!input.Sorting.Contains("Amount") ? $" ORDER BY {input.Sorting} " : "") : " ORDER BY POM_PO_NO ";
                var objResultMain = repo.ExecuteQueryList<Map.MapIssueInvoice>(strSQL + strPagination);
                var IssuedGRN = new List<ANEO.Base.P2P.Invoice.Map.MapIssueInvoice>();
                for (int index = 0; index < objResultMain.Items.Count(); index++)
                {

                    var jObjectDataMain = JsonConvert.DeserializeObject<JArray>(JObject.FromObject(new AjaxResponse(objResultMain).Result).SelectToken("Items").ToString())[index].Children<JProperty>();
                    var GrnNumber = (string)jObjectDataMain.First(x => x.Name == "GRN_Number");
                    var buyerCompanyID = (string)jObjectDataMain.First(x => x.Name == "POM_B_COY_ID");
                    var pOID = int.Parse((string)jObjectDataMain.First(x => x.Name == "POM_PO_INDEX"));
                    var amount = (string)await GetGRNPrice(
                        input.UserID,
                        GrnNumber,
                        buyerCompanyID,
                        pOID);
                    IssuedGRN.Add(new Map.MapIssueInvoice
                    {
                        POM_BILLING_METHOD = (string)jObjectDataMain.First(x => x.Name == "POM_BILLING_METHOD"),
                        POM_PO_NO = (string)jObjectDataMain.First(x => x.Name == "POM_PO_NO"),
                        DO_Number = (string)jObjectDataMain.First(x => x.Name == "DO_Number"),
                        GRN_Number = (string)jObjectDataMain.First(x => x.Name == "GRN_Number"),
                        CM_COY_NAME = (string)jObjectDataMain.First(x => x.Name == "CM_COY_NAME"),
                        POM_CURRENCY_CODE = (string)jObjectDataMain.First(x => x.Name == "POM_CURRENCY_CODE"),
                        POM_B_COY_ID = (string)jObjectDataMain.First(x => x.Name == "POM_B_COY_ID"),
                        POM_PO_INDEX = (string)jObjectDataMain.First(x => x.Name == "POM_PO_INDEX"),
                        Amount = amount
                    });
                }
                if (input.Sorting != null)
                {
                    IssuedGRN = input.Sorting.Contains("Amount") ? (input.Sorting.Contains("DESC") ? IssuedGRN.OrderByDescending(data => float.Parse(data.Amount)).ToList() : IssuedGRN.OrderBy(data => float.Parse(data.Amount)).ToList()) : IssuedGRN;
                }
                var filteredData = IssuedGRN.Where(FilterIssueInvoice(input.DONumber, input.GRNNumber, input.Filter));
                var totalCount = filteredData.Count() > 0 ? filteredData.Count() : (input.Filter != null && input.Filter != "") ? 0 : (repo.ExecuteQueryList<ANEO.Base.P2P.Invoice.Map.MapIssueInvoice>(strSQL)).TotalCount;
                return new ListResultContainer<ANEO.Base.P2P.Invoice.Map.MapIssueInvoice>(
                        filteredData.Count() > 0 ? filteredData : (input.Filter != null && input.Filter != "") ? null : (IssuedGRN.Count > 0) ? IssuedGRN : null,
                        objResultMain.Columns,
                        totalCount
                    );
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }

            Func<Map.MapIssueInvoice, bool> FilterIssueInvoice(string DONumber, string GRNNumber, string searchFilter)
            {
                return invoices =>
                        searchFilter != null && searchFilter != "" && invoices.CM_COY_NAME.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.POM_BILLING_METHOD.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.POM_PO_NO.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.DO_Number.Contains(searchFilter) ||
                        searchFilter != null && searchFilter != "" && invoices.GRN_Number.Contains(searchFilter);
            }

        }

        public async Task<dynamic> GetGSTRegNumber(string UserID, string DONumber)
        {
            try
            {
                var deliveryOrder = new AgoraNEO.AgoraNEO.DeliveryOrder();
                var gst = new AgoraNEO.AgoraNEO.GST();
                var doDate = deliveryOrder.getDODate(UserID, DONumber);
                return gst.chkGST(doDate);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> SubmitInvoice(InvoiceCreationParameter input)
        {
            try
            {

                var agora = new AgoraNEO.AgoraNEO.AppGlobals();
                var invoice = new AgoraNEO.AgoraNEO.Invoice();
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                var invoiceStatus = (int)AgoraNEO.AgoraNEO.invStatus.NewInv;
                var grnStatus = (int)AgoraNEO.AgoraNEO.GRNStatus.Invoiced;
                var doStatus = (int)AgoraNEO.AgoraNEO.DOStatus.Invoiced;
                var gstRegNo = input.GST_REG;
                var successInv = "";
                var failedInv = "";

                var dataSet = new DataSet();
                var dataTable = CreateDataTable();
                var dataRow = dataTable.NewRow();
                dataRow.SetField("doc", input.Document);
                dataRow.SetField("ref", input.Reference);
                dataRow.SetField("remark", input.Remark);
                dataRow.SetField("amount", input.Amount);
                dataRow.SetField("b_com_id", input.B_Com_Id);
                dataRow.SetField("inv_status", invoiceStatus);
                dataRow.SetField("bill_meth", input.BillMeth);
                dataRow.SetField("po_no", input.PoNo);
                dataRow.SetField("grn_no", input.GrnNo);
                dataRow.SetField("do_no", input.DoNo);
                dataRow.SetField("pay_day", input.PayDay);
                dataRow.SetField("tax", input.Tax);
                dataRow.SetField("ShipAmt", input.ShipAmt);
                dataRow.SetField("POM_PO_INDEX", input.POM_PO_INDEX);
                dataTable.Rows.Add(dataRow);
                dataSet.Tables.Add(dataTable);

                invoice.Update_InvMstr(
                    input.UserID,
                    dataSet,
                    grnStatus.ToString(),
                    doStatus.ToString(),
                    ref successInv,
                    ref failedInv,
                    null,
                    input.GST_REG == "" ? "Y" : "N",
                    input.CompResident,
                    input.DOC_NO);

                if (successInv != "")
                {
                    return new Dictionary<string, string>(){
                        { "Submit_Status", "Success" },
                        { "Message", successInv }
                    };
                }
                else
                {
                    return new Dictionary<string, string>(){
                        { "Submit_Status", "Failed" },
                        { "Message", failedInv }
                    };
                }

            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }

            DataTable CreateDataTable()
            {
                var dt = new DataTable();
                dt.Columns.Add("doc", Type.GetType("System.String"));
                dt.Columns.Add("ref", Type.GetType("System.String"));
                dt.Columns.Add("remark", Type.GetType("System.String"));
                dt.Columns.Add("amount", Type.GetType("System.String"));
                dt.Columns.Add("b_com_id", Type.GetType("System.String"));
                dt.Columns.Add("INV_STATUS", Type.GetType("System.String"));
                dt.Columns.Add("bill_meth", Type.GetType("System.String"));
                dt.Columns.Add("po_no", Type.GetType("System.String"));
                dt.Columns.Add("grn_no", Type.GetType("System.String"));
                dt.Columns.Add("do_no", Type.GetType("System.String"));
                dt.Columns.Add("pay_day", Type.GetType("System.String"));
                dt.Columns.Add("tax", Type.GetType("System.String"));
                dt.Columns.Add("ShipAmt", Type.GetType("System.String"));
                dt.Columns.Add("POM_PO_INDEX", Type.GetType("System.String"));
                return dt;
            }
        }

        public async Task<dynamic> GetIssuedGRN(GetIssuedGRNParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Invoice objInv = new AgoraNEO.AgoraNEO.Invoice();
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = string.Empty;
                strSQL = objInv.get_unInvItemEn(input.UserID, input.PONumber, input.CompanyName);
                var objResult = (repo.ExecuteQueryList<dynamic>(strSQL));

                if (objResult.TotalCount > 1)
                {
                    var filteredItem = objResult.Items.Where(x => (string)x.DO_Number == input.DONumber && (string)x.GRN_Number == input.GRNNumber).First();
                    return filteredItem;
                }
                else
                {
                    return objResult.Items.First();
                }
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> IsCompanyResident(string companyID)
        {
            try
            {
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                return repo.ExecuteQuery($"select IFNULL(cm_resident,'') AS IS_RESIDENT from company_mstr where cm_coy_id = '{companyID}'");
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetInvoiceValue(GetInvoiceValueParamaeter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Invoice objInv = new AgoraNEO.AgoraNEO.Invoice();

                var issuedGRN = await GetIssuedGRN(new GetIssuedGRNParameter() { 
                    UserID = input.UserID, 
                    PONumber = input.PONumber,
                    GRNNumber = input.GRNNumber,
                    DONumber = input.DONumber,
                    CompanyName = ""}) as dynamic;

                var data = new AgoraNEO.AgoraNEO.InvValue();
                data.doc_num = issuedGRN.GRN_Number;
                data.Inv_no = "";
                data.B_com_id = issuedGRN.CM_COY_ID;
                objInv.get_invmstr2(input.UserID,
                    data,
                    issuedGRN.POM_BILLING_METHOD,
                    issuedGRN.POM_B_COY_ID);
                return data as dynamic;


            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetUnInvoiceGRNLine(GetUnInvoiceGRNParameter input)
        {
            try
            {
                string strInv = "";
                bool blnAllowInv = false;
                AgoraNEO.AgoraNEO.Invoice invoice = new AgoraNEO.AgoraNEO.Invoice();
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var strSql = "";
                var pagination = $" LIMIT {input.MaxResultCount} OFFSET {input.SkipCount}";
                _ = invoice.getUnInvoiceGRNLine(input.PurchaseOrderIndex, 
                                                input.GRNNo, 
                                                input.BuyerCompID, 
                                                ref blnAllowInv, 
                                                ref strInv, 
                                                input.UserID, 
                                                ref strSql,
                                                !string.IsNullOrEmpty(input.Sorting) ? false : true);
                strSql += !string.IsNullOrEmpty(input.Sorting) && 
                          !input.Sorting.Contains("Subtotal") && 
                          !input.Sorting.Contains("SSTAmount") ? $" ORDER BY {input.Sorting} " : "";
                var dataWithPagination = repo.ExecuteQuery<Map.MapUnInvoiceGRNLine>(strSql + pagination).ToList();
                
                var data = repo.ExecuteQueryList<Map.MapUnInvoiceGRNLine>(strSql);
                for (int index = 0; index < dataWithPagination.Count; index++)
                {
                    dataWithPagination[index].POD_UNIT_COST = dataWithPagination[index].POD_UNIT_COST.Replace(",", ".");
                    dataWithPagination[index].QTY = dataWithPagination[index].QTY.Replace(",", ".");
                    dataWithPagination[index].POD_GST = dataWithPagination[index].POD_GST.Replace(",", ".");
                    dataWithPagination[index].Subtotal = (decimal.Parse(dataWithPagination[index].POD_UNIT_COST) * decimal.Parse(dataWithPagination[index].QTY)).ToString("0.00");
                    dataWithPagination[index].SSTAmount = ((decimal.Parse(dataWithPagination[index].Subtotal) * decimal.Parse(dataWithPagination[index].POD_GST)) / 100).ToString("0.00");
                }

                if (!string.IsNullOrEmpty(input.Sorting))
                {
                    if (input.Sorting.Contains("Subtotal DESC"))
                    {
                        dataWithPagination = dataWithPagination.OrderByDescending(x => x.Subtotal).ToList();
                    }
                    else if (input.Sorting.Contains("SSTAmount DESC"))
                    {
                        dataWithPagination = dataWithPagination.OrderByDescending(x => x.SSTAmount).ToList();
                    }
                    else if (input.Sorting.Contains("Subtotal ASC"))
                    {
                        dataWithPagination = dataWithPagination.OrderBy(x => x.Subtotal).ToList();
                    }
                    else if (input.Sorting.Contains("SSTAmount ASC"))
                    {
                        dataWithPagination = dataWithPagination.OrderBy(x => x.SSTAmount).ToList();
                    }
                }

                return new ListResultContainer<Map.MapUnInvoiceGRNLine>(dataWithPagination, data.Columns, data.TotalCount);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetAllInvoiceListingItem(GetInvoicesParameter input)
        {
            try
            {
                var invoice = new AgoraNEO.AgoraNEO.Invoice();
                var repo = new BaseRepository<dynamic>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var strSQL = invoice.get_invoiceview(input.UserID,
                                                    input.InvoiceStatus,
                                                    input.BuyerCompanyID,
                                                    input.InvoiceNumber);
                var pagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : (input.Filter != null && input.Filter != string.Empty) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                strSQL += input.Sorting != null && input.Sorting != "" ? $" ORDER BY {input.Sorting} " : "";
                var result = repo.ExecuteQueryList<ANEO.Base.P2P.Invoice.Map.MapInvoiceListing>(strSQL + pagination);
                var filteredResult = repo.ExecuteQuery<ANEO.Base.P2P.Invoice.Map.MapInvoiceListing>(strSQL + pagination)
                                .Where(FilterInvoiceListing(input.Filter));
                var totalCount = filteredResult.Count() > 0 ? filteredResult.Count() : (input.Filter != null && input.Filter != "") ? 0 : repo.ExecuteQueryList<ANEO.Base.P2P.Invoice.Map.MapInvoiceListing>(strSQL).TotalCount;
                return new ListResultContainer<ANEO.Base.P2P.Invoice.Map.MapInvoiceListing>(
                    filteredResult.Count() > 0 ? filteredResult : (input.Filter != null && input.Filter != "") ? null : result.Items,
                    result.Columns,
                    totalCount
                );
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }

            Func<ANEO.Base.P2P.Invoice.Map.MapInvoiceListing, bool> FilterInvoiceListing(string filter)
            {
                var isActualDate = DateTime.TryParse(filter, out DateTime filteredDate);

                return (invoices =>
                        filter != null && filter != "" && ((Map.MapInvoiceListing)invoices).CM_COY_NAME.Contains(filter) ||
                        filter != null && filter != "" && isActualDate && ((Map.MapInvoiceListing)invoices).IM_CREATED_ON == filteredDate ||
                        filter != null && filter != "" && ((Map.MapInvoiceListing)invoices).IM_INVOICE_NO.Contains(filter) ||
                        filter != null && filter != "" && ((Map.MapInvoiceListing)invoices).POM_PO_NO.Contains(filter));
            }
        }

        public async Task<dynamic> InvoiceAttachment(List<Master.Map.company_doc_attachment.MapFileAttachment> data)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement objPM = new AgoraNEO.AgoraNEO.FileManagement();
                var resultData = data;
                var index = 0;
                foreach (var input in data)
                {
                    string strDocNo = input.CDA_DOC_NO;
                    objPM.FileUpload(input, input.UserID, input.CDA_COY_ID, input.CDA_HUB_FILENAME, AgoraNEO.AgoraNEO.EnumUploadType.DocAttachmentTemp,"INV", AgoraNEO.AgoraNEO.EnumUploadFrom.FrontOff, strDocNo);
                    index++;
                }
                return resultData;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceAttachment), ex);
                throw ex;
            }
        }

        public async Task<dynamic> FileUploadAttachmentInvCreation(IFormFileCollection files)
        {
            try
            {
                if(files is null)
                {
                    throw new Exception(L("File_Empty_Error"));
                }

                var uploadPath = _docVault;

                AgoraNEO.AgoraNEO.FileManagement fm = new AgoraNEO.AgoraNEO.FileManagement();

                var urlBase = fm.getBasePath(AgoraNEO.AgoraNEO.EnumUploadFrom.FrontOff);
                var strUploadPath = fm.getSystemParam("DocAttachPath", "INV");
                var uploadPhysicalPath = urlBase + strUploadPath;
                uploadPath += strUploadPath.Replace("\\", string.Empty) + "/" ;
                var fileUpload = await IOHelper.FileUpload(Log, files, L("File_SizeLimit_Error"), true, uploadPath, uploadPhysicalPath, userID: AbpSession.UserId, tID: AbpSession.TenantId);
                return fileUpload as dynamic;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceManager), ex);
                throw ex;
            }
        }
    }
}
