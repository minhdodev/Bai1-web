using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace StudentApp
{
    public class StudentContext : DbContext
    {
        public StudentContext() : base("name=StudentDBConnectionString")
        {
        }

        public DbSet<Student> Students { get; set; }
    }
}
