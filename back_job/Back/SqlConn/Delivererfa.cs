using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn
{
    public interface Delivererfa
    {
        public Deliverer GetOneDeliverer(string Dno);
        public Dictionary<string, Deliverer> GetAllDeliverer();
        public void InsertOneDeliverer(Deliverer deliverer);
        public void UpdateOneDeliverer(Deliverer deliverer);
        public void DeleteOneDeliverer(Deliverer deliverer);
    }
}
