using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Facade.Notifications;
using Facebook.Business.Domain.Notifications;
using Facebook.Data;
using Facebook.Presentation.Web.Filters;
using Facebook.Presentation.Web.Security;
using Facebook.Presentation.Web.Utils;
using Facebook.Presentation.Web.ViewModels.Notifications;

namespace Facebook.Presentation.Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly IUserProvider _userProvider;
        private readonly INotificationsManagementService _notificationsManagementService;

        public NotificationsController(INotificationsManagementService notificationsManagementService, IUserProvider userProvider)
        {
            _notificationsManagementService = notificationsManagementService;
            _userProvider = userProvider;
        }

        [HttpGet]
        [AutoMap(typeof(IList<Notification>), typeof(IList<NotificationViewModel>))]
        [MultipleResponseFormats]
        public ActionResult Index(int page, int count)
        {
            var user = _userProvider.GetCurrentUser(_notificationsManagementService.UnitOfWork, HttpContext);
            var notifications = _notificationsManagementService.GetNotifications(user).Paginate(page, count).ToList();

// ReSharper disable Mvc.InvalidModelType
            return View(notifications);
// ReSharper restore Mvc.InvalidModelType
        }

    }
}
