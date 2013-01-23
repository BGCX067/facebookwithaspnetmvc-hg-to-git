namespace Facebook.Presentation.Web.Security
{
    /// <summary>
    /// This interface introduce some abstraction over all asp plumbing, very usefull for unit testing reasons.
    /// </summary>
    public interface IWebSecurity
    {
        /// <summary>
        /// Loging the user with the respective email.
        /// </summary>
        /// <param name="email">The email as user id.</param>
        void Login(string email);

        /// <summary>
        /// Logout the user.
        /// </summary>
        void Logout();
    }
}