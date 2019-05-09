<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserPage.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.UserPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"/>
    <title></title>
        <style type="text/css">
        td{
            width:250px;
            height:30px;
            padding:5px;
        }

        th{
            padding:5px;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:'Microsoft YaHei';font-size:x-large">
        <h2>用户信息：</h2>
        &nbsp&nbsp  序列号：<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label><br />
        &nbsp&nbsp  用户名：<asp:Label ID="Label2" runat="server" Text="Label"></asp:Label><br />
        &nbsp&nbsp  学号：<asp:Label ID="Label3" runat="server" Text="Label"></asp:Label><br />
        &nbsp&nbsp  类型：<asp:Label ID="Label4" runat="server" Text="Label"></asp:Label><br />
        &nbsp&nbsp  可借图书数量：<asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        
            <br /><hr />
            <h2>未还书目：</h2>
        <center>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="BorrowBname" HeaderText="图书名称" />
                    <asp:BoundField DataField="BorrowDate" HeaderText="借书日期" />
                    <asp:BoundField DataField="BorrowDeadline" HeaderText="应还日期" />
                    <asp:BoundField DataField="Bookstate" HeaderText="图书状态" />
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
        </center>

        <br /><hr />
            <h2>预约书目：</h2>
        <center>
            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="GridView2_RowCommand">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="OrderBname" HeaderText="图书名称" />
                    <asp:BoundField DataField="Contains" HeaderText="在馆数量" />
                    <asp:ButtonField CommandName="Cancel" Text="取消" />
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
            <br /><br />
        </center>
    </div>
    </form>
</body>
</html>
