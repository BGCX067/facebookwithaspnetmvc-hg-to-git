using System;

namespace Facebook.Business.Domain
{
    /// <summary>
    /// Represent the personal information of somebody.
    /// </summary>
    public class PersonalInformation
    {
        #region Fields

        private Gender? _gender;
        private bool? _interestedInMen;
        private bool? _interestedInWomen;
        private bool? _lookingForFrienship;
        private bool? _lookingForRelationship;
        private DateTime? _birthday;
        private string _hometown;
        private string _aboutMe;

        #endregion

        #region Ctor

        protected PersonalInformation()
        {
        }

        public PersonalInformation(Gender? gender = null,
                                bool? interestedInMen = null,
                                bool? interestedInWomen = null,
                                bool? lookingForFrienship = null,
                                bool? lookingForRelationship = null,
                                DateTime? birthday = null,
                                string hometown = null,
                                string aboutMe = null)
        {
            _gender = gender;
            _interestedInMen = interestedInMen;
            _interestedInWomen = interestedInWomen;
            _lookingForFrienship = lookingForFrienship;
            _lookingForRelationship = lookingForRelationship;
            _birthday = birthday;
            _hometown = hometown;
            _aboutMe = aboutMe;
        }


        #endregion

        /// <summary>
        /// Gets or sets the sex information. 
        /// </summary>
        public virtual Gender? Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        /// <summary>
        /// Gets or sets the information about interesting in men.
        /// </summary>
        public virtual bool? InterestedInMen
        {
            get { return _interestedInMen; }
            set { _interestedInMen = value; }
        }

        /// <summary>
        /// Gets or sets the information about interesting in women. 
        /// </summary>
        public virtual bool? InterestedInWomen
        {
            get { return _interestedInWomen; }
            set { _interestedInWomen = value; }
        }

        /// <summary>
        /// Gets or sets the information about looking for friendship.
        /// </summary>
        public virtual bool? LookingForFriendship
        {
            get { return _lookingForFrienship; }
            set { _lookingForFrienship = value; }
        }

        /// <summary>
        /// Gets or sets the information about looking for relationship.
        /// </summary>
        public virtual bool? LookingForRelationship
        {
            get { return _lookingForRelationship; }
            set { _lookingForRelationship = value; }
        }
        
        /// <summary>
        /// Gets or sets the birthday information.
        /// </summary>
        public virtual DateTime? BirthDay
        {
            get { return _birthday; }
            set { _birthday = value; }
        }

        /// <summary>
        /// Gets or sets the hometown information.
        /// </summary>
        public virtual string HomeTown
        {
            get { return _hometown; }
            set { _hometown = value; }
        }

        /// <summary>
        /// Gets or sets the about me information.
        /// </summary>
        public virtual string AboutMe
        {
            get { return _aboutMe; }
            set { _aboutMe = value; }
        }
    }
}