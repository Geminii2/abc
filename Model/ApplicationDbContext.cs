using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TestFileApi.Model
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public ApplicationDbContext()
        {
        }

        // protected override void OnModelCreating(ModelBuilder modelBuilder)
        // {
        //     modelBuilder.Entity<Student>().HasData(
        //         new Student()
        //         {
        //             Student_ID = 1,
        //             RollNo = 1,
        //             EnrollmentNo = "12345N123",
        //             Name ="Nikunij Satasiya",
        //             Branch = "CE",
        //             University = "FPT"
        //         }
        //     );

        // }

        public DbSet<Student> Students {get;set;}
    }
    
}