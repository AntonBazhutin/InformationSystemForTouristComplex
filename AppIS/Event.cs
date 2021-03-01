using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Date { get; set; }
        public int WorkPlace_id { get; set; }
        public Event(int id, string name, decimal price, string description, string date, int workPlace_id)
        {
            Id = id;
            Name = name;
            Price = price;
            Description = description;
            Date = date;
            WorkPlace_id = workPlace_id;
        }
        public Event()
        {
            Id = 0;
            Name = null;
            Price = 0;
            Description = null;
            Date = null;
            WorkPlace_id = 0;
        }
        public Event(int id)
        {
            Id = id;
            Name = null;
            Price = 0;
            Description = null;
            Date = null;
            WorkPlace_id = 0;
        }
    }
}
