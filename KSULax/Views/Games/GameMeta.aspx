<%@ Page Language="C#" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.News>" %><%@ Import Namespace="KSULax.Helpers" %>
<html xmlns="http://www.w3.org/1999/xhtml" xmlns:fb="http://www.facebook.com/2008/fbml" xmlns:og="http://opengraph.org/schema/">
<head><title><%= Html.Encode(Model.title)%></title>
<meta property="og:title" content="<%= Html.Encode(Model.title.Trim())%>"/>
<meta property="og:url" content="http://ksulax.com/games/<%= Model.url_title.Substring(Model.url_title.IndexOf("#")+1) %>"/>
<meta property="og:description" name="description" content="<%= (Model.story.Length.Equals(0)) ? Model.title : Html.formatDesc(Model.story).Trim() %>" />
<meta property="og:type" content="article"/>
<% Html.RenderPartial("FacebookGraph"); %>
<meta http-equiv="refresh" content="0;url=http://ksulax.com<%= Model.url_title %>"/>
</head><body>
</body></html>