using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Profession
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Profession(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public Profession()
        {
            Id = 0;
            Name = null;
        }
        public Profession(int id)
        {
            Id = id;
            Name = null;
        }
    }
}
