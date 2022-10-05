using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TaskManager.Data.Models
{
    public class Task
    {
        public Task()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime TimeCreated { get; set; }

        public DateTime DueDate { get; set; }

        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        [Required]
        [MaxLength(200)]
        public string Statuses { get; set; }

        [Required]
        [MaxLength(200)]
        public string TaskTypes { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
