using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OdeToFood.Models
{
    public class Restaurant
    {
        public Restaurant(int Id, string Name)
        {
            this.Id = Id;
            this.Name = Name;
        }
        public int Id { get; set; }
        public string Name { get; set; }

}
}
