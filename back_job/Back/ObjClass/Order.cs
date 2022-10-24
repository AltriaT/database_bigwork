using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Order
    {
        private string Ono;
        private string Dno;
        private string Cno;
        private string Ostate;
        private string Otip;
        public decimal ODelfee;
        public decimal Omoney;
        private string Obtime;

        //Purchase购买的东西
        public Dictionary<Goods,int> Purchase=new Dictionary<Goods, int>();

        public Order(string ono, string dno, string cno,string sno, string ostate, string otip="null", decimal oDelfee=0, decimal omoney=0)
        {
            Ono = ono;
            Dno = dno;
            Cno = cno;
            Ostate = ostate;
            Otip = otip;
            ODelfee = oDelfee;
            Omoney = omoney;
            Obtime = DateTime.Now.ToString("yyyy-MM-dd HH：mm：ss：ffff");
        }
        public void SetOno(string ono) { Ono = ono; }
        public string GetOno() { return Ono; }
        public void SetDno(string dno) { Dno = dno; }
        public string GetDno() { return Dno; }
        public void SetCno(string cno) { Cno = cno; }
        public string GetCno() { return Cno; }
        public void SetOstate(string ostate) { Ostate = ostate; }
        public string GetOstate() { return Ostate; }
        public void SetOtip(string tip) { Otip = tip; }
        public string GetOtip() { return Otip; }
        public void SetODelfee(decimal fee) { ODelfee = fee; }
        public decimal GetOdelfee() { return ODelfee; }
        public void SetOmoney(decimal money) { Omoney = money; }
        public decimal GetOmoney() { return Omoney; }
        public void SetObtime(string time){ Obtime = time; }
        public string GetObtime() { return Obtime; }



    }
}
