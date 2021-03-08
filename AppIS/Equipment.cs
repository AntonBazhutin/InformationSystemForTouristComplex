using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ProfessionId { get; set; }

        public Equipment(int id, string name, int quantity, int professionId)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            ProfessionId = professionId;
        }
        public Equipment()
        {
            Id = 0;
            Name = null;
            Quantity = 0;
            ProfessionId = 0;
        }
        public Equipment(int id)
        {
            Id = id;
            Name = null;
            Quantity = 0;
            ProfessionId = 0;
        }
    }
}
