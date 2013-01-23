using System.Collections.Generic;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Infrastructure.Contracts;
using System.Linq;

namespace Facebook.Business.Domain.Facade.Messages
{
    public class MessagesManagementService : IMessagesManagementService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessagesManagementService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Message> GetMessages(User user)
        {
            ContractUtil.NotNull(user);

            return _unitOfWork.Messages.FindMessagesTo(user).OrderByDescending(message => message.Date);
        }

        public IUnitOfWork UnitOfWork { get { return _unitOfWork; } }
    }
}