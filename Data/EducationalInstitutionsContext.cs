using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EducationalInstitutions.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalInstitutions.Data
{
    public class EducationalInstitutionsContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<ClassRoom> ClassRooms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = PC67\\DEVELOPER2022;DataBase = Educational1;Integrated Security = true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Teacher>()
            //    .HasKey(e => e.Id);

            //modelBuilder.Entity<Teacher>()
            //    .Property(c => c.FirstName)
            //    .IsRequired()
            //    .HasMaxLength(50);

            //modelBuilder.Entity<Teacher>()
            //    .Property(c => c.LastName)
            //    .IsRequired()
            //.HasMaxLength(50);

            modelBuilder.Entity<Course>()
                 .HasData(new Course { Id = 1, Name = "SoftWare" },
                          new Course { Id = 2, Name=  "HardWare" });

            modelBuilder.Entity<Teacher>()
                .HasData(new Teacher { Id = 1, FirstName = "Hamed", LastName = "Fakori" },
                         new Teacher { Id = 2, FirstName = "Sohrab", LastName = "Amiri" });
        }

    }
}
