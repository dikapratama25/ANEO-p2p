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
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.General.Map;
using ANEO.Base.P2P.Master.Map;
using ANEO.Base.P2P.General.Model;
using System.Data;
using System.Collections.Generic;
using AgoraNEO;
using System.Collections;

namespace ANEO.Base.P2P.General
{
    public class GeneralManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public GeneralManager(
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
                Log.Error(nameof(GeneralManager), ex);
            }
        }

        public async Task<dynamic> GetUserDetail(string userid, string compid)
        {
            try
            {
                AgoraNEO.AgoraNEO.Users objUser = new AgoraNEO.AgoraNEO.Users();

                var res = objUser.GetUserDetails(userid, compid);

                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> UpdateUser(MapUser input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Users objUser = new AgoraNEO.AgoraNEO.Users();

                AgoraNEO.AgoraNEO.User pUser = _objectMapper.Map<AgoraNEO.AgoraNEO.User>(input);

                var res = objUser.UpdateUser(pUser.UserID, pUser.CompanyID, pUser, false, string.Empty);

                if (res)
                {
                    res = objUser.UpdatePassword(pUser.UserID, pUser.Password, pUser.CompanyID, false);
                }

                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetUserGrouplist(GetP2PListParameter input)
        {
            try
            {
                var repo = new BaseRepository<DTO.P2P.Master.user_mstr.USER_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var data = repo.ExecuteQueryList<Master.Map.user_group_mstr.MapUSER_GROUP_MSTR>(
                    "SELECT UU.UU_USRGRP_ID  AS ID , UM.UGM_USRGRP_NAME AS UserGroupName  " +
                    "FROM USERS_USRGRP  UU " +
                    "left join USER_GROUP_MSTR UM ON UU_USRGRP_ID = UGM_USRGRP_ID " +
                    "WHERE UU_USER_ID= '" + input.userID + "' " +
                    "AND UU_COY_ID =  '" + input.companyID + "'");


                return data;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetCountData(string status)
        {
            try
            {
                AgoraNEO.AgoraNEO.PR objPR = new AgoraNEO.AgoraNEO.PR();
                BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR> repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objPR.getCountData(status);
                var res = repo.ExecuteQueryList<MapCountData>(strSQL);
                int totalCount = (repo.ExecuteQueryList<MapCountData>(strSQL)).TotalCount;
                return res;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
       
        #region Configure Default Settings
        public async Task<dynamic> GetAllAddress(GetP2PListParameter input, bool blnSortCode = false)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin objAdmin = new AgoraNEO.AgoraNEO.Admin();
                BaseRepository<DTO.P2P.Master.address_mstr.ADDRESS_MSTR> repo = new BaseRepository<DTO.P2P.Master.address_mstr.ADDRESS_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strPagination = (input.MaxResultCount == 0 && input.SkipCount == 0) ? string.Empty : string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);

                string strSQL = objAdmin.PopulateAddr(input.userID, input.companyID, input.strType, input.strCode, input.strCity, input.strState, blnSortCode, true).strSql;
                var res = repo.ExecuteQueryList<MapADDRESS>(strSQL + strPagination);
                res.TotalCount = !string.IsNullOrEmpty(strPagination) ? repo.ExecuteQueryList<MapADDRESS>(strSQL).TotalCount : res.TotalCount;
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetUserDefault(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin objAdmin = new AgoraNEO.AgoraNEO.Admin();

                var res = objAdmin.user_Default_Add(input.userID, input.companyID, input.strType);

                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> UpdateUserDefault(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin objAdmin = new AgoraNEO.AgoraNEO.Admin();

                var res = objAdmin.updateUserDefault(input.userID, input.companyID, input.strType, input.strValue, input.strCode, input.strName, input.strModule);

                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        #endregion

        #region Send Email
        public async Task<dynamic> SendMail(MapAppMail input)
        {
            try
            {
                AgoraNEO.AgoraNEO.AppMail objMailApp = new AgoraNEO.AgoraNEO.AppMail();
                objMailApp = _objectMapper.Map<AgoraNEO.AgoraNEO.AppMail>(input);
                objMailApp.SendMail();

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        #endregion

        #region Admin
        public async Task<dynamic> GetCustomField(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin objAdmin = new AgoraNEO.AgoraNEO.Admin();
                string CF_FIELD_NO = string.Empty;

                int i = 0;
                DataView dvwCus = objAdmin.getCustomField(input.companyID, string.Empty);
                foreach (var item in dvwCus)
                {
                    CF_FIELD_NO = dvwCus.Table.Rows[i]["CF_FIELD_NO"].ToString();
                    i++;
                }
                return objAdmin.Populate_customField(input.companyID, CF_FIELD_NO ?? string.Empty, string.Empty, string.Empty);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        #endregion

        #region admin ext
        public async Task<dynamic> PopulateMfgName(string strProdCode, string companyID)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin_Ext objAdmin_ext = new AgoraNEO.AgoraNEO.Admin_Ext();
                return objAdmin_ext.PopulateMfgName(strProdCode, companyID);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> GetVendorCodeInfo(string strVendorID, string companyID)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin_Ext objAdmin_ext = new AgoraNEO.AgoraNEO.Admin_Ext();
                return objAdmin_ext.GetVendorCodeInfo(strVendorID, companyID);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> delvendor(Master.Map.company_vendor_suppcodeMap.MapCOMPANY_VENDOR_SUPPCODE data)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin_Ext objAdmin_ext = new AgoraNEO.AgoraNEO.Admin_Ext();
                return objAdmin_ext.delvendor(data.StrVendorID, data.AryList, data.CompanyID);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> delVendorCode(Master.Map.company_vendor_suppcodeMap.MapCOMPANY_VENDOR_SUPPCODE data)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin_Ext objAdmin_ext = new AgoraNEO.AgoraNEO.Admin_Ext();
                return objAdmin_ext.delVendorCode(data.StrVendorID, data.CompanyID);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> upVendorCode(Master.Map.company_vendor_suppcodeMap.MapCOMPANY_VENDOR_SUPPCODE data)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin_Ext objAdmin_ext = new AgoraNEO.AgoraNEO.Admin_Ext();
                return objAdmin_ext.upVendorCode(data.CVS_S_COY_ID, data.CVS_SUPP_CODE, data.CVS_DELIVERY_TERM, data.CVS_CURR, data.CompanyID);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getVenDefaultPayTerm(string strCode, int intRow, string strVendorID, string CompanyID)
        {
            try
            {
                AgoraNEO.AgoraNEO.Admin_Ext objAdmin_ext = new AgoraNEO.AgoraNEO.Admin_Ext();
                return objAdmin_ext.getVenDefaultPayTerm(strCode, intRow, strVendorID, CompanyID);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        #endregion

        #region MISC
        
        private string  FormatAORemark(string strAction, string  AppType)
        {
            try
            {
                string strRemark = "";
                string strTempRemark = "";
                string strUserName = "";

                switch(strAction)
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
            catch(Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        #region Attachment
        public async Task<dynamic> FileAttachment(List<Master.Map.company_doc_attachment.MapFileAttachment> datas)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement objPM = new AgoraNEO.AgoraNEO.FileManagement();
                int result = 0;
                foreach (var input in datas)
                {
                    string strDocNo = (input.CDA_DOC_NO == "xxx") ? DateTime.Now.ToString("yyyyMMdd") + GeneratorHelper.GenerateRandomString(6) : input.CDA_DOC_NO;
                    AgoraNEO.AgoraNEO.EnumUploadType attachType = AgoraNEO.AgoraNEO.EnumUploadType.DocAttachment;
                    string strDocType = string.Empty;
                    switch (input.CDA_TYPE)
                    {
                        case "I":
                        case "E":
                            attachType = AgoraNEO.AgoraNEO.EnumUploadType.DocAttachment;
                            strDocType = "PR";
                            break;
                        case "H":
                            attachType = AgoraNEO.AgoraNEO.EnumUploadType.DOAttachment;
                            strDocType = "DO";
                            break;
                    }

                    result = Convert.ToInt32(objPM.FileUpload(input, input.UserID, input.CDA_COY_ID, input.CDA_HUB_FILENAME, attachType, /*hardcoded for PR*/strDocType, AgoraNEO.AgoraNEO.EnumUploadFrom.FrontOff, strDocNo, false, /*strIndex*/string.Empty, /*strConnStr*/null,
                        /*seq*/string.Empty, /*pFrontOfficeSite*/string.Empty, /*AttchType*/input.CDA_TYPE, /*ItemCode*/string.Empty, /*LineNo*/(input.LineNo > 0) ? input.LineNo.ToString() : string.Empty, /*POLine*/string.Empty));
                    input.CDA_ATTACH_INDEX = result;
                }
                
                return datas;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> FileUpload(Microsoft.AspNetCore.Http.IFormFileCollection files, string pathtype)
        {
            try
            {
                var uploadPath = _docVault;
                var uploadPhysicalPath = string.Empty;
                //Check input
                if (files == null)
                {
                    throw new Exception(L("File_Empty_Error"));
                }

                AgoraNEO.AgoraNEO.FileManagement objFM = new AgoraNEO.AgoraNEO.FileManagement();

                string urlBase = objFM.getBasePath(AgoraNEO.AgoraNEO.EnumUploadFrom.FrontOff, null);
                string strUploadPath = objFM.getSystemParam("DocAttachPath", pathtype, null);

                uploadPhysicalPath = string.Format("{0}{1}", urlBase, strUploadPath);
                uploadPath += strUploadPath.Replace("\\", "/");

                var fileUpload = await IOHelper.FileUpload(Log, files, L("File_SizeLimit_Error"), true, uploadPath, uploadPhysicalPath, userID: AbpSession.UserId, tID: AbpSession.TenantId);

                return fileUpload;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetAttachmentDocument(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement objFM = new AgoraNEO.AgoraNEO.FileManagement();
                BaseRepository<DTO.P2P.Master.company_doc_attachment.COMPANY_DOC_ATTACHMENT> repo = new BaseRepository<DTO.P2P.Master.company_doc_attachment.COMPANY_DOC_ATTACHMENT>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);

                string strUploadPath = objFM.getSystemParam("DocAttachPath", input.strType, null);
                string uploadPath = _docVault + strUploadPath.Replace("\\", "/");

                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);
                string strSQL = objFM.getAttachment(input.strCode ?? "''", input.strValue ?? string.Empty, input.companyID, input.strType, uploadPath);
                var res = repo.ExecuteQueryList<Master.Map.company_doc_attachment.MapFileAttachment>(strSQL + strPagination);
                res.TotalCount = repo.ExecuteQueryList<Master.Map.company_doc_attachment.MapFileAttachment>(strSQL).TotalCount;

                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> DeleteAttachmentDocument(GetP2PListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.FileManagement objFM = new AgoraNEO.AgoraNEO.FileManagement();
                DataSet res = objFM.delAttachment(input.strCode, input.strValue ?? string.Empty, input.companyID, input.strType);
                if (res != null)
                {
                    string physical = objFM.getBasePath(AgoraNEO.AgoraNEO.EnumUploadFrom.FrontOff, null) + objFM.getSystemParam("DocAttachPath", "PR", null) + input.strValue;
                    System.IO.File.Delete(physical);
                }

                return (res != null) ? new ResultContainer(res.ToString(), true) : new ResultContainer(res.ToString(), false);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralManager), ex);
                throw ex;
            }
        }
        #endregion

        #endregion


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
