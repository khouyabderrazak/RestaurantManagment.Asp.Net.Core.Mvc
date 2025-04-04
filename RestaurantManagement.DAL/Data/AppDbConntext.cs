using Microsoft.EntityFrameworkCore;
using RestaurantManagement.DAL.Models;

namespace RestaurantManagement.DAL
{
    public class AppDbConntext : DbContext
    {
        public AppDbConntext(DbContextOptions<AppDbConntext> options) : base(options) { }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
