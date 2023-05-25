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

        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
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
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"ProductOrderEdit.aspx?orderId=" + Request["orderId"] + "\"} else  {location.href=\"ProductOrderList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllProductOrder.AddProductOrder(productOrder))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"ProductOrderEdit.aspx\"} else  {location.href=\"ProductOrderList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductOrderList.aspx");
        }
    }
}

