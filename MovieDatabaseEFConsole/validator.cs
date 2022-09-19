namespace MovieDatabaseEFConsole
{
    public class validator
    {
        //get user input
        public static string GetUserInput(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }

        //validate user input
        public static bool ValidateUserInput(string userInput)
        {
            if(userInput == "genre" || userInput == "title")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
