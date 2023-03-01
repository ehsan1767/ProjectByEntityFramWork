using EducationalInstitutions.Data;
using EducationalInstitutions.Models;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace EducationalInstitutions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using EducationalInstitutionsContext context = new EducationalInstitutionsContext();


            Teacher t1 = new Teacher();
            {
                t1.FirstName = "hamed";
                t1.LastName = "fakri";
                t1.Lesson = "software";
            }

            Teacher t2 = new Teacher();
            {
                t1.FirstName = "hamed";
                t1.LastName = "fakri";
                t1.Lesson = "software";
            }

            context.teachers.Add(t1);
            context.teachers.Add(t2);

            Student s1 = new Student();
            {
                s1.FirstName = "hamed";
                s1.LastName = "fakri";
                // s1.course = "hardware";
            }

            Student s2 = new Student();
            {
                s2.FirstName = "hamed";
                s2.LastName = "fakri";
                //s2.course = "hardware";
            }

            context.students.Add(s1);
            context.students.Add(s2);

            Course c1 = new Course();
            {
                c1.CourseName = "software";
                c1.CoursePresentationDay = "sat,tus";
                c1.CourseTime = "14 - 16";
            }

            Course c2 = new Course();
            {
                c2.CourseName = "hardware";
                c2.CoursePresentationDay = "tus";
                c2.CourseTime = "14 - 16";
            }

            context.courses.Add(c1);
            context.courses.Add(c2);
            context.SaveChanges();
        }
    }
}