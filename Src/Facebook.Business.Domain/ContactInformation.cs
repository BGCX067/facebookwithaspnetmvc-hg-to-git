namespace Facebook.Business.Domain
{
    /// <summary>
    /// Represent the information for contact somebody.
    /// </summary>
    public class ContactInformation
    {
        #region Fields

        private string _email;
        private bool? _emailOnlyForFriends;
        private int? _mobileNumber;
        private bool? _mobileNumberOnlyForFriends;
        private Address _address;
        private bool? _addressOnlyForFriends;

     

        #endregion

        #region Ctor

        protected ContactInformation()
        {
        }

        public ContactInformation(string email = null,
                                  bool? emailOnlyForFriends = null,
                                  int? mobileNumber = null,
                                  bool? mobileNumberOnlyForFriends = null,
                                  Address address = null,
                                  bool? addressOnlyForFriends = null)
        {
            _email = email;
            _emailOnlyForFriends = emailOnlyForFriends;
            _mobileNumber = mobileNumber;
            _mobileNumberOnlyForFriends = mobileNumberOnlyForFriends;
            _address = address ?? new Address();
            _addressOnlyForFriends = addressOnlyForFriends;
        }


        #endregion

        /// <summary>
        /// Gets or sets the email information.
        /// </summary>
        public virtual string EMail
        {
            get { return _email; }
            set { _email = value; }
        }

        /// <summary>
        /// Gets or sets the information about if the email is public only for friends.
        /// </summary>
        public virtual bool? EMailOnlyForFriends
        {
            get { return _emailOnlyForFriends; }
            set { _emailOnlyForFriends = value; }
        }

        /// <summary>
        /// Gets or sets the phone number information.
        /// </summary>
        public virtual int? MobileNumber
        {
            get { return _mobileNumber; }
            set { _mobileNumber = value; }
        }

        /// <summary>
        /// Gets or sets the information about if the phone number is public only for friends.
        /// </summary>
        public virtual bool? MobileNumberOnlyForFriends
        {
            get { return _mobileNumberOnlyForFriends; }
            set { _mobileNumberOnlyForFriends = value; }
        }

        /// <summary>
        /// Gets or sets the address information.
        /// </summary>
        public virtual Address Address
        {
            get { return _address; }
            set { _address = value; }
        }

        /// <summary>
        /// Gets or sets the information about if the address is public only for friends.
        /// </summary>
        public virtual bool? AddressOnlyForFriends
        {
            get { return _addressOnlyForFriends; }
            set { _addressOnlyForFriends = value; }
        }
    }
}