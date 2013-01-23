using NUnit.Framework;
using System.Linq;

namespace Facebook.Data.EntityFramework.Tests.Integration
{
    [TestFixture]
    [Category("Slow")]
    class PostRepositoryTests : IntegrationFixtureBase
    {
        [Test]
        public void Add_AddingASimplePostWhitText_ShouldAddIt()
        {
            // Arrange
            int id;
            const string text = "Some text ...";
            var post = ObjectMother.CreatePost(text: text);

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Posts.Add(post);
                unitOfWork.Commit();
                id = post.Id;
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Posts.FindById(id);

                Assert.IsTrue(other.Text.Equals(text));
            }
        }

        [Test]
        public void Add_AddingASimplePostWhitComments_ShouldAddIt()
        {
            // Arrange
            int id;
            var post = ObjectMother.CreatePost();
            post.Comments.Add(ObjectMother.CreateComment());
            post.Comments.Add(ObjectMother.CreateComment());
            post.Comments.Add(ObjectMother.CreateComment());
            post.Comments.Add(ObjectMother.CreateComment());

            // Act
            using (var unitOfWork = new UnitOfWork())
            {

                unitOfWork.Posts.Add(post);
                unitOfWork.Commit();
                id = post.Id;
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Posts.FindById(id);

                Assert.IsTrue(Equals(4, other.Comments.Count));
            }
        }

        [Test]
        public void Add_AddingASimplePostWhitAuthor_ShouldAddIt()
        {
            // Arrange
            int id;
            var author = ObjectMother.CreateUser();
            var post = ObjectMother.CreatePost(author: author);

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Posts.Add(post);
                unitOfWork.Commit();
                id = post.Id;
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Posts.FindById(id);

                Assert.IsTrue(author.Equals(other.Author));
            }
        }

        [Test]
        public void Add_AddingASimplePostWhitOwner_ShouldAddIt()
        {
            // Arrange
            int id;
            var owner = ObjectMother.CreateUser();
            var post = ObjectMother.CreatePost(owner: owner);

            // Act
            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Posts.Add(post);
                unitOfWork.Commit();
                id = post.Id;
            }

            // Assert
            using (var unitOfWork = new UnitOfWork())
            {
                var other = unitOfWork.Posts.FindById(id);

                Assert.IsTrue(owner.Equals(other.Owner));
            }
        }

        [Test]
        public void FindPostsFrom_FindingAPostGivenAnAuthor_ShouldRetrieveIt()
        {
            // Arrange
            var author = ObjectMother.CreateUser();
            var post = ObjectMother.CreatePost(author, text: "some text");

            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Posts.Add(post);
                unitOfWork.Commit();
            }

         
            using (var unitOfWork = new UnitOfWork())
            {
                // Act
                var other = unitOfWork.Posts.FindPostsFrom(author).First();

                // Assert
                Assert.IsTrue(author.Equals(other.Author));
                Assert.IsTrue(Equals(other.Text, "some text"));
            }
        }

        [Test]
        public void FindPostsTo_FindingAPostGivenAnReciver_ShouldRetrieveIt()
        {
            // Arrange
            var owner = ObjectMother.CreateUser();
            var post = ObjectMother.CreatePost(owner: owner, text: "some text");

            using (var unitOfWork = new UnitOfWork())
            {
                unitOfWork.Posts.Add(post);
                unitOfWork.Commit();
            }


            using (var unitOfWork = new UnitOfWork())
            {
                // Act
                var other = unitOfWork.Posts.FindPostsTo(owner).First();

                // Assert
                Assert.IsTrue(owner.Equals(other.Owner));
                Assert.IsTrue(Equals(other.Text, "some text"));
            }
        }
    }
}