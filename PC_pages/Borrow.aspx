<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="Borrow.aspx.cs" Inherits="LibraryDemo_1.PC_pages.Borrow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        td{
            width:200px;
            height:30px;
            padding-left:3%;
            padding-right:3%;
            padding-bottom:2%;
            padding-top:2%;
        }

        th{
            width:800px;
            height:30px;
            padding-left:3%;
            padding-right:3%;
            padding-bottom:2%;
            padding-top:2%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div >
        <center>
            <h2>图书借阅</h2>
                    <asp:Label ID="Label1" runat="server" Text="读者学号/工号："></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" Width="150px"></asp:TextBox>&nbsp
                    <asp:Button ID="Button1" runat="server" Text="查找" Width="100px" OnClick="Button1_Click" Font-Names="微软雅黑"></asp:Button>
            <br /><br /><hr /><br />
        <table border="1">
            <tr>
                <td>读者姓名：</td>
                <td><asp:Label ID="Label2" runat="server"></asp:Label></td>
                <td>读者学号/工号：</td>
                <td><asp:Label ID="Label3" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td >读者类型：</td>
                <td ><asp:Label ID="Label4" runat="server" ></asp:Label></td>
                <td >可借数量：</td>
                <td ><asp:Label ID="Label5" runat="server"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="4"></td>
            </tr>
            <tr>
                <td>图书名称：</td>
                <td><asp:TextBox ID="TextBox2" runat="server" Width="95%"></asp:TextBox></td>
                <td>图书序号：</td>
                <td><asp:TextBox ID="TextBox3" runat="server" Width="95%"></asp:TextBox></td>
            </tr>
            <tr>
                <th colspan="4" style=" text-align:center">
                    <asp:Button ID="Button2" runat="server" Text="确认" Width="150px" OnClick="Button2_Click" OnClientClick="return confirm('读者信息确认？');" Font-Names="微软雅黑" Font-Size="Medium"></asp:Button>
                </th>
            </tr>
        </table>
            <br /><hr /><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="微软雅黑" Font-Size="Medium" ForeColor="#333333" GridLines="None" OnRowCommand="GridView1_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="BorrowBid" HeaderText="图书序号" />
                <asp:BoundField DataField="BorrowBname" HeaderText="图书名称" />
                <asp:BoundField DataField="BorrowDate" HeaderText="借书日期" />
                <asp:BoundField DataField="BorrowDeadline" HeaderText="还书日期" />
                <asp:ButtonField CommandName="Reborrow" HeaderText="续借" Text="续借" />
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#E3EAEB" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F8FAFA" />
            <SortedAscendingHeaderStyle BackColor="#246B61" />
            <SortedDescendingCellStyle BackColor="#D4DFE1" />
            <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <br />
            <br />
        </center>
    </div>
</asp:Content>
