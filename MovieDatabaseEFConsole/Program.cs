using MovieDatabaseEFConsole.Models;

namespace MovieDatabaseEFConsole
{
    internal class Program
    {
        static void Main()
        {
            CreateMovies();
            //Movie.SearchByGenre();
            Movie.SearchByTitle();

            static void CreateMovies()
            {
                List<Movie> movieList = new();

                using(var context = new MovieDBContext())
                {
                    var AllMovies = context.Movies.ToList();


                    if(AllMovies.Count == 0)
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
