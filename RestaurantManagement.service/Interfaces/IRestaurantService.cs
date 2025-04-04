using RestaurantManagement.DAL.Models;
using RestaurantManagement.service.Models;

namespace RestaurantManagement.Service.Interfaces
{
   

    public interface IRestaurantService
    {
        Restaurant GetRestaurantById(int id);
        List<Restaurant> GetAllRestaurants();
        void AddRestaurant(RestaurantModel restaurant);
        void UpdateRestaurant(RestaurantModel restaurant);
        void DeleteRestaurant(int id);
    }

}
