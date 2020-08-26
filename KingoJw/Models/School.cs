using GeneralJw.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace KingoJw.Models
{
    public class School : ISchool
    {
        [JsonProperty("xxmc")]
        public string Name { get; set; }

        [JsonProperty("xxdm")]
        public string IdCode { get; set; }

        [JsonProperty("serviceUrl")]
        public string ServiceUrl { get; set; }
    }
}
