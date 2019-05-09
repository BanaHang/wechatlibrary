<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminInfo.aspx.cs" Inherits="LibraryDemo_1.PC_pages.AdminInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="margin-top:10%; margin-left:5%">
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="微软雅黑" Font-Size="Medium">
            <asp:ListItem>用户名</asp:ListItem>
            <asp:ListItem>工号/身份证号</asp:ListItem>
        </asp:DropDownList>
        &nbsp&nbsp&nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="300px" Height="20px"></asp:TextBox>
        &nbsp&nbsp&nbsp
        <asp:Button ID="Button1" runat="server" Text="查找" OnClick="Button1_Click" Font-Names="微软雅黑" Font-Size="Medium" Width="100px" />
        <br /><br /><hr /><br /><br />
        <center>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="10" Font-Names="微软雅黑 Light" Font-Size="Medium" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="adminid" HeaderText="ID" />
                <asp:HyperLinkField HeaderText="用户名" DataNavigateUrlFormatString="Admin.aspx?ID={0}" DataTextField="adminname" DataNavigateUrlFields="adminid" />
                <asp:BoundField HeaderText="工号/身份证号" DataField="adminnum" />
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
    </div>
    </form>
</body>
</html>
