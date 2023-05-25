using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace chengxusheji.Admin
{
    public partial class ProductOrderEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindProductSellbookSellObj();
                BindUserInfouserObj();
                if (Request["orderId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindProductSellbookSellObj()
        {
            bookSellObj.DataSource = BLL.bllProductSell.getAllProductSell();
            bookSellObj.DataTextField = "productName";
            bookSellObj.DataValueField = "sellId";
            bookSellObj.DataBind();
        }

        private void BindUserInfouserObj()
        {
            userObj.DataSource = BLL.bllUserInfo.getAllUserInfo();
            userObj.DataTextField = "name";
            userObj.DataValueField = "user_name";
            userObj.DataBind();
        }

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "orderId")))
            {
                ENTITY.ProductOrder productOrder = BLL.bllProductOrder.getSomeProductOrder(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "orderId")));
                bookSellObj.SelectedValue = productOrder.bookSellObj.ToString();
                userObj.SelectedValue = productOrder.userObj;
                price.Value = productOrder.price.ToString("0.00");
                orderMemo.Value = productOrder.orderMemo;
                addTime.Text = productOrder.addTime.ToShortDateString() + " " + productOrder.addTime.ToLongTimeString();
            }
        }

        protected void BtnProductOrderSave_Click(object sender, EventArgs e)
        {
            ENTITY.ProductOrder productOrder = new ENTITY.ProductOrder();
            productOrder.bookSellObj = int.Parse(bookSellObj.SelectedValue);
            productOrder.userObj = userObj.SelectedValue;
            productOrder.price = float.Parse(float.Parse(price.Value).ToString("0.00"));
            productOrder.orderMemo = orderMemo.Value;
            productOrder.addTime = Convert.ToDateTime(addTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "orderId")))
            {
                productOrder.orderId = int.Parse(Request["orderId"]);
                if (BLL.bllProductOrder.EditProductOrder(productOrder))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"ProductOrderEdit.aspx?orderId=" + Request["orderId"] + "\"} else  {location.href=\"ProductOrderList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllProductOrder.AddProductOrder(productOrder))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"ProductOrderEdit.aspx\"} else  {location.href=\"ProductOrderList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductOrderList.aspx");
        }
    }
}

