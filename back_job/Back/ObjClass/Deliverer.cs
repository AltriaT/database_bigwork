using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Deliverer:People
    {
        public decimal Money;
        private string State;
        
        public Deliverer()
        {

        }
        public Deliverer(string pno, string name, string password, string phoneNumber, string sex, string state, decimal money=0) :base(pno, name, password, phoneNumber, sex)
        {
            Money = money;
            State = state;
        }
        
        public void SetMoney(decimal money)
        {
            Money=money;
        }

        public decimal GetMoney()
        {
            return Money;
        }

        public void SetState(string state)
        {
            State = state;
        }

        public string GetState()
        {
            return State;
        }
        public string toString()
        {
            return GetPno() + GetName() + GetPhoneNumber() + GetState();
        }
    }
}
