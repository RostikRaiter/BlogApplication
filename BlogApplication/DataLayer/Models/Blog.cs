using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

        // Foreign key for User
        public int UserId { get; set; }

        // Navigation property
        public User User { get; set; }
    }
}
