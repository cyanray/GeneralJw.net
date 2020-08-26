using GeneralJw.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingoJw.Models
{
    public class StudentInfo : IStudentInfo
    {
        public ISchool School { get; set; }

        [JsonProperty("xh")]
        public string SchoolId { get; set; }

        [JsonProperty("xm")]
        public string Name { get; set; }

        [JsonProperty("yx")]
        public string College { get; set; }

        [JsonProperty("zy")]
        public string Major { get; set; }

        [JsonProperty("ssbj")]
        public string Class { get; set; }

        public int EnrollmentYear { get; set; } = 0;

        [JsonProperty("rxnj")]
        private string enrollmentYear 
        { 
            get => EnrollmentYear.ToString(); 
            set => EnrollmentYear = Convert.ToInt32(value); 
        }

    }
}
