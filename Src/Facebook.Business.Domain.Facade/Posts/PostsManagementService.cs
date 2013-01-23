using Facebook.Business.Domain.Users;
using Microsoft.Practices.Unity;
using System.Collections.Generic;
using System.Linq;
using Facebook.Business.Domain.Posts;
using Facebook.Data;
using Facebook.Infrastructure.Contracts;
using Facebook.Infrastructure.Ioc;

namespace Facebook.Business.Domain.Facade.Posts
{
    public class PostsManagementService : IPostsManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostsManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// Retrieve the posts that will be show to a given user.
        /// </summary>
        /// <param name="user">An user.</param>
        /// <param name="page">The page number.</param>
        /// <param name="count">The posts count.</param>
        /// <returns></returns>
        public IList<Post> GetPosts(User user, int page = 1, int count = 10)
        {
            ContractUtil.NotNull(user);
            ContractUtil.IsInRange(page, 1);
            ContractUtil.IsInRange(count, 1);

            var postRepository = _unitOfWork.Posts;

            return user.Friends.SelectMany(postRepository.FindPostsTo)
                .Where(post => post.IsPersonal)
                .Concat(postRepository.FindPostsTo(user))
                .OrderByDescending(post => post.Date)
                .Paginate(page, count)
                .ToList();
        }

        /// <summary>
        /// Retrieve the owner posts that will be show to a given user.
        /// </summary>
        /// <param name="user">An user.</param>
        /// <param name="page">The page number.</param>
        /// <param name="count">The posts count.</param>
        /// <returns></returns>
        public IList<Post> GetOwnerPosts(User user, int page = 1, int count = 10)
        {
            ContractUtil.NotNull(user);

            var postRepository = _unitOfWork.Posts;

            return postRepository.FindPostsTo(user)
                .OrderByDescending(post => post.Date)
                .Paginate(page, count)
                .ToList();
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
    }
}