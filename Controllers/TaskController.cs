using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_app.Context;
using task_app.Models;

namespace task_app.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly AppDbContext _context;
       public TaskController(AppDbContext context)
       {
           _context = context;
       }
       
       
        // GET
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var list = await _context.Tasks.ToListAsync();
                return Ok(list);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}