using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Users;

namespace Facebook.Data.EntityFramework.Repositories
{
    class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        public NotificationRepository(DbSet<Notification> set)
            :base(set)
        {       
        }

        #region Implementation of INotificationRepository

        /// <summary>
        /// Finds the unread notifications for the user <see cref="account"/>
        /// </summary>
        /// <param name="account">The account for which the notifications is looking for.</param>
        /// <param name="spec">An aditional spec.</param>
        /// <returns>All the unread notifications for <see cref="account"/></returns>
        public IQueryable<Notification> FindNotificationsFor(User account)
        {
            return Set.Where(notification => notification.Owner.Id.Equals(account.Id));
        }

        /// <summary>
        /// Adds a given notification to the current repository.
        /// </summary>
        /// <param name="notification">The notification to add.</param>
        public void Add(Notification notification)
        {
            Set.Add(notification);
        }

        #endregion
    }
}