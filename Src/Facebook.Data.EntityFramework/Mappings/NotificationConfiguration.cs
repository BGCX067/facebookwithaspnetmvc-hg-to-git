using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain.Notifications;

namespace Facebook.Data.EntityFramework.Mappings
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasKey(notification => notification.Id);
        }
    }
}