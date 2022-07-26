using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Plexform.MultiTenancy;
using Plexform.Notifications;
using Abp.Domain.Repositories;
using Plexform;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Abp.ObjectMapping;
using Castle.Core.Logging;
using Plexform.Base.Core;
using Abp.Localization;
using Plexform.Authorization.Users;
using Plexform.Base.Core.User;
using Plexform.Base.Core.Helper;
using ANEO.Base.P2P.Invoice;
using System.Threading.Tasks;
using ANEO.Base.P2P.Filter;
using Abp.Web.Models;
using Abp.UI;
using Microsoft.AspNetCore.Http;

namespace ANEO.Base.P2P.InvoiceController.Controller
{
    [Route("api/ANEO/[controller]/[action]")]
    public class InvoiceController : BaseController
    {
        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly InvoiceManager _invoiceManager;
        private readonly IP2PNotifier _P2PNotifier;

        public InvoiceController(
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
            InvoiceManager invoiceManager
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
                _invoiceManager = invoiceManager;
                _P2PNotifier = P2PNotifier;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(InvoiceController), ex);
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAllIssueInvoiceItem(GetIssuedGRNParameter input)
        {
            try
            {
                var data = Json(new AjaxResponse(await _invoiceManager.GetAllIssueInvoiceItem(input)));
                return data;
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<dynamic> GetIssuedGRN(GetIssuedGRNParameter input)
        {
            try
            {
                var data = Json(new AjaxResponse(await _invoiceManager.GetIssuedGRN(input)));
                return data;
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetGRNPrice(string userID, string dONumber, string buyerCompanyID, int pOID)
        {
            try
            {
                var data = Json(new AjaxResponse(await _invoiceManager.GetGRNPrice(userID, dONumber, buyerCompanyID, pOID)));
                return data;
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<dynamic> GetUnInvoiceGRNLine(GetUnInvoiceGRNParameter input)
        {
            try
            {
                var data = Json(new AjaxResponse(await _invoiceManager.GetUnInvoiceGRNLine(input)));
                return data;
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }

        }

        [HttpPost]
        public async Task<dynamic> GetGSTRegNumber(string UserID, string DONumber)
        {
            try
            {
                return Json(new AjaxResponse(await _invoiceManager.GetGSTRegNumber(UserID, DONumber)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> SubmitInvoice([FromBody]InvoiceCreationParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _invoiceManager.SubmitInvoice(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

       [HttpGet]
        public async Task<JsonResult> GetInvoiceValue(GetInvoiceValueParamaeter input)
        {
            try
            {
                return Json(new AjaxResponse(await _invoiceManager.GetInvoiceValue(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> IsCompanyResident(string CompanyID)
        {
            try
            {
                return Json(new AjaxResponse(await _invoiceManager.IsCompanyResident(CompanyID)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpGet]
        public async Task<JsonResult> GetAllInvoiceListingItem(GetInvoicesParameter input)
        {
            try
            {
                return Json(new AjaxResponse(await _invoiceManager.GetAllInvoiceListingItem(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> InvoiceAttachment([FromBody]List<Master.Map.company_doc_attachment.MapFileAttachment> data)
        {
            try
            {
                return Json(new AjaxResponse(await _invoiceManager.InvoiceAttachment(data)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

        [HttpPost]
        public async Task<JsonResult> FileUploadAttachmentInvCreation(IFormFileCollection files)
        {
            try
            {
                return Json(new AjaxResponse(await _invoiceManager.FileUploadAttachmentInvCreation(files)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(InvoiceController), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }

    }
}
