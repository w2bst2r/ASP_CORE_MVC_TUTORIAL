using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup
    {
        //this is where you add and register your services
        public void ConfigureServices(IServiceCollection services)
        {
           /* AddSignleton means that only one instance of the service is created for the entine application
            AddTransient creates an instance whenever someone needs the service
            AddScoped creates an instance for every HTTP request
            create instance of the class Greeter and pass it to any method that needed as an argument */
            services.AddSingleton<IGreeter, Greeter>();
            //create instance of InMemoryRestaurantData and pass it to the controller
            services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();

            services.AddMvc();






















            /*    we don't need to pass the other parameters like app , env as they are
                already passed implicitly by asp.net core framework*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //each parameter is called a service
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger<Startup> logger)
        //by using interface IGreeter, we can later create a new class that implement the interface and pass it as an object
        // suppose that a new instance of greeter was created and passed to Configure method
        //it is like Configure(new Greeter())
        {   
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage(); //map url to default method
            }

            //            app.UseDefaultFiles(); //it changes the path of the request to the default file path(index.html)
            //            app.UseStaticFiles(); //make static file available to serve 
            app.UseStaticFiles();
            app.UseMvc(ConfigureRoutes);

//            //custom middleware:
//            app.Use(next =>
//            {
//                return async context =>
//                {
//                    logger.LogInformation("request is coming");
//                    //if path is /mym, run the code below
//                    if (context.Request.Path.StartsWithSegments("/mym"))
//                    {
//                        await context.Response.WriteAsync("Hit!!");
//                        logger.LogInformation("request handled");
//                    }
//                    // if not , run the next middleware
//                    else
//                    {
//                        await next(context);
//                        logger.LogInformation("Response outgoing");
//                    }
//                };
//            });
//
//
//            //respond to every request by displaying the welcome page if the path is /wp
//            app.UseWelcomePage(new WelcomePageOptions{Path = "/wp"});  
//
//            app.Run(async (context) =>  //this is the default middleware. It is defined by app.Run
//            {
//                // throw new Exception("error!");
//                //greeter object is passed from services.AddSingleton<IGreeter, Greeter>();!!
//                var greeting = greeter.GetMessageOfTheDay();
//                    //environment name is set up in launchSettings.json
//                context.Response.ContentType = "text/plain";  //telling the browser that the http response type is a text plain
//                await context.Response.WriteAsync($"Not found");
//            });
        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder) { 
            //default router is defined at the first router
            // "" --> home/index && /x --> /x/index && /x/y --> /home/index
            routeBuilder.MapRoute("Default","{controller=home}/{action=index}/{id?}");
/*            // about --> about/address
            routeBuilder.MapRoute("about", "{controller=about}/{action=address}/{id?}");*/
          
        }
    }
}
