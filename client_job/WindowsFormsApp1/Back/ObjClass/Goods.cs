using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Goods
    {
        private string Gno;
        private string Sno;
        private string Gname;
        public decimal Gprice;
        public int Gstock;


        public Goods(string gno, string sno, string gname, decimal gprice, int gstock)
        {
            Gno = gno;
            Sno = sno;
            Gname = gname;
            Gprice = gprice;
            Gstock = gstock;
        }
        public void SetGno(string gno) { Gno = gno; }
        public string GetGno() { return Gno; }
        public void SetSno(string sno) { this.Sno = sno; }
        public string GetSno() { return Sno; }
        public void SetGname(string name) { this.Gname = name; }
        public string GetGname() { return Gname; }
        public void SetGprice(decimal gprice) { this.Gprice = gprice; }
        public decimal GetGprice() { return Gprice; }
        public void SetGstock(int gstock) { this.Gstock = gstock; }
        public int GetGstock() { return Gstock; }

    }
}
