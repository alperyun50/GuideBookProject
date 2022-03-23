# GuideBook RestApi Project

Guide Book RestApi Project with ASP.Net 5 with unit test.

Not: First of all you have to add your actual connection string to appsettings.json file. 
     Then add migrations to your database(MSSQL) with update-database command in package manager console.


HTTP Request/Response FeedBacks:

POST   : api/Guide/AddPerson
DELETE : api/Guide/DeletePerson/{id}
DELETE : api/Guide/RemovePerson/{id}
GET    : api/Guide/GetPerson/{id}
GET    : api/Guide/GetPersons
PUT    : api/Guide/UpdatePerson
POST   : api/Guide/AddCommInfo
DELETE : api/Guide/RemoveCommInfo/{id}
GET    : api/Guide/GetCommInfo/{id}
GET    : api/Guide/Reportx
