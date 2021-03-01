using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Order
    {
        public int Id { get; set; }
        public string DateOrder { get; set; }
        public string Login { get; set; }
        public bool IsDone { get; set; }
        public Order(int id, string dateOrder, string login, bool isDone)
        {
            Id = id;
            DateOrder = dateOrder;
            Login = login;
            IsDone = isDone;
        }
    }
}
