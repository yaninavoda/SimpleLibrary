﻿namespace SimpleLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var repo = new Repository();
            Service.Greeting();
            repo.Insert(new LibraryEntity());

            Console.ReadKey();
        }
    }
}