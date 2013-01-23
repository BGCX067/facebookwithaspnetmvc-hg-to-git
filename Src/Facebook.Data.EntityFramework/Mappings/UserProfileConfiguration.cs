using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain;

namespace Facebook.Data.EntityFramework.Mappings
{
    public class UserProfileConfiguration : ComplexTypeConfiguration<UserProfile>
    {
        public UserProfileConfiguration()
        {
            
        }
    }
}