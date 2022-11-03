using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn
{
    public interface Customerfa
    {
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Cno"></param>
        /// <returns>返回bool变量</returns>
        public bool IsHave(string Cno);
        /// <summary>
        /// 查找一个顾客
        /// </summary>
        /// <param name="Cno"></param>
        /// <returns>若找到返回顾客若没找到，在返回一个空的顾客</returns>
        public Customer GetOneCustomer(string Cno);
        /// <summary>
        /// 查找所有顾客的信息
        /// </summary>
        /// <returns>所有顾客信息，若为空则字典容量为0</returns>
        public Dictionary<string, Customer> GetAllCustomer();
        /// <summary>
        /// 用实体类customer创建一个顾客
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int InsertOneCustomer(Customer customer);
        /// <summary>
        /// 更改一个用户的信息
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int UpdateOneCustomer(Customer customer);
        /// <summary>
        /// 删除一个用户
        /// </summary>
        /// <param name="customer"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int DeleteOneCustomer(Customer customer);
    }
}
