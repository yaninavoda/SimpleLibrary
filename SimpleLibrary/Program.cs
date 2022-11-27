namespace SimpleLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Service.Greeting();
            var service = new Service();
           
            service.ShowLibraries();
            //service.AddLibrary();
            service.AddBook();


            Console.ReadKey();
        }
    }
}