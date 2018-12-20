using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.JsonObjects
{
    public class Userv5
    {
        public object id { get; set; }
        public string name { get; set; }
        public List<string> roles { get; set; }
    }

    public class Datav5
    {
        public Userv5 user { get; set; }
        public string token { get; set; }
    }

    public class AuthResponsev5
    {
        public bool success { get; set; }
        public Datav5 data { get; set; }
        public List<object> errors { get; set; }
    }

    public class Rolev6
    {
        public string name { get; set; }
        public int id { get; set; }
        public int version { get; set; }
    }

    public class Permissionv6
    {
        public int id { get; set; }
        public string action { get; set; }
        public string resourceId { get; set; }
        public string resourceType { get; set; }
    }

    public class Userv6
    {
        public int id { get; set; }
        public string email { get; set; }
        public string username { get; set; }
        public object domain { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int version { get; set; }
        public int principalId { get; set; }
        public bool deleted { get; set; }
        public List<Rolev6> roles { get; set; }
        public List<Permissionv6> permissions { get; set; }
        public List<string> licenseFeatures { get; set; }
        public bool emailVerified { get; set; }
        public bool passwordSet { get; set; }
        public bool questionsSet { get; set; }
        public bool enableAutoLogin { get; set; }
        public bool disabled { get; set; }
        public bool clientRegistered { get; set; }
        public string description { get; set; }
        public int createdBy { get; set; }
        public DateTime createdOn { get; set; }
        public int updatedBy { get; set; }
        public DateTime updatedOn { get; set; }
        public object publicKey { get; set; }
        public object appType { get; set; }
        public object routingName { get; set; }
        public object appUrl { get; set; }
    }

    public class AuthResponsev6
    {
        public string token { get; set; }
        public Userv6 user { get; set; }
    }

    public class AuthResponsev6_401
    {
        public string code { get; set; }
        public string details { get; set; }
        public string message { get; set; }
    }
}
