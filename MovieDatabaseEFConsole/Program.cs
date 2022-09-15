using MovieDatabaseEFConsole.Models;

namespace MovieDatabaseEFConsole
{
    internal class Program
    {
        static void Main()
        {
            CreateMovies();
            List<Movie> searchedByGenre = Movie.SearchByGenre("Action");
            List<Movie> searchedByTitle = Movie.SearchByTitle("c");
            if(searchedByGenre.Count > 0)
            {
                foreach(var movie in searchedByGenre)
                {
                    Console.WriteLine(movie);
                }
            }

            if(searchedByTitle.Count > 0)
            {
                foreach(var movie in searchedByTitle)
                {
                    Console.WriteLine(movie);
                }
            }
        }

        public static void CreateMovies()
        {
            List<Movie> movieList = new();

            using(var context = new MovieDBContext())
            {
                var countMoviesInDB = context.Movies.ToList();

                if(countMoviesInDB.Count == 0)
                {
                    MakeMovieList(movieList);

                    foreach(var movie in movieList)
                    {
                        context.Movies.Add(movie);
                    }
                    context.SaveChanges();
                }
            }
        }

        public static void MakeMovieList(List<Movie> movieList)
        {
            string[] lines = File.ReadAllLines(@".\MovieList.txt");

            foreach(string line in lines)
            {
                string[] entries = line.Split(',');
                Movie newMovie = new(entries[0], entries[1]);
                movieList.Add(newMovie);
            }
            movieList = movieList.OrderBy(x => x.Title).ThenBy(x => x.Genre).ToList();
        }
    }
}
