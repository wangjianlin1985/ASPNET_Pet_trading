using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���������ҵ���߼���*/
    public class bllXjcd{
        /*��ӳ��������*/
        public static bool AddXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.AddXjcd(xjcd);
        }

        /*����xjcdId��ȡĳ����������μ�¼*/
        public static ENTITY.Xjcd getSomeXjcd(int xjcdId)
        {
            return DAL.dalXjcd.getSomeXjcd(xjcdId);
        }

        /*���³��������*/
        public static bool EditXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.EditXjcd(xjcd);
        }

        /*ɾ�����������*/
        public static bool DelXjcd(string p)
        {
            return DAL.dalXjcd.DelXjcd(p);
        }

        /*��ѯ���������*/
        public static System.Data.DataSet GetXjcd(string strWhere)
        {
            return DAL.dalXjcd.GetXjcd(strWhere);
        }

        /*����������ҳ��ѯ���������*/
        public static System.Data.DataTable GetXjcd(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalXjcd.GetXjcd(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĳ��������*/
        public static System.Data.DataSet getAllXjcd()
        {
            return DAL.dalXjcd.getAllXjcd();
        }
    }
}
