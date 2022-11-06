using Back.ObjClass;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Back.SqlConn
{
    public interface Orderfa
    {
        /// <summary>
        /// 返回订单数量
        /// </summary>
        public int GetOrdersNum();
        /// <summary>
        /// 判断是否存在该人物
        /// </summary>
        /// <param name="Ono"></param>
        /// <returns>存在返回true</returns>
        public bool IsHave(string Ono);
        /// <summary>
        /// 根据Ono获得一个订单
        /// </summary>
        /// <param name="Ono"></param>
        /// <returns>返回一个order类</returns>
        public Order GetOneOrder(string Ono);
        /// <summary>
        /// 根据顾客号找订单
        /// </summary>
        /// <param name="Cno"></param>
        /// <returns></returns>
        public Order GetOneOrderByCno(string Cno);
        /// <summary>
        /// 根据Sno获得所有的订单
        /// </summary>
        /// <param name="sno"></param>
        /// <returns>字典key=Ono value=Order</returns>
        public Dictionary<string, Order> GetAllOrder(string sno);
        /// <summary>
        /// 根据Cno获得所有的订单
        /// </summary>
        /// <param name="Cno"></param>
        /// <returns>字典key=Ono value=Order</returns>
        public Dictionary<string, Order> GetAllOrderByCno(string Cno);
        /// <summary>
        /// 插入一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int InsertOneOrder(Order order);
        /// <summary>
        /// 更新一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int UpdateOneOrder(Order order);
        /// <summary>
        /// 删除一个订单
        /// </summary>
        /// <param name="order"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int DeleteOneOrder(Order order);
        /// <summary>
        /// 获得购物车中的所有商品和商品数量
        /// </summary>
        /// <param name="order"></param>
        /// <returns>字典 key=商品，value=数量</returns>
        public Dictionary<Goods, int> GetPurchase(Order order);
        /// <summary>
        /// 将购买的物品插入到购买表里
        /// </summary>
        /// <param name="order"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int InsertGoodsIntoPurchase(Order order);
        /// <summary>
        /// 将购买表里的物品更新
        /// </summary>
        /// <param name="order"></param>
        /// <returns>状态码1(SUCCESS),2627(插入重复键)，547(约束冲突)</returns>
        public int UpdateGoodsIntoPurchase(Order order);
    }
}
