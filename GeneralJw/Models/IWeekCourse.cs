using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralJw.Models
{
    public interface IWeekCourse
    {
        IDayCourse GetDayCourse(int dayOfWeek);
    }
}
