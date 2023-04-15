using CSharp_Lab_04.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp_Lab_04.ViewModels
{
    class PersonViewModel
    {
        private Person _person;
        public string FirstName => _person.FirstName;
        public string LastName => _person.LastName;
        public string Email => _person.Email;
        public string BirthDate => _person.BirthDate.ToString("d");
        public bool IsAdult=> _person.IsAdult;
        public bool IsBirthday=> _person.IsBirthday;
        public string WesternSign => _person.SunSign;
        public string ChineseSign => _person.ChineseSign;


        public PersonViewModel(Person person)
        {
            _person = person;
        }
    }
}
