<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.News.StoryBriefListModel>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">News</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("SponsorsTemplate"); %></div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title="Home" })%> > <%= Html.ActionLink("News", "Index", new { year = string.Empty, month = string.Empty, day = string.Empty, title = string.Empty }, new { title = "News" })%></div>
<h1>News</h1>
<% Html.RenderPartial("NewsTemplate", Model); %>
</div>
</asp:Content>