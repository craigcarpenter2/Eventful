<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateEventForm.aspx.cs" Inherits="CommunityEvents.CreateEventForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    
    <!--Import style sheet-->
    <link rel="stylesheet" href="Style/CreateEventForm.css" />

       <!-- map leaflet imports-->
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css"
    integrity= "sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
    crossorigin="" /> 
</head>
<body>
    <!--Navigation Options-->
    <ul style="text-align: left; color:forestgreen">
        <li><a href="CommunityEventForm.aspx" style="color:forestgreen">See Nearby Events</a></li>
        <li><a href="#" style="color:forestgreen">Post New Event</a></li>
        <li><a href="#" style="color:forestgreen">About Us</a></li>
        <li><a href="#" style="color:forestgreen">API</a></li>
        <li><a runat="server" id="MyProfileLink" href="UserProfile.aspx" style="color:forestgreen">My Profile</a></li>
    </ul>

    <form id="CreateNewEvent" runat="server" style="text-align:center;">
        <h1>Create New Event</h1>
        <div>
            <!--Get the Title, Venue, Description, Time from the user-->
            <table class="center">
                <tr>
                    <td><asp:Label ID="Label1" runat="server" Text="Title:"></asp:Label></td>
                    <td><asp:TextBox ID="Title" runat="server" placeholder=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td><asp:Label ID="Label2" runat="server" Text="Venue:"></asp:Label></td>
                    <td><asp:TextBox ID="Venue" runat="server" placeholder=""></asp:TextBox></td>
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
			
			<div style="margin-left: auto; margin-right: auto; text-align: center; display:inline-block; padding-bottom: 30px;">
            <!--calendar to pick date of event-->
            <asp:Calendar ID="Calendar" runat="server" OnSelectionChanged="Calendar_SelectionChanged"></asp:Calendar>
			</div>


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

                var latitude;
                var longitude;

                document.getElementById("map").style.height = "300px";

                //initialize map
                const map = L.map('map');

                // Get the tile layer from OpenStreetMaps 
                L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                    // Specify the maximum zoom of the map 
                    maxZoom: 22,

                    // Set the attribution for OpenStreetMaps 
                    attribution: ' <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                }).addTo(map);

                // Set the view of the map 
                // with the latitude, longitude and the zoom value 
                map.setView([38.42369328698392, -82.42647887471767], 15);



                var popup = L.popup();

                function onMapClick(e) {
                    popup
                        .setLatLng(e.latlng)
                        .setContent("You clicked the map at " + e.latlng.toString())
                        .openOn(map);

                    latitude = e.latlng.lat;
                    longitude = e.latlng.lng;
                    document.getElementById('<%=Latitude.ClientID%>').value = latitude;
                    document.getElementById('<%=Longitude.ClientID%>').value = longitude;

                }

                map.on('click', onMapClick);
            </script>

            <asp:TextBox ID="Latitude" runat="server" style="display:none"></asp:TextBox>
            <asp:TextBox ID="Longitude" runat="server" style="display:none"></asp:TextBox>

        </div>
        <asp:Button ID="Submit" runat="server" Text="Submit" OnClick="Submit_Click" />
        <asp:Label ID="ErrorMessage" runat="server" Text="Label">There was an error connecting to the server.</asp:Label>
    </form>
</body>
</html>
