using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IQBotAPILibrary
{

    public class DBAPICalls
    {
        ConnectionBroker broker;
        public DBAPICalls(ConnectionBroker broker)
        {
            this.broker = broker;
        }

        public String GetIQBotConfiguration()
        {
            SqlDataReader sqlr = this.broker.runQuery("Configurations", "select TOP 1 * from CognitivePlatformNodes");
            return JsonUtils.getConfigAsJson(sqlr);
        }

        public String GetIQBotLearningInstances()
        {
            SqlDataReader sqlr = this.broker.runQuery("FileManager", "SELECT * FROM ProjectActivityDetail");
            return JsonUtils.getLIsAsJson(sqlr);
        }
    }
}
