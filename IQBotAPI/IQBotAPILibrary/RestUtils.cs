using IQBotAPILibrary.JsonObjects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary
{
    public class RestResponse
    {
        public HttpStatusCode RetCode;
        public String RetResponse;
        public RestResponse(HttpStatusCode rc, string resp)
        {
            this.RetCode = rc;
            this.RetResponse = resp;
        }
    }

    public class RestUtils
    {

        public static RestResponse SendAuthRequest(String URL, String Body,int IQBotMajorVersion)
        {
            return SendPostRequest(URL,Body, null, IQBotMajorVersion);
        }

        public static RestResponse SendPostRequest(String URL, String Body, String Token, int IQBotMajorVersion)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            if(Token != null)
            {
                switch (IQBotMajorVersion){
                    case 5:
                        httpWebRequest.Headers["x-access-token"] = Token;
                        break;
                    case 6:
                        httpWebRequest.Headers["x-authorization"] = Token;
                        break;
                }
            }
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "POST";
            using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
            {
                string json = Body;
                streamWriter.Write(json);
                streamWriter.Flush();
            }

            try
            {
                
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                String Resp = GetResponseFromStream(httpResponse.GetResponseStream());
                RestResponse rp = new RestResponse(httpResponse.StatusCode,Resp);
                return rp;

            }

            catch (System.Net.WebException e)
            {

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                String Resp = GetResponseFromStream(httpResponse.GetResponseStream());
                RestResponse rp = new RestResponse(httpResponse.StatusCode, Resp);
                return rp;
            }
        }

        public static RestResponse SendGetRequest(String URL,String AuthToken,int MajorVersion)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            switch (MajorVersion)
            {
                case 5:
                    httpWebRequest.Headers["x-auth-token"] = AuthToken;
                    break;
                case 6:
                    httpWebRequest.Headers["x-authorization"] = AuthToken;
                    break;
                default:
                    httpWebRequest.Headers["x-authorization"] = AuthToken;
                    break;
            }

            
            httpWebRequest.Method = "GET";

            try
            {

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                String Resp = GetResponseFromStream(httpResponse.GetResponseStream());
                RestResponse rp = new RestResponse(httpResponse.StatusCode, Resp);
                return rp;

            }
            catch (System.Net.WebException e)
            {
                Console.WriteLine("Error: "+e.Message);
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                String Resp = GetResponseFromStream(httpResponse.GetResponseStream());
                RestResponse rp = new RestResponse(httpResponse.StatusCode, Resp);
                return rp;
            }
        }

        private static String GetResponseFromStream(Stream s)
        {
            String resp = "";
            using (var streamReader = new System.IO.StreamReader(s))
            {
                resp = streamReader.ReadToEnd();
                return resp;
            }

        }
    }
}
