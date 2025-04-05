using RestaurantManagement.DAL.Models;
using RestaurantManagement.service.Models;

namespace RestaurantManagement.Service.Interfaces
{
   

    public interface IRestaurantService
    {
        RestaurantModel GetRestaurantById(int id);
        List<RestaurantModel> GetAllRestaurants();
        void AddRestaurant(RestaurantModel restaurant);
        void UpdateRestaurant(RestaurantModel restaurant);
        void DeleteRestaurant(int id);
    }

}
