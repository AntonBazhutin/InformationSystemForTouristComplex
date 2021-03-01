using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Worker : Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Profession_id { get; set; }
        public int WorkPlace_id { get; set; }
        public string PhoneNumber { get; set; }

        public Worker(string name, string surname, string thirdname, string dateofbirth, int profession_id, int workplace_id, string phoneNumber, string login, string password)
            : base(name, surname, thirdname, dateofbirth)
        {
            Profession_id = profession_id;
            WorkPlace_id = workplace_id;
            PhoneNumber = phoneNumber;
            Login = login;
            Password = password;
        }
        public Worker(int workPlace_id)
        {
            Profession_id = 0;
            WorkPlace_id = workPlace_id;
            PhoneNumber = string.Empty;
            Login = string.Empty;
            Password = string.Empty;
        }

        public override string ToString()
        {
            return $"({Login}) {Name} {Surname} {Thirdname} ({PhoneNumber})";
        }
    }
}
