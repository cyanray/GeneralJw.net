using GeneralJw.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingoJw.Models
{
    public class ExamResult : IExamResult
    {
        [JsonProperty("kcmc")]
        public string CourseName { get; set; }

        [JsonProperty("xf")]
        public double Credit { get; set; }

        [JsonProperty("kscj")]
        public double Score { get; set; }
    }
}
