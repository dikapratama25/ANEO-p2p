using  System;
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
using System.Threading.Tasks;
using ANEO.Base.P2P.BuyerCatalogue.Model;
using Abp.Web.Models;
using Abp.UI;

namespace ANEO.Base.P2P.RFQ.Controller
{

    [Route("api/ANEO/[controller]/[action]")]
    public class RFQController : BaseController
    {

        public ILogger Log { get; set; }
        private readonly IRealTimeCommunicator _realtimeService;
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly RoleManager _roleManager;
        private readonly TenantManager _tenantManager;
        private readonly RFQManager _rfqManager;
        private readonly IP2PNotifier _P2PNotifier;

        public RFQController(
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
            RFQManager rfqmanager 
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
                _rfqManager = rfqmanager;
                _P2PNotifier = P2PNotifier;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(RFQController), ex);
            }
        }
         
        [HttpPost]
        public async Task<JsonResult> CreateRFQ([FromBody] Map.MapRFQ_MSTR input)

        {
            try
            {
                return Json(new AjaxResponse(await _rfqManager.CreateRFQ(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(CreateRFQ), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }
        [HttpPost]
        public async Task<JsonResult> CreateMultiRFQ([FromBody] Map.MapRFQ_MSTR input)

        {
            try
            {
                return Json(new AjaxResponse(await _rfqManager.CreateMultiRFQ(input)));
            }
            catch (UserFriendlyException ex)
            {
                Log.Error(nameof(CreateRFQ), ex);
                return Json(new AjaxResponse(new ErrorInfo(ex.Message)));
            }
        }





    }
}
