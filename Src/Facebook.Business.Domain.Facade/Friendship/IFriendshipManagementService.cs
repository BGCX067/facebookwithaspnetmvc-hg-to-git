using System.Collections;
using System.Collections.Generic;
using Facebook.Business.Domain.Users;
using Facebook.Data;

namespace Facebook.Business.Domain.Facade.Friendship
{
    /// <summary>
    /// This contract provide services to manage facebook friendship.
    /// </summary>
    /// <remarks>
    /// NOTE:
    /// That in this class services take efect a pipeline of actions, calls to repositories, saving changes ... that from my point of view are not suitable implement
    /// inside of the User class.
    /// </remarks>
    public interface IFriendshipManagementService
    {
        /// <summary>
        /// Send a friendship request from an user to another one.
        /// </summary>
        /// <param name="sender">The user that sends the request.</param>
        /// <param name="reciver">The user that receives the request.</param>
        void SendRequest(User sender, User reciver);

        /// <summary>
        /// Accept a friendship request sent to an user by another one.
        /// </summary>
        /// <param name="sender">The user that sends the request.</param>
        /// <param name="reciver">The user that receives the request and optionaly accept it.</param>
        void AcceptRequest(User sender, User reciver);

        /// <summary>
        /// Find friends to a given user.
        /// </summary>
        /// <param name="user">An user.</param>
        /// <returns>possibles friends for <paramref name="user"/></returns>
        IEnumerable<User> GetPossiblesFriends(User user);

        IEnumerable<User> GetResquestsTo(User user);

        FriendshipStatus GetFriendshipStatus(User a, User b);


        IUnitOfWork UnitOfWork { get; }
    }
}