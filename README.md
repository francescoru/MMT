# MMT
The solution has been tested for mysql but not for sql.
Changes to make it work with sql have been committed but not tested however should work.
In repository change value to return for the method where I have used stored procedures
To make application work add connection details into appsetings.json file, go from powershell into API directory and run dotnet ef database update.
This will create the database from migrations. Add data and stored procedure to the database from .sql file provided and run api solution.
In case of issue the .sql file contains the script for creating and seeding the all database as well stored procedure so can achieve creation from script too.
Once done you can run the api project.
Leave project running and either test the endpoints or run the console application that consumes the api which will call the four endpoints.
