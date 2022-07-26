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
using ANEO.Base.P2P.PR.Map;
using ANEO.Base.P2P.PR.Model;
using System.Collections.Generic;
namespace ANEO.Base.P2P.PR.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class PRController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly PRManager _prManager;
        private readonly IP2PNotifier _P2PNotifier;
        //private readonly Repo<DTO.P2P.Master.MASTERCODE> _masterRepo;

        public PRController(
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
            PRManager prManager
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
                _prManager = prManager;
                _P2PNotifier = P2PNotifier;
                //_masterRepo = masterRepo;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PRController), ex);
            }
        }
        [HttpGet]
        public async Task<JsonResult> PRListForConvertPO(GetPRListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.PRListForConvertPO(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> CreatePO([FromBody] List<MapGetPRListParameter> input)
        {
            try
            {

                return Json(new AjaxResponse(await _prManager.CreatePO(input[0].userID, input[0].companyID, input[0].strPRNo, input[0].pPRIndex, input[0].pPRLine, input[0].sProductIndex)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetAllPR(GetPRListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetAllPR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> SavePR([FromBody] MapPRMaster input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.SavePR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> SubmitPR([FromBody] MapPRMaster input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.SubmitPR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> ApprovePR([FromBody] mapApprovedPR input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.ApprovePR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> RejectPR([FromBody] mapRejectPR input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.RejectPR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }



        [HttpGet]
        public async Task<JsonResult> GetApprovalList(GetAOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetApprovallist(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }




        [HttpGet]
        public async Task<JsonResult> GetPRItem(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetPRItem(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetBCMListByUserNew(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetBCMListByUserNew(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAnalysisCode(GetPRListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetAnalysisCode(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> DeletePR(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.DeletePR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> CancelPR(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.CancelPR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> DuplicatePR(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.DuplicatePR(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetPRDetail(GetPRListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetPRDetail(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> getPRDetailHead(GetPRListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetPRDetailHead(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getPRDetailBody(GetPRListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetPRDetailBody(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getPRDetailFoot(string intPRIndex)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetPRDetailFoot(intPRIndex)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        #region AO
        public async Task<JsonResult> GetApprovalOrder(GetAOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _prManager.GetApprovalOrder(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PRController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        #endregion

    }
}
