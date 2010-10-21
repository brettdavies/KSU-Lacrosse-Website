<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.News>" %><%@ Import Namespace="KSULax.Helpers" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server"><%= Html.Encode(Model.title)%></asp:Content>
<asp:Content ContentPlaceHolderID="Header" runat="server">
<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
<script type="text/javascript" src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
<meta property="og:title" content="<%= Html.Encode(Model.title.Trim())%>"/>
<meta property="og:url" content="<%= Html.Encode(Request.Url.ToString())%>"/>
<meta property="og:description" name="description" content="<%= Html.Encode(Html.formatDesc(Model.story)) %>" />
<meta property="og:type" content="article"/>
<% Html.RenderPartial("FacebookGraph"); %>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("SponsorsTemplate"); %></div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("News", "Index", new { year = string.Empty, month = string.Empty, day = string.Empty, title = string.Empty }, new { title="News" })%> > <%= Html.ActionLink(Html.Encode(Model.title), "Index", new { year = Model.date.Year, month = Model.date.Month, day = Model.date.Day, url_title = Html.Encode(Model.url_title.ToLower()) }, new { title = Html.Encode(Model.title) })%></div>
<h1><%= Html.Encode(Model.title)%></h1>
<div class="homeNewsItem">
<ul class="sharing">
<li><a href="http://twitter.com/share" class="twitter-share-button" data-url="http://ksulax.com<%= Html.Encode(Request.Path) %>" data-count="horizontal" data-via="kstatelax"></a></li>
<li><fb:like href="http://ksulax.com<%= Html.Encode(Request.Path) %>" show_faces="false" layout="button_count"/></li>
</ul>
<div class="date"><%= Html.Encode(((DateTime)Model.date).ToString("MMMM dd, yyyy"))%></div>
<% if (!String.IsNullOrEmpty(Model.source) && !String.IsNullOrEmpty(Model.source_url)) { %>
<p>This article is originally from <a href='<%= Model.source_url %>'><%= Model.source %></a>.</p>
<% } if (!String.IsNullOrEmpty(Model.author)) { %>
<p>By <%= Model.author %></p>
<% } %>
<%= Model.story %>
</div></div>
</asp:Content>