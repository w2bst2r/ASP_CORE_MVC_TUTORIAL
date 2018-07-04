using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    //this service creates a list of restaurants and can return them.
    public class InMemoryRestaurantData : IRestaurantData
    {
        private List<Restaurant> _restaurantList;

        //create the restaurant list from the model Restaurant
        public InMemoryRestaurantData()
        {
            _restaurantList = new List<Restaurant>
            { 
                new Restaurant(1, "Tipico"),
                new Restaurant(2, "Milano"),
                new Restaurant(3, "PizzaHut"),
            };
        }

        public Restaurant Get(int id)
        {
            return _restaurantList.Find(r => r.Id == id);
        }

        // get the restaurant list in an ordered fashion
        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurantList.OrderBy(r => r.Name);
        }
    }
}
