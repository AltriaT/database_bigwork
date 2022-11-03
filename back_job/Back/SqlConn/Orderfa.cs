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
        /// <summary>
        /// 根据Ono获得一个订单
        /// </summary>
        /// <param name="Ono"></param>
        /// <returns>返回一个order类</returns>
        public Order GetOneOrder(string Ono);
        /// <summary>
        /// 根据Sno获得所有的订单
        /// </summary>
        /// <param name="sno"></param>
        /// <returns>字典key=Ono value=Order</returns>
        public Dictionary<string, Order> GetAllOrder(string sno);
        /// <summary>
        /// 插入一个订单
        /// </summary>
        /// <param name="order"></param>
        public void InsertOneOrder(Order order);
        /// <summary>
        /// 更新一个订单
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOneOrder(Order order);
        /// <summary>
        /// 删除一个订单
        /// </summary>
        /// <param name="order"></param>
        public void DeleteOneOrder(Order order);
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
        public void InsertGoodsIntoPurchase(Order order);
        /// <summary>
        /// 将购买表里的物品更新
        /// </summary>
        /// <param name="order"></param>
        public void UpdateGoodsIntoPurchase(Order order);
    }
}
