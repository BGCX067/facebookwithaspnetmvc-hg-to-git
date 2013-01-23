using System.Web;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Data.InMemory;
using Facebook.Infrastructure.Ioc;
using Facebook.Presentation.Web.Security;
using Microsoft.Practices.Unity;
using Moq;

namespace Facebook.Presentation.Web.Tests
{
    public static class TestsHelper
    {
         public static void AuthenticateUser(User user)
         {
             var userProvider = new Mock<IUserProvider>();
             userProvider.Setup(provider => provider.GetCurrentUserEmail(It.IsAny<HttpContextBase>()))
                         .Returns(user.EMail);
             Container.Instance.RegisterInstance<IUserProvider>(userProvider.Object);

             var unitOfWork = new InMemoryUnitOfWork();
             unitOfWork.Users.Add(user);
             Container.Instance.RegisterInstance<IUnitOfWork>(unitOfWork);

             var membershipProvider = new Mock<IMembershipProvider>();
             membershipProvider.Setup(provider => provider.Validate(user.EMail, user.Password)).Returns(true);
             Container.Instance.RegisterInstance<IMembershipProvider>(membershipProvider.Object);

             var webSecurity = new Mock<IWebSecurity>();
             Container.Instance.RegisterInstance<IWebSecurity>(webSecurity.Object);
         }
    }
}