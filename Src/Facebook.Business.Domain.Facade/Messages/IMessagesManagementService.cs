using System.Collections.Generic;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Users;
using Facebook.Data;

namespace Facebook.Business.Domain.Facade.Messages
{
    public interface IMessagesManagementService
    {
        IEnumerable<Message> GetMessages(User user);

        IUnitOfWork UnitOfWork { get; }
    }
}