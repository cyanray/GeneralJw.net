using GeneralJw.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GeneralJw
{
    public interface IJw
    {
        static bool PasswordRequired { get => true; }
        string StudentId { get; }
        static Task<IEnumerable<ISchool>> GetSchoolsAsync() => throw new NotImplementedException();
        static Task<IJw> LoginAsync(ISchool school, string schoolId, string password) => throw new NotImplementedException();
        Task<IStudentInfo> GetStudentInfoAsync();
        Task<IWeekCourse> GetWeekCourseAsync(int week, string semester);
        Task<IEnumerable<IExamResult>> GetExamResultsAsync(string semester);
    }
}
