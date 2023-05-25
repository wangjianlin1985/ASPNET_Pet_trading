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
    public partial class ProductSeekEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindProductClassproductClassObj();
                BindXjcdxjcdObj();
                BindUserInfouserObj();
                /*���뱾��Ϣ���ҳ��ʾ��ͼ��ͼƬ*/
                this.ProductPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["seekId"] != null)
                {
                    LoadData();
                }
            }
        }
        private void BindProductClassproductClassObj()
        {
            productClassObj.DataSource = BLL.bllProductClass.getAllProductClass();
            productClassObj.DataTextField = "productClassName";
            productClassObj.DataValueField = "productClassId";
            productClassObj.DataBind();
        }

        private void BindXjcdxjcdObj()
        {
            xjcdObj.DataSource = BLL.bllXjcd.getAllXjcd();
            xjcdObj.DataTextField = "xjcdName";
            xjcdObj.DataValueField = "xjcdId";
            xjcdObj.DataBind();
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
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "seekId")))
            {
                ENTITY.ProductSeek productSeek = BLL.bllProductSeek.getSomeProductSeek(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "seekId")));
                productName.Value = productSeek.productName;
                productClassObj.SelectedValue = productSeek.productClassObj.ToString();
                productPhoto.Text = productSeek.productPhoto;
                if (productSeek.productPhoto != "") this.ProductPhotoImage.ImageUrl = "../" + productSeek.productPhoto;
                price.Value = productSeek.price.ToString("0.00");
                xjcdObj.SelectedValue = productSeek.xjcdObj.ToString();
                seekDesc.Value = productSeek.seekDesc;
                userObj.SelectedValue = productSeek.userObj;
                addTime.Text = productSeek.addTime.ToShortDateString() + " " + productSeek.addTime.ToLongTimeString();
            }
        }

        protected void BtnProductSeekSave_Click(object sender, EventArgs e)
        {
            ENTITY.ProductSeek productSeek = new ENTITY.ProductSeek();
            productSeek.productName = productName.Value;
            productSeek.productClassObj = int.Parse(productClassObj.SelectedValue);
            if (productPhoto.Text == "") productPhoto.Text = "FileUpload/NoImage.jpg";
            productSeek.productPhoto = productPhoto.Text;
            productSeek.price = float.Parse(float.Parse(price.Value).ToString("0.00"));
            productSeek.xjcdObj = int.Parse(xjcdObj.SelectedValue);
            productSeek.seekDesc = seekDesc.Value;
            productSeek.userObj = userObj.SelectedValue;
            productSeek.addTime = Convert.ToDateTime(addTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "seekId")))
            {
                productSeek.seekId = int.Parse(Request["seekId"]);
                if (BLL.bllProductSeek.EditProductSeek(productSeek))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ�޸ĳɹ����Ƿ�����޸ģ����򷵻���Ϣ�б�\")) {location.href=\"ProductSeekEdit.aspx?seekId=" + Request["seekId"] + "\"} else  {location.href=\"ProductSeekList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ�޸�ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
            else
            {
                if (BLL.bllProductSeek.AddProductSeek(productSeek))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"��Ϣ��ӳɹ����Ƿ������ӣ����򷵻���Ϣ�б�\")) {location.href=\"ProductSeekEdit.aspx\"} else  {location.href=\"ProductSeekList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "��Ϣ���ʧ�ܣ������Ի���ϵ������Ա..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductSeekList.aspx");
        }
        protected void Btn_ProductPhotoUpload_Click(object sender, EventArgs e)
        {
            /*����û��ϴ����ļ�*/
            if (this.ProductPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*��֤�ϴ����ļ���ʽ��ֻ��Ϊgif��jpeg��ʽ*/
                string mimeType = this.ProductPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.productPhoto.Text = "�ϴ��ļ���....";
                    string extFileString = System.IO.Path.GetExtension(this.ProductPhotoUpload.PostedFile.FileName); /*��ȡ�ļ���չ��*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*������չ�������ļ���*/
                    string imagePath = "FileUpload/" + saveFileName;/*ͼƬ·��*/
                    this.ProductPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.ProductPhotoImage.ImageUrl = "../" + imagePath;
                    this.productPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('�ϴ��ļ���ʽ����ȷ!');</script>");
                }
            }
        }
    }
}

