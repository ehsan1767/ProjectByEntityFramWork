using EducationalInstitutions.Data;
using EducationalInstitutions.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EducationalInstitutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //InsertTecher();
            //InsertMultipleTeacher();
            InsertMultipleDifferentObject();

        }


        private static void InsertTecher()
        {
            var t1 = new Teacher() { FirstName = "hamed", LastName = "fakori", Lesson = "software" };
            using (var context = new EducationalInstitutionsContext())
            {
                context.Add(t1);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleTeacher()
        {
            var t1 = new Teacher() { FirstName = "ali", LastName = "khodaei", Lesson = "software" };
            var t2 = new Teacher() { FirstName = "mohsen", LastName = "sazgar", Lesson = "hardware" };
            var t3 = new Teacher() { FirstName = "sara", LastName = "azizi", Lesson = "hardware" };

            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange(t1,t3);
                context.SaveChanges();
            }

        }

        private static void InsertMultipleDifferentObject()
        {
            var t1 = new Teacher() { FirstName = "a" ,LastName="b",Lesson="r" };
            var c1 = new Course()
            { CourseName="r",
            CoursePresentationDay = "sat",
            co
            };
            var s1 = new Student() { FirstName = "ehsan", LastName = "salahi", course= "r", StdId = 1234; };

            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange();
                context.SaveChanges();
            }
        }
    }
}