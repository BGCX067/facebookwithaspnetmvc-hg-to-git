using System;
using System.Collections.Generic;
using System.Linq;

using Facebook.Business.Domain.Facade.Internals;
using Facebook.Business.Domain.Friendship;
using Facebook.Business.Domain.Images;
using Facebook.Business.Domain.Internals;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;
using Facebook.Infrastructure.Contracts;
using Facebook.Infrastructure.Ioc;

using Microsoft.Practices.Unity;

namespace Facebook.Data.InMemory
{ 
    public class InMemoryUnitOfWork : IUnitOfWork
    {
        #region Data
        
        private static readonly IDictionary<int, User> UsersData = new Dictionary<int, User>();
        private static readonly IDictionary<int, Message> MessagesData = new Dictionary<int, Message>(); 
        private static readonly IDictionary<int, Post> PostsData = new Dictionary<int, Post>(); 
        private static readonly IDictionary<int, Notification> NotificationsData = new Dictionary<int, Notification>(); 
        private static readonly IDictionary<int, FriendshipRequest> FriendshipRequestsData = new Dictionary<int, FriendshipRequest>();
        private static readonly IDictionary<int, FacebookKey> EntriesData = new Dictionary<int, FacebookKey>();
        private static readonly IDictionary<int, Image> ImagesData = new Dictionary<int, Image>(); 
        private static int _currentKey;

        #endregion

        public InMemoryUnitOfWork()
        {
            Users = new UserAccountRepository(UsersData);
            Messages = new MessageRepository(MessagesData);
            Posts = new PostRepository(PostsData);
            Notifications = new NotificationRepository(NotificationsData);
            FriendshipRequests = new FriendshipRequestRepository(FriendshipRequestsData);
            Entries = new FacebookKeyRepository(EntriesData);
            Images = new ImageRepository(ImagesData);
        }

        #region Implementation of IUnitOfWork

        /// <summary>
        /// Commit all changes.
        /// </summary>
        public void Commit()
        {
            // do nothing ...
        }

        /// <summary>
        /// Rollback changes not stored in databse at 
        /// this moment. See references of UnitOfWork pattern
        /// </summary>
        public void Rollback()
        {
            throw new NotSupportedException();
        }

        /// <summary>
        /// Gets a repository of users.
        /// </summary>
        public IUserAccountRepository Users { get; private set; }

        /// <summary>
        /// Gets a repository of messages.
        /// </summary>
        public IMessageRepository Messages { get; private set; }

        /// <summary>
        /// Gets a repository of notifications.
        /// </summary>
        public INotificationRepository Notifications { get; private set; }

        /// <summary>
        /// Gets a repository of posts.
        /// </summary>
        public IPostRepository Posts { get; private set; }

        /// <summary>
        /// Gets a repository of friendship requests.
        /// </summary>
        public IFriendshipRepository FriendshipRequests { get; private set; }

        /// <summary>
        /// Gets a repository with the state and representation of all facebook keys.
        /// </summary>
        public IFacebookKeyRepository Entries { get; private set; }

        public IImageRepository Images { get; private set; }

        #endregion

        #region Nested Types
        
        class UserAccountRepository : IUserAccountRepository
        {
            private readonly IDictionary<int, User> _data;

            public UserAccountRepository(IDictionary<int, User> data)
            {
                _data = data;
            }

            #region Implementation of IUserAccountRepository

            /// <summary>
            /// Retrieve all users in the current repository that match with a given specification..
            /// </summary>
            /// <remarks>
            /// NOTE: We choose add this method to all repositories definition insted of to add a generic repository definition in the bussines layer for the following reasons:
            ///       - Is only one method.
            ///       - The generic repository is too data oriented.
            /// 
            /// </remarks>
            /// <returns></returns>
            public IQueryable<User> All()
            {
                return _data.Values.AsQueryable();
            }

            /// <summary>
            /// Retrieve the user with the given id.
            /// </summary>
            /// <returns>The user account with the id passed as argument.</returns>
            public User FindById(int id)
            {
                return _data.Values.SingleOrDefault(account => Equals(account.Id, id));
            }

