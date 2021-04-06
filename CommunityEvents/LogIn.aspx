<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LogIn.aspx.cs" Inherits="CommunityEvents.LogIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="login" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Username"></asp:Label>
                <asp:TextBox ID="Username" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="Log In" OnClick="Button1_Click" />
            </div>
            <div>
                <asp:Label ID="LogInCredentialError" runat="server" Text="Invalid Login" Visible="false"></asp:Label>
            </div>
            <div>
                <asp:Label ID="LogInServerError" runat="server" Text="Server error." Visible="false"></asp:Label>
            </div>
            
        </div>
        <asp:Button ID="NoAccount" runat="server" Text="Continue Without Account" OnClick="NoAccount_Click" />
    </form>
</body>
</html>
