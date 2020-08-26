using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralJw.Models
{
    public interface IDayCourse
    {
        List<ICourse> Courses { get; set; }
    }
}
