# Portfolio

Welcome to my development portfolio!

The projects contained in this repository should be taken as a proof-of-concept product, intended to be viewed from an educational standpoint.
Each project will contain concepts that were new to me at the time of developing them. 

The goal of this repository is to show some level of understanding on business-oriented software concepts. Thanks for viewing!

## BugReporter
BugReporter is a WinForms application, designed to be a bug report windows application which has the capabilities of alerting developers to new problems.

Technical challenges of this project include:
- SMTP server
- Asynchronous programming
- Field validation
- Data formatting
- UI

## GithubAPI
GithubAPI is a Console application, designed to access various endpoints of the [Github API](https://api.github.com), and display that data in a human-readable format.

Technical challenges of this project include:
- HTTPClient usage
- Asynchronous programming
- Logging
- Reflection
- User input (validation, processing and response)

## TipoutCalculator
TipoutCalculator is a WinForms application, designed to divide cash/credit tips among n employees based on the entire day or hours worked.

Technical challenges of this project include:
- UI
- Event handling
- Multiple windows
- Basic arithmetic
- LINQ
- String manipulation

# Dependencies
The following dependencies and the projects that require them are listed below:

- [LiteNetLib 1.2.0](https://github.com/RevenantX/LiteNetLib/releases/tag/v1.2.0)
   - Chat (client, server)
- [MailKit](https://github.com/jstedfast/MailKit)
   - BugReporter
- [Newtonsoft.JSON](https://www.newtonsoft.com/json) (13.0.3)
   - GithubAPI