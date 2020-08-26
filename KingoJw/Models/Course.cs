using GeneralJw.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingoJw.Models
{
    public class Course : ICourse
    {
        [JsonProperty("kcmc")]
        public string Name { get; set; }

        [JsonProperty("rkjs")]
        public string Teacher { get; set; }

        [JsonProperty("skdd")]
        public string Classroom { get; set; }
    }
}
