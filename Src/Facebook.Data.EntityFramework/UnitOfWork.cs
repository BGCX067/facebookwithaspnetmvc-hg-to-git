using System;
using Facebook.Business.Domain.Friendship;
using Facebook.Business.Domain.Images;
using Facebook.Business.Domain.Internals;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;
using Facebook.Data.EntityFramework.Repositories;

namespace Facebook.Data.EntityFramework
{
    /// <summary>
    /// A concrete implementation of the unit of work pattern using Entity Framework.
    /// <remarks>
    /// 
    /// </remarks>
    /// </summary>
    public sealed class UnitOfWork : IUnitOfWork
    {
        private const string Name = "UnitOfWork";

        private readonly FacebookContext _context = new FacebookContext();

        private UserAccountRepository _users;
        private NotificationRepository _notifications;
        private MessageRepository _messages;
        private PostRepository _posts;
        private FriendshipRequestRepository _requests;
        private FacebookKeyRepository _entries;
        private ImageRepository _images;

        #region Implementation of IUnitOfWork

        /// <summary>
        /// Commit all changes.
        /// </summary>
        public void Commit()
        {
            if (_disposed)
                throw new ObjectDisposedException(Name);

            _context.SaveChanges();
        }

        /// <summary>
        /// Rollback changes not stored in databse at 
        /// this moment. See references of UnitOfWork pattern
        /// </summary>
        public void Rollback()
        {
            throw new NotSupportedException(); //TODO Consider remove this feature.
        }

        /// <summary>
        /// Gets a repository of users.
        /// </summary>
        public IUserAccountRepository Users
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(Name);

                return _users ?? (_users = new UserAccountRepository(_context.Users));
            }
        }

        /// <summary>
        /// Gets a repository of messages.
        /// </summary>
        public IMessageRepository Messages
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(Name);

                return _messages ?? (_messages = new MessageRepository(_context.Messages));
            }
        }

        /// <summary>
        /// Gets a repository of notifications.
        /// </summary>
        public INotificationRepository Notifications
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(Name);

                return _notifications ?? (_notifications = new NotificationRepository(_context.Notifications));
            }
        }

        /// <summary>
        /// Gets a repository of posts.
        /// </summary>
        public IPostRepository Posts
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(Name);

                return _posts ?? (_posts = new PostRepository(_context.Posts));
            }
        }

        /// <summary>
        /// Gets a repository of friendship requests.
        /// </summary>
        public IFriendshipRepository FriendshipRequests
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(Name);

                return _requests ?? (_requests = new FriendshipRequestRepository(_context.FriendshipRequests));
            }
        }

        /// <summary>
        /// Gets a repository with the state and representation of all facebook keys.
        /// </summary>
        public IFacebookKeyRepository Entries
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(Name);

                return _entries ?? (_entries = new FacebookKeyRepository(_context.Entries));
            }
        }

        public IImageRepository Images
        {
            get
            {
                if (_disposed)
                    throw new ObjectDisposedException(Name);

                return _images ?? (_images = new ImageRepository(_context.Images));
            }
        }

        #endregion

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            if (_disposed)
                return;

            // _context.Dispose(); TODO: Note important fix this
            _disposed = true;
            // GC.SuppressFinalize(this);
        }

        private bool _disposed;

        #endregion

        #region Nested types

        
        #endregion
    }
}