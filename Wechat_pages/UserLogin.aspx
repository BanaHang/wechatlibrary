<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.UserLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"/>
    <title></title>

    <style type="text/css">
        td{
            width:250px;
            height:80px;
            padding-left:5%;
            padding-right:5%;
        }
        table{
            background-color:#2B2B2B;
            opacity:0.9;
            color:#00688B;
            border-style:none;
            border-radius:8px 8px;
        }
    </style>
</head>
<body style="background-image:url(../images/UL.jpg);background-size:cover;">
    <form id="form1" runat="server">
    <div style="font-family: 微软雅黑; font-size: xx-large;">
    <center>
        <br /><br />
        <table border="1">
            <tr>
                <td colspan="2" style="padding-left:36%">用户登陆</td>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="XX-Large"></asp:TextBox></td>               
            </tr>
            <tr>
                <td>密码：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="100%" Height="60%" TextMode="Password" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox></td>                
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;padding-left:40px">
                    <asp:Button ID="Button1" runat="server" Text="登陆" Height="60%" Width="150px" OnClick="Button1_Click" Font-Names="微软雅黑" Font-Size="X-Large" BackColor="#005555" BorderStyle="None" ForeColor="White" />
                </td>              
            </tr>
        </table>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空！" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空!" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
        <p>新用户注册，<a href="UserRegister.aspx">请点击这里</a>。</p>
    </center>
    </div>
    </form>
</body>
</html>
