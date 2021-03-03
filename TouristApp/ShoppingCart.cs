using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TouristApp
{
    public class ShoppingCart
    {
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public bool IsEvent { get; set; }
        public ShoppingCart(int product_id,int quantity, decimal cost,bool isEvent)
        {
            Product_id = product_id;
            Quantity = quantity;
            Cost = cost;
            IsEvent = isEvent;
        }
        public ShoppingCart()
        {
            Product_id = 0;
            Quantity = 0;
            Cost = 0;
            IsEvent = false;
        }
    }
}
