using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Facade.Friendship;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Presentation.Web.Filters;
using Facebook.Presentation.Web.Security;
using Facebook.Presentation.Web.Utils;
using Facebook.Presentation.Web.ViewModels.User;

namespace Facebook.Presentation.Web.Controllers
{
    //[Authorize]
    public class UserController : Controller
    {
        private readonly IUserProvider _userProvider;
        private readonly IFriendshipManagementService _friendshipManagementService;

        public UserController(IUserProvider userProvider, 
                              IFriendshipManagementService friendshipManagementService)
        {
            _userProvider = userProvider;
            _friendshipManagementService = friendshipManagementService;
        }

        [HttpGet]
        [AutoMap(typeof(User), typeof(UserViewModel))]
        public ActionResult Home()
        {
            var user = _userProvider.GetCurrentUser(_friendshipManagementService.UnitOfWork, HttpContext);

// ReSharper disable Mvc.InvalidModelType
// Reasons: later mapping is performed ...
            return View(user);
// ReSharper restore Mvc.InvalidModelType
        }

        [AutoMap(typeof(object), typeof(UserViewModel))]
        public ActionResult Index(string keyword, int page = 1, int count = 10)
        {
            var user = _friendshipManagementService.UnitOfWork.Users.FindByKeyword(keyword);

            if (Equals(user, null))
                throw new InvalidOperationException(string.Format("No user exists with the current keyword: {0}", keyword));

            var status = _friendshipManagementService.GetFriendshipStatus(_userProvider.GetCurrentUser(_friendshipManagementService.UnitOfWork, HttpContext), user);
// ReSharper disable Mvc.InvalidModelType
            return View(new { User = user, FriendshipStatus = status });
// ReSharper restore Mvc.InvalidModelType
        }

        [HttpGet]
        [AutoMap(typeof(User), typeof(UserProfileViewModel))]
        public new ActionResult Profile()
        {
            var user = _userProvider.GetCurrentUser(_friendshipManagementService.UnitOfWork, HttpContext);

// ReSharper disable Mvc.InvalidModelType
// Reasons: later mapping is performed ...
            return View(user);
// ReSharper restore Mvc.InvalidModelType
        }

        [HttpPost]
        public new ActionResult Profile(UserProfileViewModel profile)
        {
            if (!ModelState.IsValid)
                return View(profile);

            var user = _userProvider.GetCurrentUser(_friendshipManagementService.UnitOfWork, HttpContext);
            profile.Update(user);
            _friendshipManagementService.UnitOfWork.Commit();
   
            return RedirectToAction("Home");
        }

        [AutoMap(typeof(IList<dynamic>), typeof(IList<UserViewModel>))]
        public ActionResult FindFriends(int page = 1, int count = 10)
        {
            var user = _userProvider.GetCurrentUser(_friendshipManagementService.UnitOfWork, HttpContext);
            var items = _friendshipManagementService.GetResquestsTo(user)
                                                    .Concat( _friendshipManagementService.GetPossiblesFriends(user))
                                                    .Paginate(page, count)
                                                    .Select(other => new  { User = other, FriendshipStatus = _friendshipManagementService.GetFriendshipStatus(user, other) })
                                                    .ToList();
          
// ReSharper disable Mvc.InvalidModelType
            return PartialView(items);
// ReSharper restore Mvc.InvalidModelType
        }
        
        public ActionResult AddFriend(int userId)
        {
            var other = _friendshipManagementService.UnitOfWork.Users.FindById(userId);
            _friendshipManagementService.SendRequest(_userProvider.GetCurrentUser(_friendshipManagementService.UnitOfWork, HttpContext), other);

            return null;
        }

        public ActionResult AcceptFriend(int userId)
        {
            var other = _friendshipManagementService.UnitOfWork.Users.FindById(userId);
            _friendshipManagementService.AcceptRequest(other, _userProvider.GetCurrentUser(_friendshipManagementService.UnitOfWork, HttpContext));

            return null;
        }
    }
}
