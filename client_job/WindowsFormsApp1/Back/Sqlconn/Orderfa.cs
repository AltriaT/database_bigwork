using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn
{
    public interface Orderfa
    {
        public Order GetOneOrder(string Ono);
        public Dictionary<string, Order> GetAllOrder(string sno);
        public void InsertOneOrder(Order order);
        public void UpdateOneOrder(Order order);
        public void DeleteOneOrder(Order order);
    }
}
