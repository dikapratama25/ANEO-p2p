using Abp.Domain.Repositories;
using Abp.Localization;
using Abp.ObjectMapping;
using Abp.UI;
using Abp.Web.Models;
using ANEO.Base.P2P.Base.ItemMaster;
using ANEO.Base.P2P.Filter;
using Castle.Core.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging.Abstractions;
using Plexform;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core;
using Plexform.Base.Core.Helper;
using Plexform.Base.Core.User;
using Plexform.MultiTenancy;
using Plexform.Notifications;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ANEO.Base.P2P.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class ItemMasterController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly ItemMasterManager _generalManager;
        private readonly IP2PNotifier _P2PNotifier;
        //private readonly Repo<DTO.P2P.Master.MASTERCODE> _masterRepo;

        public ItemMasterController(
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
            ItemMasterManager generalManager
            ) : base(roleRepository, appNotifier, env, appFolders, objectMapper, tenantManager, excelExporter, localizationManager)
        {
            try
            {
                Log = Castle.Core.Logging.NullLogger.Instance;
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
                Log.Error(nameof(ItemMasterController), ex);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetItems(GetItemsParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetItems(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(ItemMasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        //[HttpGet]
        //public async Task<JsonResult> Get1Column(Get1ColumnParameter input)
        //{
        //    try
        //    {
        //        return Json(new AjaxResponse(await _generalManager.Get1Column(input)));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        Log.Error(nameof(ItemMasterController), ex);
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}

        [HttpGet]
        public async Task<JsonResult> BIM_ItemDetails(GetBIMParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.BIM_ItemDetails(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(ItemMasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetSingleProduct(GetSingleProductParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetSingleProduct(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(ItemMasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> FillGLCode_data(GetFillGLCodeParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.FillGLCode_data(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(ItemMasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetCategoryCode(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetCategoryCode(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(ItemMasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetMasterCodeByStatus(GetP2PListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _generalManager.GetMasterCodeByStatus(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(ItemMasterController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        //[HttpPost]
        //public async Task<JsonResult> SaveItemDetail([FromBody] MapItemDetailMaster input)
        //{
        //    try
        //    {
        //        return Json(new AjaxResponse(await _generalManager.SaveItemDetail(input)));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        Log.Error(nameof(ItemMasterController), ex);
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}

        //[HttpPost]
        //public async Task<JsonResult> GetLatestItemNo([FromBody] MapItemDetailMaster input)
        //{
        //    try
        //    {
        //        return Json(new AjaxResponse(await _generalManager.GetLatestItemNo(input)));
        //    }
        //    catch (UserFriendlyException ex)
        //    {
        //        Log.Error(nameof(ItemMasterController), ex);
        //        return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
        //    }
        //}
    }
}
