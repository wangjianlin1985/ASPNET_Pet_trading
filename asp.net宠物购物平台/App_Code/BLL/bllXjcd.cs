using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*宠物年龄段业务逻辑层*/
    public class bllXjcd{
        /*添加宠物年龄段*/
        public static bool AddXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.AddXjcd(xjcd);
        }

        /*根据xjcdId获取某条宠物年龄段记录*/
        public static ENTITY.Xjcd getSomeXjcd(int xjcdId)
        {
            return DAL.dalXjcd.getSomeXjcd(xjcdId);
        }

        /*更新宠物年龄段*/
        public static bool EditXjcd(ENTITY.Xjcd xjcd)
        {
            return DAL.dalXjcd.EditXjcd(xjcd);
        }

        /*删除宠物年龄段*/
        public static bool DelXjcd(string p)
        {
            return DAL.dalXjcd.DelXjcd(p);
        }

        /*查询宠物年龄段*/
        public static System.Data.DataSet GetXjcd(string strWhere)
        {
            return DAL.dalXjcd.GetXjcd(strWhere);
        }

        /*根据条件分页查询宠物年龄段*/
        public static System.Data.DataTable GetXjcd(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalXjcd.GetXjcd(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的宠物年龄段*/
        public static System.Data.DataSet getAllXjcd()
        {
            return DAL.dalXjcd.getAllXjcd();
        }
    }
}
