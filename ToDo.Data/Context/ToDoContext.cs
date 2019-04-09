using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ToDo.Data.Models;

namespace ToDo.Data.Context
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions options)
            :base(options)
        {
            
        }

        public DbSet<ToDoTask> ToDoTasks { get; set; }
    }
}
