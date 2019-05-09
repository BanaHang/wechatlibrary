<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="LibraryDemo_1.PC_pages.AdminLogin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td{
            width:200px;
            height:30px;
            padding-left:5%;
            padding-right:5%;
            padding-bottom:3%;
            padding-top:3%;
        }

        th{
            width:400px;
            height:30px;
            padding-left:5%;
            padding-right:5%;
            padding-bottom:3%;
            padding-top:3%;
        }

        table{
            opacity:0.9;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="login" style="padding:50px; text-align:center; background-image:url(../images/library.jpg); background-repeat:no-repeat;">
        
                <p style="font-size:medium;font-weight:700">欢迎使用本图书管理系统，该系统仅供学习交流。</p>

        <center>
        <table border="1" style="background-color:white">
            <tr>
                <th colspan="2" style="font-size:x-large;">管理员登陆</th>
            </tr>
            <tr>
                <td>用户名：</td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="95%"></asp:TextBox></td>               
            </tr>
            <tr>
                <td>密码：</td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Width="95%" TextMode="Password"></asp:TextBox></td>                
            </tr>
            <tr>
                <th colspan="2" style="text-align:center">
                    <asp:Button ID="Button1" runat="server" Text="登陆" Width="150px" OnClick="Button1_Click" Font-Size="Medium" />
                </th>              
            </tr>
        </table></center>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="用户名不能为空！" ControlToValidate="TextBox1" Font-Bold="True"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="密码不能为空!" ControlToValidate="TextBox2" Font-Bold="True"></asp:RequiredFieldValidator>
    </div>
</asp:Content>
