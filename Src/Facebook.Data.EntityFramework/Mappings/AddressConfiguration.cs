using System.Data.Entity.ModelConfiguration;
using Facebook.Business.Domain;

namespace Facebook.Data.EntityFramework.Mappings
{
    public class AddressConfiguration : ComplexTypeConfiguration<Address>
    {
        public AddressConfiguration()
        {
            
        }
    }
}