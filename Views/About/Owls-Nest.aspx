<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %><%@ Import Namespace="SquishIt.Framework" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">The Owl's Nest</asp:Content>

<asp:Content ContentPlaceHolderID="HeaderAbout" runat="server">
<script type="text/javascript" src="http://maps.google.com/maps?file=api&amp;v=3"></script>
<%= Bundle.JavaScript()
    .Add("~/content/scripts/jquery.gmap-1.1.0-min.js")
    .Render("~/content/scripts/maps_#.js")
%>
<script type="text/javascript">
$(document).ready(function(){$('#map').gMap({markers:[{address:"3220 Busbee Drive Northwest Kennesaw GA 30144 USA",latitude:34.029895,longitude:-84.570024,html:"<a href='http://maps.google.com/maps?q=3220+Busbee+Drive+Northwest,+Kennesaw,+GA&z=15&daddr=3220+Busbee+Drive+Northwest,+Kennesaw,+GA'>Directions to the Owl's Nest</a>"}],zoom:15});});
</script>
</asp:Content>

<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Owl's Nest", "owls-nest", "about", null, new { title = "The Owl's Nest" })%></div>
<h1>The Owl's Nest</h1>
<p>The KSU Fighting Owls play their home games at the KSU Owls Nest Sports and Recreation Park. The complex is located next to the Town Center Ice Area and across from BrandsMart USA in Kennesaw.</p>
<br />
<h2>Ticket Prices:</h2>
<ul>
<li>KSU Students and Facility (with KSU ID) are <b>FREE</b></li>
<li>Children 12 and under are <b>FREE</b></li>
<li>Kids 13-18 are $2</li>
<li>Adults 18 and older are $5</li>
</ul>
<br />
<h2>Field Location</h2>
<br />
<p>The field is located less than 1 mile from the main campus at 3220 Busbee Drive Kennesaw, GA 30144.</p>
<br />
<div id="map" style="width:500px;height:300px;margin-left:50px;"></div>
</asp:Content>