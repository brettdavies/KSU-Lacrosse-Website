<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.News>>" %><%@ Import Namespace="KSULax.Helpers" %>
<% foreach (var item in Model) { %>
<div class="homeNewsItem">
<div class="date"><%= Html.Encode(((DateTime)item.date).ToString("MMMM dd, yyyy"))%></div>
<h1><% if(!Uri.IsWellFormedUriString(item.url_title, UriKind.Relative)) { %>
<a href="<%= Html.Encode(item.url_title) %>" title="<%= Html.Encode(item.title) %>"><%= Html.Encode(item.title) %></a>
<% } else { %>
<%= Html.ActionLink(Html.Encode(item.title), "Index", "News", new { year = item.date.Year, month = item.date.Month, day = item.date.Day, url_title = Html.Encode(item.url_title.ToLower()) }, new { title = Html.Encode(item.title) })%>
<% } %></h1>
<p><%= Html.formatDesc(item.story)%>&#8230; <span class="readMore">
<% if(!Uri.IsWellFormedUriString(item.url_title, UriKind.Relative)) { %>
<a href="<%= Html.Encode(item.url_title) %>" title="<%= Html.Encode(item.title) %>">Read More</a>
<% } else { %>
<%= Html.ActionLink("Read More", "Index", "News", new { year = item.date.Year, month = item.date.Month, day = item.date.Day, url_title = item.url_title.ToLower() }, new { title = Html.Encode(item.title) })%>
<% } %></span></p></div><% } %>