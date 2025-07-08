using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Xml.Linq;

namespace Hranitelen_magazin11
{
    internal class Program
    {
        private static Data data = new Data();
        static void Main(string[] args)
        {
            DisplayMenu();

            string choice;
            while ((choice = Console.ReadLine()) != "x")
            {
                switch (choice)
                {
                    case "1": //add product
                        AddProduct();
                        data.Save();

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

        private static void AddProduct()//1 Dobavqne na produkt
        {
            Console.WriteLine("Adding a new product...");

            string name = "";
            while (string.IsNullOrWhiteSpace(name) || !IsString(name))
            {
                Console.Write("Enter product name (letters only): ");
                name = Console.ReadLine();
            }

            string category = "";
            while (string.IsNullOrWhiteSpace(category) || !IsString(category))
            {
                Console.Write("Enter product category (letters only): ");
                category = Console.ReadLine();
            }

            int quantity;
            while (true)
            {
                Console.Write("Enter product quantity (whole number): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out quantity) && quantity >= 0)
                    break;
                Console.WriteLine("Invalid quantity. Please enter a valid whole number.");
            }

            int productId;
            while (true)
            {
                Console.Write("Enter product ID (whole number): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out productId) && productId > 0)
                    break;
                Console.WriteLine("Invalid ID. Please enter a valid positive number.");
            }

            decimal price;
            while (true)
            {
                Console.Write("Enter product price (decimal): ");
                string input = Console.ReadLine();
                if (decimal.TryParse(input, out price) && price >= 0)
                    break;
                Console.WriteLine("Invalid price. Please enter a valid decimal number.");
            }

            Product newProduct = new Product(name, category, quantity, productId, price);
            data.Products.Add(newProduct);

            Console.WriteLine($"Product '{name}' added successfully.");

        }

        private static void SellProduct()//2 Kupuvane na produkt
        {
            Console.WriteLine("Please enter the product name to sell:");
            string productName = Console.ReadLine();

            // Търсим продукта по име (case-insensitive)
            Product productToSell = data.Products
                .FirstOrDefault(p => p.Name.Equals(productName, StringComparison.OrdinalIgnoreCase));

            if (productToSell == null)
            {
                Console.WriteLine($"Product '{productName}' not found.");
                return;
            }

            Console.WriteLine($"Current stock of '{productToSell.Name}': {productToSell.Quantity}");

            // Искане на количество за продажба
            string quantityInput = "";
            while (!IsValidNumber(quantityInput))
            {
                Console.Write("Enter quantity to sell: ");
                quantityInput = Console.ReadLine();
            }
            int sellQuantity = int.Parse(quantityInput);

            if (sellQuantity <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                return;
            }

            if (sellQuantity > productToSell.Quantity)
            {
                Console.WriteLine("Not enough stock to sell that quantity.");
                return;
            }

            // Изваждане на продаденото количество
            productToSell.Quantity -= sellQuantity;
            Console.WriteLine($"Sold {sellQuantity} of '{productToSell.Name}'. Remaining stock: {productToSell.Quantity}");
        

        }

        private static void ListAllProducts()//4 Spravka za vsichki produkti
        {
            Console.WriteLine("Listing all products...");
            foreach (var product in data.Products)
            {
                Console.WriteLine(product.ToString());
            }
        }
        private static void CheckAvailability()//3 Proverka na nalichnost na daden produkt
        {
            Console.WriteLine("Checking available products...");
            string inputProduct = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(inputProduct))
            {
                Console.WriteLine("Invalid product name.");
                return;
            }


            var availableProducts = new List<string> { inputProduct };
            foreach (var product in data.Products)
            {
                if (availableProducts.Contains(product.Name))
                {
                    Console.WriteLine($"✅ Product '{product.Name}' is available.");
                }
                else
                {
                    Console.WriteLine($"❌ Product '{product.Name}' is NOT available.");
                }

            }
        }
       

        private static void DisplayMenu()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;


            Console.WriteLine("=========================");
            Console.WriteLine("★       М Е Н Ю        ★");
            Console.WriteLine("=========================");
            Console.WriteLine();
            Console.WriteLine("1. ▶ Добавяне на нов продукт ");
            Console.WriteLine("2. ▶ Купуванe на продукт ");
            Console.WriteLine("3. ▶ Проверка на наличните продукти");
            Console.WriteLine("4. ▶ Справка за всички налични продукти");
            Console.WriteLine();
            Console.WriteLine("x. ❌ Изход");
            Console.WriteLine("=========================");
            Console.Write("Твоят избор: ");
        }

        static bool IsString(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(char.IsLetter);
        }

        static bool IsNumber(string input)
        {
            return !string.IsNullOrEmpty(input) && input.All(char.IsDigit);
        }

        static bool IsValidNumber(string input)
        {
            return !string.IsNullOrWhiteSpace(input) && input.All(char.IsDigit);
        }

    }
}
