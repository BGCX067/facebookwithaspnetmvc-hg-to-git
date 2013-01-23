namespace Facebook.Presentation.Web.Security
{
    public interface IMembershipProvider
    {
        /// <summary>
        /// Validate a given user email <paramref name="email"/> with the password associated <paramref name="password"/>. 
        /// </summary>
        /// <param name="email">The email of the current user.</param>
        /// <param name="password">The password of the current user.</param>
        /// <returns>True if the user is validate, false in other case.</returns>
        bool Validate(string email, string password);

        /// <summary>
        /// Register a new user in the system.
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="securityQuestion"></param>
        /// <param name="securityAnswer"></param>
        /// <returns></returns>
        bool Register(string firstName, 
                      string lastName,
                      string email, 
                      string password,
                      string securityQuestion,
                      string securityAnswer);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="oldPassword"></param>
        /// <param name="newPassword"></param>
        /// <returns></returns>
        bool ChangePassword(string email, string oldPassword, string newPassword);
    }
}