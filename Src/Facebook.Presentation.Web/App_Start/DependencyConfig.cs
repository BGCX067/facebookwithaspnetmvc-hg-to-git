using System;
using System.IO;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Facade;
using Facebook.Business.Domain.Facade.Friendship;
using Facebook.Business.Domain.Facade.Internals;
using Facebook.Business.Domain.Facade.Messages;
using Facebook.Business.Domain.Facade.Notifications;
using Facebook.Business.Domain.Facade.Posts;
using Facebook.Business.Domain.Images;
using Facebook.Business.Domain.Notifications;
using Facebook.Business.Domain.Posts;
using Facebook.Business.Domain.Users;
using Facebook.Data.EntityFramework;
using Facebook.Presentation.Web.Security;
using Microsoft.Practices.Unity;

using System.Web.Mvc;

using Facebook.Data;
using Facebook.Data.InMemory;
using Facebook.Infrastructure.Crosscutting.Logging;
using Facebook.Infrastructure.Crosscutting.Logging.Diagnostics;
using Facebook.Infrastructure.Ioc;
using Unity.Mvc3;

namespace Facebook.Presentation.Web.App_Start
{
    public static class DependencyConfig
    {
        internal static void Register()
        {
            Container.Instance.RegisterType<IKeyGenerationService, KeyGenerationService>();
            Container.Instance.RegisterType<ILogWriter, LogWriter>();
            Container.Instance.RegisterType<IWebSecurity, FacebookWebSecurity>();
            Container.Instance.RegisterType<IMembershipProvider, FacebookMembershipProvider>();
            Container.Instance.RegisterType<IUserProvider, FacebookUserProvider>();

            Container.Instance.RegisterType<IDateTimeService, DateTimeService>();
            Container.Instance.RegisterType<INotificationsManagementService, NotificationsManagementService>();
            Container.Instance.RegisterType<IPostsManagementService, PostsManagementService>();
            Container.Instance.RegisterType<IMessagesManagementService, MessagesManagementService>();
            Container.Instance.RegisterType<IFriendshipManagementService, FriendshipManagementService>();
            Container.Instance.RegisterType<INotificationFactory, NotificationFactory>();
            //Container.Instance.RegisterType<IUnitOfWork, UnitOfWork>();

            //var unitOfWork = new InMemoryUnitOfWork();

            Container.Instance.RegisterType<IUnitOfWork, UnitOfWork>();
            var unitOfWork = Container.Instance.Resolve<IUnitOfWork>();


            FileStream stream = new FileStream("D:\\media\\pictures\\2012-10-6 Casa\\SAM_1789.JPG", FileMode.Open);
            byte[] data = new byte[stream.Length];
            stream.Read(data, 0, data.Length);
            Image img = new Image(data, "jpg", "My perra imagen");
            unitOfWork.Images.Add(img);


            var user1 = new User("Eric Javier", "Hernandez Saura", "ericjavier@gmail.com", "Trilce", "My first pet name", "Soky");
            user1.SetPhoto(img);
            unitOfWork.Users.Add(user1);
            var post1 = new Post(user1, user1, DateTime.Now, "My first post ... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post1);

            #region More than ten posts

            var post3 = new Post(user1, user1, DateTime.Now, "My first post 3... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post3);

            var post4 = new Post(user1, user1, DateTime.Now, "My first post 4... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post4);

            var post5 = new Post(user1, user1, DateTime.Now, "My first post 5... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post5);

            var post6 = new Post(user1, user1, DateTime.Now, "My first post 6... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post6);

            var post7 = new Post(user1, user1, DateTime.Now, "My first post 7... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post7);


            var post8 = new Post(user1, user1, DateTime.Now, "My first post 8... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post8);

            var post9 = new Post(user1, user1, DateTime.Now, "My first post 9... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post9);

            var post10 = new Post(user1, user1, DateTime.Now, "My first post 10... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post10);

            var post11 = new Post(user1, user1, DateTime.Now, "My first post 11... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post11);


            var post12 = new Post(user1, user1, DateTime.Now, "My first post 12... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post12);

            var post13 = new Post(user1, user1, DateTime.Now, "My first post 13... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post13);

            var post14 = new Post(user1, user1, DateTime.Now, "My first post 14... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post14);

            var post15 = new Post(user1, user1, DateTime.Now, "My first post 15... Hello Hello ...");
            post1.AddComment(new Comment(user1, "And my first comment ... Jejerejeje", DateTime.Now));
            unitOfWork.Posts.Add(post15);

            #endregion

            var user2 = new User("Pedro Jose", "Suarez Rodriguez", "pjsr@gmail.com", "Click", "The first letter of the alphabet", "A");
            user2.SetPhoto(img);
            unitOfWork.Users.Add(user2);
            var post2 = new Post(user2, user1, DateTime.Now, "Look the mirror !");
            post2.AddComment(new Comment(user1, "Here is the comment of the great Eric Ye !", DateTime.Now));
            unitOfWork.Posts.Add(post2);

            var user3 = new User("Juan Carlos", "Perez Gonzalez", "juan@aol.com", "A", "The first letter of the alphabet", "A");
            user3.SetPhoto(img);
            unitOfWork.Users.Add(user3);

            var user4 = new User("Pepe Octavio", "Gomez Martinez", "pepeoctavio@hotmail.com", "A", "The first letter of the alphabet", "A");
            user4.SetPhoto(img);
            unitOfWork.Users.Add(user4);

            var service = new FriendshipManagementService(unitOfWork, new NotificationFactory(new DateTimeService()), new DateTimeService());
            service.SendRequest(user1, user2);
            service.AcceptRequest(user1, user2);
            service.SendRequest(user3, user1);

            unitOfWork.Commit();

            DependencyResolver.SetResolver(new UnityDependencyResolver(Container.Instance)); // TODO: Update reference to mvc4
        }
    }
}