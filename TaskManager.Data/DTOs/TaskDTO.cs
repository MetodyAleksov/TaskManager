using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Data.DTOs
{
    public class TaskDTO
    {
        public TaskDTO()
        {
            Statuses = new List<string>();
            TaskTypes = new List<string>();
            Comments = new List<CommentDTO>();
        }

        public DateTime TimeCreated { get; set; }
        public DateTime DueDate { get; set; }
        public string Description { get; set; }
        public IList<string> Statuses { get; set; }
        public IList<string> TaskTypes { get; set; }
        public string Authors { get; set; }
        public IList<CommentDTO> Comments { get; set; }
    }
}
