<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.RosterData>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server"><% short? year = Model.players[0].season_id; string title = ((year - 1) + " - " + year + " Roster").Trim(); %><%= title %></asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol">
<% Html.RenderPartial("GameSidebarTemplate", Model.games); %>
</div>
<div id="mainCol">
<div class="breadcrumbs">
<%= Html.ActionLink("Home","","", null, new { title="Home" })%> > <%= Html.ActionLink("Players", "Index", new { id = string.Empty }, new { title = "Players" })%> > <%= Html.ActionLink(Model.players[0].season_id.ToString(), Model.players[0].season_id.ToString(), null, new { title = Model.players[0].season_id.ToString() })%></div>
<% short? year = Model.players[0].season_id; string title = (year - 1) + " - " + year + " Roster"; %>
<h1><%= title%></h1>
<% Html.RenderPartial("PlayersTemplate", Model.players); %>
</div>
</asp:Content>