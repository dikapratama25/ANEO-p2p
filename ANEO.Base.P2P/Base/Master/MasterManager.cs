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
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.Master.Model;

namespace ANEO.Base.P2P.Master
{
    public class MasterManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;
        public MasterManager(
            IWebHostEnvironment env,
            IAppFolders appFolders,
            IObjectMapper objectMapper,
            ILocalizationManager localizationManager,
            IExcelExporter excelExporter,
            RoleManager roleManager,
            UserManager userManager,
            TenantManager tenantManager)
            : base(env, appFolders, objectMapper, roleManager, userManager, tenantManager, excelExporter, localizationManager)
        {
            try
            {
                _connProcure = _appConfiguration["ConnectionStrings:eProcure"];
                _connSSO = _appConfiguration["ConnectionStrings:SSO"];
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterManager), ex);
            }
        }

        public async Task<dynamic> GetPRMasterList(GetListParameter input)
        {
            try
            {
                var repo = new BaseRepository<DTO.P2P.Master.pr_mstr.PR_MSTR>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var data = repo.ExecuteQueryList<Model.MapListPR_MSTR>("select * from pr_mstr limit 10");

                return data;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> getCompanyID(string userID)
        {
            try
            {
                AgoraNEO.AgoraNEO.Users objUsr = new AgoraNEO.AgoraNEO.Users();
                string strSQL = objUsr.getCompanyID(userID);

                return strSQL;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterManager), ex);
                throw ex;
            }
        }
        public async Task<dynamic> CreateOrUpdatePRMaster(IList<DTO.P2P.Master.pr_mstr.PR_MSTR> data)
        {
            try
            {
                //_agoraLegacy.CreateMasterCode(data);

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> DeletePRMaster(IList<DTO.P2P.Master.pr_mstr.PR_MSTR> data)
        {
            try
            {
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetAllMasterCode(GetCodeTableListParameter input)
        {
            try
            {
                AgoraNEO.AgoraNEO.AppDataProvider objUser = new AgoraNEO.AgoraNEO.AppDataProvider();
                var repo = new BaseRepository<DTO.P2P.Master.code_mstr.CODE_MSTR>(_env, _connSSO, LOGIC.Repo.DatabaseType.MySQL);

                string strSQL = objUser.GetAllMasterCode(input.pCodeTableEnum, true).ToString();
                string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);

                var res = repo.ExecuteQueryList<Map.code_mstr.MapCODE_MSTR>(strSQL + strPagination);

                int totalCount = (repo.ExecuteQueryList<Map.code_mstr.MapCODE_MSTR>(strSQL)).TotalCount;
                res.TotalCount = totalCount;

                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetMasterCodeByStatus(GetCodeTableListParameter input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input.pStatus))
                {
                    AgoraNEO.AgoraNEO.AppDataProvider objUser = new AgoraNEO.AgoraNEO.AppDataProvider();
                    var repo = new BaseRepository<DTO.P2P.Master.code_mstr.CODE_MSTR>(_env, _connSSO, LOGIC.Repo.DatabaseType.MySQL);

                    string strSQL = objUser.GetMasterCodeByStatus(input.pCodeTableEnum, input.pStatus, true).ToString();
                    string strPagination = string.Format(" LIMIT {0} OFFSET {1}", input.MaxResultCount, input.SkipCount);

                    var res = repo.ExecuteQueryList<MapCodeCategory>(strSQL + strPagination);

                    int totalCount = (repo.ExecuteQueryList<MapCodeCategory>(strSQL)).TotalCount;
                    res.TotalCount = totalCount;

                    return res;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Log.Error(nameof(MasterManager), ex);
                throw ex;
            }
        }
    }
}

