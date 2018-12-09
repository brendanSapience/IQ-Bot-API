using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace IQBotAPILibrary
{
    public class _530WriteDBAPICalls
    {
        ConnectionBroker broker;
        public _530WriteDBAPICalls(ConnectionBroker broker)
        {
            this.broker = broker;
        }

        public void SetLearningInstanceName(String LearningInstanceID, String NewLIName)
        {

            String Request = "UPDATE FileManager.dbo.ProjectDetail SET Name = '"+ NewLIName + "' WHERE Id = '"+ LearningInstanceID + "';";

            SqlDataReader sqlr = this.broker.runQuery("FileManager", Request);
            //return JsonUtils.getConfigAsJson(sqlr);
        }
    }
}
