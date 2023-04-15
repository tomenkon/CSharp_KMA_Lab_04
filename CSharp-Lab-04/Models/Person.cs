using CSharp_Lab_04.Tools.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CSharp_Lab_04.Models
{
    internal class Person
    {
        #region Properties

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public DateTime BirthDate { get; }
        public bool IsAdult { get; }
        public string SunSign { get; }
        public string ChineseSign { get; }
        public bool IsBirthday { get; }
        #endregion

        internal Person()
        {

        }
        internal Person(string firstName, string lastName, string email, DateTime date)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;

            BirthDate = date;

            int age = ComputeAge();
            IsAdult = (age >= 18);
            IsBirthday = CheckForBirthday();
            SunSign = ComputeWesternZodiac();
            ChineseSign = CalculateChineseZodiac();
        }

        private int ComputeAge()
        {
            DateTime atTheMoment = DateTime.Today;
            int resultAge = atTheMoment.Year - BirthDate.Year;

            if (((atTheMoment.Month == BirthDate.Month) && (BirthDate.Day > atTheMoment.Day)) || BirthDate.Month > atTheMoment.Month)
            {
                resultAge--;
            }

            if (resultAge < 0)
            {
                throw new UnbornException();
            }
            if (resultAge > 135)
            {
                throw new TooOldException();
            }
            return resultAge;
        }

        private bool CheckForBirthday()
        {
            if (BirthDate.Day == DateTime.Today.Day && BirthDate.Month == DateTime.Today.Month)
            {
                return true;
            }
            return false;
        }

        public void Validate()
        {
            if (DateTime.Today < BirthDate)
            {
                throw new UnbornException();
            }

            if (BirthDate.Year - DateTime.Today.Year > 135)
            {
                throw new TooOldException();
            }

            Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            if (!emailRegex.IsMatch(Email))
            {
                throw new InvalidEmailException(Email);
            }
        }

        public bool IsIncomplete()
        {
            if (String.IsNullOrWhiteSpace(FirstName) ||
                String.IsNullOrWhiteSpace(LastName) ||
                String.IsNullOrWhiteSpace(Email)
               )
                return true;
            return false;
        }

        private string ComputeWesternZodiac()
        {
            int month = BirthDate.Month;
            int day = BirthDate.Day;
            string zodiacSign = "";

            switch (month)
            {
                case 1: // January
                    if (day <= 19)
                        zodiacSign = "Capricorn";
                    else
                        zodiacSign = "Aquarius";
                    break;
                case 2: // February
                    if (day <= 18)
                        zodiacSign = "Aquarius";
                    else
                        zodiacSign = "Pisces";
                    break;
                case 3: // March
                    if (day <= 20)
                        zodiacSign = "Pisces";
                    else
                        zodiacSign = "Aries";
                    break;
                case 4: // April
                    if (day <= 19)
                        zodiacSign = "Aries";
                    else
                        zodiacSign = "Taurus";
                    break;
                case 5: // May
                    if (day <= 20)
                        zodiacSign = "Taurus";
                    else
                        zodiacSign = "Gemini";
                    break;
                case 6: // June
                    if (day <= 20)
                        zodiacSign = "Gemini";
                    else
                        zodiacSign = "Cancer";
                    break;
                case 7: // July
                    if (day <= 22)
                        zodiacSign = "Cancer";
                    else
                        zodiacSign = "Leo";
                    break;
                case 8: // August
                    if (day <= 22)
                        zodiacSign = "Leo";
                    else
                        zodiacSign = "Virgo";
                    break;
                case 9: // September
                    if (day <= 22)
                        zodiacSign = "Virgo";
                    else
                        zodiacSign = "Libra";
                    break;
                case 10: // October
                    if (day <= 22)
                        zodiacSign = "Libra";
                    else
                        zodiacSign = "Scorpio";
                    break;
                case 11: // November
                    if (day <= 21)
                        zodiacSign = "Scorpio";
                    else
                        zodiacSign = "Sagittarius";
                    break;
                case 12: // December
                    if (day <= 21)
                        zodiacSign = "Sagittarius";
                    else
                        zodiacSign = "Capricorn";
                    break;
            }
            return zodiacSign;
        }

        private string CalculateChineseZodiac()
        {
            int zodiacYear = (BirthDate.Year - 4) % 12;
            string zodiacSign = "";

            switch (zodiacYear)
            {
                case 0:
                    zodiacSign = "Rat";
                    break;
                case 1:
                    zodiacSign = "Ox";
                    break;
                case 2:
                    zodiacSign = "Tiger";
                    break;
                case 3:
                    zodiacSign = "Rabbit";
                    break;
                case 4:
                    zodiacSign = "Dragon";
                    break;
                case 5:
                    zodiacSign = "Snake";
                    break;
                case 6:
                    zodiacSign = "Horse";
                    break;
                case 7:
                    zodiacSign = "Sheep";
                    break;
                case 8:
                    zodiacSign = "Monkey";
                    break;
                case 9:
                    zodiacSign = "Rooster";
                    break;
                case 10:
                    zodiacSign = "Dog";
                    break;
                case 11:
                    zodiacSign = "Pig";
                    break;
            }
            return zodiacSign;
        }

    }
}
