# ContactsRepositoryForInteview
ContactsRepositoryForInteview


1) Create database

- Create [ContactDb] database
- Use table creation script file under folder SqlScriptToCreateTable\CreateTable.sql to create user table


2) Modify connecting string in webconfig file to point to correct SQL server where above database is created


3) Solution Contains two projects
    1)ContactProject  - MVC web application using Model ,view , controller 
                      with views Create. update, details, delete(soft delete- Active/inactive), List
                      
    2)ContactProject.UnitTests - Unit testing project with Dependecy injections with Microsoft Unity 



4) Contact Project Details Structure

- Repository pattern is used as solution to decouple the data access from database provider and we can use different database like oracle,Mysql,
  or any NO relational Db with minimal code change

- .\Repository\IContactRepository - Inteface with insert,update,delete,List like CRUD operations
- .\Repository\ContactRepository - Concreate implemenation of IContactRepository with Disposable pattern implemented


- EFDataModel.edmx & Model1.tt - Entity framework - ORM use to connect SQL server

- .\Controller\MyController.cs - with actionmethods which renders views
   1) Index - List of Contacts with insert,update,delete(active/ inactive)
   2) Details  - Detail of sigle contact
   3) Create - Create new contact
   4) Edit  - Update existing contact
   5) Delete  - only makes existing contact active / inactive (soft delete). record still present in table


- .\Views - .cshtml files
   1) Index - List of Contacts with insert,update,delete(active/ inactive)
   2) Details  - Detail of sigle contact
   3) Create - Create new contact
   4) Edit  - Update existing contact
   5) Delete  - only makes existing contact active / inactive (soft delete). record still present in table

- .Models\ContactModel.cs
   Model with DataAnnotations validation attributes


5) Application_Images - contains images of application in running state



 

 



