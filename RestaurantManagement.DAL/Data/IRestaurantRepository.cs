using Microsoft.AspNetCore.Http;
using RestaurantManagement.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace RestaurantManagement.DAL.Data
{
    public interface IRestaurantRepository
    {
        Restaurant GetRestaurantById(int id);
        List<Restaurant> GetAllRestaurants();
        void AddRestaurant(string Nom, string Adresse, string Cuisine, double Note,IFormFile? Image);
        void UpdateRestaurant(int id,string Nom, string Adresse, string Cuisine, double Note, IFormFile? Image);
        void DeleteRestaurant(int id);
    }
}
