using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hranitelen_magazin11
{
    using System.Text.Json;
    using static Constants;
    using static System.Reflection.Metadata.BlobBuilder;

    internal class Data
    {
        public const string FilePath = "product.txt";
        public List<Product> Product { get; private set; }
        public List<Product> AllProducts { get; private set; }

        public Data()
        {
            Product = LoadProductsFromFile();
        }

        private List<Product> LoadProductsFromFile()
        {
            var products = new List<Product>();

            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        products.Add(Product.FromString(line));
                    }
                }
            }

            return products;
        }

        public static List<Product> LoadProducts()
        {
            var products = new List<Product>();

            if (File.Exists(FilePath))
            {
                var lines = File.ReadAllLines(FilePath);
                foreach (var line in lines)
                {
                    if (!string.IsNullOrWhiteSpace(line))
                    {
                        products.Add(Product.FromString(line));
                    }
                }
            }

            return products;
        }

        public static void SaveProducts(List<Product> products)
        {
            var lines = products.Select(p => p.ToString());
            File.WriteAllLines(FilePath, lines);
        }
    }
}
