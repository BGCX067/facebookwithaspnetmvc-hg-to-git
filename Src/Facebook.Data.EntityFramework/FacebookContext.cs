using System.Data.Entity;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Friendship;
using Facebook.Business.Domain.Images;
using Facebook.Business.Domain.Internals;
using Facebook.Business.Domain.Messages;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;
using Facebook.Data.EntityFramework.Mappings;

namespace Facebook.Data.EntityFramework
{
    // TODO: set as internal in production ...
    public class FacebookContext : DbContext
    {
        public FacebookContext()
        {
            Configuration.LazyLoadingEnabled = true;
            Configuration.ValidateOnSaveEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<FriendshipRequest> FriendshipRequests { get; set; }

        public DbSet<FacebookKey> Entries { get; set; }

        public DbSet<Image> Images { get; set; } 

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Configurations.AddComment(new UserAccountConfiguration());
            //modelBuilder.Configurations.AddComment(new MessageConfiguration());
            //modelBuilder.Configurations.AddComment(new NotificationConfiguration());
            //modelBuilder.Configurations.AddComment(new PostConfiguration());
            //modelBuilder.Configurations.AddComment(new FriendshipRequestConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new UserProfileConfiguration());
            modelBuilder.Configurations.Add(new ContactInformationConfiguration());
            modelBuilder.Configurations.Add(new PersonalInformationConfiguration());
            modelBuilder.Configurations.Add(new CommentConfiguration());


            base.OnModelCreating(modelBuilder);
        }
    }
}