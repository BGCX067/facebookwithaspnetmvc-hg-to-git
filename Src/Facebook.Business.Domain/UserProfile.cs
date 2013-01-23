namespace Facebook.Business.Domain
{
    /// <summary>
    /// Represent a profile of a human.
    /// </summary>
    public class UserProfile
    {
        #region Fields

        private PersonalInformation _personalInformation;
        private ContactInformation _contactInformation;

        #endregion

        #region Ctors
        
        protected UserProfile()
        {
        }

        public UserProfile(PersonalInformation personalInformation = null, ContactInformation contactInformation = null)
        {
            _personalInformation = personalInformation ?? new PersonalInformation();
            _contactInformation = contactInformation ?? new ContactInformation();
        }

        #endregion


        /// <summary>
        /// Gets the current profile status.
        /// </summary>
        public virtual double ProfileStatus { get; private set; }

        /// <summary>
        /// Gets or sets the basic personal information.
        /// </summary>
        public virtual PersonalInformation PersonalInformation
        {
            get { return _personalInformation; }
            set { _personalInformation = value; }
        }

        /// <summary>
        /// Gets or sets the contact information.
        /// </summary>
        public virtual ContactInformation ContactInformation
        {
            get { return _contactInformation; }
            set { _contactInformation = value; }
        }
    }
}