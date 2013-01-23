using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Posts;

namespace Facebook.Data.EntityFramework.Mappings
{
    public class CommentConfiguration : EntityTypeConfiguration<Comment>
    {
        public CommentConfiguration()
        {
           
        }
    }
}