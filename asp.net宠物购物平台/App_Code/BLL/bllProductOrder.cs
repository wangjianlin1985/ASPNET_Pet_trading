using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ﶩ��ҵ���߼���*/
    public class bllProductOrder{
        /*��ӳ��ﶩ��*/
        public static bool AddProductOrder(ENTITY.ProductOrder productOrder)
        {
            return DAL.dalProductOrder.AddProductOrder(productOrder);
        }

        /*����orderId��ȡĳ�����ﶩ����¼*/
        public static ENTITY.ProductOrder getSomeProductOrder(int orderId)
        {
            return DAL.dalProductOrder.getSomeProductOrder(orderId);
        }

        /*���³��ﶩ��*/
        public static bool EditProductOrder(ENTITY.ProductOrder productOrder)
        {
            return DAL.dalProductOrder.EditProductOrder(productOrder);
        }

        /*ɾ�����ﶩ��*/
        public static bool DelProductOrder(string p)
        {
            return DAL.dalProductOrder.DelProductOrder(p);
        }

        /*��ѯ���ﶩ��*/
        public static System.Data.DataSet GetProductOrder(string strWhere)
        {
            return DAL.dalProductOrder.GetProductOrder(strWhere);
        }

        /*����������ҳ��ѯ���ﶩ��*/
        public static System.Data.DataTable GetProductOrder(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductOrder.GetProductOrder(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĳ��ﶩ��*/
        public static System.Data.DataSet getAllProductOrder()
        {
            return DAL.dalProductOrder.getAllProductOrder();
        }
    }
}
