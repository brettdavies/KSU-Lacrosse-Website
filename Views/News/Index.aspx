<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<KSULax.Models.News>>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">News</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("SponsorsTemplate"); %></div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title="Home" })%> > <%= Html.ActionLink("News", "Index", null, new { title="News" })%></div>
<h1>News</h1>
<% Html.RenderPartial("NewsTemplate", Model); %>
</div>
</asp:Content>