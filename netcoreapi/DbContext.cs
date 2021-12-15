using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Todo.Mvc.Ui.Models;

namespace Todo.Mvc.Ui
{
    public class AppDBContext : DbContext
    {
        public DbSet<Points> Points { get; set; }
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
