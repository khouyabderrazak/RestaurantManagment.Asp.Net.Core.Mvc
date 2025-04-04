using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.DAL;
using RestaurantManagement.DAL.Data;
using RestaurantManagement.DAL.DependencyInjection;

namespace RestaurantManagement.service.DependencyInjection
{
    public static class InjectService
    {
        public static void AddRestaurantManagmentService(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddScoped<IRestaurantRepository, RestaurantRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfile));
            services.AddAppDBContextService(_configuration);
        }
    }
}
