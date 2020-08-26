using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralJw.Models
{
    public interface IExamResult
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        public string CourseName { get; set; }
        /// <summary>
        /// 学分
        /// </summary>
        public double Credit { get; set; }
        /// <summary>
        /// 成绩
        /// </summary>
        public double Score { get; set; }
    }
}
