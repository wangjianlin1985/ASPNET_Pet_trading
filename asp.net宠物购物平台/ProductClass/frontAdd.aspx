﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontAdd.aspx.cs" Inherits="ProductClass_frontAdd" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>宠物分类添加</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
	<div class="col-md-12 wow fadeInLeft">
		<ul class="breadcrumb">
  			<li><a href="<%=basePath %>index.aspx">首页</a></li>
  			<li><a href="<%=basePath %>ProductClass/frontList.aspx">宠物分类管理</a></li>
  			<li class="active">添加宠物分类</li>
		</ul>
		<div class="row">
			<div class="col-md-10">
		      	<form class="form-horizontal" name="productClassAddForm" id="productClassAddForm" enctype="multipart/form-data" method="post"  class="mar_t15">
				  <div class="form-group">
				  	 <label for="productClass_productClassName" class="col-md-2 text-right">类别名称:</label>
				  	 <div class="col-md-8">
					    <input type="text" id="productClass_productClassName" name="productClass.productClassName" class="form-control" placeholder="请输入类别名称">
					 </div>
				  </div>
		          <div class="form-group">
		             <span class="col-md-2""></span>
		             <span onclick="ajaxProductClassAdd();" class="btn btn-primary bottom5 top5">添加</span>
		          </div> 
		          <style>#productClassAddForm .form-group {margin:5px;}  </style>  
				</form> 
			</div>
			<div class="col-md-2"></div> 
	    </div>
	</div>
</div>
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrapvalidator/js/bootstrapValidator.min.js"></script>
<script type="text/javascript" src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js" charset="UTF-8"></script>
<script type="text/javascript" src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js" charset="UTF-8"></script>
<script>
var basePath = "<%=basePath%>";
	//提交添加宠物分类信息
	function ajaxProductClassAdd() { 
		//提交之前先验证表单
		$("#productClassAddForm").data('bootstrapValidator').validate();
		if(!$("#productClassAddForm").data('bootstrapValidator').isValid()){
			return;
		}
		jQuery.ajax({
			type : "post",
			url : basePath + "ProductClass/ProductClassController.aspx?action=add",
			dataType : "json" , 
			data: new FormData($("#productClassAddForm")[0]),
			success : function(obj) {
				if(obj.success){ 
					alert("保存成功！");
					$("#productClassAddForm").find("input").val("");
					$("#productClassAddForm").find("textarea").val("");
				} else {
					alert(obj.message);
				}
			},
			processData: false, 
			contentType: false, 
		});
	} 
$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();
	//验证宠物分类添加表单字段
	$('#productClassAddForm').bootstrapValidator({
		feedbackIcons: {
			valid: 'glyphicon glyphicon-ok',
			invalid: 'glyphicon glyphicon-remove',
			validating: 'glyphicon glyphicon-refresh'
		},
		fields: {
			"productClass.productClassName": {
				validators: {
					notEmpty: {
						message: "类别名称不能为空",
					}
				}
			},
		}
	}); 
})
</script>
</body>
</html>
