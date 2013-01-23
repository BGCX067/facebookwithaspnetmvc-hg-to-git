using System;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Messages
{
    /// <summary>
    /// This class represent a message (for example a post in the walk) from an AccountBORRAR to another.
    /// </summary>
    public class Message : Entity<Message>
    {
        #region Fields

        private User _sender;
        private User _reciver;
        private DateTime _date;
        private string _text;

        #endregion

        #region Ctors

        protected Message()
        {
        }

        public Message(User sender,
                       User reciver,
                       string text,
                       DateTime date)
        {
            _sender = sender;
            _reciver = reciver;
            _text = text;
            _date = date;
        }

        #endregion

        /// <summary>
        /// Gets or sets the user that writes and sends the current message.
        /// </summary>
        public virtual User Sender
        {
            get { return _sender; }
            protected set { _sender = value; }
        }

        /// <summary>
        /// Gets or sets the datetime of the current message.
        /// </summary>
        public virtual DateTime Date
        {
            get { return _date; }
            protected set { _date = value; }
        }

        /// <summary>
        /// Gets or sets the text of the current message.
        /// </summary>
        public virtual string Text
        {
            get { return _text; }
            protected set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the user that receives the current message.
        /// </summary>
        public virtual User Reciver
        {
            get { return _reciver; }
            protected set { _reciver = value; }
        }
    }
}