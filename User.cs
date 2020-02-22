using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.CSharpProgramming2020.Task1
{
    class User
    {
        private DateTime _dateOfBirth;
        private int _age;
        private String _euSign;
        private String _chSign;
        private readonly string[] _westernSigns = { "Aquarius", "Pisces", "Aries", "Taurus", "Gemini", "Cancer", "Leo", "Virgo", "Libra", "Scorpio", "Saggitarius", "Capricorn" };
        private readonly string[] _chineseSigns = { "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig" };

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }
        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
        public String EUSign
        {
            get { return _euSign; }
            set { _euSign = value; }
        }
        public String CHSign
        {
            get { return _chSign; }
            set { _chSign = value; }
        }
        public string EUSignCalc()
        {
            int day = _dateOfBirth.Day;
            int month = _dateOfBirth.Month;

                if (month == 1 || month == 4)
                    return day >= 20 ? _westernSigns[month - 1] : (month == 1 ? _westernSigns[_westernSigns.Length - 1] : _westernSigns[month - 2]);

                if (month == 2)
                    return day >= 19 ? _westernSigns[month - 1] : _westernSigns[month - 2];

                if (month == 3 || month == 5 || month == 6)
                    return day >= 22 ? _westernSigns[month - 1] : _westernSigns[month - 2];

                if (month == 7 || month == 8 || month == 9 || month == 10)
                    return day >= 23 ? _westernSigns[month - 1] : _westernSigns[month - 2];

                return day >= 22 ? _westernSigns[month - 1] : _westernSigns[month - 2];
        }

        public string CHSignCalc()
        {
            int date = _dateOfBirth.Year;
                return _chineseSigns[(date-4) % 12];
        }

    }
}
