<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.Book" %>

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
            color:white
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: 微软雅黑; font-size: x-large; background-color:#4F4F4F">
    <center>
        <br />
        <p style="color:white;font-size:xx-large">图书信息</p>
        <table style="text-align:center">
            
            <tr>
                <td>序号：</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>图书名称：</td>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>图书类别：</td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>作者：</td>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>出版社：</td>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>在馆数量：</td>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>价格：</td>
                <td>
                    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
        </table>

        <br />        
        <asp:Button ID="Button1" runat="server" Text="预约" OnClick="Button1_Click" Width="150px" Height="60px" Font-Names="微软雅黑" Font-Size="X-Large"></asp:Button>
        <br /><br />
        </div>
    </form>
</body>
</html>
