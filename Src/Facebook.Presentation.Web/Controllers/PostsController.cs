using System.Web.Mvc;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Facade;
using Facebook.Business.Domain.Facade.Posts;
using Facebook.Business.Domain.Posts;
using Facebook.Data;
using Facebook.Presentation.Web.Filters;
using Facebook.Presentation.Web.Security;
using Facebook.Presentation.Web.Utils;
using Facebook.Presentation.Web.ViewModels;
using Facebook.Presentation.Web.ViewModels.Posts;

namespace Facebook.Presentation.Web.Controllers
{
    public class PostsController : Controller
    {
        private readonly IUserProvider _userProvider;
        private readonly IPostsManagementService _postsManagementService;

        public PostsController(IPostsManagementService postsManagementService, IUserProvider userProvider)
        {
            _postsManagementService = postsManagementService;
            _userProvider = userProvider;
        }


        [MultipleResponseFormats]
        [AutoMap(typeof(object), typeof(PostCollectionViewModel))]
        public ActionResult Index(int page, int count)
        {
            var user = _userProvider.GetCurrentUser(_postsManagementService.UnitOfWork, HttpContext);
            var posts = _postsManagementService.GetPosts(user, page, count);

// ReSharper disable Mvc.InvalidModelType
// Reason a mapping will be permormed
            return PartialView(new { Posts = posts, OwnerId = user.Id, Page = page, Count = count });
// ReSharper restore Mvc.InvalidModelType
        }

        //[MultipleResponseFormats]
        [AutoMap(typeof(object), typeof(PostCollectionViewModel))]       
        public ActionResult GetPosts(int userId, int page, int count)
        {
            var user = _postsManagementService.UnitOfWork.Users.FindById(userId);
            var posts = _postsManagementService.GetOwnerPosts(user, page, count);

// ReSharper disable Mvc.InvalidModelType
            return PartialView("Index", new { Posts = posts, OwnerId = user.Id, Page = page, Count = count });
// ReSharper restore Mvc.InvalidModelType
        }

        [AutoMap(typeof(Post), typeof(PostViewModel))]
        public ActionResult Create(PostCreationViewModel creation)
        {
            // TODO: remove this fake data ...
            //string text = "Fake post text, Remember remove when ajax works !";

            var owner = _postsManagementService.UnitOfWork.Users.FindById(creation.OwnerId);
            var post = new Post(_userProvider.GetCurrentUser(_postsManagementService.UnitOfWork, HttpContext), 
                                owner,
                                DependencyResolver.Current.GetService<IDateTimeService>().Now(), 
                                creation.Text);

            _postsManagementService.UnitOfWork.Posts.Add(post);
            _postsManagementService.UnitOfWork.Commit();

         
// ReSharper disable Mvc.InvalidModelType
            return PartialView("_PostPartial", post);
// ReSharper restore Mvc.InvalidModelType
        }

        [AutoMap(typeof(Comment), typeof(CommentViewModel))]
        public ActionResult Comment(int ownerId, string text)
        {
            var user = _userProvider.GetCurrentUser(_postsManagementService.UnitOfWork, HttpContext);
            var comment = new Comment(user, text, DependencyResolver.Current.GetService<IDateTimeService>().Now());

            var post = _postsManagementService.UnitOfWork.Posts.FindById(ownerId);
            post.AddComment(comment);

            _postsManagementService.UnitOfWork.Commit();

// ReSharper disable Mvc.InvalidModelType
            return PartialView("_CommentPartial", comment);
// ReSharper restore Mvc.InvalidModelType
        }
    }
}
