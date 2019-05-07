<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ADO.NET.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>ADO.NET</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="width: 615px; height: 334px">
             ID:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" AutoPostBack="True"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Descripcion:&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="TextBox2" runat="server" AutoPostBack="True" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
&nbsp;&nbsp;&nbsp; Region:&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged1">
                <asp:ListItem>Eastern</asp:ListItem>
                <asp:ListItem>Northern</asp:ListItem>
                <asp:ListItem>Southern</asp:ListItem>
                <asp:ListItem>Western</asp:ListItem>
            </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp; <asp:SqlDataSource ID="SqlDataSource2" runat="server"  ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" SelectCommand="SELECT [RegionDescription] FROM [Region]"></asp:SqlDataSource>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Nuevo" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Modificar" />
&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click1" Text="Eliminar" />
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Height="135px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1" Width="562px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True" />
                    <asp:BoundField DataField="TerritoryID" HeaderText="TerritoryID" ReadOnly="True" SortExpression="TerritoryID" />
                    <asp:BoundField DataField="TerritoryDescription" HeaderText="TerritoryDescription" SortExpression="TerritoryDescription" />
                    <asp:BoundField DataField="RegionID" HeaderText="RegionID" ReadOnly="True" SortExpression="RegionID" />
                    <asp:BoundField DataField="RegionDescription" HeaderText="RegionDescription" SortExpression="RegionDescription" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" ></asp:SqlDataSource>
        </div>
    </form>
</body>
</html>
