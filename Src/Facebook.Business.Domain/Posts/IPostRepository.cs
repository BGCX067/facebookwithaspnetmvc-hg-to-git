using System.Linq;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Posts
{
    /// <summary>
    /// Defines contracts for a post repository.
    /// </summary>
    public interface IPostRepository
    {
        /// <summary>
        /// Retrieve the posts that were posted by a given AccountBORRAR: <paramref name="author"/>
        /// </summary>
        /// <param name="author">An AccountBORRAR.</param>
        /// <returns>The posts that were posted by <paramref name="author"/></returns>
        IQueryable<Post> FindPostsFrom(User author);

        /// <summary>
        /// Retrieve the posts that were posted to a given AccountBORRAR: <paramref name="owner"/>
        /// </summary>
        /// <param name="owner">An AccountBORRAR.</param>
        /// <returns>The posts that were poetd to <paramref name="owner"/></returns>
        IQueryable<Post> FindPostsTo(User owner);

        Post FindById(int id);

        /// <summary>
        /// Adds a post to the current repository.
        /// </summary>
        /// <param name="post">The post to add.</param>
        void Add(Post post);
    }
}