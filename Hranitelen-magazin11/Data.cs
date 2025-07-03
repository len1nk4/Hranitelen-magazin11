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

        public List<Product> Product { get; private set; }
        public List<Product> AllProducts { get; private set; }

        private Customers customers;
        private Seller seller;
        public Data()
        {
            LoadProducts();
            
        }
        private void LoadProducts()
        {
          Product = new List<Product>();
            Customers customers = new Customers (inventoryPath);
            using (customers)
            {
                string jsonData = customers.Shop();
                if (!string.IsNullOrEmpty(jsonData))
                {
                   Product = JsonSerializer.Deserialize<List<Product>>(jsonData)!;
                }
            }

        }

    }
}
