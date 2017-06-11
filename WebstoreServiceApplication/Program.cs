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
                if (choice.Equals("new user"))
                    engine.RegisterUser();
                else if (choice.Equals("login"))
                    engine.Login();
                else if (choice.Equals("show users"))
                    engine.PrintAllUsers();
                else if (choice.Equals("new product"))
                    engine.CreateProduct();
                else if (choice.Equals("exit"))
                    break;
            }
            

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
