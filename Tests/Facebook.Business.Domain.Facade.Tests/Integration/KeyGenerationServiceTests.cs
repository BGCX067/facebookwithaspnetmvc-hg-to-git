using Facebook.Business.Domain.Facade.Internals;
using Facebook.Business.Domain.Internals;
using Facebook.Business.Domain.Users;
using Facebook.Data;
using Facebook.Data.InMemory;
using Facebook.Infrastructure.Ioc;
using Moq;
using NUnit.Framework;
using Microsoft.Practices.Unity;

namespace Facebook.Business.Domain.Facade.Tests.Integration
{
    [TestFixture]
    public class KeyGenerationServiceTests
    {
        [Test]
        public void CreateKey_OnNonUsedBaseAndUserWithCorrectNames_ShuoldGiveACleanKey()
        {
            // Arrange
            var user = new User("Eric Javier", "Hernandez Saura", "ericjavier@gmail.com", null, null, null);
            var service = new KeyGenerationService(new InMemoryUnitOfWork());

            // Act
            var keyword = service.CreateKey(user);

            // Assert
            Assert.IsTrue(Equals(keyword, "ericjavierhernandezsaura"));
        }

        [Test]
        public void CreateKey_OnNonUsedBaseAndUserWithIncorrectNames_ShuoldGiveAKeyTakenFromEmail()
        {
            // Arrange
            var user = new User(null, "Hernandez Saura", "ericjavier@gmail.com", null, null, null);
            var service = new KeyGenerationService(new InMemoryUnitOfWork());

            // Act
            var keyword = service.CreateKey(user);

            // Assert
            Assert.IsTrue(Equals(keyword, "ericjavier"));
        }

        [Test]
        public void CreateKey_OnUsedBaseAndUserWithCorrectNames_ShuoldGiveAKeyWithAditionalCount()
        {
            // Arrange
            var entryValue = new FacebookKey("ericjavier.hernandezsaura") {Count = 10};
            var entriesMoq = new Mock<IFacebookKeyRepository>();
            entriesMoq.Setup(repo => repo.Find("ericjavierhernandezsaura")).Returns(entryValue);
            var unitOfWorkMoq = new Mock<IUnitOfWork>();
            unitOfWorkMoq.Setup(uow => uow.Entries).Returns(entriesMoq.Object);
            var user = new User("Eric Javier", "Hernandez Saura", "ericjavier@gmail.com", null, null, null);
            var service = new KeyGenerationService(unitOfWorkMoq.Object);

            // Act
            var keyword = service.CreateKey(user);

            // Assert
            Assert.IsTrue(Equals(keyword, "ericjavierhernandezsaura11"));
        }
    }
}