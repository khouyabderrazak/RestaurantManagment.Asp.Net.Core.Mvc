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

        public List<RestaurantModel> GetAllRestaurants()
        {
            
            var restaurants = _restaurantRepository.GetAllRestaurants();

            List<RestaurantModel> restaurantModels = new List<RestaurantModel>();

            foreach (var restauarant in restaurants)
            {
                restaurantModels.Add(GetRestaurantModelFormRestaurant(restauarant));
            }

            return restaurantModels;

        }

        public RestaurantModel GetRestaurantById(int id)
        {
            Restaurant restaurant = _restaurantRepository.GetRestaurantById(id);
            return GetRestaurantModelFormRestaurant(restaurant);
        }

        public void UpdateRestaurant(RestaurantModel restaurant)
        {
            _restaurantRepository.UpdateRestaurant(restaurant.Id,restaurant.Nom, restaurant.Adresse, restaurant.Cuisine, restaurant.Note, restaurant.Image);
        }

        private RestaurantModel GetRestaurantModelFormRestaurant(Restaurant restaurant)
        {
            return _mapper.Map<RestaurantModel>(restaurant);
        }
    }
}
