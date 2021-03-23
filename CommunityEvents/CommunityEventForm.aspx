<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommunityEventForm.aspx.cs" Inherits="CommunityEvents.EventWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Eventful</title>

    <!--import necessary for map-->
    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.6.0/dist/leaflet.css"
    integrity= "sha512-xwE/Az9zrjBIphAcBb3F6JVqxf46+CDLwfLMHloNu6KEQCAWi6HcDUbeOfBIptF7tcCzusKFjFw2yuvEpDL9wQ=="
    crossorigin="" />
    <style>
        #map{width:12%; 
height:122px
        }
    </style>

    <!--navigation bar-->
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/css/bootstrap.min.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js"></script>
     <nav class="navbar navbar-inverse">
        <div class="container-fluid">
          <div class="navbar-header">
            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#myNavbar">
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>
              <span class="icon-bar"></span>                        
            </button>
            &nbsp;</div>
          <div class="collapse navbar-collapse" id="myNavbar">
            <ul class="nav navbar-nav">
                <li><a href="javascript:__renderNewEventScreen();">New Event</a></li>
                <li><a href="javascript:__renderViewEventsScreen();">View Events</a></li>
            </ul>
          </div>
        </div>
      </nav>
    
</head>
<body>
    <form id="newEvent" runat="server">
        <div>
            <label>Event Name</label>
            <div>
                <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
                <br />
            </div>
        </div>
        <div>
            <label>Date</label>&nbsp;
            <br />
            <asp:Calendar ID="Calendar1" runat="server" OnSelectionChanged="Calendar1_SelectionChanged"></asp:Calendar>
        </div>
        <div>
            <label>Venue</label>&nbsp;
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </div>
        <div>
            <label>Description</label>
            <div><label for="event_description" id="characters_left">(500 characters remaining.)</label></div>
            <div>
                <asp:TextBox ID="TextBox3" runat="server" Height="120px" Width="261px"></asp:TextBox>
            </div>
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
            <input id="coords_longitude" type="text" value="" style="display:none"/>  <!--map will be generated in this div-->

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
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click1" Text="Submit" />
        </p>
    </form>

    <!--TODO screen for users to view events-->
    <div id="viewEvents">
    </div>

    <script>
        //this funtion shows the form to create a new event on
        //it also hides the screen where users view events
        function __renderNewEventScreen() {
            document.getElementById("newEvent").style.display = "inline";
            document.getElementById("viewEvents").style.display = "none";
        }
        //this function shows the screen where users can view events
        //it also hides the form to create a new event on
        function __renderViewEventsScreen(){
            document.getElementById("newEvent").style.display = "none";
            document.getElementById("viewEvents").style.display = "inline";
        }
        
    </script>

</body>
</html>
