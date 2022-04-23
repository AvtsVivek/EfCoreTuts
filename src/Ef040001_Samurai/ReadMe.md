

1.	To generate the ER diagrams, install the EfCore tools extension.
	Then right click the data project(not the webApi project), 
	and select EF Core Power Tools -> Add DbContext Diagram.

2.  SamuraiApp.WebApi is needed because, with this project, 
	the sqlite database gets created at the project level and we can see that
	SamuraiAppDataFirstLook.Sqlite. Where as in the console application, 
	the database is created deep inside of the bin folder.

3.	
