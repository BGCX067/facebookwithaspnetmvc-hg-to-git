using Facebook.Business.Domain.Facade.Posts;
using Facebook.Data;
using Facebook.Infrastructure.Ioc;
using Facebook.Presentation.Web.Controllers;
using Facebook.Presentation.Web.Security;
using Microsoft.Practices.Unity;
using NUnit.Framework;
using System.Web.Mvc;

namespace Facebook.Presentation.Web.Tests.Controllers
{
    [TestFixture]
    public class UserControllerTest
    {
        [Test]
// ReSharper disable InconsistentNaming
        public void Index_WithAuthenticatedUser_ShouldGetTheUser()
// ReSharper restore InconsistentNaming
        {
            //// Arrange
            //var user = ObjectMother.GetUser();
            //TestsHelper.AuthenticateUser(user);
            //var controller = new UserController(Container.Instance.Resolve<IUnitOfWork>(),
            //                                    Container.Instance.Resolve<IUserProvider>(),
            //                                    Container.Instance.Resolve<IPostsManagementService>());

            //// Act
            //var result = controller.Home() as ViewResult;

            //// Assert
            //Assert.IsTrue(result != null && user.Equals(result.Model as User));
        }
    }
}
