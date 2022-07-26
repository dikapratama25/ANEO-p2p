using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plexform.MultiTenancy;
using Plexform.Notifications;
using Abp.Web.Models;
using Abp.Domain.Repositories;
using Plexform;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Abp.UI;
using Abp.ObjectMapping;
using Castle.Core.Logging;
using Plexform.Base.Core;
using Abp.Localization;
using Plexform.Authorization.Users;
using Plexform.Base.Core.User;
using Plexform.Base.Core.Helper;
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.General.Map;
using ANEO.Base.P2P.General.Model;
using System.Collections.Generic;

namespace ANEO.Base.P2P.General.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class GeneralController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly GeneralManager _generalManager;
        private readonly IP2PNotifier _P2PNotifier;
        //private readonly Repo<DTO.P2P.Master.MASTERCODE> _masterRepo;

        public GeneralController(
            IRepository<Role> roleRepository,
            IAppNotifier appNotifier,
            IRealTimeCommunicator realtimeService,
            IPlexformNotifier plexformNotifier,
            ICoreEmailer plexformEmailer,
            IWebHostEnvironment env,
            IAppFolders appFolders,
            IObjectMapper objectMapper,
            ILocalizationManager localizationManager,
            IExcelExporter excelExporter,
            IP2PNotifier P2PNotifier,
            //Repo<DTO.P2P.Master.MASTERCODE> masterRepo,
            BizUserManager bizUser,
            UserManager userManager,
            TenantManager tenantManager,
            RoleManager roleManager,
            GeneralManager generalManager
            ) : base(roleRepository, appNotifier, env, appFolders, objectMapper, tenantManager, excelExporter, localizationManager)
        {
            try
            {
                Log = NullLogger.Instance;
                _realtimeService = realtimeService;
                _plexformNotifier = plexformNotifier;
                _roleManager = roleManager;
                _userManager = userManager;
                _tenantManager = tenantManager;
                _generalManager = generalManager;
                _P2PNotifier = P2PNotifier;
                //_masterRepo = masterRepo;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GeneralController), ex);
            }
        }

        #region Personal Details
        /// <summary>
        /// ../eProcure/Common/personalSetting/PersonalDetails.aspx?pageid=107
        /// Get Personal Details
        /// </summary>
        [HttpGet]
        //[DisableAuditing]
        public async Task<JsonResult> GetUserDetail(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetUserDetail(input.userID, input.companyID)));
            }
            catch (UserFriendlyException ex)
           
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
       

        /// <summary>
        /// ../eProcure/Common/personalSetting/PersonalDetails.aspx?pageid=107
        /// Modify Personal Details
        /// </summary>
        [HttpPost]
        //[AbpMvcAuthorize]
        public async Task<JsonResult> UpdateUser([FromBody]MapUser input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.UpdateUser(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetUserGroupList(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetUserGrouplist(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        #endregion

        //#region PR


        //[HttpGet]
        //public async Task<JsonResult> PRListForConvertPO(GetPRListParameter input)
        //{
        //    try
        //    {
        //        return Json(new AjaxResponse(await _generalManager.PRListForConvertPO(input)));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        Log.Error(nameof(GeneralController), ex);
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}

        //[HttpGet]
        //public async Task<JsonResult> CreatePO(GetPRListParameter input)
        //{
        //    try
        //    {
        //        return Json(new AjaxResponse(await _generalManager.CreatePO(input)));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        Log.Error(nameof(GeneralController), ex);
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}

        //[HttpGet]
        //public async Task<JsonResult> GetAllApproval(GetP2PListParameter input)
        //{
        //    try
        //    {
        //        return Json(new AjaxResponse(await _generalManager.GetAllApproval(input)));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        Log.Error(nameof(GeneralController), ex);
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}
        [HttpGet]
        public async Task<JsonResult> GetCountData(string status)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetCountData(status)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        //#endregion

        #region Configure Default Settings
        /// <summary>
        /// ../eProcure/Common/Admin/ConfigDefValue.aspx?pageid=107
        /// Get Billing Address: strType='B';
        /// Get Delivery Address: strType='D';
        /// </summary>
        /// 
        [HttpGet]
        //[AbpMvcAuthorize]
        public async Task<JsonResult> GetAllAddress(GetP2PListParameter input, bool blnSortCode = false)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetAllAddress(input, blnSortCode)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        /// <summary>
        /// ../eProcure/Common/Admin/ConfigDefValue.aspx?pageid=107
        /// GetUserDefault: strType='B';
        /// </summary>
        [HttpGet]
        //[AbpMvcAuthorize]
        public async Task<JsonResult> GetUserDefault(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetUserDefault(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        /// <summary>
        /// ../eProcure/Common/Admin/ConfigDefValue.aspx?pageid=107
        /// Modify Billing Address: strType='B';  strValue='BA00x'; (where x=index)
        /// </summary>
        [HttpGet]
        //[AbpMvcAuthorize]
        public async Task<JsonResult> UpdateUserDefault(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.UpdateUserDefault(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        #endregion

        #region Send Email
        [HttpPost]
        //[AbpMvcAuthorize]
        public async Task<JsonResult> SendMail([FromBody]MapAppMail input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.SendMail(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        #endregion

        #region Admin

        [HttpGet]
        public async Task<JsonResult> GetCustomField(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetCustomField(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        #endregion

        #region admin_ext
        [HttpGet]
        public async Task<JsonResult> PopulateMfgName(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.PopulateMfgName(input.strProdCode,input.companyID)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetVendorCodeInfo(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetVendorCodeInfo(input.strVendorID, input.companyID)));
            }
            catch (UserFriendlyException ex )
            {

                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> delvendor([FromBody]Master.Map.company_vendor_suppcodeMap.MapCOMPANY_VENDOR_SUPPCODE data)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.delvendor(data)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> delVendorCode([FromBody]Master.Map.company_vendor_suppcodeMap.MapCOMPANY_VENDOR_SUPPCODE data)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.delVendorCode(data)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> upVendorCode([FromBody]Master.Map.company_vendor_suppcodeMap.MapCOMPANY_VENDOR_SUPPCODE data)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.upVendorCode(data)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getVenDefaultPayTerm(GetP2PListParameter param)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.getVenDefaultPayTerm(param.strCode, param.intRow, param.strVendorID, param.companyID)));
            }
            catch (UserFriendlyException ex)
            {

                throw;
            }
        }
        #endregion

        //[HttpGet]
        //#region AO
        //public async Task<JsonResult> GetApprovalOrder(GetAOListParameter  input)
        //{
        //    try
        //    {
        //        return Json(new AjaxResponse(await _generalManager.GetApprovalOrder(input)));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        Log.Error(nameof(GeneralController), ex);
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}

        //#endregion

        #region MISC

        #region Attachment

        [HttpPost]
        public async Task<JsonResult> FileAttachment([FromBody] List<Master.Map.company_doc_attachment.MapFileAttachment> input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.FileAttachment(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> FileUploadPR(Microsoft.AspNetCore.Http.IFormFileCollection files)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.FileUpload(files, "PR")));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> FileUploadDO(Microsoft.AspNetCore.Http.IFormFileCollection files)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.FileUpload(files, "DO")));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        //[AbpMvcAuthorize]
        public async Task<JsonResult> GetAttachmentDocument(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetAttachmentDocument(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        //[AbpMvcAuthorize]
        public async Task<JsonResult> DeleteAttachmentDocument(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.DeleteAttachmentDocument(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(GeneralController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        #endregion

        #endregion
    }

}
