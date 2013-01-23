using System;
using Facebook.Business.Domain.Friendship;
using Facebook.Business.Domain.Images;
using Facebook.Business.Domain.Internals;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;

namespace Facebook.Data
{
    /// <summary>
    /// This interface define basic contracts to implement th unit of work pattern.
    /// For more information see http://www.martinfowler.com/eaaCatalog/unitOfWork.html
    /// </summary>
    /// <remarks>
    /// TODO: Consider change this interface to match better with Microsoft approaches => that is remove rollback method.
    /// </remarks>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Commit all changes.
        /// </summary>
        void Commit();

        /// <summary>
        /// Rollback changes not stored in databse at 
        /// this moment. See references of UnitOfWork pattern
        /// </summary>
        void Rollback();

        /// <summary>
        /// Gets a repository of users.
        /// </summary>
        IUserAccountRepository Users { get; }

        /// <summary>
        /// Gets a repository of messages.
        /// </summary>
        IMessageRepository Messages { get; }

        /// <summary>
        /// Gets a repository of notifications.
        /// </summary>
        INotificationRepository Notifications { get; }

        /// <summary>
        /// Gets a repository of posts.
        /// </summary>
        IPostRepository Posts { get; }

        /// <summary>
        /// Gets a repository of friendship requests.
        /// </summary>
        IFriendshipRepository FriendshipRequests { get; }

        /// <summary>
        /// Gets a repository with the state and representation of all facebook keys.
        /// </summary>
        IFacebookKeyRepository Entries { get; }

        IImageRepository Images { get; }
    }
}
