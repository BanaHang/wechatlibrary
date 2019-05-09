<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotFound.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.NotFound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"/>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align:center;font-family:'Microsoft YaHei'; font-size:x-large">
        <asp:Image ID="Image1" runat="server" ImageUrl="~/images/failure.png" Width="120px" />
    <p>对不起，图书没找到！</p>
        <br />
    <p>选择<a href="BookSearch.aspx">再次寻找</a></p>
        <br />
    <p>或者去<a href="Apply.aspx">申请图书馆购买</a>  </p>
    </div>
    </form>
</body>
</html>
