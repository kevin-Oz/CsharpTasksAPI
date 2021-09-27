using Microsoft.AspNetCore.Mvc;

namespace task_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : Controller
    {

        [HttpGet]
        public string Get()
        {
            return "Welcome :)";
        }

      
    }
}