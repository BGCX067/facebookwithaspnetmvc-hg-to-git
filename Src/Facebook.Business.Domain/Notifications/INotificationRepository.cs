using System;
using System.Linq;
using System.Linq.Expressions;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Notifications
{
    /// <summary>
    /// Defines the contracts for a notification repository.
    /// </summary>
    public interface INotificationRepository 
    {
        /// <summary>
        /// Finds the unread notifications for the user <see cref="account"/>
        /// </summary>
        /// <param name="account">The account for which the notifications is looking for.</param>
        /// <returns>All the unread notifications for <see cref="account"/></returns>
        IQueryable<Notification> FindNotificationsFor(User account);

        /// <summary>
        /// Adds a given notification to the current repository.
        /// </summary>
        /// <param name="notification">The notification to add.</param>
        void Add(Notification notification);
    }
}