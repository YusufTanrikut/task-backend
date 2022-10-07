using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagement.Entities;

namespace TaskManagement.Dal
{
    public class TaskManagementContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TaskEntity> Tasks { get; set; }
        public DbSet<CommentEntity> Comments { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string startupPath = Environment.CurrentDirectory;
            options.UseSqlite(@$"Data Source= {startupPath}/Demo.db");
        }
    }
}
