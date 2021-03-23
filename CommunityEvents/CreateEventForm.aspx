<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEventForm.aspx.cs" Inherits="CommunityEvents.CreateEventForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <!--Navigation Options-->
    <ul>
        <li><a href="CommunityEventForm.aspx">See Nearby Events</a></li>
        <li><a href="#">Post New Event</a></li>
        <li><a href="#">About Us</a></li>
        <li><a href="#">API</a></li>
        <li><a href="#">My Profile</a></li>
    </ul>

    <form id="CreateNewEvent" runat="server">
        <h1>Create New Event</h1>
        <div>
            <!--Get the Title, Venue, Description, Time from the user-->
            <table>
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Title:"></asp:Label></td>
                    <td><asp:TextBox ID="Title" runat="server" placeholder=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Venue:"></asp:Label></td>
                    <td><asp:TextBox ID="TextBox1" runat="server" placeholder=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label3" runat="server" Text="Description:"></asp:Label></td>
                    <td><asp:TextBox ID="Description" runat="server"></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label4" runat="server" Text="Time:"></asp:Label></td>
                    <td><asp:TextBox ID="Time" runat="server" placeholder="00:00"></asp:TextBox></td>
                </tr>
            </table>

            <!--calendar to pick date of event-->
            <asp:Calendar ID="Calendar" runat="server" OnSelectionChanged="Calendar_SelectionChanged"></asp:Calendar>

            <asp:TextBox ID="Latitude" runat="server" style="display:none"></asp:TextBox>
            <asp:TextBox ID="Longitude" runat="server" style="display:none"></asp:TextBox>

        </div>
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
    </form>
</body>
</html>
