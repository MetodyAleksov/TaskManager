using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace TaskManager.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        public DateTime DateAdded { get; set; }

        [Required]
        [MaxLength(100)]
        public string Content { get; set; }

        [Required]
        [MaxLength(200)]
        public string Type { get; set; }

        public DateTime? ReminderDate { get; set; }

        [ForeignKey(nameof(Task))]
        public int TaskId { get; set; }
        public Task Task { get; set; }
    }
}
