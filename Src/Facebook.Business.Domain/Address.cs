namespace Facebook.Business.Domain
{
    /// <summary>
    /// Represent an address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Gets or sets the current address.
        /// </summary>
        public string AddressInfo { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public virtual string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        public virtual string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        public virtual string Country { get; set; }
    }
}