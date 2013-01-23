using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain.Friendship;

namespace Facebook.Data.EntityFramework.Mappings
{
    public class FriendshipRequestConfiguration : EntityTypeConfiguration<FriendshipRequest>
    {
        public FriendshipRequestConfiguration()
        {
            HasKey(request => request.Id);
        }
    }
}