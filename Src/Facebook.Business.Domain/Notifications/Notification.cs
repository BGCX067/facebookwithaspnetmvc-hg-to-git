using System;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Notifications
{
    /// <summary>
    /// This class represent a notification.
    /// </summary>
    public class Notification : Entity<Notification>
    {
        #region Fields

        private User _owner;
        private string _text;
        private DateTime _date;
        private bool _isRead;

        #endregion

        #region Ctors
        
        protected Notification()
        {
        }

        public Notification(User owner,
                            string text,
                            DateTime date)
        {
            _owner = owner;
            _text = text;
            _date = date;
            _isRead = false;
        }

        #endregion



        /// <summary>
        /// Gets or sets the user that who the notification is for.
        /// </summary>
        public virtual User Owner
        {
            get { return _owner; }
            protected set { _owner = value; }
        }

        /// <summary>
        /// Gets or sets the text of the notification.
        /// </summary>
        public virtual string Text
        {
            get { return _text; }
            protected set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the date of the notification.
        /// </summary>
        public virtual DateTime Date
        {
            get { return _date; }
            protected set { _date = value; }
        }

        /// <summary>
        /// Gets or sets if the notification is unread.
        /// </summary>
        public virtual bool IsRead
        {
            get { return _isRead; }
            set { _isRead = value; }
        }
    }
}