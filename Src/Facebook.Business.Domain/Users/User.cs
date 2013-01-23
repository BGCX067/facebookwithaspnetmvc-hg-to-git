using System;
using System.Collections.Generic;
using Facebook.Business.Domain.Images;

namespace Facebook.Business.Domain.Users
{
    /// <summary>
    /// Represent an user account that is a human.
    /// </summary>
    public class User : Entity<User> 
    {
        #region Fields


        private string _firstName;
        private string _lastName;
        private string _email;
        private string _password;
        private string _securityQuestion;
        private string _securityAnswer;
        private string _keyword;
        private UserProfile _userProfile;
        private ICollection<User> _friends;
        private Image _photo;
        
        #endregion

        #region Ctors

        public User()
        {
        }

        public User(string firstName,
                    string lastName,
                    string email,
                    string password,
                    string securityQuestion,
                    string securityAnswer,
                    UserProfile userProfile = null)
        {
            _firstName = firstName;
            _lastName = lastName;
            _email = email;
            _password = password;
            _securityQuestion = securityQuestion;
            _securityAnswer = securityAnswer;
            _keyword = null;
            _userProfile = userProfile ?? new UserProfile();
            _friends = new HashSet<User>();
            _photo = Image.NoImage;
        }

        
        #endregion

        /// <summary>
        /// Gets or sets the first name of the current user.
        /// </summary>
        public virtual string FirstName
        {
            get { return _firstName; } 
            set { _firstName = value; }
        }

        /// <summary>
        /// Gets or sets the last name of the current user.
        /// </summary>
        public virtual string LastName
        {
            get { return _lastName; } 
            set { _lastName = value; }
        }

        /// <summary>
        /// A valid email to verify the user.
        /// </summary>
        public virtual string EMail
        {
            get { return _email; } 
            set { _email = value; }
        }

        public virtual string Keyword
        {
            get { return _keyword; }
            set { _keyword = value; }
        }

        /// <summary>
        /// The password for the user.
        /// </summary>
        public virtual string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        /// <summary>
        /// A security question to verify the user in case of forgot password.
        /// </summary>
        public virtual string SecurityQuestion
        {
            get { return _securityQuestion; }
            set { _securityQuestion = value; }
        }

        /// <summary>
        /// A security answer to verify the user in case of forgot password.
        /// </summary>
        public virtual string SecurityAnswer
        {
            get { return _securityAnswer; } 
            set { _securityAnswer = value; }
        }

        /// <summary>
        /// Gets or sets the profile of the current user.
        /// </summary>
        public virtual UserProfile Profile
        {
            get { return _userProfile; }
            protected set { _userProfile = value; }
        }

        /// <summary>
        /// Gets or sets the friends of the current user.
        /// 
        /// </summary>
        /// <remarks>
        /// TODO: Make this field readonly, the ideal have to look like ...
        /// <code>
        /// public virtual IReadOnlyList Friends { get; protected set; }
        /// </code>
        /// </remarks>
        public virtual ICollection<User> Friends
        {
            get { return _friends; }
            protected set { _friends = value; }
        }

        /// <summary>
        /// Adds an user account as a friend.
        /// <remarks>Also visible to app layer.</remarks>
        /// </summary>
        /// <param name="other"></param>
        internal void AddFriend(User other)
        {
            if (Friends.Contains(other))
                throw new InvalidOperationException("This user already contains the other one as a friend.");

            Friends.Add(other);
        }

        public virtual Image Photo
        {
            get
            {
                return _photo;
            } 
            protected set
            {
                _photo = value;
            }
        }

        public virtual void SetPhoto(Image img)
        {
            _photo = img;
        }
    }
}