## REST API for Small Reservation Management System


Technologies: 
  - ASP .NET Core 5.0.3
  - Entity Framework. 
  - Microsoft SQL Server 2019 Express Edition.
  - (Preferably) Microsoft Visual Studio Professional 2019 Version 16.8.5  


# Installing with Visual Studio: 
    1. Open the solution in VS
    2. (Optional) Modify the connection string in appsettings.json to reflect your database environment
    3. Open Package Manager Console and and run the following commands
        Add-Migration Initial
        Update-Database
    4. Build and run the Project

# Installing without Visual Studio (dotnet CLI):
    1. In Console (cmd, poweshell, dotnet CLI) navigate to Backend directory
    2. (Optional) Modify the connection string in appsettings.json to reflect your database environment
    3. Run the following commands:
        dotnet restore
        dotnet ef migrations add InitialCreate
        dotnet ef database update
        dotnet build
        dotnet run
        
# Features
  This projects allow to storage data related to a Reservation Managements System. 
  It has two controllers (Contacts and Reservations) that support CRUD operations (GET, POST, PUT, DELETE):
