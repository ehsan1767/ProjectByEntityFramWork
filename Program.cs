using EducationalInstitutions.Data;
using EducationalInstitutions.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EducationalInstitutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InsertTecher();
            //InsertMultipleTeacher();
            //InsertMultipleDifferentObject();

        }


        private static void InsertTecher()
        {
            var t1 = new Teacher() { FirstName = "hamed", LastName = "fakori"};
            using (var context = new EducationalInstitutionsContext())
            {
                context.Add(t1);
                context.SaveChanges();
            }
        }
        private static void InsertClassRoom()
        {
             
            var cr1 = new ClassRoom() {
                StatDate= DateTime.Now,
                EndTime= DateTime.Now.AddHours(2),
                IsCanceled= false,
                Room="5",
                CourseId=1,
                TeacherId=1,
                Students = new List<Student> { new Student { FirstName="ehsan",LastName="salahi"},
                                               new Student { FirstName="ali",LastName="azizi"} }
            };
            using (var context = new EducationalInstitutionsContext())
            {
                context.Add(cr1);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleTeacher()
        {
            var t1 = new Teacher() { FirstName = "ali", LastName = "khodaei"};
            var t2 = new Teacher() { FirstName = "mohsen", LastName = "sazgar" };
            var t3 = new Teacher() { FirstName = "sara", LastName = "azizi" };

            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange(t1,t3);
                context.SaveChanges();
            }

        }

        private static void InsertMultipleDifferentObject()
        {
            var t1 = new Teacher() { FirstName = "a" ,LastName="b" };
            var c1 = new Course();
           
            var s1 = new Student() { FirstName = "ehsan", LastName = "salahi" };

            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange();
                context.SaveChanges();
            }
        }
    }
}