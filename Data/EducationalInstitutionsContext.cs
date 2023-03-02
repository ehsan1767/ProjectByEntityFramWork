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
        public DbSet<Teacher> teachers { get; set; }
        public DbSet<Student> students { get; set; }
        public DbSet<Course> courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = PC67\\DEVELOPER2022;DataBase = EducationalInstitutions3;Integrated Security = true;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasKey(e => e.Id);
                
            modelBuilder.Entity<Teacher>()
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Teacher>()
                .Property(c => c.LastName)
                .IsRequired()
            .HasMaxLength(50);


            //one to one
           // modelBuilder.Entity<Teacher>()
                
        }



    }
}
