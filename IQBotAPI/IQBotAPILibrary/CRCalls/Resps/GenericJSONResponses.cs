using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.CRCalls.Resps
{
    class GenericJSONResponses
    {

        public class Role_AuthCR200
        {
            public string name { get; set; }
            public int id { get; set; }
            public int version { get; set; }
        }

        public class Permission_AuthCR200
        {
            public int id { get; set; }
            public string action { get; set; }
            public string resourceId { get; set; }
            public string resourceType { get; set; }
        }

        public class User_AuthCR200
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
            public List<Role_AuthCR200> roles { get; set; }
            public List<Permission_AuthCR200> permissions { get; set; }
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

        public class AuthResponse_200
        {
            public string token { get; set; }
            public User_AuthCR200 user { get; set; }
        }
    }
}
