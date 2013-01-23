using NUnit.Framework;
using System.Linq;

namespace Facebook.Data.EntityFramework.Tests.Integration
{
    [TestFixture, Category("Slow")]
    
    internal class NotificationRepositoryTests : IntegrationFixtureBase
    {
        [Test]
        public void Add_AddASimpleNotification_ShouldPersist()
        {
            // Arrange
            var owner = ObjectMother.CreateUser();
            var notification = ObjectMother.CreateNotification(owner);

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Notifications.Add(notification);
                unitOfWork.Commit();
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Notifications.FindNotificationsFor(owner).First();
                Assert.NotNull(other);
            }
        }

        [Test]
        public void Add_AddASimpleNotification_ShouldPersistWithTheOwner()
        {
            // Arrange
            var owner = ObjectMother.CreateUser();
            var notification = ObjectMother.CreateNotification(owner);

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Notifications.Add(notification);
                unitOfWork.Commit();
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Notifications.FindNotificationsFor(owner).First();
                Assert.IsTrue(other.Owner.Equals(owner));
            }
        }
    }
}