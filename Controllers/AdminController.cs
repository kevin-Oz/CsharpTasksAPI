using Microsoft.AspNetCore.Mvc;

namespace task_app.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "hello word";
        }
        
    }
}