using System.Data.Entity;
using System.Linq;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Facade.Internals;
using Facebook.Business.Domain.Users;
using Facebook.Infrastructure.Contracts;
using Facebook.Infrastructure.Ioc;
using Microsoft.Practices.Unity;

namespace Facebook.Data.EntityFramework.Repositories
{
    class UserAccountRepository : Repository<User>, IUserAccountRepository
    {
        public UserAccountRepository(DbSet<User> set)
                : base(set)
        {
        }

        #region Implementation of IUserAccountRepository

        /// <summary>
        /// Retrieve all users in the current repository that match with a given specification..
        /// </summary>
        /// <returns></returns>
        public IQueryable<User> All()
        {
            return Set;
        }

        /// <summary>
        /// Retrieve the user with the given id.
        /// </summary>
        /// <returns>The user AccountBORRAR with the id passed as argument.</returns>
        public User FindById(int id)
        {
            return Set.SingleOrDefault(account => id.Equals(account.Id));
        }

        /// <summary>
        /// Retrieve the user with the given email.
        /// </summary>
        /// <param name="email">The email of the user.</param>
        /// <returns></returns>
        public User FindByEmail(string email)
        {
            ContractUtil.NotNull(email);

            return Set.SingleOrDefault(account => email.Equals(account.EMail));
        }

        public User FindByKeyword(string keyword)
        {
            ContractUtil.NotNull(keyword);

            return Set.SingleOrDefault(account => keyword.Equals(account.Keyword));
        }

        /// <summary>
        /// Adds a new user to the current repository.
        /// </summary>
        /// <param name="user">The new user to add.</param>
        public void Add(User user)
        {
            ContractUtil.NotNull(user);

            var key = Container.Instance.Resolve<IKeyGenerationService>().CreateKey(user); // TODO: Maybe inject dependency through the constructor
            user.Keyword = key;

            Set.Add(user);
        }

        #endregion

        
    }
}