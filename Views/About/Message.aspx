<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.MessageModel>" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Message Sent</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Contact Us", "contact", "about", null, new { title = "Contact Us" })%></div>
<h1>Contact</h1>
<h3><%= Html.Encode(Model.Title) %></h3>
<p><%= Html.Encode(Model.Content) %></p>
</asp:Content>