            /// <summary>
            /// Retrieve the user with the given email.
            /// </summary>
            /// <param name="email">The email of the user.</param>
            /// <returns></returns>
            public User FindByEmail(string email)
            {
                ContractUtil.NotNull(email);

                return _data.Values.SingleOrDefault(account => Equals(account.EMail, email));
            }

            public User FindByKeyword(string keyword)
            {
                return _data.Values.FirstOrDefault(account => account.Keyword.Equals(keyword));
            }

            /// <summary>
            /// Adds a new user to the current repository.
            /// </summary>
            /// <param name="user">The new user to add.</param>
            public void Add(User user)
            {
                ContractUtil.NotNull(user);
                ContractUtil.IsDefault(user.Id);


                var keyword = Container.Instance.Resolve<IKeyGenerationService>().CreateKey(user); // TODO: Maybe inject dependency through the constructor
                user.Keyword = keyword;

                var key = GetNewKey();
                user.Id = key;
                _data.Add(key, user);
            }

            #endregion
        }

        class MessageRepository : IMessageRepository
        {
            private readonly IDictionary<int, Message> _data;

            public MessageRepository(IDictionary<int, Message> data)
            {
                _data = data;
            }

            #region Implementation of IMessageRepository

            /// <summary>
            /// Retrieve the messages that are sent by a given account: <paramref name="account"/>
            /// </summary>
            /// <param name="account">An account.</param>
            /// <returns>The messages that are sent by <paramref name="account"/></returns>
            public IQueryable<Message> FindMessagesFrom(User account)
            {
                ContractUtil.NotNull(account);

                return _data.Values.Where(message => account.Equals(message.Sender)).AsQueryable();
            }

            /// <summary>
            /// Retrieve the messages that are sent to a given account: <paramref name="account"/>
            /// </summary>
            /// <param name="account">An account.</param>
            /// <returns>The messages that are sent by <paramref name="account"/></returns>
            public IQueryable<Message> FindMessagesTo(User account)
            {
                ContractUtil.NotNull(account);

                return _data.Values.Where(message => account.Equals(message.Reciver)).AsQueryable();
            }

            /// <summary>
            /// Adds a message to the current repository.
            /// </summary>
            /// <param name="message">The message to add.</param>
            public void Add(Message message)
            {
                ContractUtil.NotNull(message);
                ContractUtil.IsDefault(message.Id);

                var key = GetNewKey();
                message.Id = key;
                _data.Add(key, message);
            }

            #endregion
        }

        class NotificationRepository : INotificationRepository
        {
            private readonly IDictionary<int, Notification> _data;

            public NotificationRepository(IDictionary<int, Notification> data)
            {
                _data = data;
            }

            #region Implementation of INotificationRepository

            /// <summary>
            /// Finds the unread notifications for the user <see cref="account"/>
            /// </summary>
            /// <param name="account">The account for which the notifications is looking for.</param>
            /// <returns>All the unread notifications for <see cref="account"/></returns>
            public IQueryable<Notification> FindNotificationsFor(User account)
            {
                return _data.Values.Where(notification => notification.Owner.Equals(account)).AsQueryable();
            }

            /// <summary>
            /// Adds a given notification to the current repository.
            /// </summary>
            /// <param name="notification">The notification to add.</param>
            public void Add(Notification notification)
            {
                ContractUtil.NotNull(notification);
                ContractUtil.IsDefault(notification.Id);

                var id = GetNewKey();
                notification.Id = id;
                _data.Add(id, notification);
            }

            #endregion
        }

        class PostRepository : IPostRepository
        {
            private readonly IDictionary<int, Post> _data;

            public PostRepository(IDictionary<int, Post> data)
            {
                _data = data;
            }

            #region Implementation of IPostRepository

            /// <summary>
            /// Retrieve the posts that were posted by a given account: <paramref name="author"/>
            /// </summary>
            /// <param name="author">An account.</param>
            /// <returns>The posts that were posted by <paramref name="author"/></returns>
            public IQueryable<Post> FindPostsFrom(User author)
            {
                ContractUtil.NotNull(author);

                return _data.Values.Where(message => author.Equals(message.Author)).AsQueryable();
            }

