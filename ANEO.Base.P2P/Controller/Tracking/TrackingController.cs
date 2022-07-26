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
using ANEO.Base.P2P.Tracking;
using ANEO.Base.P2P.General.Model;
using System.Collections.Generic;

namespace ANEO.Base.P2P.DO.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class TrackingController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly TrackingManager _TrackingManager;
        private readonly IP2PNotifier _P2PNotifier;
        //private readonly Repo<DTO.P2P.Master.MASTERCODE> _masterRepo;
        public TrackingController(
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
           TrackingManager TrackingManager
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
                _TrackingManager = TrackingManager;
                _P2PNotifier = P2PNotifier;
                //_masterRepo = masterRepo;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(TrackingController), ex);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAvailableCurrencyList()
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.GetAvailableCurrencyList()));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> RejectInvoice([FromBody] RejectInvoiceParameter Input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.RejectInvoice(Input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetFundType(string CompanyId, string DeptCode)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.GetFundType(CompanyId, DeptCode)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetFinanceApprovalRemark(int invoiceIndex)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.GetFinanceApprovalRemark(invoiceIndex)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> populateGridInv(TrackingParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.populateGridINV(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetInvoiceDetail(string InvoiceNO, string VendorCompID)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.GetInvoiceDetail(InvoiceNO, VendorCompID)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> saveGridInv([FromBody]TrackingParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.saveGridInv(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> saveInvDetail([FromBody] TrackingSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.saveInvDetail(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> populateInvDetail(TrackingSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.populateInvDetail(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> populateInvDetailHeader(TrackingSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.populateInvDetailHeader(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> renderCnSummary(TrackingSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.renderCnSummary(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> renderDnSummary(TrackingSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.renderDnSummary(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getFinanceApprFlow(TrackingSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.getFinanceApprFlow(input)));
            }
            catch (UserFriendlyException ex)
            {

                Log.Error(nameof(TrackingController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetInvoiceDetailString(string InvoiceNO, string VendorCompID)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.GetInvoiceDetailString(InvoiceNO, VendorCompID)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getInvAttachmentString(TrackingSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.getInvAttachmentString(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> saveGridDetail([FromBody] TrackingGridSaveParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _TrackingManager.saveGridDetail(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(TrackingManager), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        
    }
}
