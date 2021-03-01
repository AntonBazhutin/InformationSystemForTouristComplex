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
        public uint Rooms { get; set; }

        public Building(string id, uint rooms)
        {
            Id = id;
            Rooms = rooms;
        }
    }
}
