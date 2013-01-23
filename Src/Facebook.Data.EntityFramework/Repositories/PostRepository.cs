using System.Data.Entity;
using System.Linq;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Data.EntityFramework.Repositories
{
    internal class PostRepository : Repository<Post>, IPostRepository
    {
        public PostRepository(DbSet<Post> set)
                : base(set)
        {
        }

        #region Implementation of IPostRepository

        /// <summary>
        /// Retrieve the posts that were posted by a given account: <paramref name="author"/>
        /// </summary>
        /// <param name="author">An account.</param>
        /// <returns>The posts that were posted by <paramref name="author"/></returns>
        public IQueryable<Post> FindPostsFrom(User author)
        {
            ContractUtil.NotNull(author);

            return Set.Where(post => post.Author.Id.Equals(author.Id));
        }

        /// <summary>
        /// Retrieve the posts that were posted to a given account: <paramref name="owner"/>
        /// </summary>
        /// <param name="owner">An account.</param>
        /// <returns>The posts that were poetd to <paramref name="owner"/></returns>
        public IQueryable<Post> FindPostsTo(User owner)
        {
            ContractUtil.NotNull(owner);

            return Set.Where(post => post.Owner.Id.Equals(owner.Id));
        }

        public Post FindById(int id)
        {
            return Set.Find(id);
        }

        /// <summary>
        /// Adds a post to the current repository.
        /// </summary>
        /// <param name="post">The post to add.</param>
        public void Add(Post post)
        {
            ContractUtil.NotNull(post);

            Set.Add(post);
        }

        #endregion
    }
}