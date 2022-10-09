using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager.Data.DTOs
{
    public class CommentDTO
    {
        public string Content { get; set; }

        public string Author { get; set; }

        public int TaskId { get; set; }
    }
}
