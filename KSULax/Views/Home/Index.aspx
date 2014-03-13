<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Home.HomepageDataModel>" %>

<asp:Content ContentPlaceHolderID="titleContent" runat="server">Homepage</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="server">
<meta name="google-site-verification" content="uH_owkFAkq319JgINOym-7OizGCb1UvlejogcMbKxKc" />
<meta name="msvalidate.01" content="A24836F893DB6FD9E8E17732BA2DA967" />
<meta name="y_key" content="0a46360bd8e12844" />
<meta property="og:title" content="KSU Lacrosse Homepage"/>
<meta property="og:url" content="http://ksulax.com"/>
<meta property="og:description" name="description" content="KSU Lacrosse is a club sport at Kennesaw State University. We are members of the SELC, competing in the Central Region of Division 2." />
<meta property="og:type" content="website"/>
<meta property="fb:admins" content="5702803" />
<% Html.RenderPartial("FacebookGraph"); %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="fb-root"></div>
<script type="text/javascript">
    window.fbAsyncInit = function () {
        FB.init({ appId: '755158114529699', status: true, cookie: true, xfbml: true });
        FB.getLoginStatus(function (response) {
            if (response.status != "unknown") {
                $('#noFBnewsbox').hide();
            } else {
                $('#newsbox').hide();
            }
        });
    };
    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) return;
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/all.js#xfbml=1&appId=755158114529699";
        fjs.parentNode.insertBefore(js, fjs);
    } (document, 'script', 'facebook-jssdk'));
</script>
<div id="leftCol"><% Html.RenderPartial("UpcomingGamesTemplate"); %><% Html.RenderPartial("StandingTemplate"); %><% Html.RenderPartial("RankingTemplate"); %></div>
<div id="midCol">
<div id="homeSlide"><img src="../../content/images/home-side.jpg" width="440" height="267" alt="" /></div>
<div id="homeFeature"><img src="../../content/images/yellow-arrow.png" width="11" height="10" alt="" /> <b><%= Html.ActionLink("Register for the Skills Camp!", "skills-clinic", "forms", null, new { title = "Skills Camp Registration" })%></b></div>
<div class="homeNews"><%= Html.ActionLink("News & Updates", "Index", "News", null, new { title = "News & Updates" })%></div>
<fb:like-box href="https://www.facebook.com/ksulax" width="450" height="850" colorscheme="light" show_faces="false" header="false" stream="true" show_border="false"></fb:like-box>
<p id="noFBnewsbox">Sign into Facebook to see the news</p>
</div>
<div id="rightCol"><% Html.RenderPartial("DonationTemplate"); %><% Html.RenderPartial("FacebookTemplate"); %><% Html.RenderPartial("TwitterTemplate"); %></div>
</asp:Content>