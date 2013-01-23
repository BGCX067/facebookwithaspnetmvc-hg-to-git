using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Facebook.Business.Domain.Friendship;
using Facebook.Business.Domain.Users;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Data.EntityFramework.Repositories
{
    class FriendshipRequestRepository : Repository<FriendshipRequest>, IFriendshipRepository
    {
        public FriendshipRequestRepository(DbSet<FriendshipRequest> set)
            : base(set)
        {
        }

        #region Implementation of IFriendshipRepository

        /// <summary>
        /// Retrieve all requests that are sent by a given user.
        /// </summary>
        /// <param name="user">Sender</param>
        /// <returns>All the friendship request that <paramref name="user"/> had sent.</returns>
        public IQueryable<FriendshipRequest> FindSentFrom(User user)
        {
            ContractUtil.NotNull(user);

            return Set.Where(request => request.Sender.Id.Equals(user.Id));
        }

        /// <summary>
        /// Retrieve all requests that are sent to a given user.
        /// </summary>
        /// <param name="user">Reciver</param>
        /// <param name="spec">An optional aditional specification. </param>
        /// <returns>All the friendship request that <paramref name="user"/> had receive.</returns>
        public IQueryable<FriendshipRequest> FindSentTo(User user)
        {
            ContractUtil.NotNull(user);

            return Set.Where(request => request.Reciver.Id.Equals(user.Id));
        }

        /// <summary>
        /// Adds a request to the current repository.
        /// </summary>
        /// <param name="request">A new request.</param>
        public void Add(FriendshipRequest request)
        {
            ContractUtil.NotNull(request);
            ContractUtil.IsDefault(request.Id);


            Set.Add(request);
        }

        #endregion


        private static readonly Expression<Func<FriendshipRequest, bool>> Everybody = account => true;
    }
}
