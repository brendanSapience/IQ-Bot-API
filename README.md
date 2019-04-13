# IQ-Bot-API

Automation Anywhere IQ Bot API and Metabot

### Prerequisites

IQ Bot version 6.5+

### General Info

this API combines calls that are SQL Based and calls that are Rest based. The metabot is built on top of the API.

### Getting Started for Metabot Usage

* Download the mbot file from the Delivery folder, add it to your AAE Meetabot folder

### Getting Started with API

* Download the dll file from the Delivery folder, add it to your .NET project
* Use the following code to initiate the API:

```         
            // initiate the broker for SQL and for Rest
            ConnectionBroker broker = new ConnectionBroker("localhost",1434,"myadmin","MYPassword");
            ConnectionBroker rbroker = new ConnectionBroker("http://localhost", 3000, @"creator", @"MyPassword",9996);

            // initiate the apicalls libraries
            _530ReadDBAPICalls apicallsR = new IQBotAPILibrary._530ReadDBAPICalls(broker);
            _530WriteDBAPICalls apicallsW = new IQBotAPILibrary._530WriteDBAPICalls(broker);
            _530ReadRestAPICalls apicallsRest = new _530ReadRestAPICalls(rbroker);

            // submit Rest api calls
            resp = apicallsRest.GetAllLearningInstances();
```


### Available Functions (SP0)

SQL Based Methods:


Rest Based Methods:

* Generate Authentication Token (returns a valid authentication token to use in all other calls)
* Get Learning Instance ID From Name (returns the internal ID of a LI)
* Get Learning Instance Statistics (returns the statistics of an LI based on its internal ID)
* Get Validation Queue Count (returns the current number of files in the validation queue of an LI)


### Formats

All Responses are in JSON format or CSV format (depending on the value of variable vInputJsonResponse (true or false))


## Authors

* **Bren Sapience** - *Initial work* - [GitHub](https://github.com/BrendanSapience)
