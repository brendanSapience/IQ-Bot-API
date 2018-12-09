using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    public class User
    {
        public object id { get; set; }
        public string name { get; set; }
        public List<string> roles { get; set; }
    }

    public class Data
    {
        public User user { get; set; }
        public string token { get; set; }
    }

    public class AuthResponse
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public List<object> errors { get; set; }
    }
}
