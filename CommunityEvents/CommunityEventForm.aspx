﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommunityEventForm.aspx.cs" Inherits="CommunityEvents.EventWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Events</title>

    <!-- map leaflet imports-->
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css"
    integrity= "sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
    crossorigin="" /> 

</head>
<body>
    <ul>
        <li><a href="#">See Nearby Events</a></li>
        <li><a href="CreateEventForm.aspx">Post New Event</a></li>
        <li><a href="#">About Us</a></li>
        <li><a href="#">API</a></li>
        <li><a runat="server" id="MyProfileLink" href="UserProfile.aspx">My Profile</a></li>
    </ul>
    <form id="ViewEvents" runat="server">
        <div><h1>Welcome to Eventful!</h1></div>
        <asp:TextBox ID="ZipCode" runat="server" placeholder="Enter local zip code"></asp:TextBox>
        <asp:Button ID="GetLocalEvents" runat="server" Text="Get Local Events" OnClick="GetLocalEvents_Click" />
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
    <div>
        <!--area to create open street map-->
        <div id="map"></div> 
                
        <!-- Get the leaflet JavaScript file
            notice that this is done before the map is initialized-->
        <script src="https://unpkg.com/leaflet@1.6.0/dist/leaflet.js"
        integrity= 
        "sha512-gZwIG9x3wUXg2hdXF6+rVkLF/0Vi9U8D2Ntg4Ga5I5BZpVkVxlJWbSQtXPSiUTtC0TjtGOmxa1AJPuV0CPthew=="
        crossorigin=""></script> 
    </div>

    <script>
        function buildMap() {


        }

    </script>



   
        
    
</body>
</html>
