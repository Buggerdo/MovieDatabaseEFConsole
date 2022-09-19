namespace MovieDatabaseEFConsole.Models
{
    public partial class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Genre { get; set; } = null!;

        public Movie(string title, string genre)
        {
            Title = title;
            Genre = genre;
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
            return $"Title: {Title}\nGenre: {Genre}\n";
        }
    }
}