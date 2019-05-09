<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.aspx.cs" Inherits="LibraryDemo_1.Wechat_pages.SearchResult" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
<meta name="viewport" content="width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0"/>
    <title></title>
    <style>
        a:link{
            color:black;
            text-decoration:none;
        }
        a:visited{
            color:black;
            text-decoration:none;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family:FangSong;font-size:x-large;text-align:center">        
        <center>
            <div style="background-color:#008B8B">
                <br />
                <p style="font-family:'Microsoft YaHei';font-size:xx-large;color:white">查询结果</p>
                <br />
            </div>
            <hr />
            <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" Width="90%">
                <ItemTemplate>
                    <table>
                        <tr>
                            <td>
                                <a href='Book.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Bid") %>'>
                                    <img height="120" src="../images/cover.jpg" style="border:none;"/>
                                </a>
                                &nbsp&nbsp
                            </td>
                            <td>
                                <a href='Book.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Bid") %>'>
                                    <%#DataBinder.Eval(Container.DataItem,"Bname") %>——
                                    <%#DataBinder.Eval(Container.DataItem,"Bwriter") %>
                                </a>
                                &nbsp&nbsp
                            </td>
                            <td>
                                <a href='Book.aspx?id=<%#DataBinder.Eval(Container.DataItem,"Bid") %>'>
                                    <%#DataBinder.Eval(Container.DataItem,"Btype") %>
                                </a>
                                &nbsp&nbsp
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
            </asp:DataList>

            <br /><br />
        </center>
    </div>
    </form>
</body>
</html>
