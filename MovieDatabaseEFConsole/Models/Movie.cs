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
        public static void SearchByGenre()
        {

            Console.Write("Please enter the genre you would like to see: ");

            string userInput = Console.ReadLine();
            using(var context = new MovieDBContext())
            {
                if(!string.IsNullOrWhiteSpace(userInput))
                {
                    try
                    {
                        Console.Clear();
                        Movie genre = context.Movies.Where(s => s.Genre.StartsWith(userInput)).First();
                        Console.WriteLine($"List of {genre.Genre} movies.");
                        foreach(var m in context.Movies)
                        {
                            if(m.Genre == genre.Genre)
                            {
                                Console.WriteLine($"{m.Title}");
                            }
                        }
                        return;
                    }
                    catch(Exception)
                    {
                        Console.WriteLine($"Sorry {userInput} is not a valid genre.");
                        return;
                    } 
                }
                Console.WriteLine("Sorry that is not a valid entry.");
            }
        }

        //SearchByTitle: This method will return a list of Movie instances that match the title.
        public static void SearchByTitle()
        {
            Console.Write("Please enter the title you are looking for: ");

            string userInput = Console.ReadLine();
            using(var context = new MovieDBContext())
            {
                if(!string.IsNullOrWhiteSpace(userInput))
                {
                    try
                    {
                        Console.Clear();               
                        foreach(var m in context.Movies)
                        {
                            if(m.Title.StartsWith(userInput ,StringComparison.OrdinalIgnoreCase))
                            {
                                Console.WriteLine($"{m.Title} {m.Genre}");
                            }
                        }
                        return;
                    }
                    catch(Exception)
                    {
                        Console.WriteLine($"Sorry {userInput} is not a valid genre.");
                        return;
                    }
                }
                Console.WriteLine("Sorry that is not a valid entry.");
            }
        }
    }
}
