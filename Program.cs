using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory_management_system
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>()
            {
                new Product("Mouse", 20, 100),
                new Product("Keyboard", 40, 200)
            };
            Menu(products);
        }

        //Show menu
        public static void Menu(List<Product> products)
        {
            bool exited = false;
            while (!exited)
            {
                Console.WriteLine("------------Welcome to Inventory management system------------\n");
                Console.Write("Select an option: \n" +
                    "1. Add product\n" +
                    "2. Sell product\n" +
                    "3. Restock product\n" +
                    "4. View all products\n" +
                    "5. Remove product\n" +
                    "6. Exit\n");
                int choice = int.Parse(Console.ReadLine());
                if (choice < 1 || choice > 6)
                {
                    Console.WriteLine("Invalid input, press any key to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }
                else
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 1:
                            AddProduct(products);
                            break;
                        case 2:
                            SellProduct(products);
                            break;
                        case 3:
                            RestockProduct(products);
                            break;
                        case 4:
                            ViewProducts(products);
                            Console.ReadLine();
                            break;
                        case 5:
                            RemoveProduct(products);
                            break;
                        case 6:
                            exited = true;
                            break;
                    }
                    Console.Clear() ;
                }
            }
        }
        
        //Add New Product
        public static void AddProduct(List<Product> products)
        {
            //Prompt user input for a new product information
            Product product = new Product();
            Console.WriteLine("Please enter product name: ");
            product.Name = Console.ReadLine();
            Console.WriteLine("Please enter product price: ");
            product.Price = Double.Parse(Console.ReadLine());
            Console.WriteLine("Please enter product quantity: ");
            product.Stock = int.Parse(Console.ReadLine());

            products.Add(product);
        }
        //Sell Product
        public static void SellProduct(List<Product> products) { 
            ViewProducts(products);
            Console.WriteLine("Please enter the product number that you want to sell: ");
            int input = int.Parse(Console.ReadLine() );
            if(input < 0 || input > products.Count - 1)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine("Please enter sell amount: ");
                int amount = int.Parse(Console.ReadLine());
                if (products[input].Stock >= amount)
                    products[input].Stock-=amount;
                else
                    Console.WriteLine("Out of stock, please restock!");
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadLine() ;
        }
        //Restock Product
        public static void RestockProduct(List<Product> products)
        {
            ViewProducts(products);
            Console.WriteLine("Please enter the product number that you want to restock: ");
            int input = int.Parse(Console.ReadLine());
            if (input < 0 || input > products.Count - 1)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                Console.WriteLine("Please enter the restock amount: ");
                int amount = int.Parse(Console.ReadLine()) ;
                products[input].Stock += amount;
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadLine();
        }
        //Remove Product
        public static void RemoveProduct(List<Product> products)
        {
            ViewProducts(products);
            Console.WriteLine("Please enter the product number that you want to remove: ");
            int input = int.Parse(Console.ReadLine());
            if (input < 0 || input > products.Count - 1)
            {
                Console.WriteLine("Invalid Input");
            }
            else
            {
                products.Remove(products[input]);
            }
            Console.WriteLine("Press any key to return to menu");
            Console.ReadLine();
        }
        //View Product
        public static void ViewProducts(List<Product> products) {
            Console.WriteLine("No\tProduct Name\t\t\tPrice\t\t\tStock");
            Console.WriteLine("----\t------------\t\t\t------\t\t\t------");
            for (int i = 0; i < products.Count; i++) {
                Console.WriteLine($"{i,-8}" + 
                    $"{products[i].Name,-32}" +  
                    $"{products[i].Price, -24}" +  
                    $"{products[i].Stock}");
            }
        }
    }


    public class Product
    {
        public Product() { }
        public Product(string name, double price, int stock)
        {
            Name = name;
            Price = price;
            Stock = stock;
        }
        public string Name { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
    }
}
