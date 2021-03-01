using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public Product(int id, string name, decimal price, string description, string type, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Type = type;
            Quantity = quantity;
        }
        public Product()
        {
            Id = 0;
            Name = null;
            Price = 0;
            Description = null;
            Type = null;
            Quantity = 0;
        }
    }
}
