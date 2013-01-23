using AutoMapper;
using Facebook.Presentation.Web.Utils.AutoMapper;

namespace Facebook.Presentation.Web.App_Start
{
    public static class AutoMapperConfig
    {
        public static void Configure()
        {
            Mapper.Initialize(configuration => configuration.AddProfile(new FacebookAutoMapperProfile()));
        }
    }
}