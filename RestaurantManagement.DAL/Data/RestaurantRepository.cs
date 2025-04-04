using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using RestaurantManagement.DAL.Models;

namespace RestaurantManagement.DAL.Data
{
  

    public class RestaurantRepository(AppDbConntext _db, Microsoft.AspNetCore.Hosting.IHostingEnvironment _host) : IRestaurantRepository
    {

        public void AddRestaurant(string Nom, string Adresse, string Cuisine, double Note, IFormFile? Image)
        {

            var restaurant = new Restaurant()
            {
                Nom =Nom,
                Adresse = Adresse,
                Cuisine = Cuisine,
                Image = Image
            };

            if (restaurant.Image is not null)
            {
                string fileName = loadImage(restaurant.Image);
                restaurant.ImagePath = fileName;
            }
            _db.Restaurants.Add(restaurant);
            _db.SaveChanges();
        }

        public void DeleteRestaurant(int id)
        {
            var restaurant = _db.Restaurants.FirstOrDefault(res => res.Id == id);

            if (restaurant is not null)
            {
                _db.Restaurants.Remove(restaurant);
                _db.SaveChanges();
            }
        }

        public List<Restaurant> GetAllRestaurants()
        {
            return _db.Restaurants.ToList();
        }

        public Restaurant GetRestaurantById(int id)
        {
            return _db.Restaurants.FirstOrDefault(res => res.Id == id);
        }


        public void UpdateRestaurant(int id,string Nom, string Adresse, string Cuisine, double Note, IFormFile? Image)
        {
            var restaurant = _db.Restaurants.FirstOrDefault(re => re.Id == id);

            if (restaurant is not null)
            {
                restaurant.Adresse = Adresse;
                restaurant.Cuisine = Cuisine;
                restaurant.Note = Note;
            if (restaurant.Image is not null)
            {
                string fileName = loadImage(restaurant.Image);
                restaurant.ImagePath = fileName;
            }
            _db.Restaurants.Update(restaurant);
            _db.SaveChanges();
            }

        }

        private string loadImage(IFormFile path)
        {
            string fileName = string.Empty;
            if (path is null)
                return fileName;
            string upLoadPath = Path.Combine(_host.WebRootPath, "images");
            fileName = path.FileName;

            string fullPath = Path.Combine(upLoadPath, fileName);

            path.CopyTo(new FileStream(fullPath, FileMode.Create));
            return fileName;
        }
    }
}
