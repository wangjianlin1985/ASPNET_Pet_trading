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
    public partial class XjcdEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                if (Request["xjcdId"] != null)
                {
                    LoadData();
                }
            }
        }
        /*�������Ҫ�Լ�¼���б༭��Ҫ�ڽ����ʼ����ʾ����*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "xjcdId")))
            {
                ENTITY.Xjcd xjcd = BLL.bllXjcd.getSomeXjcd(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "xjcdId")));
                xjcdName.Value = xjcd.xjcdName;
            }
        }

        protected void BtnXjcdSave_Click(object sender, EventArgs e)
        {
            ENTITY.Xjcd xjcd = new ENTITY.Xjcd();
            xjcd.xjcdName = xjcdName.Value;
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "xjcdId")))
            {
                xjcd.xjcdId = int.Parse(Request["xjcdId"]);
                if (BLL.bllXjcd.EditXjcd(xjcd))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"XjcdEdit.aspx?xjcdId=" + Request["xjcdId"] + "\"} else  {location.href=\"XjcdList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllXjcd.AddXjcd(xjcd))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"XjcdEdit.aspx\"} else  {location.href=\"XjcdList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("XjcdList.aspx");
        }
    }
}

