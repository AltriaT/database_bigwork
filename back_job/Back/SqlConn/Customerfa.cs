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
        public Customer GetOneCustomer(string Cno);
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
