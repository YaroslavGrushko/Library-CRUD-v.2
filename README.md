# Asp.Net Core Web.API, Entity Framework, SQLite, AngularJs with using a static html page (Microsoft.AspNetCore.StaticFiles).

# How to run the project:  

When you first run the project on your computer, you possibly will need to reboot VS2017 several times.  
You can use author's database. For this:
1) Download the project.
2) Run the project, after that MyDbBooks.db file will be created (in Library-CRUD-master\Library\bin\Debug\netcoreapp1.1\  directory).
3) Replace Library-CRUD-master\Library\bin\Debug\netcoreapp1.1\MyDbBooks.db file with Library-CRUD-master\MyDbBooks.db
4) Run the project again.  


# Features of the project:  

Asp.Net Core Web.API, Entity Framework, SQLite, AngularJs with using a static html page (Microsoft.AspNetCore.StaticFiles).   
The project is a card index of books in a library with CRUD (Create Read Update Delete) operations to a database with the ability to search books by part of Title or AuthorName using WebAPI and related services.  

# SOLID:

1) Single Responsibility Principle  
It is implemented in that business logic is rendered in separate services (CRUDService.cs, SearchService.cs). In addition, ICRUDService.cs is available for the implementation of the database context in CRUDService.cs.
2) Open/Closed Principle  
The project allows the creation of additional services that will be inherited from the interface ICRUDService.cs with further implementation of the Open / Closed Principle.
3) Liskov Substitution Principle  
In the project there is only one class inheritance (public class BooksSQLiteContext: DbContext), which satisfies Liskov Substitution Principle. Because in the DbContext class, there are no Preconditions, Postconditions, and Invariants.
4) Interface Segregation Principle  
All methods of class CRUDService.cs inherited from the ICRUDService.cs interface are not superfluous.
5) Dependency Inversion Principle  
Due to the fact that there is no need to implement various variants of CRUD methods in this project, Dependency Inversion Principle is executed automatically.
