<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Report.aspx.cs" Inherits="LibraryDemo_1.PC_pages.Report" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top:10%; margin-left:5%">
        <asp:Label ID="Label1" runat="server" Text="报表："></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="微软雅黑 Light" Font-Size="Medium" Width="100px">
            <asp:ListItem>申购情况</asp:ListItem>
            <asp:ListItem>借阅情况</asp:ListItem>
        </asp:DropDownList>
        &nbsp&nbsp&nbsp
        <asp:Label ID="Label2" runat="server" Text="时间："></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" Font-Names="微软雅黑 Light" Font-Size="Medium" Width="100px">
            <asp:ListItem>１月</asp:ListItem>
            <asp:ListItem>２月</asp:ListItem>
            <asp:ListItem>３月</asp:ListItem>
            <asp:ListItem>４月</asp:ListItem>
            <asp:ListItem>５月</asp:ListItem>
            <asp:ListItem>６月</asp:ListItem>
            <asp:ListItem>７月</asp:ListItem>
            <asp:ListItem>８月</asp:ListItem>
            <asp:ListItem>９月</asp:ListItem>
            <asp:ListItem>１０月</asp:ListItem>
            <asp:ListItem>１１月</asp:ListItem>
            <asp:ListItem>１２月</asp:ListItem>
        </asp:DropDownList>
        &nbsp&nbsp&nbsp
        <asp:Button ID="Button1" runat="server" Text="情况查询" Width="100px" OnClick="Button1_Click" Font-Size="Medium" />
        &nbsp&nbsp
        <asp:Button ID="Button2" runat="server" Text="导出" Width="100px" OnClick="Button2_Click" Font-Size="Medium" />
        <br /><br />
        <hr />
        <br /><br />
        <center>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" CellPadding="10" ForeColor="#333333" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging" PageSize="15" Font-Names="微软雅黑 Light" Font-Size="Medium">
            <AlternatingRowStyle BackColor="White" />
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
    </div>
    </form>
</body>
</html>
