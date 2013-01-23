using System;
using System.Collections.Generic;
using Facebook.Business.Domain.Images;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Posts
{
    /// <summary>
    /// This class defines a post.
    /// </summary>
    public class Post : Entity<Post>, ICommentable
    {
        #region Fields

        private User _author;
        private User _owner;
        private DateTime _date;
        private string _text;
        private Image _image;
        private IList<Comment> _comments; 

        #endregion

        #region Ctors
        
        protected Post()
        {
        }

        public Post(User author,
                    User owner,
                    DateTime date,
                    string text)
        {
            _author = author;
            _owner = owner;
            _date = date;
            _text = text;
            _comments = new List<Comment>(100);
        }

        #endregion

        /// <summary>
        /// Gets or sets the account that writes and sends the current post.
        /// </summary>
        public virtual User Author
        {
            get { return _author; }
            protected set { _author = value; }
        }

        /// <summary>
        /// Gets or sets the datetime of the current post.
        /// </summary>
        public virtual DateTime Date
        {
            get { return _date; }
            protected set { _date = value; }
        }

        /// <summary>
        /// Gets or sets the text of the current post.
        /// </summary>
        public virtual string Text
        {
            get { return _text; }
            protected set { _text = value; }
        }

        public virtual Image Image
        {
            get { return _image; }
            protected set { _image = value; }
        }

        /// <summary>
        /// Gets or sets the user that receives the current post.
        /// </summary>
        public virtual User Owner
        {
            get { return _owner; }
            protected set { _owner = value; }
        }

        /// <summary>
        /// Gets or sets the comments for the current post.
        /// </summary>
        public virtual IList<Comment> Comments
        {
            get { return _comments; }
            protected set { _comments = value; }
        }



        #region Implementation of ICommentable

        IEnumerable<Comment> ICommentable.Comments { get { return Comments; } }

        public void AddComment(Comment comment)
        {
            Comments.Add(comment);
        }

        #endregion

        /// <summary>
        /// A post is considered personal when a user writes it in his own walk.
        /// </summary>
        public bool IsPersonal 
        {
            get { return Author.Equals(Owner); }
        }
    }
}