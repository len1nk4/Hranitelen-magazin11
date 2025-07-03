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
        public const string FilePath = "../../../product.txt";
        public List<Product> Products { get; private set; }

        private StreamReader reader;
        private StreamWriter writer;

        public Data()
        {
            LoadProducts();
        }

        public void Save()
        {
            writer = new StreamWriter(FilePath);
            using (writer)
            {
                string jsonData = JsonSerializer.Serialize(Products);
                writer.Write(jsonData);
            }
        }

        public void LoadProducts()
        {
            Products = new List<Product>();
            reader = new StreamReader(FilePath);
            using (reader)
            {
                string jsonData = reader.ReadToEnd();
                if (!string.IsNullOrEmpty(jsonData))
                {
                    Products = JsonSerializer.Deserialize<List<Product>>(jsonData)!;
                }
            }
        }

        public List<Product> GetAvailableProducts()
        {
            return Products.Where(p => p.Quantity > 0).ToList();
        }


    }
}
