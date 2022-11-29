namespace SimpleLibrary
{
    public class Service
    {  
        private RepositoryGeneric<LibraryEntity> _libraries;   
        private RepositoryGeneric<BookEntity> _books;

        public Service()
        {
            _libraries = new RepositoryGeneric<LibraryEntity>();
            _books = new RepositoryGeneric<BookEntity>();
        }

        public void Greeting()
        {
            Console.WriteLine("Welcome to the library service app!");
        }
         public void GetCommand()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Choose operation:\n" +
                    "(-lib_c) - create library,\n" +
                    "(-book_c) - create book,\n" +
                    "(-lib_list) - print all libraries,\n" +
                    "(-book_list) - print all books in the chosen library,\n" +
                    "(-out) - exit:");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "-lib_c":
                        AddLibrary();
                        break;
                    case "-book_c":
                        AddBook();
                        break;
                    case "-lib_list":
                        Console.Clear();
                        ShowLibraries();
                        break;
                    case "-book_list":
                        Console.Clear();
                        ShowBooks();
                        break;

                    case "-out":
                        goto Exit;
                    default:
                        continue;
                }
            } while (true);

        Exit:;

            Console.ReadKey();

        }
        public void AddLibrary()
        {
            Console.Clear();

            var newLibrary = new LibraryEntity
            {
                LibTitle = AskLibraryTitle()
            };

            _libraries.Insert(newLibrary);
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
            Console.Clear();

            _books.Insert(newBook);

            ShowAddedBook(newBook);
        }
        public static string AskLibraryTitle()
        {
            Console.WriteLine("You are adding a new library. Please enter the title:");
            string libTitle = Console.ReadLine();
            
            return libTitle;
        }

        public void ShowLibraries()
        {   
            Console.Clear();
            var libraries = _libraries.GetAll();

            foreach (var lib in libraries)
            {
                Console.WriteLine($"Library id: {lib.Id}, Library title: {lib.LibTitle}");
            } 
        }

        public void ShowBooks()
        { 
            Console.Clear();
            var library = ChooseLibrary();
            foreach (var book in _books.GetAll())
            {
                if (book.LibraryId == library.Id)
                {
                    ShowBook(book);
                }
            }
        }

        private LibraryEntity ChooseLibrary()
        {
            Console.WriteLine("Choose library id:");

            foreach (var lib in _libraries.GetAll())
            {
                Console.WriteLine($"Id: {lib.Id}, Title: {lib.LibTitle}");
            }

 
            return _libraries.Get(int.Parse(Console.ReadLine()));
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
            ShowBook(newBook);
        }
        private static void ShowBook(BookEntity book)
        {
            Console.WriteLine($"Book id: {book.Id}");
            Console.WriteLine($"Library id: {book.LibraryId}");
            Console.WriteLine($"Book Title: {book.Title}");
            Console.WriteLine($"Book Author: {book.Author}");
            Console.WriteLine($"Published: {book.Year}");
            Console.WriteLine();
        }
    }
}
