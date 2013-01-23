using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain.Users;

namespace Facebook.Data.EntityFramework.Mappings
{
    class UserAccountConfiguration : EntityTypeConfiguration<User>
    {
        public UserAccountConfiguration()
        {
            HasKey(account => account.Id);

            
        }
    }
}