<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KSULax.Models.News.StoryBriefListModel>" %><%@ Import Namespace="KSULax.Helpers" %>
<% foreach (var story in Model.Stories) { %>
<div class="homeNewsItem">
<div class="date"><%= Html.formatDate(story.Date) %></div>
<h1><% if(story.StoryType.Equals(KSULax.Interfaces.NewsType.Game)) { %>
<a href="<%= Html.Encode(Url.Action("Index", "games", new { id = story.SeasonID }) + "#" + story.GameID) %>" title="<%= Html.Encode(story.Title) %>"><%= Html.Encode(story.Title) %></a>
<% } else { %>
<%= Html.ActionLink(Html.Encode(story.Title), "Index", "News", new { year = story.Date.Year, month = story.Date.Month, day = story.Date.Day, url_title = Html.Encode(story.TitlePath) }, new { title = Html.Encode(story.Title) })%>
<% } %></h1>
<p><%= Html.formatDesc(story.Story)%>&#8230; <span class="readMore">
<% if(story.StoryType.Equals(KSULax.Interfaces.NewsType.Game)) { %>
<a href="<%= Html.Encode(Url.Action("Index", "games", new { id = story.SeasonID }) + "#" + story.GameID) %>" title="<%= Html.Encode(story.Title) %>">Read More</a>
<% } else { %>
<%= Html.ActionLink("Read More", "Index", "News", new { year = story.Date.Year, month = story.Date.Month, day = story.Date.Day, url_title = story.TitlePath }, new { title = Html.Encode(story.Title) })%>
<% } %></span></p></div><% } %>