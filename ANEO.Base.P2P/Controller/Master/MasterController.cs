using System;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Plexform.MultiTenancy;
using Plexform.Notifications;
using Abp.Web.Models;
using Abp.Domain.Repositories;
using Abp.Auditing;
using Plexform;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Abp.UI;
using Abp.ObjectMapping;
using Castle.Core.Logging;
using LOGIC.Shared.Collection;
using LOGIC.Shared;
using System.Collections.Generic;
using Plexform.Base.Core;
using Abp.Localization;
using Plexform.Authorization.Users;
using Plexform.Base.Core.User;
using Plexform.Base.Core.Helper;
using ANEO.Base.P2P.Filter;

namespace ANEO.Base.P2P.Master.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class MasterController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly MasterManager _masterManager;
        private readonly IP2PNotifier _P2PNotifier;

        public MasterController(
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
            BizUserManager bizUser,
            UserManager userManager,
            TenantManager tenantManager,
            RoleManager roleManager,
            MasterManager masterManager
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
                _masterManager = masterManager;
                _P2PNotifier = P2PNotifier;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterController), ex);
            }
        }

        /// <summary>
        /// README PLEASE...
        /// This are place for call function from Manager, rule of thumbs :
        /// - Here, Error exception/Handler using this format :
        ///   catch (Exception ex)
        ///   catch (UserFriendlyException ex)
        ///    {
        ///        Log.Error(nameof(CampaignController), ex);
        ///        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        ///    }
        /// - Put a logic/function inside a region to make it tidy and easy to search/maintaince
        /// - Name your logic/function as clear as possible + add summary to ease documentation
        /// - Ask Other/Senior Member if there is any question
        /// </summary>
        /// <param name="REGION PUBLIC">Logic/Function for general purpose (can be use without login/permission)</param>
        /// <param name="REGION APP">Login/Function for use after login (need permission either Manager/Admin/Affiliate to use)</param>
        /// <returns>Thank You</returns>

        #region MASTERCODE
        [HttpGet]
        //[AbpMvcAuthorize]
        [DisableAuditing] // only on due to sample purpose
        public async Task<JsonResult> GetPRMasterList(GetListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _masterManager.GetPRMasterList(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(MasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        

        [HttpPost]
        //[AbpMvcAuthorize]
        [DisableAuditing] // only on due to sample purpose
        public async Task<JsonResult> CreateOrUpdatePRMaster([FromBody] IList<Map.pr_mstr.MapPR_MSTR> json)
        {
            try
            {
                bool data = await _masterManager.CreateOrUpdatePRMaster(_objectMapper.Map<IList<DTO.P2P.Master.pr_mstr.PR_MSTR>>(json));
                return Json(new AjaxResponse(new { success = data }));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(MasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        //[AbpMvcAuthorize]
        [DisableAuditing] // only on due to sample purpose
        public async Task<JsonResult> DeletePRMaster([FromBody] IList<Map.pr_mstr.MapPR_MSTR> json)
        {
            try
            {
                bool data = await _masterManager.DeletePRMaster(_objectMapper.Map<IList<DTO.P2P.Master.pr_mstr.PR_MSTR>>(json));
                return Json(new AjaxResponse(new { success = data }));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(MasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAllMasterCode(GetCodeTableListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _masterManager.GetAllMasterCode(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(MasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        /// <summary>
        /// pStatus 'N' = not deleted
        /// </summary>
        [HttpGet]
        public async Task<JsonResult> GetMasterCodeByStatus(GetCodeTableListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _masterManager.GetMasterCodeByStatus(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(MasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        #endregion

        #region USER
        [HttpGet]
        public async Task<JsonResult> getCompanyID(string userID)
        {
            try
            {
                string data = await _masterManager.getCompanyID(userID);
                return Json(new AjaxResponse(new { data = data }));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(MasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        #endregion
    }

}
