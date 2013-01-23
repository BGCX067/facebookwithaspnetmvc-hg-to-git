using System.Collections.Generic;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;
using Facebook.Data;

namespace Facebook.Business.Domain.Facade.Posts
{
    public interface IPostsManagementService
    {
        /// <summary>
        /// Retrieve the posts of a given user.
        /// </summary>
        /// <remarks>
        /// NOTE: that is method don't get owner specific posts.
        /// </remarks>
        /// <param name="user">An user.</param>
        /// <param name="page">The page number.</param>
        /// <param name="count">The posts count.</param>
        /// <returns></returns>
        IList<Post> GetPosts(User user, int page = 1, int count = 10);

        /// <summary>
        /// Retrieve the owner posts of a given user.
        /// </summary>
        /// <param name="user">An user.</param>
        /// <param name="page">The page number.</param>
        /// <param name="count">The posts count.</param>
        /// <returns>The owner post of <paramref name="user"/></returns>
        IList<Post> GetOwnerPosts(User user, int page = 1, int count = 10);

        IUnitOfWork UnitOfWork { get; }
    }
}