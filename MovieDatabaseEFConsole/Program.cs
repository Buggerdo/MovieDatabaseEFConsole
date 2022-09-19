using MovieDatabaseEFConsole.Models;

namespace MovieDatabaseEFConsole
{
    internal class Program
    {
        static void Main()
        {
            CreateMovies();
            List<Movie> results = Search();
            //List<Movie> searchedByGenre = Movie.SearchByGenre("Action");
            //List<Movie> searchedByTitle = Movie.SearchByTitle("c");



            if(results.Count > 0)
            {
                results.ForEach(m => Console.WriteLine(m));
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
                    movieList.ForEach(m => context.Movies.Add(m));
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

        public static List<Movie> Search()
        {
            string search = WhatToSearch();
            if(search == "genre")
            {
                return Movie.SearchByGenre(validator.GetUserInput("Please enter the genre you would like to see: "));
            }
            else
            {
                return Movie.SearchByTitle(validator.GetUserInput("Please enter the title you would like to search for: "));
            }
        }

        //Ask the user to choose SearchByGenre or SeachByTitle
        public static string WhatToSearch()
        {
            do
            {
                string userInput = validator.GetUserInput("Please chose genre or title: ");
                Console.Clear();
                if(validator.ValidateUserInput(userInput))
                {
                    return userInput;
                }
                Console.WriteLine("That is not a valid input.");
            } while(true);
        }
    }
}
 