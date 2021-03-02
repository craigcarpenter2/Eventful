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
            <div><input id="event_title" type="text" /></div>
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
            <div><textarea name="event_description" id="event_description" rows="5" maxlength="500"></textarea></div>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </p>
    </form>
</body>
</html>
