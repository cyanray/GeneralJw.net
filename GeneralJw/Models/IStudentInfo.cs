using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralJw.Models
{
    public interface IStudentInfo
    {
        ISchool School { get; set; }
        string SchoolId { get; set; }
        string Name { get; set; }
        string College { get; set; }
        string Major { get; set; }
        string Class { get; set; }
        int EnrollmentYear { get; set; }
    }
}
