# IQ-Bot-API

Automation Anywhere IQ Bot API

### Prerequisites

IQ Bot version 5.3+

### Getting Started

1- Download the dll file from the Delivery folder, add it to your .NET project
2- Use the following code to initiate the API:

```         
           // initiate the broker
            ConnectionBroker broker = new ConnectionBroker("localhost",1434,"aaadmin","Un1ver$e123");
            // initiate the SQL Connection
            broker.initiateSQLConnection();
            // initiate the apicalls library
            DBAPICalls apicalls = new IQBotAPILibrary.DBAPICalls(broker);
            // submit api calls
            String resp = apicalls.GetIQBotLearningInstances();
```


### Available Functions (SP0)

* GetIQBotConfiguration
* GetIQBotLearningInstances

### Formats

All Responses are in JSON format


## Authors

* **Bren Sapience** - *Initial work* - [GitHub](https://github.com/BrendanSapience)


