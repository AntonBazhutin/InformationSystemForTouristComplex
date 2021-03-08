using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Room
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public int Beds { get; set; }
        public bool IsAvailable { get; set; }
        public string Building_id { get; set; }

        public Room(int id, decimal price, int beds, bool isAvailable, string building_id)
        {
            Id = id;
            Price = price;
            Beds = beds;
            IsAvailable = isAvailable;
            Building_id = building_id;
        }
        public Room()
        {
            Id = 0;
            Price = 0;
            Beds = 0;
            IsAvailable = false;
            Building_id = string.Empty;
        }
        //public override string ToString()
        //{
        //    return $"({Id}) Кроватей : {Beds}, {Price}p";
        //}
    }
}
