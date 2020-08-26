using GeneralJw;
using System;
using KingoJw;
using KingoJw.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.IO;

namespace KingoJwClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string studentId = "123456", password = "88888888";
            if(args.Length >= 1)
            {
                var json = JObject.Parse(File.ReadAllText($"{args[0]}/KingoClient.json"));
                studentId = json["studentId"].ToString();
                password = json["password"].ToString();
            }

            var schools = await Jw.GetSchoolsAsync() as List<School>;
            Console.WriteLine($"总共找到 {schools.Count} 个院校");

            var mySchool = schools.Where(x => x.Name.Contains("河南大学")).FirstOrDefault();
            if (mySchool != null)
            {
                try
                {
                    IJw jw = await Jw.LoginAsync(mySchool, studentId, password);
                    //Console.WriteLine($"token: {jw.Token}");
                    var studentInfo = await jw.GetStudentInfoAsync();
                    Console.WriteLine($"姓名: {studentInfo.Name}");
                    Console.WriteLine($"学院: {studentInfo.College}");
                    Console.WriteLine($"专业: {studentInfo.Major}");
                    Console.WriteLine($"班级: {studentInfo.Class}");
                    Console.WriteLine($"入学年份: {studentInfo.EnrollmentYear}");

                    Console.WriteLine();

                    var examResults = await jw.GetExamResultsAsync("20191");

                    foreach (var item in examResults)
                    {
                        Console.WriteLine($"{item.CourseName} : {item.Score} , {item.Credit}");
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine($"出现错误：{ex.Message}");
                }
                
            }


        }
    }
}
