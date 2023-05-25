<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductSellEdit.aspx.cs" Inherits="chengxusheji.Admin.ProductSellEdit" %>
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
                alert("�������������...");
                document.getElementById("productName").focus();
                return false;
            }

            var sellPrice = document.getElementById("sellPrice").value;
            if(sellPrice == ""){
                alert("��������ۼ۸�...");
                document.getElementById("sellPrice").focus();
                return false;
            }
            else if (!re.test(sellPrice))
            {
                alert("���ۼ۸�����������");
                document.getElementById("sellPrice").focus();
                //input.rate.focus();
                return false;
            }

            var sellDesc = document.getElementById("sellDesc").value;
            if (sellDesc == "") {
                alert("���������˵��...");
                document.getElementById("sellDesc").focus();
                return false;
            }

            var addTime = document.getElementById("addTime").value;
            if (addTime == "") {
                alert("�����뷢��ʱ��...");
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
    <div class="Body_Title">������۹��� �����༭�������</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   �������ƣ�</td>
                    <td width="650px;">
                         <input id="productName" type="text"   style="width:400px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>������������ƣ�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ������ࣺ</td>
                    <td width="650px;">
                         <asp:DropDownList ID="productClassObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ������ͼ��</td>
                    <td width="650px;">
                       <table cellpadding="0px" cellspacing="0px" width="90%">
                        <tr><td width="400px">
                         ͼƬ·����<asp:TextBox ID="productPhoto" runat="server" ReadOnly="True" Width="228px" Enabled="False"></asp:TextBox> &nbsp; &nbsp; &nbsp
                         <br />
                         <br />
                         �ϴ�ͼƬ��<asp:FileUpload ID="ProductPhotoUpload" runat="server" Width="237px" />&nbsp;
                         <asp:Button ID="Btn_ProductPhotoUpload" runat="server" Text="�ϴ�" OnClick="Btn_ProductPhotoUpload_Click" /></td><td>
                         <asp:Image ID="ProductPhotoImage" runat="server" Height="90px" Width="99px" />
                         </td></tr>
                       </table>
                    </td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ���ۼ۸�</td>
                    <td width="650px;">
                         <input id="sellPrice" type="text"   style="width:74px;" runat="server"
                             maxlength="25"/><span class="WarnMes">*</span>��������ۼ۸�</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    ��������Σ�</td>
                    <td width="650px;">
                         <asp:DropDownList ID="xjcdObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   ����˵����</td>
                    <td width="650px;">
                        <textarea id="sellDesc" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>���������˵����</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    �����û���</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  ����ʱ�䣺</td>
                    <td width="650px;">
                          <asp:TextBox ID="addTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnProductSellSave" runat="server" Text=" ������Ϣ "
                            OnClientClick="return CheckIn()" onclick="BtnProductSellSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="ȡ��" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

