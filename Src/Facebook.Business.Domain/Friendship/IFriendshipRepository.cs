using System;
using System.Linq;
using System.Linq.Expressions;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Friendship
{
    /// <summary>
    /// Define contracts for a repository of friendship requests.
    /// </summary>
    public interface IFriendshipRepository
    {
        /// <summary>
        /// Retrieve all requests that are sent by a given user.
        /// </summary>
        /// <param name="user">Sender</param>
        /// <returns>All the friendship request that <paramref name="user"/> had sent.</returns>
        IQueryable<FriendshipRequest> FindSentFrom(User user);

        /// <summary>
        /// Retrieve all requests that are sent to a given user.
        /// </summary>
        /// <param name="user">Reciver</param>
        /// <returns>All the friendship request that <paramref name="user"/> had receive.</returns>
        IQueryable<FriendshipRequest> FindSentTo(User user);

        /// <summary>
        /// Adds a request to the current repository.
        /// </summary>
        /// <param name="request">A new request.</param>
        void Add(FriendshipRequest request);
    }
}