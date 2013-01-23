using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain.Posts;

namespace Facebook.Data.EntityFramework.Mappings
{
    public class PostConfiguration : EntityTypeConfiguration<Post>
    {
        public PostConfiguration()
        {
            HasKey(post => post.Id);
        }
    }
}