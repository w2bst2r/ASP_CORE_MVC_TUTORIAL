using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OdeToFood.Models;

namespace OdeToFood.Services
{
    public class test : IRestaurantData
    {
        private List<Restaurant> _restaurantList;

        public test()
        {
            _restaurantList = new List<Restaurant>
            {
                new Restaurant(1, "what",CuisineType.French),
                new Restaurant(2, "asdf",CuisineType.German),
                new Restaurant(3, "asdfwef",CuisineType.Italian),
            };
        }

        public Restaurant Add(Restaurant restaurant)
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurantList.OrderBy(r => r.Name);
        }
    }
}

