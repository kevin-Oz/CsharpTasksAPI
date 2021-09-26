using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace task_app.Models
{
    public class Task
    {
        public int id { get; set; } 
        [Required]
        [Column(TypeName = "varchar(100)")]
        public string name { get; set; }
        public bool status { get; set; }
    }
}