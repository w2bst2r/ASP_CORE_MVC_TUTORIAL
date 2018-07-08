using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OdeToFood.Models;

namespace OdeToFood.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        //you can consider it as a list of restaurant object
        public DbSet<Restaurant> Restaurant { get; set; }

        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
