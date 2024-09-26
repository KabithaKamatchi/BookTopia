<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddBooks.aspx.cs" Inherits="BookTopia.BookTopia.AddBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>BOOK TOPIA</title>
    <link rel="stylesheet" type="text/css" href="../Assets/Css/Themes/themes.css">
    <link rel="stylesheet" type="text/css" href="../Assets/Css/Core/style.css">
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblBookId" runat="server" Text="Book ID:"></asp:Label>
            <asp:TextBox ID="txtBookId" runat="server"></asp:TextBox><br /><br />
        </div>

        <div>
            <asp:Label ID="lblName" runat="server" Text="Book Name:"></asp:Label>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox><br /><br />
        </div>

        <div>
            <asp:Label ID="lblAuthor" runat="server" Text="Book Author:"></asp:Label>
            <asp:TextBox ID="txtAuthor" runat="server"></asp:TextBox><br /><br />
        </div>

        <div>
            <asp:Label ID="lblISBN" runat="server" Text="Book ISBN:"></asp:Label>
            <asp:TextBox ID="txtISBN" runat="server"></asp:TextBox><br /><br />
        </div>

        <div>
            <asp:Label ID="lblPublicationDate" runat="server" Text="Date of Publication[YYYY-MM-DD]:"></asp:Label>
            <asp:TextBox ID="txtDateOfPublication" runat="server"></asp:TextBox><br /><br />
        </div>

        <div>
             <asp:Label ID="lblErrorMessage" runat="server" ForeColor="Red"></asp:Label><br />
        </div>

        <div class="button-Onclick">
            <asp:Button class="Submit" ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:Button class="Cancel" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click" />
            <asp:Button class="Back" ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        </div>

        <div>
            <asp:Label ID="lblSuccessMessage" runat="server" ForeColor="Green"></asp:Label><br />
        </div>
    </form>
</body>
</html>
