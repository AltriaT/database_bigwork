using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Customer:People
    {
        private double Money;
        private string Address;
        public Customer(string pno, string name, string password, string phoneNumber, string sex, string address, double money=0) : base(pno, name, password, phoneNumber, sex)
        {
            Address = address;
            Money = money;
        }

        public void SetMoney(double money)
        {
            this.Money = money;
        }
        public double GetMoney()
        {
            return Money;
        }
        public void SetAddress(string addr)
        {
            Address = addr;
        }
        public string GetAddress()
        {
            return Address;
        }

    }
}
