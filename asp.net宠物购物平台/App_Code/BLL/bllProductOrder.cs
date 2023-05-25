using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*宠物订单业务逻辑层*/
    public class bllProductOrder{
        /*添加宠物订单*/
        public static bool AddProductOrder(ENTITY.ProductOrder productOrder)
        {
            return DAL.dalProductOrder.AddProductOrder(productOrder);
        }

        /*根据orderId获取某条宠物订单记录*/
        public static ENTITY.ProductOrder getSomeProductOrder(int orderId)
        {
            return DAL.dalProductOrder.getSomeProductOrder(orderId);
        }

        /*更新宠物订单*/
        public static bool EditProductOrder(ENTITY.ProductOrder productOrder)
        {
            return DAL.dalProductOrder.EditProductOrder(productOrder);
        }

        /*删除宠物订单*/
        public static bool DelProductOrder(string p)
        {
            return DAL.dalProductOrder.DelProductOrder(p);
        }

        /*查询宠物订单*/
        public static System.Data.DataSet GetProductOrder(string strWhere)
        {
            return DAL.dalProductOrder.GetProductOrder(strWhere);
        }

        /*根据条件分页查询宠物订单*/
        public static System.Data.DataTable GetProductOrder(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductOrder.GetProductOrder(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的宠物订单*/
        public static System.Data.DataSet getAllProductOrder()
        {
            return DAL.dalProductOrder.getAllProductOrder();
        }
    }
}
