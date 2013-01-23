using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Facade.Notifications
{
    public class NotificationFactory : INotificationFactory
    {
        private readonly IDateTimeService _dateTimeService;

        public NotificationFactory(IDateTimeService dateTimeService)
        {
            _dateTimeService = dateTimeService;
        }

        #region Implementation of INotificationFactory

        public Notification CreateFriendshipRequest(User sender, User reciver)
        {
            return new Notification(reciver, 
                                    string.Format("{0} want's to be your friend.", sender.FirstName + " " + sender.LastName), 
                                    _dateTimeService.Now());
        }

        public Notification CreateFriendshipAccepted(User sender, User reciver)
        {
            return new Notification(sender,
                                    string.Format("{0} is now your friend.", reciver.FirstName + " " + reciver.LastName),
                                    _dateTimeService.Now());
        }

        #endregion
    }
}