<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommunityEventForm.aspx.cs" Inherits="CommunityEvents.EventWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Event Name</label>
            <input type="text" />
            
        </div>
        <div>
            <label>City</label>
            <input type="text" />
        </div>
        <div>
            <label>State</label>
            <input type="text" />
        </div>
        <div>
            <label>Zip</label>
            <input type="text" />
        </div>
        <div>
            <label>Date</label>
            <input type="text" />
        </div>
        <div>
            <label>Venue</label>
            <input type="text" />
        </div>
        <div>
            <label>Description</label>
            <input type="text" />
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
