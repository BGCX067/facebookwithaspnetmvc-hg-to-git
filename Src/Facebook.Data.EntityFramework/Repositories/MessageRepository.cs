using System.Data.Entity;
using System.Linq;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Users;
using Facebook.Infrastructure.Contracts;

namespace Facebook.Data.EntityFramework.Repositories
{
    class MessageRepository : Repository<Message>, IMessageRepository
    {
        public MessageRepository(DbSet<Message> set)
            :base(set)
        {      
        }

        #region Implementation of IMessageRepository

        /// <summary>
        /// Retrieve the messages that are sent by a given account: <paramref name="account"/>
        /// </summary>
        /// <param name="account">An account.</param>
        /// <returns>The messages that are sent by <paramref name="account"/></returns>
        public IQueryable<Message> FindMessagesFrom(User account)
        {
            ContractUtil.NotNull(account);

            return Set.Where(message => message.Sender.Id.Equals(account.Id));
        }

        /// <summary>
        /// Retrieve the messages that are sent to a given account: <paramref name="account"/>
        /// </summary>
        /// <param name="account">An account.</param>
        /// <returns>The messages that are sent by <paramref name="account"/></returns>
        public IQueryable<Message> FindMessagesTo(User account)
        {
            ContractUtil.NotNull(account);

            return Set.Where(message => message.Reciver.Id.Equals(account.Id));
        }

        /// <summary>
        /// Adds a message to the current repository.
        /// </summary>
        /// <param name="message">The message to add.</param>
        public void Add(Message message)
        {
            ContractUtil.NotNull(message);

            Set.Add(message);
        }

        #endregion
    }
}