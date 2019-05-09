<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reader.aspx.cs" Inherits="LibraryDemo_1.PC_pages.Reader" %>

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
    <div style="padding-left:5%; padding-top:10px;">
        <center>
    <table border="1" style="text-align:center">
            <tr>
                <th colspan="2" style="font-size:x-large">读者信息</th>
            </tr>
            <tr>
                <td>序号：</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%"  Height="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>学号：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="100%"  Height="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>类型：</td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="微软雅黑" Font-Size="Medium" Width="80%">
                        <asp:ListItem>本科生</asp:ListItem>
                        <asp:ListItem>研究生</asp:ListItem>
                        <asp:ListItem>博士生</asp:ListItem>
                        <asp:ListItem>教职工</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>可借图书数量：</td>
                <td>
                    <asp:Label ID="Label2" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>密码：</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%"  Height="60%"></asp:TextBox>
                </td>
            </tr>
        </table>
        <br />&nbsp&nbsp&nbsp&nbsp
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空！" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="用户学号不能为空！" ControlToValidate="TextBox2"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="用户密码不能为空！" ControlToValidate="TextBox3"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="修改" Width="100px" OnClick="Button1_Click" Font-Size="Medium" Height="30px" />&nbsp
        <asp:Button ID="Button2" runat="server" Text="保存" Width="100px" OnClick="Button2_Click" OnClientClick="return confirm('确认保存修改信息？');" Font-Size="Medium" Height="30px" />&nbsp
        <asp:Button ID="Button3" runat="server" Text="删除该用户" Width="100px" OnClick="Button3_Click" OnClientClick="return confirm('确认删除该用户？');" Font-Size="Medium" Height="30px" />
    </center>
    </div>
    </form>
</body>
</html>
