using Facebook.Business.Domain.Users;
using Facebook.Infrastructure.Contracts;
using Microsoft.Practices.Unity;
using Facebook.Data;
using Facebook.Infrastructure.Ioc;

namespace Facebook.Presentation.Web.Security
{
    public class FacebookMembershipProvider : IMembershipProvider
    {
        /// <summary>
        /// Validate a given user credentials.
        /// </summary>
        /// <param name="email">The email to validate.</param>
        /// <param name="password">The associated password to validate.</param>
        /// <returns>True if the credentials are validated, False in other case.</returns>
        public bool Validate(string email, string password)
        {
            ContractUtil.NotNull(email);
            ContractUtil.NotNull(password);

            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var user = unitOfWork.Users.FindByEmail(email);
                return !Equals(user, null) && Equals(user.Password, EncryptPassword(password));
            }
        }

        /// <summary>
        /// Register a new user with the given credentials.
        /// </summary>
        /// <param name="firstName">The first name of the user.</param>
        /// <param name="lastName">The last name of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <param name="securityQuestion">The security question of the user.</param>
        /// <param name="securityAnswer">The security answer of the user.</param>
        /// <returns>True if the new user is successfully registred, False in other case.</returns>
        public bool Register(string firstName, 
                             string lastName,
                             string email, 
                             string password,
                             string securityQuestion,
                             string securityAnswer)
        {
            ContractUtil.NotNull(firstName);
            ContractUtil.NotNull(lastName);
            ContractUtil.NotNull(email);
            ContractUtil.NotNull(password);
            ContractUtil.NotNull(securityQuestion);
            ContractUtil.NotNull(securityAnswer);

            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                if (!Equals(unitOfWork.Users.FindByEmail(email), null))
                    return false;

                var newUser = new User(firstName, lastName, email, EncryptPassword(password), securityQuestion, securityAnswer);
                unitOfWork.Users.Add(newUser);
                unitOfWork.Commit();
            }

            return true;
        }

        /// <summary>
        /// Change the current password for a given credentials.
        /// </summary>
        /// <param name="email">The email as user identifier.</param>
        /// <param name="oldPassword">The old password.</param>
        /// <param name="newPassword">The new password.</param>
        /// <returns>True if the password is successfully changed, False in other case.</returns>
        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            ContractUtil.NotNull(email);
            ContractUtil.NotNull(oldPassword);
            ContractUtil.NotNull(newPassword);

            using (var unitOfWork = Container.Instance.Resolve<IUnitOfWork>())
            {
                var user = unitOfWork.Users.FindByEmail(email);

                if (Equals(user, null))
                    return false;

                if (!Equals(user.Password, EncryptPassword(oldPassword)))
                    return false;

                user.Password = EncryptPassword(newPassword);
                unitOfWork.Commit();
            }

            return true;
        }

        #region Helpers methods

        private string EncryptPassword(string password)
        {
            // TODO: encrypt is not performing ...
            return password;
        }

        #endregion
    }
}