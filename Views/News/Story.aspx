<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.News.StoryModel>" %><%@ Import Namespace="KSULax.Helpers" %>

<asp:Content ContentPlaceHolderID="titleContent" runat="server"><%= Html.Encode(Model.Title)%></asp:Content>

<asp:Content ContentPlaceHolderID="Header" runat="server">
<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
<script type="text/javascript" src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
<meta name="original-source" content="<%= Html.Encode(Model.SourceUrl) %>"/>
<meta property="og:title" content="<%= Html.Encode(Model.Title)%>"/>
<meta property="og:url" content="<%= Html.Encode(Request.Url.ToString())%>"/>
<meta property="og:description" name="description" content="<%= Html.Encode(Html.formatDesc(Model.Story)) %>"/>
<meta property="og:type" content="article"/>
<% Html.RenderPartial("FacebookGraph");%>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("DonationTemplate"); %></div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("News", "Index", new { year = string.Empty, month = string.Empty, day = string.Empty, url_title = string.Empty }, new { title = "News" })%> > <%= Html.ActionLink(Html.Encode(Model.Title), "Index", new { year = Model.Date.Year, month = Model.Date.Month, day = Model.Date.Day, url_title = Html.Encode(Model.TitlePath) }, new { title = Html.Encode(Model.Title) })%></div>
<h1><%= Html.Encode(Model.Title)%></h1>
<div class="homeNewsItem">
<ul class="sharing">
<li><a href="http://twitter.com/share" class="twitter-share-button" data-url="http://ksulax.com<%= Html.Encode(Request.Path) %>" data-counturl="http://ksulax.com<%= Html.Encode(Request.Path) %>" data-count="horizontal" data-via="kstatelax"></a></li>
<li><fb:like href="http://ksulax.com<%= Html.Encode(Request.Path) %>" show_faces="false" layout="button_count"/></li>
</ul>
<div class="date"><%= Html.formatDate(Model.Date)%></div>
<% if (Model.HasExternalSource) { %>
<p>This article is originally from <a href='<%= Model.SourceUrl %>'><%= Model.Source %></a>.</p>
<% } if (Model.HasAuthor) { %>
<p>By <%= Model.Author %></p>
<% } %>
<%= Model.Story %>
</div></div>
</asp:Content>