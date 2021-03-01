using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppIS
{
    public class Tourist : Person
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DateOfComing { get; set; }
        public string DateOfLeaving { get; set; }
        public string Country { get; set; }
        public int Room_id { get; set; }

        public Tourist(string login, string password, string name, string surname, string thirdname, string dateOfBirth, string email,
            string dateOfComing, string dateOfLeaving, string country, int room_id) : base(name, surname, thirdname, dateOfBirth)
        {
            Login = login;
            Password = password;
            Email = email;
            DateOfComing = dateOfComing;
            DateOfLeaving = dateOfLeaving;
            Country = country;
            Room_id = room_id;
        }
        public Tourist()
        {
            Login = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            DateOfComing = string.Empty;
            DateOfLeaving = string.Empty;
            Country = string.Empty;
            Room_id = 0;
        }
        public Tourist(int room_id)
        {
            Login = string.Empty;
            Password = string.Empty;
            Email = string.Empty;
            DateOfComing = string.Empty;
            DateOfLeaving = string.Empty;
            Country = string.Empty;
            Room_id = room_id;
        }

        public override string ToString()
        {
            return $"({Login}) {Surname} {Name} {Thirdname} (Пароль: {Password}, Эл. почта: {Email})";
        }
    }
}
