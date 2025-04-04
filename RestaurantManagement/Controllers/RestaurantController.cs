﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestaurantManagement.service.Models;
using RestaurantManagement.Service.Interfaces;
using System.Net.NetworkInformation;

namespace RestaurantManagement.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRestaurantService _restaurantService;
     
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        // GET: RestaurantController
        public ActionResult Index()
        {
            var restaurants = _restaurantService.GetAllRestaurants();

            List<RestaurantModel> restaurantModels = new List<RestaurantModel>();

            foreach(var restauarant in restaurants)
            {
                restaurantModels.Add(_restaurantService.GetRestaurantModelFormRestaurant(restauarant));
            }

            return View(restaurantModels);
        }

        // GET: RestaurantController/Details/5
        public ActionResult Details(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            
            return View(_restaurantService.GetRestaurantModelFormRestaurant(restaurant));
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        { 
            return View(new RestaurantModel());
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RestaurantModel restaurant)
        {
            try
            {
                TempData["MessageSucess"] = "Restaurant created successfully";
                _restaurantService.AddRestaurant(restaurant);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            return View(_restaurantService.GetRestaurantModelFormRestaurant(restaurant));
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RestaurantModel restaurant)
        {
            try
            {
                _restaurantService.UpdateRestaurant(restaurant);
                TempData["MessageSucess"] = "Restaurant updated successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Delete/5
        public ActionResult Delete(int id)
        {
            var restaurant = _restaurantService.GetRestaurantById(id);
            return View(_restaurantService.GetRestaurantModelFormRestaurant(restaurant));
        }

        // POST: RestaurantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id,RestaurantModel restaurant)
        {
            try
            {
                _restaurantService.DeleteRestaurant(id);
                TempData["MessageSucess"] = "Restaurant deleted successfully";
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
