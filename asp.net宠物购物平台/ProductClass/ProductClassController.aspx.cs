using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using com.force.json;

public partial class ProductClass_ProductClassController : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string action = Request.QueryString["action"];
        if (action == "add") addProductClass();
        if (action == "delete") deleteProductClass();
        if (action == "update") updateProductClass();
        if (action == "getProductClass") getProductClass();
        if (action == "listAll") listAll();
    }
    //处理添加宠物分类控制层方法
    protected void addProductClass()
    {
        int success = 0;
        string message = "";
        ENTITY.ProductClass productClass = new ENTITY.ProductClass();
        productClass.productClassName = Request["productClass.productClassName"];
        if (!BLL.bllProductClass.AddProductClass(productClass))
        {
            message = "添加宠物分类发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //处理删除宠物分类控制层方法
    protected void deleteProductClass()
    {
        int success = 0;
        string message = "";
        string productClassId = Request["productClassId"];
        try {
            BLL.bllProductClass.DelProductClass(productClassId);
            success = 1;
        } catch {
            message = "宠物分类删除失败";
        }
        writeResult(success, message);
    }

    //处理更新宠物分类控制层方法
    protected void updateProductClass()
    {
        int success = 0;
        string message = "";
        ENTITY.ProductClass productClass = new ENTITY.ProductClass();
        productClass.productClassId = int.Parse(Request["ProductClass.productClassId"]);
        productClass.productClassName = Request["productClass.productClassName"];
        if (!BLL.bllProductClass.EditProductClass(productClass))
        {
            message = "更新宠物分类发生错误!";
            writeResult(success, message);
            return;
        }
        success = 1;
        writeResult(success, message);
    }

    //获取单个宠物分类对象，返回json格式
    protected void getProductClass()
    {
        int productClassId = int.Parse(Request.QueryString["productClassId"]);
        ENTITY.ProductClass productClass = BLL.bllProductClass.getSomeProductClass(productClassId);
        JSONObject jsonProductClass = new JSONObject();
        jsonProductClass.Put("productClassId", productClass.productClassId);
        jsonProductClass.Put("productClassName", productClass.productClassName);
        Response.Write(jsonProductClass.ToString());
    }

    protected void listAll()
    {
        DataSet productClassDs = BLL.bllProductClass.getAllProductClass();
        JSONArray productClassArray = new JSONArray();
        for (int i = 0; i < productClassDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = productClassDs.Tables[0].Rows[i];
            JSONObject jsonProductClass = new JSONObject();
            jsonProductClass.Put("productClassId", Convert.ToInt32(dr["productClassId"]));
            jsonProductClass.Put("productClassName", dr["productClassName"].ToString());
            productClassArray.Put(jsonProductClass);
        }
        Response.Write(productClassArray.ToString());
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
