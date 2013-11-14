<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Game.GameListModel>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">Sponsors</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("GameSidebarTemplate", Model); %></div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("Sponsors", "Index", "sponsors", null, new { title = "Sponsors" })%></div>
<h1>Sponsors</h1>
<p>The KSU Club Lacrosse team would like to thank our sponsors for the <%= DateTime.Now.Year %> season.</p>
</div>
</asp:Content>