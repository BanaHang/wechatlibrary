<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminAdd.aspx.cs" Inherits="LibraryDemo_1.PC_pages.AdminAdd1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    <style type="text/css">
        td{
            width:400px;
            height:60px;
            padding-left:5%;
            padding-right:5%;
        }
        th{
            width:800px;
            height:60px;
            padding-left:5%;
            padding-right:5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="login" style="padding-left:5%; padding-top:10px; text-align:center; height:500px">
        <center>
        <table border="1">
            <tr>
                <th colspan="2" style="font-size:x-large">新增管理员</th>
            </tr>
            <tr>
                <td>请输入一个已注册管理员名：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%" Height="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>请输入该用户的密码：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="100%" Height="60%" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>新增用户名：</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%" Height="60%"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td>新增用户工号/身份证号：</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%" Height="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>新增用户密码：</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="100%" Height="60%" TextMode="Password"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td>再次输入密码：</td>
                <td>
                    <asp:TextBox ID="TextBox6" runat="server" Width="100%" Height="60%" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="2" style="text-align:center">
                    <asp:Button ID="Button1" runat="server" Text="注册" Height="60%" Width="150px" OnClick="Button1_Click" Font-Size="Medium" />
                </th>
            </tr>
        </table>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="管理员名称不能为空！" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="密码错误！" ControlToValidate="TextBox2" OnServerValidate="CustomValidate_1"></asp:CustomValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="新用户名不能为空！" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请输入工号或身份证号！" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="密码不能为空！" ControlToValidate="TextBox5"></asp:RequiredFieldValidator>
        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="输入错误！" ControlToValidate="TextBox6" ControlToCompare="TextBox5"></asp:CompareValidator>
        </center>
    </div>
    </form>
</body>
</html>
