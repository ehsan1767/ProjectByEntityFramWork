using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalInstitutions.Models
{
    public class ClassRoom
    {
        public int Id { get; set; }
        public DateTime StatDate { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsCancel { get; set; }
        public string Room { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set;}

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set;}

        public  List<Student> students { get; set; }


    }
}
