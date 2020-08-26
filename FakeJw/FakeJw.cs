using FakeJw.Models;
using GeneralJw;
using GeneralJw.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FakeJw
{
    public class FakeJw : IJw
    {
        public static bool PasswordRequired { get => true; }

        public async static Task<IEnumerable<ISchool>> GetSchoolsAsync()
        {
            return await Task.FromResult(new List<ISchool>
            {
                new School(){ Name="学校1" },
                new School(){ Name="学校2" }
            });
        }

        public async static Task<IJw> LoginAsync(ISchool school, string schoolId, string password)
        {
            FakeJw result = new FakeJw();

            return await Task.FromResult(result);
        }

        public Task<List<IExamResult>> GetExamResultsAsync(string semester)
        {
            throw new NotImplementedException();
        }

        public async Task<IStudentInfo> GetStudentInfoAsync()
        {
            StudentInfo studentInfo = new StudentInfo()
            {
                Name = "StudentName",
                School = new School() { Name = "SchoolName" }
            };
            return await Task.FromResult(studentInfo);
        }

        public Task<IWeekCourse> GetWeekCourseAsync(int week, string semester)
        {
            throw new NotImplementedException();
        }
    }
}
