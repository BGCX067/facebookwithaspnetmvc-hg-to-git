using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Facade.Internals
{
    public interface IKeyGenerationService
    {
        string CreateKey(User user);
    }
}