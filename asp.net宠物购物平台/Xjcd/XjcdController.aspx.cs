using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Xjcd_XjcdController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addXjcd();
        if (action == "delete") deleteXjcd();
        if (action == "update") updateXjcd();
        if (action == "getXjcd") getXjcd();
        if (action == "listAll") listAll();
    }
    //处理添加宠物年龄段控制层方法
    protected void addXjcd()
    {
        int success = 0;
        string message = "";
        ENTITY.Xjcd xjcd = new ENTITY.Xjcd();
        xjcd.xjcdName = Request["xjcd.xjcdName"];
        if (!BLL.bllXjcd.AddXjcd(xjcd))
        {
            message = "添加宠物年龄段发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除宠物年龄段控制层方法
    protected void deleteXjcd()
    {
        int success = 0;
        string message = "";
        string xjcdId = Request["xjcdId"];
        try {
            BLL.bllXjcd.DelXjcd(xjcdId);
            success = 1;
        } catch {
            message = "宠物年龄段删除失败";
        }
        writeResult(success, message);
    }

    //处理更新宠物年龄段控制层方法
    protected void updateXjcd()
    {
        int success = 0;
        string message = "";
        ENTITY.Xjcd xjcd = new ENTITY.Xjcd();
        xjcd.xjcdId = int.Parse(Request["Xjcd.xjcdId"]);
        xjcd.xjcdName = Request["xjcd.xjcdName"];
        if (!BLL.bllXjcd.EditXjcd(xjcd))
        {
            message = "更新宠物年龄段发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个宠物年龄段对象，返回json格式
    protected void getXjcd()
    {
        int xjcdId = int.Parse(Request.QueryString["xjcdId"]);
        ENTITY.Xjcd xjcd = BLL.bllXjcd.getSomeXjcd(xjcdId);
        JSONObject jsonXjcd = new JSONObject();
        jsonXjcd.Put("xjcdId", xjcd.xjcdId);
        jsonXjcd.Put("xjcdName", xjcd.xjcdName);
        Response.Write(jsonXjcd.ToString());
    }

    protected void listAll()
    {
        DataSet xjcdDs = BLL.bllXjcd.getAllXjcd();
        JSONArray xjcdArray = new JSONArray();
        for (int i = 0; i < xjcdDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = xjcdDs.Tables[0].Rows[i];
            JSONObject jsonXjcd = new JSONObject();
            jsonXjcd.Put("xjcdId", Convert.ToInt32(dr["xjcdId"]));
            jsonXjcd.Put("xjcdName", dr["xjcdName"].ToString());
            xjcdArray.Put(jsonXjcd);
        }
        Response.Write(xjcdArray.ToString());
    }

    //把处理结果返回给界面层
    protected void writeResult(int success, string message)
    {
        JSONObject resultObj = new JSONObject();
        resultObj.Put("success", success);
        resultObj.Put("message", message);
        Response.Write(resultObj.ToString());
    }

}
