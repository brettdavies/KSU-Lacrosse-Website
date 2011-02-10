<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Player.RosterModel>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server"><%= Model.Title %></asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol">
<% Html.RenderPartial("GameSidebarTemplate", Model.Games); %>
</div>
<div id="mainCol">
<div class="breadcrumbs">
<%= Html.ActionLink("Home","","", null, new { title="Home" })%> > <%= Html.ActionLink("Players", "Index", new { id = string.Empty }, new { title = "Players" })%> > <%= Html.ActionLink(Model.CurSeasonStr, Model.CurSeasonStr, null, new { title = Model.Title })%></div>
<h1><%= Model.Title %></h1>
<% Html.RenderPartial("PlayerRosterTemplate", Model.Players); %>
</div>
</asp:Content>