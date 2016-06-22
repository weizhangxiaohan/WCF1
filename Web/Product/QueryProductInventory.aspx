<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="QueryProductInventory.aspx.cs" Inherits="Web.Product.QueryProductInventory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <h1>产品库存查询</h1>
    <form id="form1" runat="server">
        <div>
            <span>产品编号：</span>
            <asp:TextBox ID="productCodeInput" runat="server"></asp:TextBox>
            <asp:Button ID="queryButton" runat="server" Text="查询" OnClick="queryButton_Click" /><br />
            <asp:Label runat="server" ID="queryResult" Text=""></asp:Label>
        </div>
    </form>
</body>


</html>
