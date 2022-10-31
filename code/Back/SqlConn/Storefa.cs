using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn
{
    public interface Storefa
    {
        public Store GetOneStore(string sno);
        public Dictionary<string, Store> GetAllStore();
        public void UpdateAllStore(List<Store> stores);
        public void UpdateOneStore(Store store);
        public void InsertOneStore(Store store);
        public void InsertAllStore(List<Store> stores);
        public void DeleteOneStore(Store store);
        public void DeleteAllStore(List<Store> stores);
        public List<Store> PutInList(Dictionary<string, Store> stores);
    }
}
