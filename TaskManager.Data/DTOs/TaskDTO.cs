using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Data.DTOs
{
    public class TaskDTO
    {
        public TaskDTO()
        {
            Comments = new List<CommentDTO>();
        }
        public int  Id { get; set; }
        public DateTime TimeCreated { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public string Statuses { get; set; }
        public string TaskTypes { get; set; }
        public string Author { get; set; }
        public IList<CommentDTO> Comments { get; set; }
    }
}
