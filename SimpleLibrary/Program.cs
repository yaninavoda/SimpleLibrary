namespace SimpleLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {              
            var service = new Service();

            //service.Greeting();
            service.GetCommand();
            //service.ShowLibraries();
            //service.AddLibrary();
            //service.AddBook();
            //service.ShowBooks();

            Console.ReadKey();
        }
    }
}