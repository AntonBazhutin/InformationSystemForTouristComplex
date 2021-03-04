using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Order
    {
        public int Order_id { get; set; }
        public int Product_id { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public string DateOrder { get; set; }
        public string Login { get; set; }
        public bool IsDone { get; set; }
        public Order(int order_id, int product_id, int quantity, decimal cost, string dateOrder, string login, bool isDone)
        {
            Order_id = order_id;
            Product_id = product_id;
            Quantity = quantity;
            Cost = cost;
            DateOrder = dateOrder;
            Login = login;
            IsDone = isDone;
        }
        public Order()
        {
            Order_id = 0;
            Product_id = 0;
            Quantity = 0;
            Cost = 0;
            DateOrder = string.Empty;
            Login = string.Empty;
            IsDone = false;
        }

        public override string ToString()
        {
            return $"({Order_id}) {Product_id} - {Quantity} шт. {Cost} цена, Дата офрмления {DateOrder}, Заказ выполнен? - {IsDone}";
        }
    }
}
