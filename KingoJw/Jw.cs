using GeneralJw;
using GeneralJw.Models;
using KingoJw.Encrypt;
using KingoJw.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KingoJw
{
    public class Jw : IJw
    {
        public static bool PasswordRequired { get => true; }
        public string StudentId { get; }
        public string Token => LoginInfo.Token;
        public School School { get; set; }
        private LoginInfo LoginInfo { get; set; }

        private Jw(string studentId)
        {
            StudentId = studentId;
        }

        public async static Task<IEnumerable<ISchool>> GetSchoolsAsync()
        {
            RestClient restClient = new RestClient("http://www.xiqueer.com:8080");
            var request = new RestRequest("/manager/wap/wapController.jsp", Method.POST);
            var rawParam = "appver=2.6.109&action=getAgent&xxmc=";
            request.AddParameter("param", Param.Encrypt(rawParam));
            request.AddParameter("param2", "4cdb913629de86f59af8ad9f46d48f7a");
            request.AddParameter("appinfo", "android2.6.109");
            request.AddParameter("token", "00000");
            var response = await restClient.ExecutePostAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");
            var json = JArray.Parse(response.Content);
            return json.ToObject<List<School>>();
        }

        public async static Task<IJw> LoginAsync(ISchool school, string studentId, string password)
        {
            School school_ = school as School;
            if (school_ == null) throw new Exception("教务实例无法处理传入的学校");

            RestClient restClient = new RestClient(school_.ServiceUrl);
            var request = new RestRequest("/wap/wapController.jsp", Method.POST);
            var rawParam =
                "action=getLoginInfoNew&sjbz=&isky=1&sswl=&sjxh=&os=android&xtbb=&appver=2.6.109&loginmode=0" +
                $"&loginId={studentId}&pwd={password}&xxdm={school_.IdCode}";

            request.AddParameter("param", Param.Encrypt(rawParam));
            request.AddParameter("param2", "4cdb913629de86f59af8ad9f46d48f7a");
            request.AddParameter("appinfo", "android2.6.109");
            request.AddParameter("token", "00000");
            var response = await restClient.ExecutePostAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");

            var loginInfo = JsonConvert.DeserializeObject<LoginInfo>(response.Content);

            if (loginInfo.Flag != "0") throw new Exception(loginInfo.Message);
            Jw result = new Jw(studentId) { School = school_, LoginInfo = loginInfo };
            return result;
        }

        public async Task<IEnumerable<IExamResult>> GetExamResultsAsync(string semester)
        {
            RestClient restClient = new RestClient(School.ServiceUrl);
            var request = new RestRequest("/wap/wapController.jsp", Method.POST);
            var rawParam = $"flag=1&xnxq={semester}&action=getStucj&usertype=STU&step=detail&" +
                            $"userId={School.IdCode}_{StudentId}&sfid={LoginInfo.UserId}&uuid={LoginInfo.UUID}";

            request.AddParameter("param", Param.Encrypt(rawParam));
            request.AddParameter("param2", "4cdb913629de86f59af8ad9f46d48f7a");
            request.AddParameter("appinfo", "android2.6.109");
            request.AddParameter("token", LoginInfo.Token);
            var response = await restClient.ExecutePostAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");

            var json = JObject.Parse(response.Content);
            return json["xscj"].ToObject<List<ExamResult>>();

        }

        public async Task<IStudentInfo> GetStudentInfoAsync()
        {
            RestClient restClient = new RestClient(School.ServiceUrl);
            var request = new RestRequest("/wap/baseInfoServlet", Method.POST);
            var rawParam = $"usertype=STU&step=list&userId={School.IdCode}_{StudentId}&sfid={LoginInfo.UserId}&uuid={LoginInfo.UUID}";

            request.AddParameter("param", Param.Encrypt(rawParam));
            request.AddParameter("param2", "4cdb913629de86f59af8ad9f46d48f7a");
            request.AddParameter("appinfo", "android2.6.109");
            request.AddParameter("token", LoginInfo.Token);
            var response = await restClient.ExecutePostAsync(request);
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception("非200状态响应");

            return JsonConvert.DeserializeObject<StudentInfo>(response.Content);
        }

        public Task<IWeekCourse> GetWeekCourseAsync(int week, string semester)
        {
            throw new NotImplementedException();
        }

    }
}
