<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %><%@ Import Namespace="KSULax.Helpers" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Media Guides</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Media Guides", "media-guides", "about", null, new { title = "Media Guides" })%></div>
<h1>Printable Schedules</h1>
<ul class="mg">
<li><asp:HyperLink NavigateUrl="~/content/pdf/KSU-Lax-2014-Schedule.pdf" title="2014 Schedule" Height="400" Width="261" runat="server"><%= Html.Image("", "~/content/images/KSU-Lax-2014-Schedule.png", "2014 Schedule", new { height = 400, width = 261, title = "2014 Schedule", style = "border-width:0"})%></asp:HyperLink><br />2014 Schedule</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/KSU-Lax-2013-Schedule.pdf" title="2013 Schedule" Height="400" Width="300" runat="server"><%= Html.Image("", "~/content/images/KSU-Lax-2013-Schedule.png", "2013 Schedule", new { height = 400, width = 300, title = "2013 Schedule", style = "border-width:0"})%></asp:HyperLink><br />2013 Schedule</li>
</ul>
<br style="clear:both;"/>
<h1>Media Guides</h1>
<p>From 2007 - 2010 the Kennesaw State Lacrosse Club published an annual media guide. Click on a cover below to read the media guide.</p><br />
<ul class="mg">
<li><asp:HyperLink NavigateUrl="~/content/pdf/2010-media-guide.pdf" title="2010 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2010.jpg", "2010 Media Guide", new { height = 388, width = 300, title = "2010 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2010 Media Guide</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/2009-media-guide.pdf" title="2009 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2009.jpg", "2009 Media Guide", new { height = 388, width = 300, title = "2009 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2009 Media Guide</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/2008-media-guide.pdf" title="2008 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2008.jpg", "2008 Media Guide", new { height = 388, width = 300, title = "2008 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2008 Media Guide</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/2007-media-guide.pdf" title="2007 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2007.jpg", "2007 Media Guide", new { height = 388, width = 300, title = "2007 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2007 Media Guide</li>
</ul>
</asp:Content>