using AutoMapper;
using RestaurantManagement.DAL.Data;
using RestaurantManagement.DAL.Models;
using RestaurantManagement.service.Models;
using RestaurantManagement.Service.Interfaces;

namespace RestaurantManagement.Service.Services
{
    public class RestaurantService(IRestaurantRepository _restaurantRepository,IMapper _mapper) : IRestaurantService
    {
       
        public void AddRestaurant(RestaurantModel restaurant)
        {
            _restaurantRepository.AddRestaurant(restaurant.Nom, restaurant.Adresse, restaurant.Cuisine, restaurant.Note,restaurant.Image);
        }

        public void DeleteRestaurant(int id)
        {
            _restaurantRepository.DeleteRestaurant(id);
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _restaurantRepository.GetAllRestaurants();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _restaurantRepository.GetRestaurantById(id);
        }

        public void UpdateRestaurant(RestaurantModel restaurant)
        {
            _restaurantRepository.UpdateRestaurant(restaurant.Id,restaurant.Nom, restaurant.Adresse, restaurant.Cuisine, restaurant.Note, restaurant.Image);
        }

        public RestaurantModel GetRestaurantModelFormRestaurant(Restaurant restaurant)
        {
            return _mapper.Map<RestaurantModel>(restaurant);
        }
    }
}
