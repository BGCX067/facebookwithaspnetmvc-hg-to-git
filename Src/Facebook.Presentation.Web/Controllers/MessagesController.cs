using System.Collections.Generic;
using System.Linq;
using Facebook.Business.Domain;
using System.Web.Mvc;
using Facebook.Business.Domain.Facade.Messages;
using Facebook.Business.Domain.Messages;
using Facebook.Data;
using Facebook.Presentation.Web.Filters;
using Facebook.Presentation.Web.Security;
using Facebook.Presentation.Web.Utils;
using Facebook.Presentation.Web.ViewModels.Messages;
using Facebook.Presentation.Web.ViewModels.User;

namespace Facebook.Presentation.Web.Controllers
{
    public class MessagesController : Controller
    {
        private readonly IUserProvider _userProvider;
        private readonly IMessagesManagementService _messagesManagementService;

        public MessagesController(IMessagesManagementService messagesManagementService, IUserProvider userProvider)
        {
            _messagesManagementService = messagesManagementService;
            _userProvider = userProvider;
        }

        [AutoMap(typeof(IList<Message>), typeof(IList<MessageViewModel>))]
        [MultipleResponseFormats]
        public ActionResult Index(int page, int count)
        {
            var user = _userProvider.GetCurrentUser(_messagesManagementService.UnitOfWork, HttpContext);
            var messages = _messagesManagementService.GetMessages(user).Paginate(page, count).ToList();

// ReSharper disable Mvc.InvalidModelType
// Reason a mapping will be performd later ...
            return View(messages);
// ReSharper restore Mvc.InvalidModelType
        }

    }
}
