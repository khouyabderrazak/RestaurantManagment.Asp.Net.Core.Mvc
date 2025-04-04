using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestaurantManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagement.DAL.DependencyInjection
{
    public static class InjectAppDbContext
    {
        public static void AddAppDBContextService(this IServiceCollection services, IConfiguration _configuration)
        {
            services.AddDbContext<AppDbConntext>(
                   options => options.UseSqlServer(_configuration.GetConnectionString("connectionString"))
             );
        }
    }
}
