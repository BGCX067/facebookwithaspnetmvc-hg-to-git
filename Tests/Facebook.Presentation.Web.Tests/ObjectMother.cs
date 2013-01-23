using Facebook.Business.Domain.Users;

namespace Facebook.Presentation.Web.Tests
{
    public static class ObjectMother
    {
         public static User GetUser()
         {
             return new User("Eric Javier", "Hernandez Saura", "ericjavierhernandezsaura@gmail.com", "Trilce", "My first pet name", "Soky");
         }
    }
}