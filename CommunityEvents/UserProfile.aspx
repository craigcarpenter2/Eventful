<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="CommunityEvents.UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <ul>
        <li><a href="#">See Nearby Events</a></li>
        <li><a href="CreateEventForm.aspx">Post New Event</a></li>
        <li><a href="#">About Us</a></li>
        <li><a href="#">API</a></li>
        <li><a href="#">My Profile</a></li>
    </ul>
    <form id="form1" runat="server">
        <div>
            <h1>My Profile</h1>
            <asp:Label ID="WelcomeMessage" runat="server" Text=""></asp:Label>
        </div>
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
