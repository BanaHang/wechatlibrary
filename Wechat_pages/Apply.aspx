<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Apply.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.Apply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"/>
    <title></title>
    <style type="text/css">
        td{
            width:300px;
            height:80px;
            padding-left:5%;
            padding-right:5%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:FangSong; font-size: x-large;text-align:center">
    <center>
        <br /><br />
        <p style="font-family: 微软雅黑; font-size: xx-large;text-align:center">提示：请填写申请购买的图书的相关信息，以方便采购。</p>
        <br /><br />
        <table border="1">
            <tr>
                <td colspan="2"  style="padding-left:42%">图书申购</td>
            </tr>
            <tr>
                <td>图书名称：</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td>作者：</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td>出版社：</td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Width="100%" Height="60%" Font-Names="微软雅黑 Light" Font-Size="X-Large"></asp:TextBox>                   
                </td>
            </tr>
            <tr>
                <td colspan="2" style="padding-left:35%">
                    <asp:Button ID="Button1" runat="server" Text="申请购买" Height="60%" Width="200px" OnClick="Button1_Click" Font-Names="仿宋" Font-Size="X-Large" />
                </td>
            </tr>
        </table>

        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="图书名不能为空！" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="请作者名称！" ControlToValidate="TextBox4"></asp:RequiredFieldValidator>

    </center>
    </div>
    </form>
</body>
</html>
