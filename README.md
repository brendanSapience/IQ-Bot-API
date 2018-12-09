# IQ-Bot-API

Automation Anywhere IQ Bot API

### Prerequisites

IQ Bot version 5.3+
Not tested with IQ Bot v6.0

### General Info

this API combines calls that are SQL Based and calls that are Rest based.

### Getting Started

* Download the dll file from the Delivery folder, add it to your .NET project
* Use the following code to initiate the API:

```         
            // initiate the broker for SQL and for Rest
            ConnectionBroker broker = new ConnectionBroker("localhost",1434,"aaadmin","Un1ver$e123");
            ConnectionBroker rbroker = new ConnectionBroker("http://localhost", 3000, @"creator", @"Un1ver$e",9996);

            // initiate the apicalls libraries
            _530ReadDBAPICalls apicallsR = new IQBotAPILibrary._530ReadDBAPICalls(broker);
            _530WriteDBAPICalls apicallsW = new IQBotAPILibrary._530WriteDBAPICalls(broker);
            _530ReadRestAPICalls apicallsRest = new _530ReadRestAPICalls(rbroker);

            // submit Rest api calls
            resp = apicallsRest.GetAllLearningInstances();
```


### Available Functions (SP0)

SQL Based Calls:

* GetIQBotConfiguration
* GetIQBotLearningInstances
* GetLIFiles
* GetLIUnclassifiedFiles
* GetLIDetails
* GetFileDetails
* GetClassificationReport
* GetCustomFields
* GetInvalidFiles
* GetExportImportActivities
* GetListOfCorrectedValues
* GetListOfDomains
* GetListOfLanguages
* GetGroupFromFilename
* SetLearningInstanceName

Rest Based Calls:

* GetAllLearningInstances

### Formats

All Responses are in JSON format


## Authors

* **Bren Sapience** - *Initial work* - [GitHub](https://github.com/BrendanSapience)


