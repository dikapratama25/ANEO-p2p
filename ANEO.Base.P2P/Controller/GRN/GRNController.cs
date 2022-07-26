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
using ANEO.Base.P2P.GRN;
using ANEO.Base.P2P.General.Model;
using System.Collections.Generic;

namespace ANEO.Base.P2P.DO.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class GRNController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly GRNManager _grnManager;
        private readonly IP2PNotifier _P2PNotifier;
        //private readonly Repo<DTO.P2P.Master.MASTERCODE> _masterRepo;
        public GRNController(
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
           GRNManager grnManager
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
                _grnManager = grnManager;
                _P2PNotifier = P2PNotifier;
                //_masterRepo = masterRepo;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(GRNController), ex);
            }
        }
        [HttpGet]
        public async Task<JsonResult> getVendorItemCode(string companyID,string strPONo , string strBCoyID , string strDONo,string strVendorCode )
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.getVendorItemCode(companyID,strPONo, strBCoyID, strDONo, strVendorCode)));
            }       
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> populatDOAttachment(GetGRNListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.populateDOAttachment(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getPOListForOutsDO(GetGRNListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.getPOListForOutsDO(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> populateIssueGRN(GetGRNListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.populateIssueGrn(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> populateDetailIssueGrn(GetGRNListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.populateDetailIssueGrn(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> populateDetailIssueGrnSumm(GetGRNListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.populateDetailIssueGrnSumm(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> submitGRNIssue([FromBody]GetGRNListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.submitGRNIssue(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> populateGRN(GetGRNParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.populateGRN(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetGRNHistory(GetGRNParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.GetGRNHistory(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetGRNHistoryString(GetGRNParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _grnManager.GetGRNHistoryString(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(GRNController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

    }
}
