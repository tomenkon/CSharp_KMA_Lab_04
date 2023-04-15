using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_04.Models
{
    class UserDataBase
    {
        public static List<Person> users = new()
        {
            new Person("a", "Doe", "aaa@gmail.com", new DateTime(1965, 1, 10)),
            new Person("b", "Doe", "bbb@gmail.com", new DateTime(1975, 1, 10)),
            new Person("c", "Doe", "ccc@gmail.com", new DateTime(1995, 1, 10)),
            new Person("d", "Doe", "ddd@gmail.com", new DateTime(2005, 1, 10)),
            new Person("e", "Doe", "eee@gmail.com", new DateTime(2015, 1, 10))
        };
    }
}
