using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.ObjClass
{
    public class Goods
    {
        public string Gno;
        public string Sno;
        public string Gname;
        public double Gprice;
        public int Gstock;

        public Goods(string gno, string sno, string gname, double gprice, int gstock)
        {
            Gno = gno;
            Sno = sno;
            Gname = gname;
            Gprice = gprice;
            Gstock = gstock;
        }
        
    }
}
