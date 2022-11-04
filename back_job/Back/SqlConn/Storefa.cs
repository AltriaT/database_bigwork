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
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Sno"></param>
        /// <returns>返回bool变量</returns>
        public bool IsHave(string Sno);
        /// <summary>
        ///通过Sno获得某一个商店信息，返回值为一个商店实体
        /// </summary>
        public Store GetOneStore(string sno);
        /// <summary>
        ///获取所有的商店信息，返回值为Dictionary<string,Store>商店的字典，key是商店的Sno
        /// </summary>
        public Dictionary<string, Store> GetAllStore();
        /// <summary>
        ///更新List中所有商店的信息
        /// </summary>
        public void UpdateAllStore(List<Store> stores);
        /// <summary>
        ///更新某一个有商店的信息
        /// </summary>
        public void UpdateOneStore(Store store);
        /// <summary>
        ///插入某一商店
        /// </summary>
        public void InsertOneStore(Store store);
        /// <summary>
        ///插入List中所有商店
        /// </summary>
        public void InsertAllStore(List<Store> stores);
        /// <summary>
        ///删除某一商店的信息
        /// </summary>
        public void DeleteOneStore(Store store);
        /// <summary>
        ///删除List中所有商店的信息
        /// </summary>
        public void DeleteAllStore(List<Store> stores);
        /// <summary>
        ///将字典转化为列表
        /// </summary>
        public List<Store> PutInList(Dictionary<string, Store> stores);
    }
}
