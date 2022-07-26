using Abp.Localization;
using Abp.ObjectMapping;
using Microsoft.AspNetCore.Hosting;
using Plexform.Authorization.Roles;
using Plexform.Authorization.Users;
using Plexform.Base.Core.Helper;
using Plexform.MultiTenancy;
using System;
using System.Threading.Tasks;
using Plexform;
using Plexform.Base;
using Plexform.Base.Core;
using ANEO.Base.P2P.Filter;
using ANEO.Base.P2P.General.Map;
using ANEO.Base.P2P.Master.Map;
using ANEO.Base.P2P.General.Model;
using System.Data;
using System.Collections.Generic;

namespace ANEO.Base.P2P.BuyerCatalogue
{
    public class BuyerCatalogueManager : BaseClass
    {
        private readonly string _connProcure;
        private readonly string _connSSO;

        public BuyerCatalogueManager(
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
                Log.Error(nameof(BuyerCatalogueManager), ex);
            }
        }

        public async Task<dynamic> BuyerCatItems(Model.BuyerCatModel input)
        {
            try
            {
                AgoraNEO.AgoraNEO.BuyerCat objBuyer = new AgoraNEO.AgoraNEO.BuyerCat();

                System.Collections.ArrayList arrayItemType = new System.Collections.ArrayList();
                if (!string.IsNullOrEmpty(input.pItemType))
                {
                    arrayItemType.AddRange(input.pItemType.Split(","));
                }
                
                string strSQL = objBuyer.getBuyerCatItemsByCombo1(input.CompanyID, input.pCatIndex ?? "0", input.pComType ?? string.Empty, input.pItemName ?? string.Empty, true , input.pItemCode ?? string.Empty, arrayItemType);
                var repo = new BaseRepository<DTO.P2P.Master.BuyerCategory_mstr.BUYER_CATALOGUE_ITEMS>(_env, _connProcure, LOGIC.Repo.DatabaseType.MySQL);
                var data = repo.ExecuteQueryList<Master.Map.BuyerCategoryMap.MapBuyerCat>(strSQL);
                return data;

            }
            catch (Exception ex)
            {
                Log.Error(nameof(BuyerCatalogueManager), ex);
                throw ex;
            }
        }

        public async Task<dynamic> GetBuyerCatByUser(Model.BuyerCatModel input)
        {
            try
            {
                AgoraNEO.AgoraNEO.BuyerCat objCat = new AgoraNEO.AgoraNEO.BuyerCat();
                DataView data = objCat.getBuyerCatByUser(input.UserID);
                DataTable res = data.ToTable();
                return res;
            }
            catch (Exception ex)
            {
                Log.Error(nameof(BuyerCatalogueManager), ex);
                throw ex;
            }
        }

    }
}
