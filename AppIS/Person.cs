using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Person
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string  Thirdname { get; set; }
        public string DateOfBirth { get; set; }

        public Person(string name,string surname,string thirdname,string dateofbirth)
        {
            Name = name;
            Surname = surname;
            Thirdname = thirdname;
            DateOfBirth = dateofbirth;
        }

        public Person()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Thirdname = string.Empty;
            DateOfBirth = string.Empty;
        }
    }
}
