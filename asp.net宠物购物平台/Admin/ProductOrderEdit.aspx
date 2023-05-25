<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductOrderEdit.aspx.cs" Inherits="chengxusheji.Admin.ProductOrderEdit" %>
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
            var price = document.getElementById("price").value;
            if(price == ""){
                alert("请输入意向出价...");
                document.getElementById("price").focus();
                return false;
            }
            else if (!re.test(price))
            {
                alert("意向出价请输入数字");
                document.getElementById("price").focus();
                //input.rate.focus();
                return false;
            }

            var addTime = document.getElementById("addTime").value;
            if (addTime == "") {
                alert("请输入下单时间...");
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
    <div class="Body_Title">宠物订单管理 》》编辑宠物订单</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    宠物信息：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="bookSellObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    意向用户：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   意向出价：</td>
                    <td width="650px;">
                         <input id="price" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>请输入意向出价！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   用户备注：</td>
                    <td width="650px;">
                        <textarea id="orderMemo" rows=6 cols=80 runat="server"></textarea></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  下单时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="addTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnProductOrderSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnProductOrderSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