            /// <summary>
            /// Retrieve the posts that were posted to a given account: <paramref name="owner"/>
            /// </summary>
            /// <param name="owner">An account.</param>
            /// <returns>The posts that were poetd to <paramref name="owner"/></returns>
            public IQueryable<Post> FindPostsTo(User owner)
            {
                ContractUtil.NotNull(owner);

                return _data.Values.Where(post => owner.Equals(post.Owner)).AsQueryable();
            }

            public Post FindById(int id)
            {
                return _data.Values.SingleOrDefault(post => post.Id == id);
            }

            /// <summary>
            /// Adds a post to the current repository.
            /// </summary>
            /// <param name="post">The post to add.</param>
            public void Add(Post post)
            {
                ContractUtil.NotNull(post);
                ContractUtil.IsDefault(post.Id);

                var key = GetNewKey();
                post.Id = key;
                _data.Add(key, post);
            }

            #endregion
        }

        class FriendshipRequestRepository : IFriendshipRepository
        {

            private readonly IDictionary<int, FriendshipRequest> _data;

            public FriendshipRequestRepository(IDictionary<int, FriendshipRequest> data)
            {
                _data = data;
            }

            #region Implementation of IFriendshipRepository

            /// <summary>
            /// Retrieve all requests that are sent by a given user.
            /// </summary>
            /// <param name="user">Sender</param>
            /// <returns>All the friendship request that <paramref name="user"/> had sent.</returns>
            public IQueryable<FriendshipRequest> FindSentFrom(User user)
            {
                ContractUtil.NotNull(user);
                return _data.Values.AsQueryable().Where(request => user.Equals(request.Sender));
            }

            /// <summary>
            /// Retrieve all requests that are sent to a given user.
            /// </summary>
            /// <param name="user">Reciver</param>
            /// <returns>All the friendship request that <paramref name="user"/> had receive.</returns>
            public IQueryable<FriendshipRequest> FindSentTo(User user)
            {
                ContractUtil.NotNull(user);

                return _data.Values.AsQueryable().Where(request => user.Equals(request.Reciver));
            }

            /// <summary>
            /// Adds a request to the current repository.
            /// </summary>
            /// <param name="request">A new request.</param>
            public void Add(FriendshipRequest request)
            {
                ContractUtil.NotNull(request);
                ContractUtil.IsDefault(request.Id);

                var key = GetNewKey();
                request.Id = key;
                _data.Add(key, request);
            }

            #endregion
        }

        class FacebookKeyRepository : IFacebookKeyRepository
        {
            
            private readonly IDictionary<int, FacebookKey> _data;

            public FacebookKeyRepository(IDictionary<int, FacebookKey> data)
            {
                _data = data;
            }


            /// <summary>
            /// Retrieve a facebook key representation given the keyword.
            /// </summary>
            /// <param name="key">The keyword to find about.</param>
            /// <returns>The facebook key representation if exist, null otherwise.</returns>
            public FacebookKey Find(string key)
            {
                return _data.Values.SingleOrDefault(k => k.KeyBase.Equals(key));
            }

            public void Add(string key)
            {
                ContractUtil.NotNull(key);

                var fk = new FacebookKey(key);
                var id = GetNewKey();
                fk.Id = id;
                _data.Add(id, fk);
            }
        }

        class ImageRepository : IImageRepository
        {
            private readonly IDictionary<int, Image> _data;

            public ImageRepository(IDictionary<int, Image> data)
            {
                _data = data;
            }

            #region Implementation of IImageRepository

            public Image FindById(int id)
            {
                return _data[id];
            }

            public void Add(Image img)
            {
                int id = GetNewKey();
                img.Id = id;
                _data.Add(id, img);
            }

            #endregion
        }

        #endregion

        private static int GetNewKey()
        {
            return ++_currentKey;
        }

        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }

        #endregion
    }
}
