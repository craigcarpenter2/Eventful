<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommunityEventForm.aspx.cs" Inherits="CommunityEvents.EventWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Event</title>

    <!--import necessary for map-->
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css"
    integrity= "sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
    crossorigin="" />

    <style>
        #map{width:70%; height:0px}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <label>Event Name</label>
            <div><input id="title" type="text" /></div>
        </div>
        <div>
            <label>Date</label>
            <input id="date" type="text" />
        </div>
        <div>
            <label>Venue</label>
            <input id="venue" type="text" />
        </div>
        <div>
            <label>Description</label>
            <div><label for="event_description" id="characters_left">(500 characters remaining.)</label></div>
            <div><textarea name="event_description" id="description" rows="6" maxlength="500"></textarea></div>
        </div>

        <!--script to have 'characters remaining' counter updated-->
        <script>
         const textarea = document.querySelector("textarea");
         textarea.addEventListener("input", event => {
             const target = event.currentTarget;
             const maxLength = target.getAttribute("maxlength");
             const currentLength = target.value.length;
             document.getElementById("characters_left").innerHTML = `<em>(${maxLength - currentLength} characters remaining)</em>`;
         });
        </script>

        <!--Get location of event-->
        <div class="row">
            <input id="coords_latitude" type="text" value="" style="display:none" />  <!--invisible text inputs for coordinates-->
            <input id="coords_longitude" type="text" value="" style="display:none"/>

        
            <div id="map"></div>  <!--map will be generated in this div-->

            <!-- Get the leaflet JavaScript file
                this is done before the map is initialized in buildMap() -->
            <script src="https://unpkg.com/leaflet@1.6.0/dist/leaflet.js" integrity= 
                    "sha512-gZwIG9x3wUXg2hdXF6+rVkLF/0Vi9U8D2Ntg4Ga5I5BZpVkVxlJWbSQtXPSiUTtC0TjtGOmxa1AJPuV0CPthew=="
                    crossorigin=""></script> 
          
        </div>
    
        <script>

            //get position of the user
            function getPosition() {
                navigator.geolocation.getCurrentPosition(showPosition, showError);
                console.log("yes");
            }

            function showPosition(position) {
                //save user coordinates to invisible text field
                document.getElementById("coords_latitude").value = position.coords.latitude;
                document.getElementById("coords_longitude").value = position.coords.longitude;

                buildMap(position.coords.latitude, position.coords.longitude);

            }

            function showError(error) {

            }

            //generate a map showing the user's location
            function buildMap(latitude, longitude) {

                document.getElementById("map").style.height = "300px";

                if (latitude != null && longitude != null) {
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
                    map.setView([latitude, longitude], 15);

                    //once location is available
                    var marker = L.marker([latitude, longitude]).addTo(map);
                    marker.bindPopup("Location saved!<br>Latitude: " + latitude + "<br>Longitude: " + longitude).openPopup();

                    var popup = L.popup();
                    map.on('click', function (ev) {

                        var coord = ev.latlng.toString().split(',');
                        var lat = coord[0].split('(');
                        var long = coord[1].split(')');

                        document.getElementById("coords_latitude").value = lat[1];
                        document.getElementById("coords_longitude").value = long[0];

                        popup
                            .setLatLng(ev.latlng)
                            .setContent("Location Saved<br>Latitude:" + lat[1] + "<br>Longitude:" + long[0])
                            .openOn(map);
                    });
                }
            }
            //call get position to start
            getPosition();
        </script>


        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
