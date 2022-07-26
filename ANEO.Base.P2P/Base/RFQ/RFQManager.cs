/*----- RFQManager.cs -----*/
using Abp.Localization;
using Abp.ObjectMapping;
using Abp.UI;
using Abp.Web.Models;
using LOGIC.Shared.Collection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Controller;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;
using System.Xml.XPath;
using System.IO;
using System.Transactions;
using Plexform.DTO.Core.Location;
using Plexform.DTO.Core.General;
using System.Web;
using Abp.Runtime.Security;
using System.Linq;
using Plexform.Base.Core.General.Model;
using Plexform.Base.Core.General.Repo;
using Newtonsoft.Json.Linq;
using Abp.IdentityFramework;
using Plexform;
using Plexform.Base;
using Plexform.Base.Core;
using ANEO.Base.P2P.RFQ.Map;
using ANEO.Base.P2P.General.Model;


namespace ANEO.Base.P2P.RFQ
{
    public class RFQManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;
        public RFQManager(
             Plexform.Base.Core.Entity.EntityManager entityManager,
            IWebHostEnvironment env,
            IAppFolders appFolders,
            IObjectMapper objectMapper,
            ILocalizationManager localizationManager,
            IExcelExporter excelExporter,
            RoleManager roleManager,
            UserManager userManager,
            TenantManager tenantManager
            )
            : base(env, appFolders, objectMapper, roleManager, userManager, tenantManager, excelExporter, localizationManager)
        {
            try
            {
                _connProcure = _appConfiguration["ConnectionStrings:eProcure"];
                _connSSO = _appConfiguration["ConnectionStrings:SSO"];
            }
            catch (Exception ex)
            {
                Log.Error(nameof(RFQManager), ex);
            }
        }
        public async Task<dynamic> CreateRFQ(MapRFQ_MSTR input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                string[] pquery = new string[1];
                BaseRepository<DTO.P2P.Master.rfq_mstr.RFQ_MSTR> repo = new BaseRepository<DTO.P2P.Master.rfq_mstr.RFQ_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var res = objPR.CreateRFQ(input.CompanyID, input.UserID , input.strPRNo, input.strPRIndex, input.strVendor,ref pquery , input.strUserID, input.strItemLine, false );
                return new ResultContainer(string.Format(res), true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(CreateRFQ), ex);
                throw ex;
            }

        }
        public async Task<dynamic> CreateMultiRFQ(MapRFQ_MSTR input)
        {
            try
            {
                AgoraNEO.AgoraNEO.PurchaseReq2 objPR = new AgoraNEO.AgoraNEO.PurchaseReq2();
                string[] pquery = new string[1];
                BaseRepository<DTO.P2P.Master.rfq_mstr.RFQ_MSTR> repo = new BaseRepository<DTO.P2P.Master.rfq_mstr.RFQ_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var res = objPR.CreateRFQMulti(input.CompanyID, input.UserID ,  input.strPRNo, input.strPRIndex,  input.strVendor, ref pquery, input.strUserID, input.strItemLine, false, input.PRList );
                return new ResultContainer(string.Format(res), true);
            }
            catch (Exception ex)
            {
                Log.Error(nameof(CreateRFQ), ex);
                throw ex;
            }

        }
    }
  
}
