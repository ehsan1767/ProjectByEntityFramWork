using EducationalInstitutions.Data;
using EducationalInstitutions.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using Microsoft.IdentityModel.Tokens;

namespace EducationalInstitutions
{
    internal class Program
    {
        private static EducationalInstitutionsContext _context = new EducationalInstitutionsContext();
        static void Main(string[] args)
        {
            char userchoice = ' ';
            Console.WriteLine("choose an option");
            Console.WriteLine("1- Add   Student");
            Console.WriteLine("2- Edit  Student");
            Console.WriteLine("3- show  InfoStudent");
            Console.WriteLine("4- Show  ClassRoom");
            Console.WriteLine("5- Add   Course");
            Console.WriteLine("6- Edit  Course");
            Console.WriteLine("Q- Quit  program");
            do
            {
                userchoice = char.ToUpper(Console.ReadKey(true).KeyChar);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"userchoice: {userchoice}");

                switch (userchoice)
                {
                    case '1':
                        InsertStudent();
                        break;
                    case '2':
                        RetriveAndUpdateStudent();
                        break;
                    case '3':
                        StudentQuery();
                        break;
                    case '4':
                        //ClassRoomFullInfo();
                        break;
                    case '5':
                       // AddCourse();
                        break;
                    case '6':
                        //EditCourse();
                        break;

                    default:
                        Console.WriteLine("returning choice of menu");
                        continue;
                }
                Console.WriteLine("choose another option");

            } while (!userchoice.Equals('Q'));


            //InsertStudent();
            //RetriveAndUpdateStudent();
            //InsertMultipleTeacher();
            //InsertClassRoom();
            // ClassRoomFullInfo();

           
            
        }

        private static void InsertStudent()
        {
            Console.Write("Enter FirstName:");
            var fn = Console.ReadLine();
            Console.Write("Enter LastName:");
            var ln = Console.ReadLine();
            Console.Write("Enter Phone Number:");
            var ph = Console.ReadLine();
            Console.Write("Enter Email Address:");
            var em = Console.ReadLine();
            _context.Students.Add(new Student
            {
                FirstName = fn,
                LastName = ln,
                phone = ph,
                Email=em
            });
            _context.SaveChanges();

            var std = _context.Students.FirstOrDefault(s => s.FirstName == fn && s.LastName==ln);
            Console.WriteLine($"Thank you for your registration {std.FirstName} {std.LastName}");
            Console.WriteLine($"Id {std.FirstName} {std.LastName} is {std.Id}");
        }

        private static void RetriveAndUpdateStudent()
        {
            Console.Write("Enter IdStudent:");
            var id = int.Parse(Console.ReadLine());

            var upstudent = _context.Students.FirstOrDefault(s => s.Id == id);
            if (upstudent != null)
            {
                Console.Write("Enter New FirstName Student:");
                var newFirstName = Console.ReadLine();
                upstudent.FirstName = newFirstName;
                Console.Write("Enter New FirstName student:");
                var newLastName = Console.ReadLine();
                upstudent.LastName = newLastName;

                using (var newContext = new EducationalInstitutionsContext())
                {
                    newContext.Students.Update(upstudent);
                    newContext.SaveChanges();
                }
                Console.WriteLine("Your edit was successful");
            }
            else
            {
                Console.WriteLine("StudentID Not Valid");
            }
        }

        private static void StudentQuery()
        {
            using (var context = new EducationalInstitutionsContext())
            {
                Console.Write("Enter StudentID: ");
                var id = int.Parse(Console.ReadLine());
                var stu = context.Students.FirstOrDefault(s=>s.Id == id);
                if (stu != null)
                {
                    var q1 = context.Students;
                    Console.WriteLine("studentID    FirstName       LastName");

                    Console.WriteLine($"{stu.Id}  {stu.FirstName,17} {stu.LastName,15}");
                }
                else
                { 
                    Console.WriteLine("StudentId Not Valid");
                }
            }
        }

        private static void ClassRoomFullInfo()
        {
            var ClassRoom = _context.ClassRooms.ToList();
            
            foreach (var c in ClassRoom)
            {
                Console.WriteLine($"{c.StartDate:Y} {c.EndDate:Y} {c.StartTime:t} {c.EndTime:t}  {c.Room}");
            }
        }

        private static void AddCourse()
        {
            Console.Write("Enter StudentID: ");
            var id = int.Parse(Console.ReadLine());
            var stu = _context.Students.FirstOrDefault(s => s.Id == id);
            if (stu != null)
            {
                Console.Write("Enter Number Course:");
                var c= int.Parse(Console.ReadLine());
                if (c == 1)
                    InsertClassRoom1();
                else if(c==2)
                    InsertClassRoom2();
                else
                    Console.WriteLine("Not Valid ClassRoom");
            }
            else
            {
                Console.WriteLine("StudentID Not Valid");
            }
            }
        private static void InsertClassRoom1()
        {
            var std = _context.Students.FirstOrDefault();
            var cr1 = new ClassRoom()
            {
                CourseId = 1,
                TeacherId = 1,
                Room = "5",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),

                Students = new List<Student> { new Student { FirstName = std.FirstName, LastName = std.LastName } }
            };
            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange(cr1);
                context.SaveChanges();
            }
        }
        private static void InsertClassRoom2()
        {
            var std = _context.Students.FirstOrDefault();
            var cr2 = new ClassRoom()
            {
                Id = 2,
                CourseId = 2,
                TeacherId = 2,
                Room = "3",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now.AddMonths(3),
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(2),

                Students = new List<Student> { new Student { FirstName = std.FirstName, LastName = std.LastName } }
            };
            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange(cr2);
                context.SaveChanges();
            }
        }

            private static void InsertMultipleTeacher()
        {
            var t1 = new Teacher() { FirstName = "ali", LastName = "khodaei" };
            var t2 = new Teacher() { FirstName = "mohsen", LastName = "sazgar" };
            var t3 = new Teacher() { FirstName = "sara", LastName = "azizi" };

            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange(t1, t3);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleDifferentObject()
        {
            var t1 = new Teacher() { FirstName = "a", LastName = "b" };
            var c1 = new Course();

            var s1 = new Student() { FirstName = "ehsan", LastName = "salahi" };

            using (var context = new EducationalInstitutionsContext())
            {
                context.AddRange();
                context.SaveChanges();
            }
        }


       
        private static void Deleteourse()
        {
          
            Console.WriteLine("Enter StudentID");
            var id = int.Parse(Console.ReadLine());
            var students = _context.Students.FirstOrDefault(t => t.Id == id);
           // _context.Teachers.Remove(students);
            _context.SaveChanges();
        }


    }
}
