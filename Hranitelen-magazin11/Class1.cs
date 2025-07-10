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
        private decimal price;
        private int quantity;
        private string name;
        private string category;
        public int ProductId { get; set; }

        public string Name 
        {
            get { return name; }
            set
            {
               name = value;
            }
        }

        public int Quantity
        {
            get { return quantity; }
            set
            {
                quantity = value;
            }
        }

        public string Category
        {
            get { return category; }
            set
            { 
               category = value;
            }
        }
        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
               price = value;
            }
        }
        public Product(string name, string category, int quantity, int productid, decimal price)
        {
            Name = name;
            Category = category;
            Quantity = quantity;
            ProductId = productid;
            Price = price;
        }
        public override string ToString()
        {
            return $" {Name} , {Price}, {ProductId},{Quantity},{Category} "   ;
        }

       
    }
}
