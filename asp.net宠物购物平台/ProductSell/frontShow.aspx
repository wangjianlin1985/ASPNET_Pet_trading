<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontShow.aspx.cs" Inherits="ProductSell_frontShow" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
    ENTITY.ProductSell productSell = BLL.bllProductSell.getSomeProductSell(int.Parse(Request.QueryString["sellId"]));
    
    System.Data.DataSet orderDs = BLL.bllProductOrder.GetProductOrder(" where bookSellObj=" + Request.QueryString["sellId"]);
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>查看宠物出售详情</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<uc:header ID="header" runat="server" />
<div class="container">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li><a href="<%=basePath %>ProductSell/frontList.aspx">宠物出售信息</a></li>
  		<li class="active">详情查看</li>
	</ul>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">出售id:</div>
		<div class="col-md-10 col-xs-6"><%=productSell.sellId%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">宠物名称:</div>
		<div class="col-md-10 col-xs-6"><%=productSell.productName%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">宠物分类:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllProductClass.getSomeProductClass(productSell.productClassObj).productClassName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">宠物主图:</div>
		<div class="col-md-10 col-xs-6"><img class="img-responsive" src="<%=basePath %><%=productSell.productPhoto %>"  border="0px"/></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">出售价格:</div>
		<div class="col-md-10 col-xs-6"><%=productSell.sellPrice%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">宠物年龄段:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllXjcd.getSomeXjcd(productSell.xjcdObj).xjcdName %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">出售说明:</div>
		<div class="col-md-10 col-xs-6"><%=productSell.sellDesc%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发布用户:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllUserInfo.getSomeUserInfo(productSell.userObj).name %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发布时间:</div>
		<div class="col-md-10 col-xs-6"><%=productSell.addTime%></div>
	</div>
	<div class="row bottom15">
		<div class="col-md-2 col-xs-4"></div>
		<div class="col-md-6 col-xs-6">
			<a href="<%=basePath %>ProductOrder/frontUserAdd.aspx?sellId=<%=productSell.sellId %>" class="btn btn-primary">我想买</a>
			<button onclick="history.back();" class="btn btn-info">返回</button>
		</div>
	</div>

    
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold"></div>
		<div class="col-md-8 col-xs-7">
			<% for (int i = 0; i < orderDs.Tables[0].Rows.Count; i++) { 
                System.Data.DataRow  dr = orderDs.Tables[0].Rows[i];
		        String user_name = dr["userObj"].ToString();
                ENTITY.UserInfo user = BLL.bllUserInfo.getSomeUserInfo(user_name);
		    %>
			<div class="row" style="margin-top: 20px;">
				<div class="col-md-2 col-xs-3">
					<div class="row text-center"><img src="<%=basePath %><%=user.userPhoto %>" style="border: none;width:60px;height:60px;border-radius: 50%;" /></div>
					<div class="row text-center" style="margin: 5px 0px;"><%=user.user_name%></div>
				</div>
				<div class="col-md-7 col-xs-5"><font color="red">出价:¥<%=dr["price"]%></font>&nbsp;&nbsp;<%=dr["orderMemo"]%></div>
				<div class="col-md-3 col-xs-4" ><%=dr["addTime"]%></div>
			</div>
		
			<% } %>
		 
		</div>
	</div>

	
</div> 
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script>
var basePath = "<%=basePath%>";
$(function(){
        /*小屏幕导航点击关闭菜单*/
        $('.navbar-collapse a').click(function(){
            $('.navbar-collapse').collapse('hide');
        });
        new WOW().init();
 })
 </script> 
</body>
</html>

