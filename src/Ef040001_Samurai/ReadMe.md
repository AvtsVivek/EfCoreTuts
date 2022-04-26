

1.	To generate the ER diagrams, install the EfCore tools extension.
	Then right click the data project(not the webApi project), 
	and select EF Core Power Tools -> Add DbContext Diagram.

2.  SamuraiApp.WebApi is needed because, with this project, 
	the sqlite database gets created at the project level and we can see that
	SamuraiAppDataFirstLook.Sqlite. Where as in the console application, 
	the database is created deep inside of the bin folder.

3.	This is needed on the machine. 
	dotnet tool install --global dotnet-ef
	Then run the command get-help entityframework

4.	Add-Migration Init
	Script-Migration
	Update-Database -verbose

	When you add a migration do the following. First set the start up project. 
	This should be the web project. 
	Then in the package manager console, select the Samurai.Data in the default proejct dropdown.

5.	The SamuraiScaffoldConsole Project is understaning how to reverse engineer a database.
	This is a good way to create a dbcontext with its efcore configuration.
	So just create some database with relationships, and you can know from it how 
	to create model classes for it.

6.  For Reverse engineering, create a .net project simila to SamuraiScaffoldConsole.
	Ensure necessary refernces are in place(see the proj file.)
	In the package manager console, select the Default project to be SamuraiScaffoldConsole(or what ever yours is)
	Then also ensure the project SamuraiScaffoldConsole is startup project.
	Finally run the following command.
	Set the project SamuraiScaffoldConsole as startup project.
	scaffold-dbcontext -provider Microsoft.EntityFrameworkCore.SqlServer -connection "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=SamuraiAppDataFirstLook;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" -Force


