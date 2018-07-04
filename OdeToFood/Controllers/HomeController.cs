using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OdeToFood.Models;
using OdeToFood.Services;
using OdeToFood.ViewModels;


namespace OdeToFood.Controllers
{
    public class HomeController : Controller
    {
        private IRestaurantData _restaurantData;

        private IGreeter _greeter;
        /*      Remember, we registered the IRestaurantData service, so whenever IRestaurantData argument is needed,
                an instance of IRestaurantData is created and passed automatically
        
                Then as the constructor needs the IRestaurantData parameter, InMemoryRestaurant object is initiated 
                passed explicity to the constructor!! what the hell!! right?
                InMemoryRestaurantData instance is passed as the service was registered. the instance passed is initialized
                so it contains a list of restaurant objects.*/
   
        //InMemoryRestaurantData restaurantData = new InMemoryRestaurantData();
        //New HomeController(restaurantData)
        public HomeController(IRestaurantData restaurantData, IGreeter greeter)
        {
            _restaurantData = restaurantData;
            _greeter = greeter;
        }

/*         "" &&  /Home && /Home/Index 
        so when the user type one of the path above, the index method is executed, but before it get executed,
        a lot of stuff happens implicity as the HomeController is accessed
        those stuff are the constructor of HomeController is executed, and as the constructor needs IRestaurantData
        parameter, the instance of the class that implements the interface IRestaurantData that we registered is 
        created which is InMemoryRestaurantData in this case and is passed to the constructor*/
        
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel();
            model.Restaurants = _restaurantData.GetAll();//this return a list of restaurant objects
            model.CurrentMessage = _greeter.GetMessageOfTheDay();
            //return new ObjectResult(model);  we use that if we want don't want to use a view
            return View(model); //This view is passed to razor view engine
        }

        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
