using GeneralJw.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace FakeJw.Models
{
    public class StudentInfo : IStudentInfo
    {
        public ISchool School { get; set; }
        public string SchoolId { get; set; }
        public string Name { get; set; }
        public string College { get; set; }
        public string Major { get; set; }
        public string Class { get; set; }
        public int EnrollmentYear { get; set; }
    }
}
