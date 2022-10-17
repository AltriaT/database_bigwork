using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class People
    {
        private string Pno;
        private string Name;
        private string Password;
        private string? PhoneNumber;
        private string? Sex;

        public People(string pno, string name, string password, string phoneNumber, string sex)
        {
            Pno = pno;
            Name = name;
            Password = password;
            PhoneNumber = phoneNumber;
            Sex = sex;
        }

        public void SetPno(string pno)
        {
            this.Pno = pno;
        }

        public string GetPno()
        {
            return this.Pno;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }

        public string GetName()
        {
            return Name;
        }
        public void SetPassword(string pass)
        {
            Password = pass;
        }
        public string GetPassword()
        {
            return Password;
        }

        public void SetPhoneNumber(string phonenumber)
        {
            PhoneNumber = phonenumber;
        }
        public string? GetPhoneNumber()
        {
            return PhoneNumber;
        }

        public void SetSex(string sex)
        {
            Sex= sex;
        }
        public string? GetSex(string sex)
        {
            return Sex;
        }
    }
}
