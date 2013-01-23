using System.Collections.Generic;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Users;
using Facebook.Data;

namespace Facebook.Business.Domain.Facade.Notifications
{
    public interface INotificationsManagementService
    {
        IEnumerable<Notification> GetNotifications(User user);

        IUnitOfWork UnitOfWork { get; }
    }
}