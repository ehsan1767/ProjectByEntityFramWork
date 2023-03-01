using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalInstitutions.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? phone { get; set; }
        public string? Email { get; set; }
        public int StdId { get; set; }
        //Foreingn Key
        public List <Course> course { get; set; }
    }
}
