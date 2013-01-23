using System;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Friendship
{
    /// <summary>
    /// This class defines a friendship request.
    /// </summary>
    public class FriendshipRequest : Entity<FriendshipRequest>
    {
        #region Fields


        private User _sender;
        private User _reciver;
        private DateTime _date;
        private FriendshipRequestState _state;

        
        #endregion

        #region Ctor

        protected FriendshipRequest()
        {
        }

        public FriendshipRequest(User sender,
                                 User reciver,
                                 DateTime date)
        {
            _sender = sender;
            _reciver = reciver;
            _date = date;
            _state = FriendshipRequestState.Unread;
        }
        
        #endregion

        /// <summary>
        /// Get or sets the user that sends the current request.
        /// </summary>
        public virtual User Sender
        {
            get { return _sender; }
            protected set { _sender = value; }
        }

        /// <summary>
        /// Gets or sets the user that recives the current request.
        /// </summary>
        public virtual User Reciver
        {
            get { return _reciver; }
            protected set { _reciver = value; }
        }

        /// <summary>
        /// Gets or sets when was sent the current request.
        /// </summary>
        public virtual DateTime Date
        {
            get { return _date; }
            protected set { _date = value; }
        }

        /// <summary>
        /// Get or sets if the current request was attended.
        /// </summary>
        public virtual FriendshipRequestState State
        {
            get { return _state; } 
            set { _state = value; }
        }
    }
}
