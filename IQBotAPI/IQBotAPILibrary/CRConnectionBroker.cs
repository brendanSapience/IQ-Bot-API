using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using IQBotAPILibrary.JsonObjects;
using Newtonsoft.Json;
using IQBotAPILibrary.CRCalls;
using static IQBotAPILibrary.CRCalls.Resps.GenericJSONResponses;

namespace IQBotAPILibrary
{
    public class CRConnectionBroker
    {
        Boolean IsSqlConnectionOK = false;
        Boolean IsRestConnectionOK = false;

        
        public String RestEndpointURL = "";
        String RestLogin = "";
        String RestPassword = "";
        public String RestAuthToken = "";
        public int CRPort = 8080;

        String SQLServerHostname = "";
        int SQLServerPort = 1433;
        String SQLUser = "";
        String SQLPassword = "";
        int CRMajorVersion = -1;

        String DBName_CR = "CRDB";


        SqlConnection myConnection;

        public CRConnectionBroker(String DBName, String SQLHost, int SQLPort, String SQLLogin, String SQLPassword)
        {
            this.SQLServerHostname = SQLHost;
            this.SQLServerPort = SQLPort;
            this.SQLUser = SQLLogin;
            this.SQLPassword = SQLPassword;

            Boolean ConnectionIsOK = initiateSQLConnection();
            if (!ConnectionIsOK)
            {
                Console.WriteLine(" -- Error: SQL Connection Could Not Be Established.");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            IsSqlConnectionOK = true;
        }

        public CRConnectionBroker(int MajorVersion, String RestBaseURI,int CRPort, String Login, String Password)
        {
            this.RestEndpointURL = RestBaseURI;

            this.RestLogin = Login;
            this.RestPassword = Password;
            this.CRMajorVersion = MajorVersion;
            this.CRPort = CRPort;

            Boolean ConnectionIsOK = false;

            switch (this.CRMajorVersion)
            {
                case 11:
                    
                    ConnectionIsOK = testRestConnectionv11();
                    break;
               
                default:
                    Console.WriteLine("-- Error, IQ Bot Version not supported: "+this.CRMajorVersion);
                    Environment.Exit(-1);
                    break;
            }

            
            if (!ConnectionIsOK)
            {
                Console.WriteLine(" -- Error: REST Connection Could Not Be Established.");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
            IsRestConnectionOK = true;
        }

       

        public Boolean testRestConnectionv11()
        {
            String URL = this.RestEndpointURL + ":" + this.CRPort + "/v1/authentication";
            string json = "{ \"username\" : \"" + this.RestLogin + "\", \"password\" : \"" + this.RestPassword + "\" }";

            RestResponse resp = CRRestUtils.SendAuthRequest(URL, json, this.CRMajorVersion);
            Console.WriteLine("Debug:" + URL);

            //AuthResponsev6_401
            AuthResponse_200 r = JsonConvert.DeserializeObject<AuthResponse_200>(resp.RetResponse);

           
            if (r.token == null)
            {
                Console.WriteLine(" -- Error: REST Authentication failed: "+ resp.RetResponse);
                return false;
            }
            else
            {
                Console.WriteLine("Token: " + r.token);
            }

            this.RestAuthToken = r.token;
            return true;

        }

        public Boolean testSQLConnection()
        {
            try
            {
                this.myConnection.Open();
                //Console.WriteLine("Connection String: "+ this.myConnection.ConnectionString);
                
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public Boolean initiateSQLConnection()
        {
            String connectionString = @"Data Source="+this.SQLServerHostname+","+
                this.SQLServerPort+";Trusted_Connection=yes;connection timeout=30;Initial Catalog="+
                this.DBName_CR+";User ID="+this.SQLUser+";Password="+this.SQLPassword+ ";integrated security=false";

            //Console.WriteLine(connectionString);
            
            this.myConnection = new SqlConnection(connectionString);
            
            Boolean ConnStatus = testSQLConnection();
            if (!ConnStatus)
            {
                Console.WriteLine("Error: could not connect to DB.");
                this.myConnection.Close();
                return false;
            }
            else
            {
                SqlCommand myCommand = new SqlCommand("select * from CognitivePlatformNodes;", this.myConnection);
                SqlDataReader myReader = myCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    //this.myConnection.Close();
                    myCommand.Dispose();
                    myReader.Close();
                   
                    return true;
                }
                else
                {
                    Console.WriteLine("Error: No content was retrieved from DB.");
                    //this.myConnection.Close();
                    myCommand.Dispose();
                    myReader.Close();
                    return false;
                }
            }

        }

        public SqlDataReader runQuery(String DatabaseName, String Query)
        {
            myConnection.ChangeDatabase(DatabaseName);

            SqlDataReader myReader = null;
            SqlCommand myCommand = new SqlCommand(Query, this.myConnection);
            try
            {

                myReader = myCommand.ExecuteReader();
                return myReader;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

        }


    }
}
