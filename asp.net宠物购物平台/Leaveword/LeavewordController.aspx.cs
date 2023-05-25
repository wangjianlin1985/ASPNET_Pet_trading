using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class Leaveword_LeavewordController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addLeaveword();
        if (action == "userAdd") userAddLeaveword();
        if (action == "delete") deleteLeaveword();
        if (action == "update") updateLeaveword();
        if (action == "getLeaveword") getLeaveword();
        if (action == "listAll") listAll();
    }
    //处理添加留言控制层方法
    protected void addLeaveword()
    {
        int success = 0;
        string message = "";
        ENTITY.Leaveword leaveword = new ENTITY.Leaveword();
        leaveword.leaveTitle = Request["leaveword.leaveTitle"];
        leaveword.leaveContent = Request["leaveword.leaveContent"];
        leaveword.userObj = Request["leaveword.userObj.user_name"];
        leaveword.leaveTime = Convert.ToDateTime(Request["leaveword.leaveTime"]);
        leaveword.replyContent = Request["leaveword.replyContent"];
        leaveword.replyTime = Convert.ToDateTime(Request["leaveword.replyTime"]);
        if (!BLL.bllLeaveword.AddLeaveword(leaveword))
        {
            message = "添加留言发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理添加留言控制层方法
    protected void userAddLeaveword()
    {
        int success = 0;
        string message = "";

        if (Session["user_name"] == null)
        {
            message = "请先登录网站!";
            writeResult(success, message);
            return;
        }

        ENTITY.Leaveword leaveword = new ENTITY.Leaveword();
        leaveword.leaveTitle = Request["leaveword.leaveTitle"];
        leaveword.leaveContent = Request["leaveword.leaveContent"];
        leaveword.userObj = Session["user_name"].ToString();
        leaveword.leaveTime = Convert.ToDateTime(DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToLongTimeString());
        leaveword.replyContent = Request["leaveword.replyContent"];
        leaveword.replyTime = Convert.ToDateTime(Request["leaveword.replyTime"]);
        if (!BLL.bllLeaveword.AddLeaveword(leaveword))
        {
            message = "添加留言发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }


    //处理删除留言控制层方法
    protected void deleteLeaveword()
    {
        int success = 0;
        string message = "";
        string leaveWordId = Request["leaveWordId"];
        try {
            BLL.bllLeaveword.DelLeaveword(leaveWordId);
            success = 1;
        } catch {
            message = "留言删除失败";
        }
        writeResult(success, message);
    }

    //处理更新留言控制层方法
    protected void updateLeaveword()
    {
        int success = 0;
        string message = "";
        ENTITY.Leaveword leaveword = new ENTITY.Leaveword();
        leaveword.leaveWordId = int.Parse(Request["Leaveword.leaveWordId"]);
        leaveword.leaveTitle = Request["leaveword.leaveTitle"];
        leaveword.leaveContent = Request["leaveword.leaveContent"];
        leaveword.userObj = Request["leaveword.userObj.user_name"];
        leaveword.leaveTime = Convert.ToDateTime(Request["leaveword.leaveTime"]);
        leaveword.replyContent = Request["leaveword.replyContent"];
        leaveword.replyTime = Convert.ToDateTime(Request["leaveword.replyTime"]);
        if (!BLL.bllLeaveword.EditLeaveword(leaveword))
        {
            message = "更新留言发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个留言对象，返回json格式
    protected void getLeaveword()
    {
        int leaveWordId = int.Parse(Request.QueryString["leaveWordId"]);
        ENTITY.Leaveword leaveword = BLL.bllLeaveword.getSomeLeaveword(leaveWordId);
        JSONObject jsonLeaveword = new JSONObject();
        jsonLeaveword.Put("leaveWordId", leaveword.leaveWordId);
        jsonLeaveword.Put("leaveTitle", leaveword.leaveTitle);
        jsonLeaveword.Put("leaveContent", leaveword.leaveContent);
        jsonLeaveword.Put("userObj", BLL.bllUserInfo.getSomeUserInfo(leaveword.userObj).name);
        jsonLeaveword.Put("userObjPri", leaveword.userObj);
        jsonLeaveword.Put("leaveTime", leaveword.leaveTime.ToShortDateString() + " " + leaveword.leaveTime.ToLongTimeString());
        jsonLeaveword.Put("replyContent", leaveword.replyContent);
        jsonLeaveword.Put("replyTime", leaveword.replyTime.ToShortDateString() + " " + leaveword.replyTime.ToLongTimeString());
        Response.Write(jsonLeaveword.ToString());
    }

    protected void listAll()
    {
        DataSet leavewordDs = BLL.bllLeaveword.getAllLeaveword();
        JSONArray leavewordArray = new JSONArray();
        for (int i = 0; i < leavewordDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = leavewordDs.Tables[0].Rows[i];
            JSONObject jsonLeaveword = new JSONObject();
            jsonLeaveword.Put("leaveWordId", Convert.ToInt32(dr["leaveWordId"]));
            jsonLeaveword.Put("leaveTitle", dr["leaveTitle"].ToString());
            leavewordArray.Put(jsonLeaveword);
        }
        Response.Write(leavewordArray.ToString());
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
