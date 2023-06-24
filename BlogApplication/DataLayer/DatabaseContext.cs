using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class BlogContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Blog> Blogs { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options)
       : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=BlogAppBase;Username=postgres;Password=1");
        }
    }

}
