# IQ Bot Metabot

Automation Anywhere IQ Bot API and Metabot for IQ Bot

### Prerequisites for IQ Bot Metabot

IQ Bot version 6.5+

### General Info

this API combines calls that are SQL Based and calls that are Rest based. The metabot is built on top of the API.

### Getting Started for Metabot Usage

* Download the mbot file from the Delivery folder, add it to your AAE Meetabot folder

### Available Functions (SP0)

SQL Based Methods:


Rest Based Methods:

* Generate Authentication Token (returns a valid authentication token to use in all other calls)
* Get Learning Instance ID From Name (returns the internal ID of a LI)
* Get Learning Instance Statistics (returns the statistics of an LI based on its internal ID)
* Get Validation Queue Count (returns the current number of files in the validation queue of a LI)

* Get List of Files in Learning Instance (returns the list of files associated / processed in a LI)
* Get Field Accuracy Statistics for Learning Instance
* Get Field Classification Statistics for Learning Instance
* Get Group Definition (List of all Fields and associated Bounds)


### Formats

All Responses are in JSON format or CSV format (depending on the value of variable vInputJsonResponse (true or false))





# Doctools Metabot

Automation Anywhere Metabot for Doctools

### Prerequisites for Doctools Metabot

ABBYY FineReader installed with a valid license
Doctools installed and started


### Getting Started for Metabot Usage

* Download the mbot file from the Delivery folder, add it to your AAE Metabot folder

### Available Functions (SP0)


* Split PDF Document per blank page
* Split PDF Document per blank page v2 (with option to change output folder for generated pdfs and automatically delete temp files)


## Authors

* **Bren Sapience** - *Initial work* - [GitHub](https://github.com/BrendanSapience)
