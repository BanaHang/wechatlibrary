<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="BookInfo.aspx.cs" Inherits="LibraryDemo_1.PC_pages.BookInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center">
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="微软雅黑" Font-Size="Medium">
            <asp:ListItem>图书名称</asp:ListItem>
            <asp:ListItem>图书作者</asp:ListItem>
            <asp:ListItem>出版社</asp:ListItem>
            <asp:ListItem>图书类别</asp:ListItem>
        </asp:DropDownList>
        &nbsp
        <asp:TextBox ID="TextBox1" runat="server" Width="300px"></asp:TextBox>
        &nbsp
        <asp:Button ID="Button1" runat="server" Text="查找" OnClick="Button1_Click" Width="100px" Font-Names="微软雅黑" Font-Size="Medium"/>
        <br /><hr /><br />
        <center>
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" PageSize="12" OnPageIndexChanging="GridView1_PageIndexChanging" Font-Names="微软雅黑">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Bid" HeaderText="ID" />
                    <asp:HyperLinkField DataNavigateUrlFields="Bid" DataNavigateUrlFormatString="Book.aspx?ID={0}" DataTextField="Bname" HeaderText="图书名称" />
                    <asp:BoundField DataField="Btype" HeaderText="图书类型" />
                    <asp:BoundField DataField="Bwriter" HeaderText="作者" />
                    <asp:BoundField DataField="Bpublish" HeaderText="出版社" />
                    <asp:BoundField DataField="Bamount" HeaderText="在馆数量" />
                    <asp:BoundField DataField="Bprice" HeaderText="价格" />
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
        </center>
    </div>
</asp:Content>
