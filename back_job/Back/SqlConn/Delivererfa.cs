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
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Dno"></param>
        /// <returns>返回bool变量</returns>
        public bool IsHave(string Dno);
        /// <summary>
        /// 获得一个人的基本信息
        /// </summary>
        /// <param name="Dno"></param>
        /// <returns>返回快递员类</returns>
        public Deliverer GetOneDeliverer(string Dno);
        /// <summary>
        /// 获得所有的快递员的信息
        /// </summary>
        /// <returns>字典 key=Dno,value=快递员类</returns>
        public Dictionary<string, Deliverer> GetAllDeliverer();
        /// <summary>
        /// 插入一个快递员
        /// </summary>
        /// <param name="deliverer"></param>
        public void InsertOneDeliverer(Deliverer deliverer);
        /// <summary>
        /// 更新一个快递员信息
        /// </summary>
        /// <param name="deliverer"></param>
        public void UpdateOneDeliverer(Deliverer deliverer);
        /// <summary>
        /// 删除一个快递员
        /// </summary>
        /// <param name="deliverer"></param>
        public void DeleteOneDeliverer(Deliverer deliverer);
    }
}
