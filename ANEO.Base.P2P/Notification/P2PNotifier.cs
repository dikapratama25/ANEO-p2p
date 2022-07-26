using System;
using System.Threading.Tasks;
using Abp;
using Abp.Localization;
using Abp.Notifications;
using Abp.Dependency;
using Plexform.Authorization.Users;
using System.Linq;
using System.Collections.Generic;

namespace Plexform.Notifications
{
    public interface IP2PNotifier
    {
        Task Sample(string str, long sendToUserId);
    }

    public class P2PNotifier : PlexformDomainServiceBase, IP2PNotifier, ITransientDependency
    {
        private readonly IPlexformNotifier _plexformNotifier;
        private readonly UserManager _userManager;
        private readonly INotificationPublisher _notificationPublisher;

        public P2PNotifier(IPlexformNotifier plexformNotifier, UserManager userManager, INotificationPublisher notificationPublisher)
        {
            _plexformNotifier = plexformNotifier;
            _userManager = userManager;
            _notificationPublisher = notificationPublisher;
        }

        public async Task Sample(string str, long sendToUserId)
        {
            var notificationData = new LocalizableMessageNotificationData(
                new LocalizableString(
                    "Sample",
                    PlexformConsts.LocalizationSourceName
                    )
                );

            var _users = _userManager.GetUserById(sendToUserId);

            notificationData["data"] = str;
            await _notificationPublisher.PublishAsync(
                P2PNotifications.SampleNotif,
                notificationData, userIds: new[] { _users.ToUserIdentifier() }, severity: NotificationSeverity.Info);
        }
    }
}