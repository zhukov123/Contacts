# Contacts
Contacts REST API

This Contacts REST API is built with Microsoft Web API using .Net Core. MongoDB is used as the storage solution, and the application has been hosted in Azure, with Azure's DocumentDB.

You can test the service at the following URL using Postman or a similar tool.

http://contactsvk.azurewebsites.net/api/contact/

The API supports the following methods:

### Get All Records:
GET http://contactsvk.azurewebsites.net/api/contact/

### Get Single Record (By Id)
GET http://contactsvk.azurewebsites.net/api/contact/[id]

### Create record (complete record with Id and LastModified time will be returned)
POST http://contactsvk.azurewebsites.net/api/contact/
Json content sample (raw)

{  
  "firstName": "Darth",  
  "lastName": "Vader",  
  "email": "vader@empire.com",  
  "phoneNumber": "123-456-7894",  
  "statusIsActive": true  
}

### Update Single Record (By Id)
http://contactsvk.azurewebsites.net/api/contact/[id]
Json content sample (raw)
{  
  "id": "58eefe267861602284469564",  
  "firstName": "Darth",  
  "lastName": "Maul",  
  "email": "maul@empire.com",  
  "phoneNumber": "123-456-7894",  
  "statusIsActive": true  
}

### Remove Record (By Id)
DELETE http://contactsvk.azurewebsites.net/api/contact/[id]
