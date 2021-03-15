using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class UserPower
    {
        public int Profession_id { get; set; }
        public bool LimitPower { get; set; }
        public UserPower(int prof_id, bool limitPower)
        {
            Profession_id = prof_id;
            LimitPower = limitPower;
        }
        public UserPower()
        {
            Profession_id = 0;
            LimitPower = false;
        }
    }
}
