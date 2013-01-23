using System.Linq;

namespace Facebook.Business.Domain.Users
{
    /// <summary>
    /// This interface defines contracts for a repository of user AccountBORRAR entities.
    /// </summary>
    public interface IUserAccountRepository
    {
        /// <summary>
        /// Retrieve all users in the current repository that match with a given specification..
        /// </summary>
        /// <remarks>
        /// NOTE: We choose add this method to all repositories definition insted of to add a generic repository definition in the bussines layer for the following reasons:
        ///       - Is only one method.
        ///       - The generic repository is too data oriented.
        /// 
        /// </remarks>
        /// <returns></returns>
        IQueryable<User> All();

        /// <summary>
        /// Retrieve the user with the given id.
        /// </summary>
        /// <returns>The user Account with the id passed as argument.</returns>
        User FindById(int id);

        /// <summary>
        /// Retrieve the user with the given email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns></returns>
        User FindByEmail(string email);

        /// <summary>
        /// Retrieve the user with the keyword specified.
        /// </summary>
        /// <param name="keyword">The keyword that was assigned to the user.</param>
        /// <returns></returns>
        User FindByKeyword(string keyword);

        /// <summary>
        /// Adds a new user to the current repository.
        /// </summary>
        /// <param name="user">The new user to add.</param>
        void Add(User user);
    }
}