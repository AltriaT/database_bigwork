using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Shop
    {
        private string Sno;
        private string Spass;
        private string Sname;
        private string Saddr;
        private string Stel;
        private double Smoney;
        private string State;

        //Goods此商店的商品列表
        public List<Goods> Goods = new List<Goods>();

        public Shop(string Sno,string Spass,string Sname,string Saddr,string Stel,double Smoney,string State)
        {
            this.Sno = Sno;
            this.Spass = Spass;
            this.Sname = Sname;
            this.Saddr = Saddr;
            this.Stel = Stel;
            this.Smoney = Smoney;
            this.State = State;
        }

        public void SetSon(string no)
        {
            this.Sno = no;
        }

        public string GetSno()
        {
            return this.Sno;
        }

        public void SetSpass(string pass)
        {
            this.Spass = pass;
        }

        public string GetSpass()
        {
            return this.Spass;
        }

        public void SetSname(string name)
        {
            this.Sname = name;
        }

        public string GetSname()
        {
            return this.Sname;
        }

        public void SetSaddr(string addr)
        {
            this.Saddr = addr;
        }

        public string GetSaddr()
        {
            return this.Saddr;
        }
        public void SetStel(string tel)
        {
            this.Stel = tel;
        }
        public string GetStel()
        {
            return this.Stel;
        }

        public void SetSmoney(double money)
        {
            this.Smoney = money;
        }
        public double GetSmoney()
        {
            return this.Smoney;
        }
        public void SetState(string state)
        {
            this.State = state;
        }
        public string GetState()
        {
            return this.State;
        }
    }
}
