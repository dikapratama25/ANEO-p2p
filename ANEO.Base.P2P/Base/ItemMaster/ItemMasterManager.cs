using Abp.Localization;
using Abp.ObjectMapping;
using AgoraNEO.AgoraNEO;
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.General.Map;
using ANEO.Base.P2P.General.Model;
using Microsoft.AspNetCore.Hosting;
using Plexform;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base;
using Plexform.Base.Core;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using static ANEO.Base.P2P.Filter.GetInsert2AryParameter;

namespace ANEO.Base.P2P.Base.ItemMaster
{
    public class ItemMasterManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public ItemMasterManager(
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
                Log.Error(nameof(ItemMasterManager), ex);
            }
        }

        public async Task<dynamic> GetItems(GetItemsParameter input)
        {
            try
            {
                string strCommodity = "";

                AgoraNEO.AgoraNEO.BuyerCat app = new AgoraNEO.AgoraNEO.BuyerCat();
                BaseRepository<DTO.P2P.Dto.Master.items_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.items_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                if (input.aryItemType == null)
                {
                    input.aryItemType = new System.Collections.ArrayList();
                }

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                string strSQL = app.getItems(input.companyID, "B", input.strBCIdx, input.strVendorItemCode, input.strDesc, strCommodity, input.strDel, input.aryItemType);
                //string strSQL = app.getItems(input.strCoyId, input.strItemType, input.strBCIdx, input.strVendorItemCode, input.strDesc, strCommodity, input.strDel, input.aryItemType);
                var res = repo.ExecuteQueryList<mapGetItems>(strSQL + strPagination);
                res.TotalCount = repo.ExecuteQueryList<mapGetItems>(strSQL + strPagination).TotalCount;
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetTempImageAttachBuyer(GetTempImageParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.ContCat app = new AgoraNEO.AgoraNEO.ContCat();
                BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                string strSQL = app.getTempImageAttachBuyer(input.strIndex).ToString();
                var res = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination);
                res.TotalCount = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination).TotalCount;
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }


        public async Task<dynamic> FileDownload(GetFileParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement app = new AgoraNEO.AgoraNEO.FileManagement();
                //BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var strSQL = app.FileDownload(input.companyID, input.strFileName, input.pEnumDownloadType, input.strDocType, input.pEnumUploadFrom, input.strCoy, input.strConnStr);
                //var res = repo.ExecuteQueryList<mapGetFileDownload>(strSQL + strPagination);
                //res.TotalCount = repo.ExecuteQueryList<mapGetFileDownload>(strSQL + strPagination).TotalCount;
                return strSQL;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<bool> FileExist(GetFileParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement app = new AgoraNEO.AgoraNEO.FileManagement();
                //BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                //string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var strSQL = app.FileExist(input.strFileName, input.strCoy, input.strConnStr);
                //var res = repo.ExecuteQueryList<mapGetFileExist>(strSQL/* + strPagination*/);
                //res.TotalCount = repo.ExecuteQueryList<mapGetFileExist>(strSQL + strPagination).TotalCount;
                return strSQL;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<bool> Direct(GetDirectParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement app = new AgoraNEO.AgoraNEO.FileManagement();
                //BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                //string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var strSQL = app.FileExist(input.sFolder, input.sFileName, input.sGet);
                //var res = repo.ExecuteQueryList<mapGetFileExist>(strSQL/* + strPagination*/);
                //res.TotalCount = repo.ExecuteQueryList<mapGetFileExist>(strSQL + strPagination).TotalCount;
                return strSQL;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> DeleteAttachmentBuyer(GetDeleteAttBuyerParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.ContCat app = new AgoraNEO.AgoraNEO.ContCat();
                BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.item_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var strSQL = app.deleteAttachmentBuyer(input.intIndex, input.strPrdCode, input.strType);
                var res = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination);
                res.TotalCount = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination).TotalCount;
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> Get1Column(Get1ColumnParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.EAD.DBCom app = new AgoraNEO.AgoraNEO.EAD.DBCom();
                //BaseRepository<DTO.P2P.Dto.Master.get1column> repo = new BaseRepository<DTO.P2P.Dto.Master.get1column>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var strSQL = app.Get1Column(input.pTable, input.pFieldName, input.pCondition);
                //var res = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination);
                //res.TotalCount = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination).TotalCount;
                return strSQL;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic>GetCategoryCode(GetP2PListParameter input)
        {
            try
            {
                // AgoraNEO.AgoraNEO.EAD.DBCom app = new AgoraNEO.AgoraNEO.EAD.DBCom();
                //string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                // var strSQL = app.GetVal(input.pSQL);
                //var res = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination);
                //res.TotalCount = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination).TotalCount;
                //  return strSQL;
                var repo = new BaseRepository<DTO.P2P.Master.code_mstr.CODE_MSTR> (_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var data = repo.ExecuteQueryList<mapCategory>(
                    "SELECT CBC_B_CATEGORY_CODE FROM COMPANY_B_CATEGORY_CODE  " +
                    "WHERE CBC_B_COY_ID= '" + input.companyID + "'");
                return data;

            }
            catch(Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetMasterCodeByStatus(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.AppDataProvider app = new AgoraNEO.AgoraNEO.AppDataProvider();
                var StrSQL = app.GetMasterCodeByStatus(AgoraNEO.AgoraNEO.CodeTable.Uom, input.status , true);
                BaseRepository <DTO.P2P.Master.code_mstr.CODE_MSTR> repo = new BaseRepository<DTO.P2P.Master.code_mstr.CODE_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var data = repo.ExecuteQueryList<Master.Map.code_mstr.MapCODE_MSTR>(StrSQL.ToString());
                return data;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetVal(GetValParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.EAD.DBCom app = new AgoraNEO.AgoraNEO.EAD.DBCom();
                //BaseRepository<DTO.P2P.Dto.Master.get1column> repo = new BaseRepository<DTO.P2P.Dto.Master.get1column>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string strSQL = app.getItems(input.strCoyId, input.strItemType);
                //string strSQL = app.getItems(Session("CompanyId"), "B", strBCIdx, txtVendorItemCode.Text, txtDesc.Text, strCommodity, strDel, aryItemType);
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var strSQL = app.GetVal(input.pSQL);
                //var res = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination);
                //res.TotalCount = repo.ExecuteQueryList<mapGetTempImage>(strSQL + strPagination).TotalCount;
                return strSQL;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> ItemExist(GetExistParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.EAD.DBCom app = new AgoraNEO.AgoraNEO.EAD.DBCom();
                
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                var strSQL = app.Exist(input.pstrSQL);

                return strSQL;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

     
        public async Task<dynamic> FillGLCode_data(GetFillGLCodeParameter input)
        {
            try
            {
                string fillGLcode;
                AgoraNEO.AgoraNEO.ContCat app = new AgoraNEO.AgoraNEO.ContCat();
                BaseRepository<DTO.P2P.Dto.Master.BIM_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.BIM_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                //string[] comp = compid.Split('=');

                //foreach (var i in comp)
                //{
                //    if (i != "CompanyID")
                //    {
                //        //string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                //        fillGLcode = app.FillGLCode_data(input.compid, pDropDownList, strConn);
                //    }
                //}
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);

                fillGLcode = app.FillGLCode_data(input.companyID, input.pDropDownList, input.strConn);

                var res = repo.ExecuteQueryList<MapFillGLCode>(fillGLcode + strPagination);
                int totalCount = (repo.ExecuteQueryList<MapFillGLCode>(fillGLcode)).TotalCount;

                res.TotalCount = totalCount;

                //return ResultContainer();
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> BIM_ItemDetails(GetBIMParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.AppBaseClass appbase = new AgoraNEO.AgoraNEO.AppBaseClass();
                AgoraNEO.AgoraNEO.ContCat app = new AgoraNEO.AgoraNEO.ContCat();
                BaseRepository<DTO.P2P.Dto.Master.BIM_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.BIM_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                GST gst = new GST();


                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                //var fillGLcode = app.FillGLCode_data(input.pDropDownList, input.strConn);
                var strSQL = app.BIM(input.dsProduct, input.strMode, input.strImageIndex, input.strNewProductCode, input.OldVendor, input.OldVendorItemCode, input.OldItemName, input.strUpload);
                
                //var fillCatCode = app.FillCatCode_data(input.pDropDownList, input.strConn);
                //var getSingleproduct = app.getSingleProduct(input.strCode, input.blnTemp);
                //var getTempattachbuyer = app.getTempAttachBuyer(input.strItemId);
                //var getTempimageattachbuyer = app.getTempImageAttachBuyer(input.strIndex);
                //var getSingleproductvenlead = app.getSingleProductVenLead(input.strCode, input.blnTemp);
                //var deleteTempattachment = app.deleteTempAttachment(input.strItemId, input.strSessionID);

                //for (int i = 0; i<7; i++)
                //{
                //    if (i==0) {
                //        //var resr = repo.ExecuteQueryList<mapBIM>(fillGLcode + strPagination);
                //        var resr = repo.ExecuteQueryList<mapBIM>(fillGLcode + strPagination);
                //        return resr; }
                //    else if (i == 1) {
                //        var resr = repo.ExecuteQueryList<mapBIM>(fillCatCode + strPagination);
                //        return resr; }
                //    else if (i == 2) {
                //        var resr = repo.ExecuteQueryList<mapBIM>(getSingleproduct + strPagination);
                //        return resr; }
                //    else if (i == 3) {
                //        var resr = repo.ExecuteQueryList<mapBIM>(getTempattachbuyer + strPagination);
                //        return resr; }
                //    else if (i == 4) {
                //        var resr = repo.ExecuteQueryList<mapBIM>(getTempimageattachbuyer + strPagination);
                //        return resr; }
                //    else if (i == 5) {
                //        var resr = repo.ExecuteQueryList<mapBIM>(getSingleproductvenlead + strPagination);
                //        return resr; }
                //    else {
                //        var resr = repo.ExecuteQueryList<mapBIM>(deleteTempattachment + strPagination);
                //        return resr; }
                //}

                var res = repo.ExecuteQueryList<mapBIM>(strSQL + strPagination);
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        //GetInsert2AryParameter inp;
        //public async Task<dynamic> Insert2Ary(GetInsert2ArrayParameter input)
        //{
        //    try
        //    {
        //        AgoraNEO.AgoraNEO.Common app = new AgoraNEO.AgoraNEO.Common();

        //        //string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
        //        string strSQL = app.Insert2Ary(ref inp.pQuerys(input.pQuery),input.pstrSQL);

        //        return strSQL;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(nameof(ItemMasterManager), ex);
        //        throw ex;
        //    }
        //}
        //public async Task<dynamic> Parse(string pInstring)
        //{
        //    try
        //    {
        //        AgoraNEO.AgoraNEO.Common app = new AgoraNEO.AgoraNEO.Common();

        //        //string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
        //        var strSQL = app.Parse(pInstring);

        //        return strSQL;
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Error(nameof(ItemMasterManager), ex);
        //        throw ex;
        //    }
        //}

        public async Task<dynamic> SaveItemDetail(MapItemDetailMaster input)
        {
            try
            {
                AgoraNEO.AgoraNEO.ContCat objItem = new AgoraNEO.AgoraNEO.ContCat();
                DataSet ds = PopulateItemDetailDataSet(input);
                string strItemNo = string.Empty;
                var res = objItem.BIM(ds, input.Type, input.PictAttachment, input.itemcode, input.PrefVend_UseType);
                //switch (input.Type)
                //{
                //    case "new":
                //        res = objItem.BIM(ds, input.Type, input.PictAttachment, input.item_code, input.PrefVend_UseType);
                //        break;
                //    case "mod":
                //        objItem(input.UserID, input.CompanyID, ds, input.NonFTN);
                //        strPRNo = input.PRNo;
                //        break;
                //}
                return new ResultContainer(string.Format(strItemNo), true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        #region MISC
        private DataSet PopulateItemDetailDataSet(MapItemDetailMaster input)
        {
            try
            {
                #region init
                AgoraNEO.AgoraNEO.ContCat objItem = new AgoraNEO.AgoraNEO.ContCat();
                //AgoraNEO.AgoraNEO.Admin objAdmin = new AgoraNEO.AgoraNEO.Admin();
                //AgoraNEO.AgoraNEO.EAD.DBCom objDB = new AgoraNEO.AgoraNEO.EAD.DBCom();
                objItem.Init_bindProduct();
                #endregion

                #region populate mstr
                DataRow dtr;
                dtr = objItem.dtProduct.NewRow();
                dtr["PM_ACCT_CODE"] = input.AccountCode;
                dtr["PM_CATEGORY_NAME"] = input.CategoryCode;
                //dtr["chkMRO"] = input.chkMRO;
                //dtr["chkSpot"] = input.chkSpot;
                //dtr["chkStock"] = input.chkStock;
                dtr["PM_COLOR_INFO"] = input.ColorInfo;
                dtr["CT_NAME"] = input.CommodityType;
                dtr["PM_DRAW_NO"] = input.DrawingNumber;
                dtr["PM_LONG_DESC"] = input.ext_remarks;
                dtr["PM_REMARKS"] = input.ext_remarks1;
                dtr["FileAttachment"] = input.FileAttachment;
                dtr["PV_LEAD_TIME"] = input.First_OrderLead;
                dtr["PM_1ST_S_COY_ID"] = input.First_UseType;
                dtr["PV_VENDOR_CODE"] = input.First_VenItemCode;
                dtr["PM_GROSS_WEIGHT"] = input.GrossWeight;
                dtr["PM_HSC_CODE"] = input.HSCode;
                dtr["PM_PRODUCT_BRAND"] = input.id_Brand;
                dtr["PM_HEIGHT"] = input.id_height;
                dtr["PM_LENGHT"] = input.id_length;
                dtr["PM_PRODUCT_MODEL"] = input.id_model;
                dtr["PM_VOLUME"] = input.id_volume;
                dtr["PM_WIDTH"] = input.id_width;
                //dtr["isActive"] = input.isActive;
                dtr["PM_VENDOR_ITEM_CODE"] = input.itemcode;
                dtr["PM_PRODUCT_DESC"] = input.item_name;
                dtr["PM_MANUFACTURER"] = input.ManufacturerName;
                dtr["PM_MAX_INV_QTY"] = input.Max_Inventory;
                dtr["PM_ORD_MAX_QTY"] = input.Max_OrderQty;
                dtr["Min_Inventory"] = input.Min_Inventory;
                dtr["PM_ORD_MIN_QTY"] = input.Min_OrderQty;
                dtr["PM_NET_WEIGHT"] = input.NetWeight;
                dtr["PM_PACKING_REQ"] = input.PackingSpecification;
                dtr["PictAttachment"] = input.PictAttachment;
                dtr["PV_LEAD_TIME"] = input.PrefVend_OrderLead;
                dtr["PM_PREFER_S_COY_ID"] = input.PrefVend_UseType;
                dtr["PV_VENDOR_CODE"] = input.PrefVend_VenItemCode;
                //dtr["radio"] = input.radio;
                dtr["PM_REF_NO"] = input.ref_no;
                dtr["PV_LEAD_TIME"] = input.Second_OrderLead;
                dtr["PM_2ND_S_COY_ID"] = input.Second_UseType;
                dtr["PV_VENDOR_CODE"] = input.Second_VenItemCode;
                dtr["PV_LEAD_TIME"] = input.Third_OrderLead;
                dtr["PM_3RD_S_COY_ID"] = input.Third_UseType;
                dtr["PV_VENDOR_CODE"] = input.Third_VenItemCode;
                dtr["PV_VENDOR_TYPE"] = input.Type;
                dtr["PM_UOM"] = input.UOM;
                dtr["PM_VERS_NO"] = input.VersionNo;
                objItem.dtProduct.Rows.Add(dtr);
                #endregion

                //#region populate address
                //DataSet dsBilling;
                //DataView dvwBilling;
                //dsBilling = objAdmin.PopulateAddr(input.UserID, input.CompanyID, "B", objAdmin.user_Default_Add(input.UserID, input.CompanyID, "B"), "", "").dsAddr;
                //dvwBilling = dsBilling.Tables[0].DefaultView;
                //foreach (DataRowView x in dvwBilling)
                //{
                //    dtr["BillAddrLine1"] = (!string.IsNullOrEmpty(input.BillAddrLine1)) ? input.BillAddrLine1 : (x.Row["AM_ADDR_LINE1"] != null && x.Row["AM_ADDR_LINE1"] != DBNull.Value ? x.Row["AM_ADDR_LINE1"].ToString() : string.Empty);
                //    dtr["BillAddrLine2"] = (!string.IsNullOrEmpty(input.BillAddrLine2)) ? input.BillAddrLine2 : (x.Row["AM_ADDR_LINE2"] != null && x.Row["AM_ADDR_LINE2"] != DBNull.Value ? x.Row["AM_ADDR_LINE2"].ToString() : string.Empty);
                //    dtr["BillAddrLine3"] = (!string.IsNullOrEmpty(input.BillAddrLine3)) ? input.BillAddrLine3 : (x.Row["AM_ADDR_LINE3"] != null && x.Row["AM_ADDR_LINE3"] != DBNull.Value ? x.Row["AM_ADDR_LINE3"].ToString() : string.Empty);
                //    dtr["BillAddrPostCode"] = (!string.IsNullOrEmpty(input.BillAddrPostCode)) ? input.BillAddrPostCode : (x.Row["AM_POSTCODE"] != null && x.Row["AM_POSTCODE"] != DBNull.Value ? x.Row["AM_POSTCODE"].ToString() : string.Empty);
                //    dtr["BillAddrState"] = (!string.IsNullOrEmpty(input.BillAddrState)) ? input.BillAddrState : (x.Row["AM_CITY"] != null && x.Row["AM_CITY"] != DBNull.Value ? x.Row["AM_CITY"].ToString() : string.Empty);
                //    dtr["BillAddrCity"] = (!string.IsNullOrEmpty(input.BillAddrCity)) ? input.BillAddrCity : (x.Row["AM_COUNTRY"] != null && x.Row["AM_COUNTRY"] != DBNull.Value ? x.Row["AM_COUNTRY"].ToString() : string.Empty);
                //    dtr["BillAddrCountry"] = (!string.IsNullOrEmpty(input.BillAddrCountry)) ? input.BillAddrCountry : (x.Row["AM_COUNTRY"] != null && x.Row["AM_COUNTRY"] != DBNull.Value ? x.Row["AM_COUNTRY"].ToString() : string.Empty); ;
                //}
                //dtr["BillAddrCode"] = (!string.IsNullOrEmpty(input.BillAddrCode)) ? input.BillAddrCode : objAdmin.user_Default_Add(input.UserID, input.CompanyID, string.Format("B"));
                //#endregion

                //#region populate details
                //TimeSpan diffDay;
                //DataRow dtrd;
                //int i = 1;
                //foreach (var detail in input.Details)
                //{
                //    dtrd = objPR.dtDetails.NewRow();

                //    dtrd["Line"] = (detail.Line > 0) ? detail.Line : i;
                //    detail.Line = (int)dtrd["Line"];

                //    dtrd["ProductCode"] = detail.ProductCode;
                //    dtrd["VendorItemCode"] = detail.VendorItemCode;
                //    dtrd["ProductDesc"] = detail.ProductDesc;
                //    dtrd["Qty"] = detail.Qty;


                //    //dtrd["Commodity"] = objDB.GetVal(string.Format("SELECT CT_ID FROM COMMODITY_TYPE WHERE CT_NAME = '{0}'", detail.Commodity));
                //    DataTable dt = objDB.FillDt(string.Format("SELECT CT_ID FROM COMMODITY_TYPE WHERE CT_NAME = '{0}'", detail.Commodity));
                //    dtrd["Commodity"] = (dt.Rows.Count > 0 ? dt.Rows[0].ItemArray[0] : 0);

                //    dtrd["UOM"] = detail.UOM;
                //    dtrd["Currency"] = detail.Currency;
                //    dtrd["UnitCost"] = detail.UnitCost;
                //    dtrd["GST"] = detail.GST.ToString();
                //    dtrd["GSTRate"] = detail.GSTRate ?? string.Empty;
                //    dtrd["GSTTaxCode"] = detail.GstTaxCode ?? string.Empty; // GSTTaxCode
                //    dtrd["DeliveryAddr"] = detail.DeliveryAddr;

                //    diffDay = detail.Est.Subtract(DateTime.Today);
                //    dtrd["ETD"] = Math.Abs(diffDay.Days); //detail.ETD;
                //    dtrd["WarrantyTerms"] = detail.WarrantyTerms;
                //    dtrd["Remark"] = detail.Remark;
                //    dtrd["Source"] = detail.Source;
                //    dtrd["VendorID"] = detail.VendorID;
                //    dtrd["GLCode"] = detail.GLCode;
                //    dtrd["CategoryCode"] = detail.CategoryCode ?? string.Empty;
                //    dtrd["CDGroup"] = detail.CDGroup ?? string.Empty;
                //    dtrd["AcctIndex"] = detail.AcctIndex;
                //    dtrd["AssetGroup"] = detail.AssetGroup ?? string.Empty;
                //    dtrd["Gift"] = detail.Gift;
                //    dtrd["FundType"] = detail.FundType;
                //    dtrd["PersonCode"] = detail.PersonCode;
                //    dtrd["ProjectCode"] = detail.ProjectCode;

                //    objPR.dtDetails.Rows.Add(dtrd);
                //    i++;
                //}
                //#endregion

                DataSet ds = new DataSet();
                ds.Tables.Add(objItem.dtProduct);
                //ds.Tables.Add(objPR.dtDetails);

                //#region PR_CUSTOM_FIELD_MSTR
                //DataView dvwCus;
                //dvwCus = objAdmin.getCustomField(input.CompanyID, string.Empty);
                //if (dvwCus != null)
                //{
                //    for (i = 0; i < dvwCus.Count; i++)
                //    {
                //        dtr = objPR.dtCustomMaster.NewRow();
                //        dtr["FieldNo"] = dvwCus.Table.Rows[i]["CF_FIELD_NO"];
                //        dtr["FieldName"] = dvwCus.Table.Rows[i]["CF_FIELD_NAME"];
                //        objPR.dtCustomMaster.Rows.Add(dtr);
                //    }
                //}
                //ds.Tables.Add(objPR.dtCustomMaster);
                //#endregion

                //#region PR_CUSTOM_FIELD_DETAILS
                //if (dvwCus != null)
                //{
                //    for (i = 0; i < dvwCus.Count; i++)
                //    {
                //        foreach (var detail in input.Details)
                //        {
                //            dtr = objPR.dtCustomDetails.NewRow();
                //            dtr["Line"] = detail.Line;
                //            dtr["FieldNo"] = dvwCus.Table.Rows[i]["CF_FIELD_NO"];
                //            dtr["FieldValue"] = detail.FieldValue;
                //            objPR.dtCustomDetails.Rows.Add(dtr);
                //        }
                //    }
                //}
                //ds.Tables.Add(objPR.dtCustomDetails);
                //#endregion

                #region AttachmentID
                foreach (var item in input.FileAttachment)
                {
                    string docNo = string.Format("'{0}'", item.CDA_DOC_NO);
                    //input.FileAttachment += string.IsNullOrEmpty(input.AttachmentID) ? docNo : ", " + docNo;
                }
                #endregion

                return ds;
            }
            catch (Exception ex)
            {

                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }
        #endregion

        public async Task<dynamic> GetLatestItemNo(MapItemDetailMaster input)
        {
            try
            {
                AgoraNEO.AgoraNEO.ContCat objItem = new AgoraNEO.AgoraNEO.ContCat();

                string strItemNo = input.itemcode;
                var res = objItem.GetLatestItemNo(ref strItemNo);
                
                return new ResultContainer(string.Format(strItemNo), true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetSingleProduct(GetSingleProductParameter input)
        {
            try
            {
                //DataSet ds = new DataSet();
                //AgoraNEO.AgoraNEO.ContCat objItem = new AgoraNEO.AgoraNEO.ContCat();

                //string strItemNo = input.itemcode;
                //var res = objItem.getSingleProduct(strItemNo, false);

                //return new ResultContainer(string.Format(strItemNo), true);
                AgoraNEO.AgoraNEO.ContCat app = new AgoraNEO.AgoraNEO.ContCat();
                BaseRepository<DTO.P2P.Dto.Master.BIM_mstrDTO> repo = new BaseRepository<DTO.P2P.Dto.Master.BIM_mstrDTO>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string getsingle = app.getSingleProduct(input.itemcode, false);

                var res = repo.ExecuteQueryList<mapBIM>(getsingle);
                //return ResultContainer();
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(ItemMasterManager), ex);
                throw ex;
            }
        }
    }
    #region CodeTable
    public enum CodeTable
    {
        Country,
        State,
        Currency,
        Uom,
        Gst,
        PaymentTerm,
        ShipmentMode,
        ShipmentTerm,
        PaymentMethod,
        MgmtCode,
        ApprovalGroup,
        Business,
        OwnerShip,
        IPPPaymentMethod,
        GRNCtrlDays,
        IPPCompanyCategory, 
    }
    #endregion
}
