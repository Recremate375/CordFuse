using IdentityService.Domain.Mapper;

namespace IdentityService.WebAPI.Extensions
{
    public static class AutoMapperExtension
    {
        public static IServiceCollection AddMapperExtension(this IServiceCollection services)
        {
            return services.AddAutoMapper(typeof(MappingProfile).Assembly);
        }
    }
}
