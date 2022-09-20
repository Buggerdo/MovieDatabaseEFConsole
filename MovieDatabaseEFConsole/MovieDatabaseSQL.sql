CREATE DATABASE MovieDB;

CREATE TABLE Movies (
	ID int IDENTITY(1,1) PRIMARY KEY NOT NULL,
	Title varchar(50) NOT NULL,
	Genre varchar(20) NOT NULL,
	RunTime FLOAT (53) NOT NULL,
);

SELECT * FROM Movies;

DELETE FROM Movies;

DROP TABLE Movies;




--	Scaffold-DbContext 'Data Source=TROYSPC;Initial Catalog=MovieDB; Integrated Security=SSPI;' Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models

--  ef dbcontext scaffold 'Data Source=TROYSPC;Initial Catalog=MovieDB; Integrated Security=SSPI;' Microsoft.EntityFrameworkCore.SqlServer --output-dir=Models --force

 --  Scaffold-DbContext "Server=(localdb)\v11.0;Database=Blogging;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force


        --//SearchByGenre: This method will return a list of Movie instances that match the genre.
        --public static List<Movie> SearchByGenre(string input)
        --{
        --    using(var context = new MovieDBContext())
        --    {
        --        return context.Movies.Where(m => m.Genre == input).ToList();
        --    }
        --}


        --//SearchByTitle: This method will return a list of Movie instances that match the title.
        --public static List<Movie> SearchByTitle(string input)
        --{
        --    using(var context = new MovieDBContext())
        --    {
        --        return context.Movies.Where(m => m.Title.StartsWith(input)).ToList();
        --    }
        --}

        --public override string ToString()
        --{
        --    return $"Title: {Title}\nGenre: {Genre}\n";
        --}
