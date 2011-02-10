<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.News.StoryModel>" %><%@ Import Namespace="KSULax.Helpers" %>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="http://www.facebook.com/2008/fbml" xmlns:og="http://opengraph.org/schema/">
<head><title><%= Html.Encode(Model.Title)%></title>
<meta property="og:title" content="<%= Html.Encode(Model.Title) %>"/>
<meta property="og:url" content="http://ksulax.com/games/<%= Model.TitlePath.Substring(Model.TitlePath.IndexOf("#")+1) %>"/>
<meta property="og:description" name="description" content="<%= (Model.Story.Length.Equals(0)) ? Model.Title : Html.formatDesc(Model.Story) %>" />
<meta property="og:type" content="article"/>
<% Html.RenderPartial("FacebookGraph"); %>
<meta http-equiv="refresh" content="0;url=http://ksulax.com/games/<%= Model.TitlePath.Substring(Model.TitlePath.IndexOf("#")+1) %>"/>
</head><body>
</body></html>