<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CommunityEventForm.aspx.cs" Inherits="CommunityEvents.EventWebForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>New Event</title>
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
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
