<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LeavewordEdit.aspx.cs" Inherits="chengxusheji.Admin.LeavewordEdit" %>
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
            var leaveTitle = document.getElementById("leaveTitle").value;
            if (leaveTitle == "") {
                alert("请输入留言标题...");
                document.getElementById("leaveTitle").focus();
                return false;
            }

            var leaveContent = document.getElementById("leaveContent").value;
            if (leaveContent == "") {
                alert("请输入留言内容...");
                document.getElementById("leaveContent").focus();
                return false;
            }

            var leaveTime = document.getElementById("leaveTime").value;
            if (leaveTime == "") {
                alert("请输入留言时间...");
                document.getElementById("leaveTime").focus();
                return false;
            }

            var replyTime = document.getElementById("replyTime").value;
            if (replyTime == "") {
                alert("请输入回复时间...");
                document.getElementById("replyTime").focus();
                return false;
            }

            return true;
       } 
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="div_All">
    <div class="Body_Title">留言管理 》》编辑留言</div>
        <hr />
        <table cellspacing="1" cellpadding="2">
                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   留言标题：</td>
                    <td width="650px;">
                         <input id="leaveTitle" type="text"   style="width:800px;" runat="server" maxlength="25"/><span class="WarnMes">*</span>请输入留言标题！</td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   留言内容：</td>
                    <td width="650px;">
                        <textarea id="leaveContent" rows=6 cols=80 runat="server"></textarea><span class="WarnMes">*</span>请输入留言内容！</td>
                </tr>

                <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                    留言人：</td>
                    <td width="650px;">
                         <asp:DropDownList ID="userObj" runat="server" AutoPostBack="true">
                </asp:DropDownList></td>
                </tr>

                  <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  留言时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="leaveTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                 <tr>
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                   管理回复：</td>
                    <td width="650px;">
                        <textarea id="replyContent" rows=6 cols=80 runat="server"></textarea></td>
                </tr>

                  <tr style="display:none;">
                    <td style="width:80px; text-align:right; font-weight:bolder;">
                  回复时间：</td>
                    <td width="650px;">
                          <asp:TextBox ID="replyTime"  runat="server" Width="150px"
                              onclick="javascript:SelectDate(this,'yyyy-MM-dd hh:mm:ss');"></asp:TextBox></td>
                </tr>

                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="BtnLeavewordSave" runat="server" Text=" 保存信息 "
                            OnClientClick="return CheckIn()" onclick="BtnLeavewordSave_Click"  />
                        <asp:Button ID="Button1" runat="server" Text="取消" onclick="Button1_Click" /></td>
                </tr>
            </table>
    </div>
    </form>
</body>
</html>

