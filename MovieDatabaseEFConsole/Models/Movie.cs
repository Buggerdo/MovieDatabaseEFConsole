using System;
using System.Collections.Generic;

namespace MovieDatabaseEFConsole.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public double Runtime { get; set; }

        public Movie()
        {
            
        }

        public Movie(string title, string genre, float runTime)
        {
            Title = title;
            Genre = genre;
            Runtime = runTime;
        }

        //SearchByGenre: This method will return a list of Movie instances that match the genre.
        public static List<Movie> SearchByGenre(string input)
        {
            using(var context = new MovieDBContext())
            {
                return context.Movies.Where(m => m.Genre == input).ToList();
            }
        }


        //SearchByTitle: This method will return a list of Movie instances that match the title.
        public static List<Movie> SearchByTitle(string input)
        {
            using(var context = new MovieDBContext())
            {
                return context.Movies.Where(m => m.Title.StartsWith(input)).ToList();
            }
        }

        public override string ToString()
        {
            return $"\nTitle: {Title}\nGenre: {Genre}\nRun Time: {Runtime}";
        }
    }
}
