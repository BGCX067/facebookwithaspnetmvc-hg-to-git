using System.Web.Security;

namespace Facebook.Presentation.Web.Security
{
    /// <summary>
    /// This class integrate us with the asp net security plumbing.
    /// </summary>
    public class FacebookWebSecurity : IWebSecurity
    {
        #region Implementation of IWebSecurity

        /// <summary>
        /// Loging the user with the respective email.
        /// </summary>
        /// <param name="email">The email as user id.</param>
        public void Login(string email)
        {
            FormsAuthentication.SetAuthCookie(email, true);
        }

        /// <summary>
        /// Logout the user.
        /// </summary>
        public void Logout()
        {
            FormsAuthentication.SignOut();
        }

        #endregion
    }
}