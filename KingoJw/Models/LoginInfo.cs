using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace KingoJw.Models
{
    internal class LoginInfo
    {
        [JsonProperty("flag")]
        public string Flag { get; set; }

        [JsonProperty("msg")]
        public string Message { get; set; }

        [DefaultValue("")]
        [JsonProperty("token")]
        public string Token { get; set; }

        [JsonProperty("userid")]
        public string UserId { get; set; }

        [JsonProperty("uuid")]
        public string UUID { get; set; }
    }
}
