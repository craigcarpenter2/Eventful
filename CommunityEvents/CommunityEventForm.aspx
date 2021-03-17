<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommunityEventForm.aspx.cs" Inherits="CommunityEvents.EventWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Events</title>

</head>
<body>
    <form id="ViewEvents" runat="server">
        <div><h1>Welcome to Eventful!</h1></div>
        <asp:Button ID="GetLocalEvents" runat="server" Text="Get Events" OnClick="GetLocalEvents_Click" />
    </form>
    <table runat="server" id="ResultTable" border="1" style="width:100%;">
        <tr>
            <th>Title</th>
            <th>Time and Date</th>
            <th>Venue</th>
            <th>City</th>
            <th>State</th>
            <th>Zip</th>
            <th>Description</th>
        </tr>
    </table>

   
        
    
</body>
</html>
