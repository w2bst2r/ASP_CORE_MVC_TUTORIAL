using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();   //run the web server
        }
        
        public static IWebHost BuildWebHost(string[] args) =>
            //use Startup class for building the server
            //configureServices and Configure methods are called startup method
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>() //registering USeStartup class
                .Build();
    }
}
