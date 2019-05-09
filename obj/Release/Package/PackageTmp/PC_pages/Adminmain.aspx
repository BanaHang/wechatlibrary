<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adminmain.aspx.cs" Inherits="LibraryDemo_1.PC_pages.Adminmain" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div style="height:500px;padding:30px;font-size:x-large">
        <br />
        <b>Welcome,administrator <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label> !</b>
        <br /><br />
        当前在线人数为： <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br /><br />
        你可以用图书馆管理系统进行管理活动。
        <br /><br />

    </div>
    </div>
    </form>
</body>
</html>
