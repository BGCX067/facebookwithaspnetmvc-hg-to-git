using System;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain
{
    /// <summary>
    /// The class represent a simple comment.
    /// </summary>
    public class Comment : Entity<Comment>
    {
        #region Fields

        private User _author;
        private string _text;
        private DateTime _date;

        #endregion

        #region Ctors

        protected Comment()
        {
        }

        public Comment(User author,
                       string text,
                       DateTime date)
        {
            _author = author;
            _text = text;
            _date = date;
        }

        #endregion

        /// <summary>
        /// Gets or sets the author of the current comment.
        /// </summary>
        public virtual User Author
        {
            get { return _author; }
            protected set { _author = value; }
        }

        /// <summary>
        /// Gets or sets the text of the current comment.
        /// </summary>
        public virtual string Text
        {
            get { return _text; }
            protected set { _text = value; }
        }

        /// <summary>
        /// Gets or sets the datetime of the current comment.
        /// </summary>
        public virtual DateTime Date
        {
            get { return _date; }
            protected set { _date = value; }
        }
    }
}