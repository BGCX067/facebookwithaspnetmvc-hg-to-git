using System.Web;

namespace Facebook.Presentation.Web.Security
{
    public interface IUserProvider
    {
        string GetCurrentUserEmail(HttpContextBase context);
    }
}