using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Deliverer:People
    {
        private double Money;
        private string State;
        
        public Deliverer(string pno, string name, string password, string phoneNumber, string sex, string state, double money=0) :base(pno, name, password, phoneNumber, sex)
        {
            Money = money;
            State = state;
        }
        
        public void SetMoney(double money)
        {
            Money=money;
        }

        public double GetMoney()
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

    }
}
