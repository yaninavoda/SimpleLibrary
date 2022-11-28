namespace SimpleLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {              
            var service = new Service();

            service.Greeting();
            service.GetCommand();
            
            Console.ReadKey();
        }
    }
}