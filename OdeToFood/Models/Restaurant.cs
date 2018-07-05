using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name="Restaurant Name"),MinLength(5)]      
        public string Name { get; set; }
        [Display(Name = "Cuisine nationality")]
        public CuisineType Cuisine { get; set; }

        public Restaurant()
        {
            
        }
        public Restaurant(int Id, string Name,CuisineType Cuisine)
        {
            this.Id = Id;
            this.Name = Name;
            this.Cuisine = Cuisine;
        }
    }
}
