<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="Return.aspx.cs" Inherits="LibraryDemo_1.PC_pages.Return" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height:500px">
        <center>
            <table>
            <tr>
                <th style="font-size:x-large;padding:20px;width:auto">图书归还</th>
            </tr>
            <tr>
                <th style="width:auto" >
                    <asp:DropDownList ID="DropDownList1" runat="server" Font-Names="微软雅黑" Font-Size="Medium">
                        <asp:ListItem>图书名称</asp:ListItem>
                        <asp:ListItem>图书序号</asp:ListItem>
                        <asp:ListItem>读者名称</asp:ListItem>
                        <asp:ListItem>读者学号/工号</asp:ListItem>
                    </asp:DropDownList>
                    &nbsp
                    <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>&nbsp
                    <asp:Button ID="Button1" runat="server" Text="查找" Width="100px" OnClick="Button1_Click" Font-Names="微软雅黑" Font-Size="Medium"></asp:Button>
                </th>               
            </tr>
            </table>
            <br /><hr /><br />
            <h3>借书记录</h3>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowCommand="GridView1_RowCommand" CellPadding="5" Font-Names="微软雅黑" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="Borrowid" HeaderText="记录序号" />
                    <asp:BoundField HeaderText="图书序号" DataField="BorrowBid" />
                    <asp:BoundField DataField="BorrowBname" HeaderText="图书名称" />
                    <asp:BoundField DataField="BorrowRname" HeaderText="读者姓名" />
                    <asp:BoundField DataField="BorrowRnum" HeaderText="读者学号/工号" />
                    <asp:BoundField DataField="BorrowDate" HeaderText="借书日期" />
                    <asp:BoundField DataField="BorrowDeadline" HeaderText="应还日期" />
                    <asp:BoundField DataField="Bookstate" HeaderText="图书状态" />
                    <asp:BoundField DataField="IsOutDate" HeaderText="是否逾期" />
                    <asp:ButtonField ButtonType="Button" CommandName="return" Text="归还"  />
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
