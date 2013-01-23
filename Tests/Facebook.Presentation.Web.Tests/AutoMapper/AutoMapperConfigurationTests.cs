using AutoMapper;
using Facebook.Presentation.Web.App_Start;
using Facebook.Presentation.Web.Utils.AutoMapper;
using NUnit.Framework;

namespace Facebook.Presentation.Web.Tests.AutoMapper
{
    [TestFixture]
    public class AutoMapperConfigurationTests
    {
        [Test]
        public void Should_map_everything()
        {
            AutoMapperConfig.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}