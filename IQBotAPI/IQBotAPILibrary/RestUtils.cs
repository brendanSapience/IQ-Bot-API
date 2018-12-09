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
    public class RestUtils
    {

        public static String SendAuthRequest(String URL, String Body)
        {
            return SendPostRequest(URL,Body, null);
        }

        public static String SendPostRequest(String URL, String Body, String Token)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            if(Token != null)
            {
                httpWebRequest.Headers["x-access-token"] = Token;
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
                return Resp;

            }
            catch (System.Net.WebException e)
            {
                
                var response = (HttpWebResponse)e.Response;
                String Resp = GetResponseFromStream(response.GetResponseStream());
                return Resp;
            }
        }

        public static String SendGetRequest(String URL,String AuthToken)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers["x-access-token"] = AuthToken;
            httpWebRequest.Method = "GET";

            try
            {

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                String Resp = GetResponseFromStream(httpResponse.GetResponseStream());

                return Resp;

            }
            catch (System.Net.WebException e)
            {

                var response = (HttpWebResponse)e.Response;
                String Resp = GetResponseFromStream(response.GetResponseStream());

                return Resp;
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
