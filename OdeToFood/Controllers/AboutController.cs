using Microsoft.AspNetCore.Mvc;

namespace OdeToFood.Controllers
{
    [Route("about")] //if the path is /about
    public class AboutController 
    {
        [Route("")]//if you see just /about , execute this action
        [Route("phone")] //if you see about/phone , execute this action
        public string Phone()
            {
                return "05555555555";
            }
        [Route("Address")]
        public string Address()
            {
                return "USA";
            }        
    }
}