MOVIE DATABASE - EF Console
Objective:  Build a Movie database and an EF/Console app that uses it. You will use this database in future labs.


Build Specifications:
Use Database First and create a movie database. The database should contain a table named “Movies” with the following Columns: 
	int Id - Primary Key
	nvarchar(50) Title
	nvarchar(20) Genre
	float Runtime 
Create a static function in your program class that populates your table with 10 to 15 movies. Call this function from your main; run it; then remove the call from your main so it doesn’t run again.
Add two static methods to your Movie class:

SearchByGenre: This method will return a list of Movie instances that match the genre.

SearchByTitle: This method will return a list of Movie instances that match the title.

Hint: Use the .ToList() method on the table to get it into list format.


Write a console application that displays a menu and asks the user whether they wish to search by genre or title. Then allow the user to enter either genre or title respectively. Call the appropriate method to retrieve the movies. Print out the movie information to the console.
Tip: Include a ToString() method in your Movie class to make printing easier.

