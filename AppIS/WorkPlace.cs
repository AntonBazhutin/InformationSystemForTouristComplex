using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class WorkPlace
    {
        public int Id { get; set; }
        public string Building_id { get; set; }
        public string Place_id { get; set; }
        public WorkPlace(int id, string building_id, string place_id)
        {
            Id = id;
            Building_id = building_id;
            Place_id = place_id;
        }
        public WorkPlace()
        {
            Id = 0;
            Building_id = null;
            Place_id = null;
        }
    }
}
