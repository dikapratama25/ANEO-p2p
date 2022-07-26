using System;
using System.IO;
using System.Text;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.AspNetZeroCore.Licensing;
using Abp.AspNetZeroCore.Web;
using Abp.Configuration.Startup;
using Abp.Dependency;
using Abp.Hangfire;
using Abp.Hangfire.Configuration;
using Abp.IO;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Runtime.Caching.Redis;
using Abp.Zero.Configuration;
using Castle.Core.Internal;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Plexform.Authorization;
using Plexform.Chat;
using Plexform.Configuration;
using Plexform.EntityFrameworkCore;
using Plexform.Localization;
using Plexform.Startup;
//using Plexform.Web.Authentication.JwtBearer;
//using Plexform.Web.Authentication.TwoFactor;
//using Plexform.Web.Chat.SignalR;
//using Plexform.Web.Configuration;
using Plexform;
using Plexform.Notifications;

namespace ANEO.Base.P2P
{
    [DependsOn(
        typeof(PlexformApplicationModule),
        typeof(PlexformEntityFrameworkCoreModule),
        typeof(AbpAspNetZeroCoreWebModule),
        typeof(AbpAspNetCoreSignalRModule),
        typeof(PlexformGraphQLModule),
        typeof(AbpRedisCacheModule), //AbpRedisCacheModule dependency (and Abp.RedisCache nuget package) can be removed if not using Redis cache
        typeof(AbpHangfireAspNetCoreModule) //AbpHangfireModule dependency (and Abp.Hangfire.AspNetCore nuget package) can be removed if not using Hangfire
    )]
    public class P2PModule : AbpModule
    {
        private readonly IWebHostEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public P2PModule(IWebHostEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            //Set Localization
            P2PLocalizationConfigurer.Configure(Configuration.Localization);

            //Set Permission
            Configuration.Authorization.Providers.Add<P2PAuthorizationProvider>();

            //Set default connection string
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                PlexformConsts.ConnectionStringName
            );

            //Adding notification providers
            Configuration.Notifications.Providers.Add<P2PNotificationProvider>();

            //Configuration.Modules.AbpAspNetCore()
            //    .CreateControllersForAppServices(
            //        typeof(PlexformApplicationModule).GetAssembly()
            //    );

            //Configuration.Caching.Configure(TwoFactorCodeCacheItem.CacheName, cache =>
            //{
            //    cache.DefaultAbsoluteExpireTime = TimeSpan.FromMinutes(2);
            //});

            //Configuration.ReplaceService<IAppConfigurationAccessor, PlexformConfigurationAccessor>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(P2PModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            SetAppFolders();
            IocManager.RegisterIfNot<IP2PNotifier>();
        }

        private void SetAppFolders()
        {
            var appFolders = IocManager.Resolve<AppFolders>();

            appFolders.SampleProfileImagesFolder = Path.Combine(_env.WebRootPath, $"Common{Path.DirectorySeparatorChar}Images{Path.DirectorySeparatorChar}SampleProfilePics");
            appFolders.WebLogsFolder = Path.Combine(_env.ContentRootPath, $"App_Data{Path.DirectorySeparatorChar}Logs");

#if NET461
            if (_env.IsDevelopment())
            {
                var currentAssemblyDirectoryPath = typeof(LOGICCoreModule).GetAssembly().GetDirectoryPathOrNull();
                if (currentAssemblyDirectoryPath != null)
                {
                    appFolders.WebLogsFolder = Path.Combine(currentAssemblyDirectoryPath, $"App_Data{Path.DirectorySeparatorChar}Logs");
                }
            }
#endif
        }
    }
}
