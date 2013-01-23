using System.Linq;
using Facebook.Business.Domain;
using Facebook.Business.Domain.Users;
using NUnit.Framework;

namespace Facebook.Data.EntityFramework.Tests.Integration
{
    [TestFixture]
    [Category("Slow")]
    class UserAccountRepositoryTests : IntegrationFixtureBase
    {
        [Test]
        public void Add_AddSimpleUser_ShouldAddIt()
        {
            // Arrange
            string name;
            var user1 = ObjectMother.CreateUserWithName(out name);
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Add(user1);
                unitOfWork.Commit();
            }

            // Act
            User user2;
            using (var unitOfWork = new UnitOfWork())
            {
                user2 = unitOfWork.Users.All().FirstOrDefault(user => Equals(user.FirstName, name));
            }

            // Assert
            Assert.NotNull(user2);
        }

        [Test]
        public void Add_AddSeveralUsersAndAccessToTheFirstOne_ShouldNotbeNull()
        {
            // Arrange
            var user1 = ObjectMother.CreateUser();
            var user2 = ObjectMother.CreateUser();
            var user3 = ObjectMother.CreateUser();
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Add(user1);
                unitOfWork.Users.Add(user2);
                unitOfWork.Users.Add(user3);
                unitOfWork.Commit();
            }

            // Act
            User first;
            using (var unitOfWork = new UnitOfWork())
            {
                first = unitOfWork.Users.All().First();
            }

            // Assert
            Assert.NotNull(first);
        }

        [Test]
        public void Add_AddUserWithFriends_ShouldPersistTheFirstWithHisFriend()
        {
            // Arrange
            string name;
            string friend;
            var user = ObjectMother.CreateUserWithName(out name);
            user.Friends.Add(ObjectMother.CreateUserWithName(out friend));

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Commit();
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Users.All().First(account => name.Equals(account.FirstName));
                Assert.IsTrue(Equals(1, other.Friends.Count()));
            }
        }

        [Test]
        public void Add_AddUserWithFriends_ShouldPersistTheFriendToo()
        {
            // Arrange
            string name;
            string friend;
            var user = ObjectMother.CreateUserWithName(out name);
            user.Friends.Add(ObjectMother.CreateUserWithName(out friend));

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Commit();
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Users.All().FirstOrDefault(account => friend.Equals(account.FirstName));
                Assert.NotNull(other);
            }
        }

        [Test]
        public void Add_AddUserWithSeveralFriends_ShouldPersistTheFirstWithHisFriends()
        {
            // Arrange
            string name;
            var user = ObjectMother.CreateUserWithName(out name);
            user.Friends.Add(ObjectMother.CreateUser());
            user.Friends.Add(ObjectMother.CreateUser());
            user.Friends.Add(ObjectMother.CreateUser());

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Commit();
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Users.All().First(account => name.Equals(account.FirstName));
                Assert.IsTrue(Equals(3, other.Friends.Count()));
            }
        }


        [Test]
        public void Add_AddUserWithProfileData_ShouldPersist()
        {
            // Arrange
            string name;
            var profile = new UserProfile(new PersonalInformation(lookingForFrienship: true),
                                          new ContactInformation(email: "blahblah@blah.com"));
            var user = ObjectMother.CreateUserWithNameAndProfile(profile, out name);

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Users.Add(user);
                unitOfWork.Commit();
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Users.All().First(account => name.Equals(account.FirstName));
                Assert.IsTrue(Equals(other.Profile.ContactInformation.EMail, "blahblah@blah.com"));
                Assert.IsTrue(Equals(other.Profile.PersonalInformation.LookingForFriendship, true));
            }
        }
    }
}