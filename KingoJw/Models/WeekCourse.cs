using GeneralJw.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingoJw.Models
{
    public class WeekCourse : IWeekCourse
    {
       private List<DayCourse> DayCourses { get; set; }

        public IDayCourse GetDayCourse(int dayOfWeek)
        {
            if (dayOfWeek < 0 || dayOfWeek >= 7) throw new ArgumentOutOfRangeException("dayOfWeek 的范围是 0~6");
            return DayCourses[dayOfWeek];
        }
    }
}
