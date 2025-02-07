﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewBooks.aspx.cs" Inherits="BookTopia.BookTopia.ViewBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ViewBooks</title>
     <link rel="stylesheet" type="text/css" href="../Assets/Css/Themes/themes.css">
    <link rel="stylesheet" type="text/css" href="../Assets/Css/Core/ViewBooks.css">
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>View Books</h1>
            <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False" DataKeyNames="BookId"
                OnRowEditing="gvBooks_RowEditing" OnRowDeleting="gvBooks_RowDeleting">
                <Columns>
                    <asp:BoundField DataField="BookId" HeaderText="Book ID" ReadOnly="True" />
                    <asp:BoundField DataField="Name" HeaderText="Book Name" />
                    <asp:BoundField DataField="Author" HeaderText="Author" />
                    <asp:BoundField DataField="ISBN" HeaderText="ISBN" />
                    <asp:BoundField DataField="DateOfPublication" HeaderText="Date of Publication" />
                    <asp:CommandField ShowEditButton="True" HeaderText="Edit" />
                    <asp:TemplateField HeaderText="Delete">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnDelete" runat="server" CommandName="Delete"
                                CommandArgument='<%# Eval("BookId") %>' Text="Delete"
                                OnClientClick="return confirm('Are you sure you want to delete this record?');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <div>
                <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="button" />
            </div>

            <div class="back-button">
                <asp:Button ID="Button1" runat="server" Text="&#8249; HomePage" OnClick="btnHome_Click" />
            </div>
        </div>  
    </form>
</body>
</html>