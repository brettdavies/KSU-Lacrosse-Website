<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.HomepageData>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">Homepage</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
<meta property="og:title" content="KSU Lacrosse Homepage"/>
<meta property="og:url" content="http://ksulax.com"/>
<meta property="og:description" name="description" content="KSU Lacrosse is a club sport at Kennesaw State University. We are members of the SELC, competing in the Central Region of Division 2." />
<meta property="og:type" content="website"/>
<meta property="fb:admins" content="5702803" />
<% Html.RenderPartial("FacebookGraph"); %>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("GameSidebarTemplate", Model.games); %></div>
<div id="midCol">
<div id="homeSlide"><img src="../../content/images/home-side.jpg" width="440" height="267" alt="" /></div>
<div id="homeFeature"><img src="../../content/images/yellow-arrow.png" width="11" height="10" alt="" /> <b>Winter Skills Camp Registration Opens Thursday, January 6th!</b></div>
<div class="homeNews"><%= Html.ActionLink("News & Updates", "Index", "News", null, new { title = "News & Updates" })%></div>
<% Html.RenderPartial("NewsTemplate", Model.news); %>
</div>
<div id="rightCol"><% Html.RenderPartial("SponsorsTemplate"); %><% Html.RenderPartial("RankingTemplate"); %><% Html.RenderPartial("FacebookTemplate"); %><% Html.RenderPartial("TwitterTemplate"); %></div>
</asp:Content>