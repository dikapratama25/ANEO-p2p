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
using ANEO.Base.P2P.DO;
using ANEO.Base.P2P.General.Model;
using System.Collections.Generic;

namespace ANEO.Base.P2P.DO.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class DOController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly DOManager _doManager;
        private readonly IP2PNotifier _P2PNotifier;
        //private readonly Repo<DTO.P2P.Master.MASTERCODE> _masterRepo;
        public DOController(
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
           DOManager dOManager
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
                _doManager = dOManager;
                _P2PNotifier = P2PNotifier;
                //_masterRepo = masterRepo;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(DOController), ex);
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetOutStandingPOWithDAddress(GetDOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.GetOutStandingPOWithDAddress(input)));
            }       
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetDOList(GetDOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.GetDOList(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetPODetails(GetDOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.GetPODetails(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDODetails(GetDOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.GetDODetails(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDODraftAvaibility(GetDOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.GetDODraftAvaibility(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetDOSummary(GetDOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.GetDOSummary(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetTempDOAttachment(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.GetTempDOAttachment(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpDelete]
        public async Task<JsonResult> DeleteTempDOAttachment([FromBody] Map.MapCOMPANY_DO_DOC_ATTACHMENT_TEMP input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.DeleteTempDOAttachment(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> InsertDO([FromBody] Map.MapDOParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _doManager.InsertDO(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(DOController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

    }
}
