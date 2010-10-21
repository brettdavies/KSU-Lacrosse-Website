<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %><%@ Import Namespace="KSULax.Helpers" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Media Guides</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Media Guides", "media-guides", "about", null, new { title = "Media Guides" })%></div>
<h1>Media Guides</h1>
<p>Beginning in 2007, the Kennesaw State Lacrosse Club has published an annual media guide. Click on a cover below to read the media guide.</p><br />
<ul class="mg">
<li><asp:HyperLink NavigateUrl="~/content/pdf/2010-media-guide.pdf" title="2010 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2010.jpg", "2010 Media Guide", new { height = 388, width = 300, title = "2010 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2010 Media Guide</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/2009-media-guide.pdf" title="2009 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2009.jpg", "2009 Media Guide", new { height = 388, width = 300, title = "2009 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2009 Media Guide</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/2008-media-guide.pdf" title="2008 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2008.jpg", "2008 Media Guide", new { height = 388, width = 300, title = "2008 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2008 Media Guide</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/2007-media-guide.pdf" title="2007 Media Guide" Height="388" Width="300" runat="server"><%= Html.Image("", "~/content/images/media-guides/2007.jpg", "2007 Media Guide", new { height = 388, width = 300, title = "2007 Media Guide", style = "border-width:0"})%></asp:HyperLink><br />2007 Media Guide</li>
</ul>
</asp:Content>