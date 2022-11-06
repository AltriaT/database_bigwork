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
        ///<summary>
        ///更新某一个物品
        ///</summary>
        ///<param name="goods"></param>
        ///<returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int UpdateOneGoods(Goods goods);
        ///<summary>
        ///插入某一个物品
        ///</summary>
        ///<param name="goods"></param>
        ///<returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int InsertOneGoods(Goods goods);
        ///<summary>
        ///删除某一个物品
        ///</summary>
        ///<param name="goods"></param>
        ///<returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int DeleteOneGoods(Goods goods);
        ///<summary>
        ///更新所有物品
        ///</summary>
        ///<param name="goodses"></param>
        ///<returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int UpdateAllGoods(List<Goods> goodses);
        ///<summary>
        ///插入所有物品
        ///</summary>
        ///<param name="goodses"></param>
        ///<returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int InsertAllGoods(List<Goods> goodses);
        ///<summary>
        ///更新所有物品
        ///</summary>
        /// <param name="goodses"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int DeleteAllGoods(List<Goods> goodses);
        public List<Goods> PutInList(Dictionary<string, Goods> Goodses);
    }
}
