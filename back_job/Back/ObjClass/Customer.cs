using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Customer:People
    {
        public decimal Money;
        private string Address;
        public Customer() { }
        public Customer(string pno, string name, string password, string phoneNumber, string sex, string address, decimal money=0m) : base(pno, name, password, phoneNumber, sex)
        {
            Address = address;
            Money = money;
        }

        public void SetMoney(decimal money)
        {
            this.Money = money;
        }
        public decimal GetMoney()
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
        public string toString()
        {
            return GetPno() + GetName() + GetSex();
        }
    }
}
