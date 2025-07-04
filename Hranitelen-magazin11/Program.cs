﻿using System.ComponentModel.DataAnnotations;
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
                Quantity = quantity,
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


    }
}
