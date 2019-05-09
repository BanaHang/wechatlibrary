<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserRegister.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.UserRegister" %>

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
                <td colspan="2" style="padding-left:36%" >用户注册</td>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="XX-Large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>用户学号/工号：</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="XX-Large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>用户类型：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="XX-Large">
                        <asp:ListItem>本科生</asp:ListItem>
                        <asp:ListItem>研究生</asp:ListItem>
                        <asp:ListItem>博士生</asp:ListItem>
                        <asp:ListItem>教职工</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>用户密码：</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="100%" Height="60%" TextMode="Password" Font-Names="微软雅黑 Light" Font-Size="XX-Large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>再次输入密码：</td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="100%" Height="60%" TextMode="Password" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" style="text-align:center;padding-left:40px">
                    <asp:Button ID="Button1" runat="server" Text="注册" Height="60%" Width="150px" OnClick="Button1_Click" Font-Names="微软雅黑" Font-Size="X-Large" BackColor="#005555" BorderStyle="None" ForeColor="White" />
                </td>
            </tr>
        </table>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="新用户名不能为空！" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入学号或工号！" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="密码不能为空！" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="输入错误！" ControlToValidate="TextBox6" ControlToCompare="TextBox5"></asp:CompareValidator>

    </center>
    </div>
    </form>
</body>
</html>
