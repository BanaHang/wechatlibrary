<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookSearch.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.BookSearch" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"/>
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <center>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Width="75%" Font-Names="宋体" Font-Size="X-Large" Height="50px" BackColor="#E8E8E8" BorderStyle="None"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="Search" Width="20%" OnClick="Button1_Click" Font-Bold="False" Font-Names="微软雅黑" Font-Size="X-Large" Height="50px" BackColor="#009ACD" BorderStyle="None" ForeColor="White"></asp:Button>

    </center>   
        <br /><hr /><br />
        <p style="font-family:'Microsoft YaHei UI'; font-size:x-large">热门书籍：</p>
        <br />
    
        <div style="text-align:center">
            <center>       
        <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="2" Width="90%">
            <ItemTemplate>
                <table>
                    <tr>
                        <td rowspan="3">
                            <img height="120" src="../images/cover.jpg" style="border:none;"/>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem,"Hbname") %>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <%#DataBinder.Eval(Container.DataItem,"Hbwriter") %>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:DataList>
        </center>
        </div>
      
    </div>
    </form>
</body>
</html>
