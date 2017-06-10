using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Repository;
using Model;

namespace ConsoleEngine
{
    public class Engine
    {
        public string Options()
        {
            Console.WriteLine("Type \"new user\" to register a new user, \"show users\" to print a list of users or \"exit\" to quit the program...");
            return Console.ReadLine();
        }
        public void RegisterUser()
        {
            using (var db = new WebstoreContext())
            {
                Console.WriteLine("Type username: ");
                var newUsername = Console.ReadLine();

                var newUser = new User { Username = newUsername };
                newUser.Password = new string(newUsername.ToCharArray().Reverse().ToArray());
                db.Users.Add(newUser);
                db.SaveChanges();

                var newUserQuery = from u in db.Users
                                   where newUsername == u.Username
                                   select u;

                foreach (var item in newUserQuery)
                    Console.WriteLine("New user created: {0}", item.Username);
            }
        }
        public void PrintAllUsers()
        {
            using (var db = new WebstoreContext())
            {
                var users = from u in db.Users
                            orderby u.Username
                            select u;
                foreach (var user in users)
                    Console.WriteLine("User {0}: {1}", user.UserId, user.Username);
                            
            }
        }
    }
}
