<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.Order" %>

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

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:FangSong; font-size: xx-large;text-align:center">
    <center>
        <p style="font-family: 微软雅黑; font-size: xx-large;text-align:center">提示：请填写表格相关信息，以方便通知。</p>
        <table border="1">
            <tr>
                <td colspan="2" style="padding-left:38%">图书预约</td>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Overline="False" Font-Size="X-Large"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td>用户学号/工号：</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td>图书序号：</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox>                    
                </td>
            </tr>
            <tr>
                <td>图书名称：</td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-left:40%">
                    <asp:Button ID="Button1" runat="server" Text="确定预约"  Height="60%" OnClick="Button1_Click" Font-Names="仿宋" Font-Size="X-Large" />
                </td>
            </tr>
        </table>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="用户名不能为空！" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入学号或工号！" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="图书序号不能为空！" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="图书名称不能为空！" ControlToValidate="TextBox6"></asp:RequiredFieldValidator>

    </center>
    </div>
    </form>
</body>
</html>
