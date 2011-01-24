<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.News.StoryModel>>" %><%@ Import Namespace="KSULax.Helpers" %>
<% foreach (var item in Model) { %>
<div class="homeNewsItem">
<div class="date"><%= Html.formatDate(item.Date) %></div>
<h1><% if(!Uri.IsWellFormedUriString(item.TitlePath, UriKind.Relative)) { %>
<a href="<%= Html.Encode(item.TitlePath) %>" title="<%= Html.Encode(item.Title) %>"><%= Html.Encode(item.Title) %></a>
<% } else { %>
<%= Html.ActionLink(Html.Encode(item.Title), "Index", "News", new { year = item.Date.Year, month = item.Date.Month, day = item.Date.Day, url_title = Html.Encode(item.TitlePath) }, new { title = Html.Encode(item.Title) })%>
<% } %></h1>
<p><%= Html.formatDesc(item.Story)%>&#8230; <span class="readMore">
<% if(!Uri.IsWellFormedUriString(item.TitlePath, UriKind.Relative)) { %>
<a href="<%= Html.Encode(item.TitlePath) %>" title="<%= Html.Encode(item.Title) %>">Read More</a>
<% } else { %>
<%= Html.ActionLink("Read More", "Index", "News", new { year = item.Date.Year, month = item.Date.Month, day = item.Date.Day, url_title = item.TitlePath }, new { title = Html.Encode(item.Title) })%>
<% } %></span></p></div><% } %>