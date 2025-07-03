using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hranitelen_magazin11
{
    internal class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantiy { get; set; }
        public int ProductId { get; set; }
        public decimal Price
        {
            get { return Price; }
            set { Price = value; }
        }
        public void Products(string name, string category, int quantity, int productid, decimal price)
        {
            Name = name;
            Category = category;
            quantity = quantity;
            ProductId = productid;
            Price = price;
        }
    }
}
