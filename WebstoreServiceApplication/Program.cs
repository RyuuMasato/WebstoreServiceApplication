using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleEngine;

namespace WebstoreServiceApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            while (true)
            {
                string choice = engine.Options();
                if (choice.Equals("new user") || choice.Equals("1"))
                    engine.RegisterUser();
                else if (choice.Equals("login") || choice.Equals("2"))
                    engine.Login();
                else if (choice.Equals("show users") || choice.Equals("3"))
                    engine.PrintAllUsers();
                else if (choice.Equals("new product") || choice.Equals("4"))
                    engine.CreateProduct();
                else if (choice.Equals("show products") || choice.Equals("5"))
                    engine.PrintAllProducts();
                else if (choice.Equals("exit") || choice.Equals("6"))
                    break;
            }
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
