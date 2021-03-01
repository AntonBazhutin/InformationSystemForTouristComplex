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
        public string SerialNumber { get; set; }
        public int ProfessionId { get; set; }

        public Equipment(int id, string name, int quantity, string serialNumber, int professionId)
        {
            Id = id;
            Name = name;
            Quantity = quantity;
            SerialNumber = serialNumber;
            ProfessionId = professionId;
        }
        public Equipment()
        {
            Id = 0;
            Name = null;
            Quantity = 0;
            SerialNumber = null;
            ProfessionId = 0;
        }
    }
}
