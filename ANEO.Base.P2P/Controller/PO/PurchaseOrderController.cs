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
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Net.Http.Headers;
using System.IO;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;
using System.Globalization;
using ANEO.Base.P2P.Base.PurchaseOrder;

namespace ANEO.Base.P2P.PurchaseOrder.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class PurchaseOrderController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly PurchaseOrderManager _purchaseorderManager;
        private readonly IP2PNotifier _P2PNotifier;
        //private readonly Repo<DTO.P2P.Master.MASTERCODE> _masterRepo;

        public PurchaseOrderController(
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
            PurchaseOrderManager purchaseorderManager
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
                _purchaseorderManager = purchaseorderManager;
                _P2PNotifier = P2PNotifier;
                //_masterRepo = masterRepo;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
            }
        }
        #region PO
        [HttpGet]
        public async Task<JsonResult> getPoList(GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.getPoList(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getPOListForApproval(GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.getPOListForApproval(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> ApprovePO ([FromBody] mapApprovedPO input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.ApprovePO(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> AcceptPO([FromBody] mapAcceptPO input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.AcceptPO(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> RejectPO([FromBody] mapAcceptPO input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.RejectPO(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getPODetail(GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.getPODetail(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetPOForApprDetails(string userID, string companyID, string PO_No, string PRIndex)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.GetPOForApprDetails(userID, companyID, PO_No, PRIndex)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> GetAcknowledgePO(GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.AcknowledgePO(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getAppFlowPO(string userID, string companyID, long intPRIndex, string strFOR)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.getAppFlowPO(intPRIndex, companyID, strFOR)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getLineitem(string userID, string companyID, string strPONo, string side, bool blnPreview, string strBCoyId, bool blnShowAddr = true)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.getlineitem(userID, companyID, strPONo, side, blnPreview, strBCoyId, blnShowAddr)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> get_CRView(string userID, string companyID, string strPONo, string cr_no, string side, string bcom_id, string cr_status = "")
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.get_CRView(userID, companyID, strPONo, cr_no, side, bcom_id, cr_status)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> get_docitem(GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.get_docitem(input.strPONo, input.strSide, input.companyID, input.companyID)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getPoAttachment(GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.getPoAttachment(input.strPONo, input.companyID)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> update_POStatus([FromBody] GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.update_POStatus(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpGet]
        public async Task<JsonResult> getListRaisePO(GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.getPODetail(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> raisePO([FromBody] GetPOListParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.update_POStatus(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> SubmitPO([FromBody] MapPO_DETAILS input)
        {
            try
            {
                return Json(new AjaxResponse(await _purchaseorderManager.SubmitPO(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(PurchaseOrderController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        #endregion


    }
}
