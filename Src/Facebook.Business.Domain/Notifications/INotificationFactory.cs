using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Notifications
{
    public interface INotificationFactory
    {
        Notification CreateFriendshipRequest(User sender, User reciver);

        Notification CreateFriendshipAccepted(User sender, User reciver);
    }
}