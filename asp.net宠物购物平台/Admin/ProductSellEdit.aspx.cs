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
    public partial class ProductSellEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DAL.Function.CheckState();
            if (!IsPostBack)
            {
                BindProductClassproductClassObj();
                BindXjcdxjcdObj();
                BindUserInfouserObj();
                /*进入本信息添加页显示无图的图片*/
                this.ProductPhotoImage.ImageUrl = "../FileUpload/NoImage.jpg";
                if (Request["sellId"] != null)
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

        /*如果是需要对记录进行编辑需要在界面初始化显示数据*/
        private void LoadData()
        {
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "sellId")))
            {
                ENTITY.ProductSell productSell = BLL.bllProductSell.getSomeProductSell(Convert.ToInt32(Common.GetMes.GetRequestQuery(Request, "sellId")));
                productName.Value = productSell.productName;
                productClassObj.SelectedValue = productSell.productClassObj.ToString();
                productPhoto.Text = productSell.productPhoto;
                if (productSell.productPhoto != "") this.ProductPhotoImage.ImageUrl = "../" + productSell.productPhoto;
                sellPrice.Value = productSell.sellPrice.ToString("0.00");
                xjcdObj.SelectedValue = productSell.xjcdObj.ToString();
                sellDesc.Value = productSell.sellDesc;
                userObj.SelectedValue = productSell.userObj;
                addTime.Text = productSell.addTime.ToShortDateString() + " " + productSell.addTime.ToLongTimeString();
            }
        }

        protected void BtnProductSellSave_Click(object sender, EventArgs e)
        {
            ENTITY.ProductSell productSell = new ENTITY.ProductSell();
            productSell.productName = productName.Value;
            productSell.productClassObj = int.Parse(productClassObj.SelectedValue);
            if (productPhoto.Text == "") productPhoto.Text = "FileUpload/NoImage.jpg";
            productSell.productPhoto = productPhoto.Text;
            productSell.sellPrice = float.Parse(float.Parse(sellPrice.Value).ToString("0.00"));
            productSell.xjcdObj = int.Parse(xjcdObj.SelectedValue);
            productSell.sellDesc = sellDesc.Value;
            productSell.userObj = userObj.SelectedValue;
            productSell.addTime = Convert.ToDateTime(addTime.Text);
            if (!string.IsNullOrEmpty(Common.GetMes.GetRequestQuery(Request, "sellId")))
            {
                productSell.sellId = int.Parse(Request["sellId"]);
                if (BLL.bllProductSell.EditProductSell(productSell))
                {
                    Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息修改成功，是否继续修改？否则返回信息列表。\")) {location.href=\"ProductSellEdit.aspx?sellId=" + Request["sellId"] + "\"} else  {location.href=\"ProductSellList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息修改失败，请重试或联系管理人员..");
                }
            }
            else
            {
                if (BLL.bllProductSell.AddProductSell(productSell))
                {
                   Common.ShowMessage.myScriptMes(Page, "Suess", "if(confirm(\"信息添加成功，是否继续添加？否则返回信息列表。\")) {location.href=\"ProductSellEdit.aspx\"} else  {location.href=\"ProductSellList.aspx\"} ");
                }
                else
                {
                    Common.ShowMessage.Show(Page, "error", "信息添加失败，请重试或联系管理人员..");
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProductSellList.aspx");
        }
        protected void Btn_ProductPhotoUpload_Click(object sender, EventArgs e)
        {
            /*如果用户上传了文件*/
            if (this.ProductPhotoUpload.PostedFile.ContentLength > 0)
            {
                /*验证上传的文件格式，只能为gif和jpeg格式*/
                string mimeType = this.ProductPhotoUpload.PostedFile.ContentType;
                if (String.Compare(mimeType, "image/gif", true) == 0 || String.Compare(mimeType, "image/pjpeg", true) == 0 || String.Compare(mimeType, "image/jpeg", true) == 0)
                {
                    this.productPhoto.Text = "上传文件中....";
                    string extFileString = System.IO.Path.GetExtension(this.ProductPhotoUpload.PostedFile.FileName); /*获取文件扩展名*/
                    string saveFileName = DAL.Function.MakeFileName(extFileString); /*根据扩展名生成文件名*/
                    string imagePath = "FileUpload/" + saveFileName;/*图片路径*/
                    this.ProductPhotoUpload.PostedFile.SaveAs(Server.MapPath("../" + imagePath));
                    this.ProductPhotoImage.ImageUrl = "../" + imagePath;
                    this.productPhoto.Text = imagePath;
                }
                else
                {
                    Response.Write("<script>alert('上传文件格式不正确!');</script>");
                }
            }
        }
    }
}

