using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Other
{
    public partial class SQLContext : DbContext
    {
        public SQLContext()
        { }
        public SQLContext(DbContextOptions<SQLContext> options)
              : base(options)
        {
        }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=139.159.151.47;database=Blog;uid=sa;pwd=qwe@123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { }
    }
}
