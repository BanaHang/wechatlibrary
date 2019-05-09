<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="Book.aspx.cs" Inherits="LibraryDemo_1.PC_pages.Book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td{
            width:300px;
            height:50px;
            padding-left:5%;
            padding-right:5%;
        }
        th{
            width:600px;
            height:50px;
            padding-left:5%;
            padding-right:5%;
        }

        .auto-style1 {
            height: 60px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <center>
        <table border="1" style="text-align:center;">
            <tr>
                <th colspan="2" style="font-size:x-large">图书信息</th>
            </tr>
            <tr>
                <td>序号：</td>
                <td>
                    <asp:Label ID="Label1" runat="server" Width="100%"></asp:Label>
                </td>
            </tr>
            <tr>
                <td>图书名称：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="100%"  Height="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">图书类别：</td>
                <td class="auto-style1">
                    <asp:DropDownList ID="DropDownList1" runat="server"  Width="80%" Font-Names="微软雅黑" Font-Size="Medium">
                        <asp:ListItem>马克思主义著作</asp:ListItem>
                        <asp:ListItem>哲学</asp:ListItem>
                        <asp:ListItem>社会科学</asp:ListItem>
                        <asp:ListItem>自然科学</asp:ListItem>
                        <asp:ListItem>综合性图书</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>作者：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="100%"  Height="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>出版社：</td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="100%"  Height="60%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>在馆数量：</td>
                <td>
                    <asp:Label ID="Label2" runat="server" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td>价格：</td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Width="100%"  Height="60%"></asp:TextBox>
                </td>
            </tr>
        </table>
            <br />
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="图书名称不能为空！" ControlToValidate="TextBox1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="图书类别不能为空！" ControlToValidate="DropDownList1"></asp:RequiredFieldValidator>
        <br /><br />
        <asp:Button ID="Button1" runat="server" Text="修改" Width="100px" OnClick="Button1_Click" Font-Names="微软雅黑" Font-Size="Medium" />&nbsp
        <asp:Button ID="Button2" runat="server" Text="保存" Width="100px" OnClick="Button2_Click" OnClientClick="return confirm('确认保存修改信息？');" Font-Names="微软雅黑" Font-Size="Medium" />
        </center>
    </div>
</asp:Content>
