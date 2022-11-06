using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn
{
    public interface Goodsfa
    {
        public Goods GetOneGoods(string gno);
        public Dictionary<string, Goods> GetAllGoods();
        public void UpdateOneGoods(Goods goods);
        public void InsertOneGoods(Goods goods);
        public void DeleteOneGoods(Goods goods);
        public void UpdateAllGoods(List<Goods> goodses);
        public void InsertAllGoods(List<Goods> goodses);
        public void DeleteAllGoods(List<Goods> goodses);
        public List<Goods> PutInList(Dictionary<string, Goods> Goodses);
    }
}
