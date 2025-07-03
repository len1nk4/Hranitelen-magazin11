using System.ComponentModel.DataAnnotations;

namespace Hranitelen_magazin11
{
    internal class Program
    {
        private static Data data = new Data();
        static void Main(string[] args)
        {
            DisplayMenu();

            string choice;
            while((choice = Console.ReadLine()) != "x")
            {
                switch (choice)
                {
                    case "1": //add product
                     AddProduct();
                         
              
                    break;
                    case "2": //sell a product
                    SellProduct();
                    break;
                    case "3": //check available products
                        CheckAvailability();
                        break;
                    case "4": //list all products
                        ListAllProducts();
                        break;
                    case "5":
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private static void AddProduct()
        {
            Console.WriteLine("Adding a new product...");
            Console.Write("Enter product name: ");
            string name = Console.ReadLine();
            Console.Write("Enter product category: ");
            string category = Console.ReadLine();
            Console.Write("Enter product quantity: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter product ID: ");
            int productId = int.Parse(Console.ReadLine() ?? "0");
            Console.Write("Enter product price: ");
            decimal price = decimal.Parse(Console.ReadLine() ?? "0.0");
            Product newProduct = new Product(name, category, quantity, productId, price)
            {
                Name = name,
                Category = category,
                Quantiy = quantity,
                ProductId = productId,
                Price = price
            };
            data.Products.Add(newProduct);
            Console.WriteLine($"Product {name} added successfully.");
        }

        private static void SellProduct()
        {
            Console.WriteLine("Product sold successfully.");
        }

        private static void ListAllProducts()
        {
            Console.WriteLine("Listing all products...");
            foreach (var product in data.Products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        private static void CheckAvailability()
        {
            Console.WriteLine("Checking product availability...");
        }
        private static void DisplayMenu()
        {

        }


        
    }
}
