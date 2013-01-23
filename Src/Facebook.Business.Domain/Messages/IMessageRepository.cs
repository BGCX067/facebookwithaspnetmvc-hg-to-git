using System.Linq;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Messages
{
    /// <summary>
    /// This interface defines contract for a repository of messages.
    /// </summary>
    public interface IMessageRepository 
    {



        /// <summary>
        /// Retrieve the messages that are sent by a given account: <paramref name="account"/>
        /// </summary>
        /// <param name="account">An account.</param>
        /// <returns>The messages that are sent by <paramref name="account"/></returns>
        IQueryable<Message> FindMessagesFrom(User account);

        /// <summary>
        /// Retrieve the messages that are sent to a given account: <paramref name="account"/>
        /// </summary>
        /// <param name="account">An account.</param>
        /// <returns>The messages that are sent by <paramref name="account"/></returns>
        IQueryable<Message> FindMessagesTo(User account);

        /// <summary>
        /// Adds a message to the current repository.
        /// </summary>
        /// <param name="message">The message to add.</param>
        void Add(Message message);
    }
}