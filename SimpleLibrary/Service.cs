
using System.Net;
using System.Net.Http.Headers;

namespace SimpleLibrary
{
    public class Service
    {
        public Repository Repository;
        

        public Service()
        {
            Repository = new Repository();
        }
        public static void Greeting()
        {
            Console.WriteLine("Welcome to the library service app!");
        }
        
        public void AddLibrary()
        {
            Repository.InsertLibrary(new LibraryEntity());
        }
        public static string AskLibraryTitle()
        {
            Console.WriteLine("You are adding a new library. Please enter the title:");
            string libTitle = Console.ReadLine();
            
            return libTitle;
        }

        public void ShowLibraries()
        {   var libraries = Repository.GetAllLibs();

            foreach (var lib in libraries)
            {
                Console.WriteLine($"Library id: {lib.Id}, Library title: {lib.LibTitle}");
            } 
        }

        

        public void AddBook()  
        {
            var library = ChooseLibrary();
            
            var newBook = new BookEntity
            {
                LibraryId = library.Id,
                Title = AskBookTitle(),
                Author = AskAuthor(),
                Year = AskYear()
            };
           
            Repository.InsertBook(newBook);
            ShowAddedBook(newBook);
        }
        
        public void ShowBooks()
        {
            
        }

        private LibraryEntity ChooseLibrary()
        {
            Console.WriteLine("To add a book choose library id:");

            foreach (var lib in Repository.GetAllLibs())
            {
                Console.WriteLine($"Id: {lib.Id}, Title: {lib.LibTitle}");
            }

 
            return Repository.GetLibrary(int.Parse(Console.ReadLine()));
        }

        public static string AskBookTitle()
        {
            Console.Clear();
            Console.WriteLine("You are adding a new book. Please enter the title:");
            string bookTitle = Console.ReadLine();

            return bookTitle;
        }

        public static string AskAuthor()
        {
            Console.Clear();
            Console.WriteLine("Please enter the author:");
            string bookAuthor = Console.ReadLine();

            return bookAuthor;
        }

        public static int AskYear()
        {
            Console.Clear();
            Console.WriteLine("Please enter the publication year:");
            var bookYear = int.Parse(Console.ReadLine());

            return bookYear;
        }

        private static void ShowAddedBook(BookEntity newBook)
        {
            Console.WriteLine("You added a new book!");
            Console.WriteLine($"Book id: {newBook.Id}");
            Console.WriteLine($"Library id: {newBook.LibraryId}");
            Console.WriteLine($"Book Title: {newBook.Title}");
            Console.WriteLine($"Book Author: {newBook.Author}");
            Console.WriteLine($"Published: {newBook.Year}");
        }
    }
}
