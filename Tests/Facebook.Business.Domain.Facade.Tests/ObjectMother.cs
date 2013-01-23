using System;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;

namespace Facebook.Business.Domain.Facade.Tests
{
    public static class ObjectMother
    {
        public static User CreateUser()
        {
            return new User(null, null, null, null, null, null);
        }

        public static User CreateUserWithName(out string name)
        {
            name = Guid.NewGuid().ToString();
            return new User(name, null, null, null, null, null);
        }

        public static User CreateUserWithNameAndProfile(UserProfile profile, out string name)
        {
            name = Guid.NewGuid().ToString();
            return new User(name, null, null, null, null, null, profile);
        }

        public static Post CreatePost(User author = null,
                                      User owner = null,
                                      string text = null)
        {
            return new Post(author ?? CreateUser(), owner ?? CreateUser(), DateTime.Now, text);
        }

        public static Comment CreateComment(User author = null,
                                            string text = null)
        {
            return new Comment(author ?? CreateUser(), text, DateTime.Now);
        }

        public static Notification CreateNotification(User owner = null, string text = null)
        {
            return new Notification(owner ?? CreateUser(), text, DateTime.Now);
        }
    }
}