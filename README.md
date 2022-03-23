# GuideBook RestApi Project

Summary
Guide Book RestApi Project with ASP.Net 5 with unit test.

Not: First of all you have to add your actual connection string to appsettings.json file. 
     Then add migrations to your sql database with update-database command in package manager console.


HTTP Request/Response FeedBacks:

* **POST**   : api/Guide/AddPerson  ---> Adding person to guidebook
* **DELETE** : api/Guide/DeletePerson/{id}  ---> Deleting person from guidebook with id
* **DELETE** : api/Guide/RemovePerson/{id}  ---> Removing person from guidebook with id
* **GET**    : api/Guide/GetPerson/{id}  ---> Getting one person from guidebook with id
* **GET**    : api/Guide/GetPersons  ---> Getting all persons from guidebook
* **PUT**    : api/Guide/UpdatePerson  ---> Updating person in guidebook
* **POST**   : api/Guide/AddCommInfo  ---> Adding person communication info to guidebook
* **DELETE** : api/Guide/RemoveCommInfo/{id}  ---> Removing person communication info from guidebook with id
* **GET**    : api/Guide/GetCommInfo/{id}  ---> Getting one person communication info from guidebook with id
* **GET**    : api/Guide/Reportx  ---> Getting report info from guidebook
