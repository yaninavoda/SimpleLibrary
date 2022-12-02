namespace SimpleLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {              
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var service = new Service();

            service.Greeting();
            service.GetCommand();
            
            Console.ReadKey();
        }
    }
}