using AutoMapper;
using RequestPermission.Api.Mapping;

namespace RequestPermission.Api.Infrastracture
{
    public static class AutoMapperConfiguration
    {
        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var mappperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });
            IMapper mapper = mappperConfig.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
