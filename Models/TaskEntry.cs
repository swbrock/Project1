using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project1.Models
{
    public class TaskEntry
    {
        [Key]
        [Required]
        public int TaskId { get; set; }

        [Required(ErrorMessage = "Task is required!")]
        public string Task { get; set; }

        //helps user to input due date correctly
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public string DueDate { get; set; }

        [Required(ErrorMessage = "Quadrant is required!")]
        [MaxLength(4)]
        public int Quadrant { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public bool Completed { get; set; }

        internal void Add(TaskEntry task)
        {
            throw new NotImplementedException();
        }
    }
}
