<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductSeekEdit.aspx.cs" Inherits="chengxusheji.Admin.ProductSeekEdit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
   <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script type="text/javascript" src="JavaScript/Admin.js"></script>
    <script type="text/javascript" src="../js/jsdate.js"></script>
    <script type="text/javascript">
        function CheckIn() {
            var re = /^[0-9]+.?[0-9]*$/;
            var resc=/^[1-9]+[0-9]*]*$/ ;
            var productName = document.getElementById("productName").value;
            if (productName == "") {
                alert("请输入宠物名称...");
                document.getElementById("productName").focus();
                return false;
            }

            var price = document.getElementById("price").value;
            if(price == ""){
                alert("请输入求购价格...");
                document.getElementById("price").focus();
                return false;
            }
            else if (!re.test(price))
            {
                alert("求购价格请输入数字");
                document.getElementById("price").focus();
                //input.rate.focus();
                return false;
            }

            var seekDesc = document.getElementById("seekDesc").value;
            if (seekDesc == "") {
                alert("请输入求购说明...");
                document.getElementById("seekDesc").focus();
                return false;
            }

            var addTime = document.getElementById("addTime").value;
            if (addTime == "") {
                alert("请输入发布时间...");
                document.getElementById("addTime").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">宠物求购管理 》》编辑宠物求购</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   宠物名称：</td>
                    <td width="650px;">
                         <input id="productName" type="text"   style="width:400px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入宠物名称！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    宠物类别：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="productClassObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   宠物主图：</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         图片路径：<asp:TextBox ID="productPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         上传图片：<asp:FileUpload ID="ProductPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_ProductPhotoUpload" runat="server" Text="上传" OnClick="Btn_ProductPhotoUpload_Click" /></td><td>
                         <asp:Image ID="ProductPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   求购价格：</td>
                    <td width="650px;">
                         <input id="price" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入求购价格！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    宠物年龄段：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="xjcdObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   求购说明：</td>
                    <td width="650px;">
                        <textarea id="seekDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入求购说明！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    发布用户：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  发布时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="addTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnProductSeekSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnProductSeekSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

