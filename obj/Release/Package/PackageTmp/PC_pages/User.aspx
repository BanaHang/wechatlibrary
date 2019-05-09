<%@ Page Title="" Language="C#" MasterPageFile="~/Manage.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="LibraryDemo_1.PC_pages.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div style="height:700px; border:1px solid grey">
        <div id="d1" style="float:left; width:15%; margin-left:10px;margin-top:10px">
        <asp:Menu ID="Menu1" runat="server" BackColor="#E3EAEB" DynamicHorizontalOffset="2" Font-Names="宋体" Font-Size="Medium" ForeColor="#666666" OnMenuItemClick="Menu1_MenuItemClick" StaticSubMenuIndent="10px" ClientIDMode="AutoID">
            <DynamicHoverStyle BackColor="#666666" ForeColor="White" />
            <DynamicMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
            <DynamicMenuStyle BackColor="#E3EAEB" />
            <DynamicSelectedStyle BackColor="#1C5E55" />
            <Items>
                <asp:MenuItem Text="读者管理" Value="读者管理"></asp:MenuItem>
                <asp:MenuItem Text="管理员管理" Value="管理员管理"></asp:MenuItem>
            </Items>
            <StaticHoverStyle BackColor="#666666" ForeColor="White" />
            <StaticMenuItemStyle HorizontalPadding="10px" VerticalPadding="10px" />
            <StaticMenuStyle BorderColor="#CCCCFF" BorderStyle="Solid" BorderWidth="1px" HorizontalPadding="10px" VerticalPadding="10px" Width="100px" />
            <StaticSelectedStyle BackColor="#009933" />
        </asp:Menu>
        </div>
        
        <div id="d2" style="float:left; height:100%;width:80%">

        <iframe id="iframe1" runat="server" src="./Adminmain.aspx" scrolling="no" style="width:100%; height:700px"></iframe>

        </div>
    </div>
</asp:Content>
