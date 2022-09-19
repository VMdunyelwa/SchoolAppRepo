using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Course
    {
        public int CourseID { get; set; }
        public string CourseDescription { get; set; }
        public string Duration { get; set; }
        public int CourseTypeID { get; set; }
        public string Status { get; set; }
        
    }
}
