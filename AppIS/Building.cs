using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Building
    {
        public string Id { get; set; }
        public int Rooms { get; set; }

        public Building(string id, int rooms)
        {
            Id = id;
            Rooms = rooms;
        }
        public Building()
        {
            Id = string.Empty;
            Rooms = 0;
        }
    }
}
