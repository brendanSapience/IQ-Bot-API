using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IQBotAPILibrary
{
    public class ConnectionBroker
    {
        String SQLServerHostname = "";
        String RestEndpointURL = "";
        int SQLServerPort = 1433;
        String SQLUser = "";
        String SQLPassword = "";
        String RestLogin = "";
        String RestPassword = "";
        int RestAuthEndpointPort = 3000;
        int RestEndpointPort = 3000;
        String DBName_AliasData = "AliasData";
        String DBName_ClassifierData = "ClassifierData";
        String DBName_Configurations = "Configurations";
        String DBName_FileManager = "FileManager";
        String DBName_MLData = "MLData";

        SqlConnection myConnection;

        public ConnectionBroker(String SQLHost, int SQLPort, String SQLLogin, String SQLPassword)
        {
            this.SQLServerHostname = SQLHost;
            this.SQLServerPort = SQLPort;
            this.SQLUser = SQLLogin;
            this.SQLPassword = SQLPassword;
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
                this.DBName_Configurations+";User ID="+this.SQLUser+";Password="+this.SQLPassword+ ";integrated security=false";

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
