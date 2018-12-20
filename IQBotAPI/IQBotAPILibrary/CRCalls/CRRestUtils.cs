using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary.CRCalls
{
    class CRRestUtils
    {

        public static RestResponse SendAuthRequest(String URL, String Body, int CRMajorVersion)
        {
            return SendPostRequest(URL, Body, null, CRMajorVersion);
        }

        public static RestResponse SendPostRequest(String URL, String Body, String Token, int IQBotMajorVersion)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            if (Token != null)
            {
                switch (IQBotMajorVersion)
                {
                    case 11:
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

            HttpWebResponse httpResponse = null;
            try
            {

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                String Resp = GetResponseFromStream(httpResponse.GetResponseStream());
                RestResponse rp = new RestResponse(httpResponse.StatusCode, Resp);
                return rp;

            }

            catch (System.Net.WebException e)
            {

                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    httpResponse = (HttpWebResponse)e.Response;
                    Console.Write("Errorcode: {0}", (int)httpResponse.StatusCode);
                }
                else
                {
                    Console.Write("Error: {0}", e.Status);
                }
                return new RestResponse(httpResponse.StatusCode, GetResponseFromStream(httpResponse.GetResponseStream()));
            }
        }

        public static RestResponse SendGetRequest(String URL, String AuthToken)
        {

            System.Net.HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(URL);
            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Headers["x-authorization"] = AuthToken;
            httpWebRequest.Method = "GET";

            HttpWebResponse httpResponse = null;

            try
            {

                httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                String Resp = GetResponseFromStream(httpResponse.GetResponseStream());
                RestResponse rp = new RestResponse(httpResponse.StatusCode, Resp);
                return rp;

            }
            catch (System.Net.WebException e)
            {
                if (e.Status == WebExceptionStatus.ProtocolError)
                {
                    httpResponse = (HttpWebResponse)e.Response;
                    Console.Write("Errorcode: {0}", (int)httpResponse.StatusCode);
                }
                else
                {
                    Console.Write("Error: {0}", e.Status);
                }
                return new RestResponse(httpResponse.StatusCode, GetResponseFromStream(httpResponse.GetResponseStream()));
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
