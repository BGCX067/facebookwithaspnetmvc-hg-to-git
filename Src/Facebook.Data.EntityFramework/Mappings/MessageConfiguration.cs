using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain.Messages;

namespace Facebook.Data.EntityFramework.Mappings
{
    public class MessageConfiguration : EntityTypeConfiguration<Message>
    {
        public MessageConfiguration()
        {
            HasKey(message => message.Id);
        }
    }
}