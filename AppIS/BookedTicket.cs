using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class BookedTicket
    {
        public int Item_id { get; set; }
        public int Event_id { get; set; }
        public int Quantity { get; set; }
        public decimal Cost { get; set; }
        public string Login { get; set; }
        public bool isPaid { get; set; }
        public BookedTicket()
        {
            Item_id = 0;
            Event_id = 0;
            Quantity = 0;
            Cost = 0;
            Login = string.Empty;
            isPaid = false;
        }
        public BookedTicket(int item_id, int event_id, int quantity, decimal cost, string login,bool paid)
        {
            Item_id = item_id;
            Event_id = event_id;
            Quantity = quantity;
            Cost = cost;
            Login = login;
            isPaid = paid;
        }
    }
}
