using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hranitelen_magazin11
{
    public class Product
    {
        public string Name { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
        public int ProductId { get; set; }
        
        public Product(string name, string category, int quantity, int productid, decimal price)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            ProductId = productid;
            Price = price;
        }
        public decimal Price
        {
            get
            {
                return Price;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price must be a positive number.");
                }
                Price = value;
            }
        }
        public override string ToString()
        {
            return $"{Name} , {Price}, {ProductId},{Quantity},{Category}";
        }

       
    }
}
