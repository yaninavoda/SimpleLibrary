
namespace SimpleLibrary
{
    public class Service
    {
        //private Repository? _libRepository;
        public static void Greeting()
        {
            Console.WriteLine("Welcome to the library service app!");
        }

        public static string AskLibraryTitle()
        {
            Console.WriteLine("You are adding a new library. Please enter the title:");
            string libTitle = Console.ReadLine();
            
            return libTitle;
        }
        //public static LibraryEntity AddLibrary()
        //{
              
        //}

        public void AddBook() { }
        public void ShowLibraries() { }
        public void ShowBooks() { }
    }
}
