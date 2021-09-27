using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using task_app.Context;
using task_app.Models;
using Task = task_app.Models.Task;

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

        [HttpPost]
        public async Task<IActionResult> save( Task newTask )
        {
            try
            {
                _context.Tasks.Add(newTask);
                 await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //this method only works with task status
        [HttpPut("{id}")]
        public async Task<IActionResult> changeTaskStatus(int id, Task task)
        {
            try
            {
                if (id != task.id)
                {
                    return NotFound();
                }
                _context.Entry(task).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return Ok(new {message = "task updated"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var task = await _context.Tasks.FindAsync(id);
                if (task == null)
                {
                    return NotFound();
                }
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
                return Ok(new {message="task deleted"});
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

    }
}