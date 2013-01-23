using System.Collections.Generic;
using System.Linq;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Business.Domain.Facade.Notifications
{
    public class NotificationsManagementService : INotificationsManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationsManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Notification> GetNotifications(User user)
        {
            ContractUtil.NotNull(user);

            foreach (var notification in _unitOfWork.Notifications.FindNotificationsFor(user)
                                                                  .Where(notification => !notification.IsRead))
            {
                notification.IsRead = true;
                //_unitOfWork.Commit();

                yield return notification;
            }
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
    }
}