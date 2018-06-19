using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Startup
    {
        //this is where you add and register your services
        public void ConfigureServices(IServiceCollection services)
        {
            //singleton means that only one instance of the service is created for the entine application
            //AddTransient creates an instance whenever someone needs the service
            //AddScoped creates a service for every HTTP request
            //create instance of the class Greeter and pass it to the method Configure 
        services.AddSingleton<IGreeter, Greeter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //each parameter is called a service
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        {
            //            if (env.IsDevelopment())
            //            {
            //                //this is a middleware responsbile for  
            //                app.UseDeveloperExceptionPage();
            //            }

            //custom middleware:
            app.Use(next =>
            {
                return async context =>
                {
                    logger.LogInformation("request is coming");
                    //if path starts with /mym, run the code below
                    if (context.Request.Path.StartsWithSegments("/mym"))
                    {
                        await context.Response.WriteAsync("Hit!!");
                        logger.LogInformation("request handled");
                    }
                    // if not , run the next middleware
                    else
                    {
                        await next(context);
                        logger.LogInformation("Response outgoing");
                    }
                };
            });


            //respond to every request by displaying the welcome page if the path is /wp
            app.UseWelcomePage(new WelcomePageOptions{Path = "/wp"});  
            app.Run(async (context) =>  //this is a middleware
            {
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync(greeting);
            });
        }
    }
}
