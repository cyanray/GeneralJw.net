using GeneralJw.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingoJw.Models
{
    public class DayCourse : IDayCourse
    {
        public List<ICourse> Courses { get; set; }
    }
}
