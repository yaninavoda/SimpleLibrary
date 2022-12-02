using FluentValidation.Results;

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
            string? input;
            do
            {   Console.Clear();

                Console.WriteLine("Choose operation:\n" +
                    "(-lib_c) - create library,\n" +
                    "(-book_c) - create book,\n" +
                    "(-lib_list) - print all libraries,\n" +
                    "(-book_list) - print all books in the chosen library,\n" +
                    "(-out) - exit:");

                input = Console.ReadLine();

                switch (input)
                {
                    case "-lib_c":
                        AddLibrary();
                        break;
                    case "-book_c":
                        AddBook();
                        break;
                    case "-lib_list":
                        //Console.Clear();
                        ShowLibraries();
                        break;
                    case "-book_list":
                        //Console.Clear();
                        ShowBooks();
                        break;

                    case "-out":
                        break;
                    default:
                        continue;
                }
            } while (input != "-out");

            Console.ReadKey();

        }
        public void AddLibrary()
        {
            var newLibrary = new LibraryEntity
            {
                LibTitle = AskLibraryTitle()
            };

            var libraryValidator = new LibraryValidator();
            ValidationResult results = libraryValidator.Validate(newLibrary);

            if (! results.IsValid)
            {
                Console.WriteLine($"{results.Errors.First()}");
                Console.WriteLine();
                Console.WriteLine("Press any key to proceed.");
                Console.ReadKey();
            }
            else
            {
                _libraries.Insert(newLibrary);
            }           
        }

        public void AddBook()
        {
            var library = ChooseLibrary();

            if (library != null)
            {
                var newBook = new BookEntity
                {
                    LibraryId = library.Id,
                    Title = AskBookTitle(),
                    Author = AskAuthor(),
                    Year = AskYear()
                };

                var bookValidator = new BookValidator();
                ValidationResult results = bookValidator.Validate(newBook);

                if (!results.IsValid)
                {
                    foreach (var failure in results.Errors)
                    {
                        Console.WriteLine("Property " + failure.PropertyName +
                            " failed validation. Error was: " + failure.ErrorMessage);
                    }

                    Console.WriteLine();
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadKey();
                }
                else
                {
                    Console.Clear();

                    _books.Insert(newBook);

                    ShowAddedBook(newBook);
                }
            }
             
        }
        public static string AskLibraryTitle()
        {
            Console.WriteLine("You are adding a new library. Please enter the title:");
            string? libTitle = Console.ReadLine();
            
            return libTitle ?? string.Empty;
        }

        public void ShowLibraries()
        {   
            
            var libraries = _libraries.GetAll();

            foreach (var lib in libraries)
            {
                Console.WriteLine($"Library id: {lib.Id}, Library title: {lib.LibTitle}");
            }

            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        public void ShowBooks()
        { 
            var library = ChooseLibrary();

            if (library != null)
            {
                foreach (var book in _books.GetAll())
                {
                    if (book.LibraryId == library.Id)
                    {
                        ShowBook(book);
                    }
                }
            }
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
        }

        private LibraryEntity? ChooseLibrary()
        {
            Console.WriteLine("Choose library id:");

            foreach (var lib in _libraries.GetAll())
            {
                Console.WriteLine($"Id: {lib.Id}, Title: {lib.LibTitle}");
            }

            if (int.TryParse(Console.ReadLine(), out int libraryId)) 
            {
                if (libraryId <= _libraries.GetAll().Count)
                {
                    return _libraries.Get(libraryId);
                }
                else Console.WriteLine("You entered an incorrect library id.");

                return null;
            }
            else Console.WriteLine("id must be a number.");

            return null;
        }

        public static string AskBookTitle()
        {
            Console.Clear();
            Console.WriteLine("You are adding a new book. Please enter the title:");
            string? bookTitle = Console.ReadLine();

            return bookTitle ?? string.Empty;
        }

        public static string AskAuthor()
        {
            Console.Clear();
            Console.WriteLine("Please enter the author:");
            string? bookAuthor = Console.ReadLine();
            
            return bookAuthor ?? string.Empty;
        }

        public static int AskYear()
        {
            Console.Clear();
            Console.WriteLine("Please enter the publication year:");

            if (int.TryParse(Console.ReadLine(), out int bookYear))
            {
                return bookYear;
            }
            else
            {
                Console.WriteLine("Publication year must be a number.");

                return int.MaxValue;
            }  
        }
        private static void ShowAddedBook(BookEntity newBook)
        {
            Console.WriteLine("You added a new book!");

            ShowBook(newBook);

            Console.WriteLine();
            Console.WriteLine("Press any key to continue.");
            Console.ReadKey();
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
