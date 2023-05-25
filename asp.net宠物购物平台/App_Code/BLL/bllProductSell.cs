using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*�������ҵ���߼���*/
    public class bllProductSell{
        /*��ӳ������*/
        public static bool AddProductSell(ENTITY.ProductSell productSell)
        {
            return DAL.dalProductSell.AddProductSell(productSell);
        }

        /*����sellId��ȡĳ��������ۼ�¼*/
        public static ENTITY.ProductSell getSomeProductSell(int sellId)
        {
            return DAL.dalProductSell.getSomeProductSell(sellId);
        }

        /*���³������*/
        public static bool EditProductSell(ENTITY.ProductSell productSell)
        {
            return DAL.dalProductSell.EditProductSell(productSell);
        }

        /*ɾ���������*/
        public static bool DelProductSell(string p)
        {
            return DAL.dalProductSell.DelProductSell(p);
        }

        /*��ѯ�������*/
        public static System.Data.DataSet GetProductSell(string strWhere)
        {
            return DAL.dalProductSell.GetProductSell(strWhere);
        }

        /*����������ҳ��ѯ�������*/
        public static System.Data.DataTable GetProductSell(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductSell.GetProductSell(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĳ������*/
        public static System.Data.DataSet getAllProductSell()
        {
            return DAL.dalProductSell.getAllProductSell();
        }
    }
}
