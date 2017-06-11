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
            Console.WriteLine(@"
Type method and press Enter:

1:  new user
2:  login
3:  show users
4:  new product
5:  show products
6:  exit");
            return Console.ReadLine();
        }

        public void CreateProduct()
        {
            using (var db = new WebstoreContext())
            {
                Console.WriteLine("Type product name");
                var prodName = Console.ReadLine();

                Console.WriteLine("Type product price");
                var prodPrice = Double.Parse(Console.ReadLine());

                var newProduct = new Product { Name = prodName, Price = prodPrice};

                db.Products.Add(newProduct);
                db.SaveChanges();

                Console.WriteLine("Created new product with the ID: {0}", GetProductIdByName(newProduct.Name));

                var newProductQuery = from p in db.Products
                                   where prodName == p.Name
                                   select p;

                foreach (var product in newProductQuery)
                    Console.WriteLine("New product created: {0}", product.Name);
            }
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

                Console.WriteLine("Created new user with the ID: {0}", GetUserIdByName(newUsername));

                var newUserQuery = from u in db.Users
                                   where newUsername == u.Username
                                   select u;

                foreach (var item in newUserQuery)
                    Console.WriteLine("New user created: {0}", item.Username);
            }
        }
        public int GetUserIdByName(string name)
        {
            using (var db = new WebstoreContext())
            {
                var result = -1;
                var queryUserId = from u in db.Users
                                  where u.Username.Equals(name)
                                  select u.UserId;
                if (queryUserId.Count() == 1)
                    result = queryUserId.First();
                return result;
            }
            
        }

        public int GetProductIdByName(string name)
        {
            using (var db = new WebstoreContext())
            {
                var result = -1;
                var queryProductId = from p in db.Products
                                  where p.Name.Equals(name)
                                  select p.ProductId;
                if (queryProductId.Count() == 1)
                    result = queryProductId.First();
                return result;
            }

        }
        public void Login()
        {
            using (var db = new WebstoreContext())
            {
                Console.WriteLine("Enter username");
                var name = Console.ReadLine();

                Console.WriteLine("Enter password");
                var pass = Console.ReadLine();

                var user = (from u in db.Users
                           where u.Username == name && u.Password == pass
                           select u).Count();

                Console.WriteLine(user.ToString());
                Console.ReadKey();

                var message = (user != 1) ? "Failed" : "Succeeded";
                Console.WriteLine("Login attempt {0}", message);

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


        public void PrintAllProducts()
        {
            using (var db = new WebstoreContext())
            {
                var products = from p in db.Products
                            orderby p.Name
                            //where Ammount
                            select p;
                foreach (var product in products)
                    Console.WriteLine("Product {0}: {1}", product.ProductId, product.Name);

            }
        }
    }
}
