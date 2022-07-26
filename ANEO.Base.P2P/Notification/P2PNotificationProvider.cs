using Abp.Authorization;
using Abp.Localization;
using Abp.Notifications;
using Plexform.Authorization;

namespace Plexform.Notifications
{
    public static class P2PNotifications
    {
        #region Campaign
        public const string SampleNotif = "App.ANEO.SampleNotif";
        #endregion
    }

    class P2PNotificationProvider : NotificationProvider
    {
        public override void SetNotifications(INotificationDefinitionContext context)
        {
            context.Manager.Add(
                new NotificationDefinition(
                    P2PNotifications.SampleNotif,
                    displayName: L("Sample")
                    )
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, PlexformConsts.LocalizationSourceName);
        }
    }
}
