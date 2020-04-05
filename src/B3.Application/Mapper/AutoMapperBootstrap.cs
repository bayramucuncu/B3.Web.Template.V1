using AutoMapper;

namespace B3.Application.Mapper
{
    public static class AutoMapperBootstrap
    {
        public static IMapper GetConfiguration()
        {
            var mapperConfiguration = new MapperConfiguration(configurationExpression => {
                configurationExpression.AddProfile(new ApplicationMappingProfile());
            });

            return mapperConfiguration.CreateMapper();
        }
    }
}
