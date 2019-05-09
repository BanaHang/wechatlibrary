<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="BookOut.aspx.cs" Inherits="LibraryDemo_1.PC_pages.BookOut" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align:center; height:500px">
        <center>
            <br />
        <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="微软雅黑" Font-Size="Medium">
            <asp:ListItem>图书名称</asp:ListItem>
            <asp:ListItem>图书作者</asp:ListItem>
            <asp:ListItem>出版社</asp:ListItem>
        </asp:DropDownList>
        <asp:TextBox ID="TextBox1" runat="server" Width="250px"></asp:TextBox>&nbsp
        <asp:Button ID="Button1" runat="server" Text="查找" Width="100px" OnClick="Button1_Click" Font-Names="微软雅黑" Font-Size="Medium" />&nbsp

        <asp:Label ID="Label1" runat="server" Text="出库数量：" Font-Names="微软雅黑" Font-Size="Medium"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" Width="50px" TextMode="Number" ></asp:TextBox>&nbsp
            <asp:Button ID="Button2" runat="server" Text="出库" Width="100px" OnClientClick="return confirm('出库信息确认？');" OnClick="Button2_Click" Font-Names="微软雅黑" Font-Size="Medium"></asp:Button>

        <br /><hr /><br />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCreated="GridView1_RowCreated" Font-Names="微软雅黑" Font-Size="Medium">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Bname" HeaderText="图书名称" />
                <asp:BoundField DataField="Btype" HeaderText="图书类型" />
                <asp:BoundField DataField="Bwriter" HeaderText="图书作者" />
                <asp:BoundField DataField="Bpublish" HeaderText="出版社" />
                <asp:BoundField DataField="Bamount" HeaderText="在馆数量" />
                <asp:BoundField DataField="Bprice" HeaderText="图书价格" />
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
</asp:Content>
