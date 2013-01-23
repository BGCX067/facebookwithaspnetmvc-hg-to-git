using System.Data.Entity;
using System.Linq;
using Facebook.Business.Domain.Internals;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Data.EntityFramework.Repositories
{
    class FacebookKeyRepository : Repository<FacebookKey>, IFacebookKeyRepository
    {
        public FacebookKeyRepository(DbSet<FacebookKey> set) 
            : base(set)
        {
        }

        /// <summary>
        /// Retrieve a facebook key representation given the keyword.
        /// </summary>
        /// <param name="key">The keyword to find about.</param>
        /// <returns>The facebook key representation if exist, null otherwise.</returns>
        public FacebookKey Find(string key)
        {
            return Set.SingleOrDefault(k => k.KeyBase.Equals(key));
        }

        public void Add(string key)
        {
            ContractUtil.NotNull(key);

            var newKey = new FacebookKey(key);
            Set.Add(newKey);
        }
    }
}