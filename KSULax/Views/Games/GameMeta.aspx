<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.News.StoryBriefModel>" %><%@ Import Namespace="KSULax.Helpers" %>
<% string url = Request.Url.GetLeftPart(UriPartial.Authority) + Url.RouteUrl("games", new { id = Model.SeasonID }) + "#" + Model.GameID; %>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="http://www.facebook.com/2008/fbml" xmlns:og="http://opengraph.org/schema/">
<head><title><%= Html.Encode(Model.Title)%></title>
<meta property="og:title" content="<%= Html.Encode(Model.Title) %>"/>
<meta property="og:url" content="<%= url %>"/>
<meta property="og:description" name="description" content="<%= (Model.Story.Length.Equals(0)) ? Model.Title : Html.formatDesc(Model.Story) %>" />
<meta property="og:type" content="article"/>
<% Html.RenderPartial("FacebookGraph"); %>
<meta http-equiv="refresh" content="0;url=<%= url %>"/>
</head><body>
</body></html>