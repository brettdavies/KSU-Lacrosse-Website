<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Associations</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("About", "index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Associations", "associations", "about", null, new { title = "Associations" })%></div>
<h1>Associations</h1>
<h2>SELC</h2>
<h3>Southeastern Lacrosse Conference</h3>
<p>Kennesaw State University is a proud member of the SELC. The Owls joined the league in the Fall of 2005. The Owls enter each season in full league competition with hopes of earning a national ranking. The conference is comprised of 18 Division II teams such as Furman, UNC-Charlotte, Emory, SCAD, Elon and many others. Each season we have a league mandate on the number of required games we play. Those games go towards earning post season play in the SELC Championships.</p>
<p>The SELC holds their annual conference tournament at Northview HS in Atlanta, GA for the last 5 years. This past season over 7000 people attended the weekend of festivities. The SELC is regarded as one of the top conferences in the nation and will be home to the largest number of teams come the 2010 season. Visit <asp:HyperLink NavigateUrl="http://www.selc.org" Text="SELC" runat="server" />.</p>
<h2>MCLA</h2>
<h3>Men&#8217;s Collegiate Lacrosse Association</h3>
<p>The MCLA is a national organization of non-varsity, college lacrosse programs. With over 230 teams in two divisions, the MCLA represents the fastest growing segment of college men�s lacrosse. The MCLA provides a governing structure much like the NCAA, with eligibility rules, national polls, All-Americans, and a national tournament to decide national champions in both Division I and Division II. Its nine conferences are spread across the country. The MCLA exists to provide a quality college lacrosse experience where varsity lacrosse does not yet exist. On an individual scale, the MCLA provides rules and a structure that promotes &#8220;virtual varsity&#8221; lacrosse.</p>
<p>On a national scale, the MCLA provides infrastructure to support a level playing field through eligibility rules and enforcement and use of NCAA rules of play. The purpose of the MCLA is to grow the men&#8217;s college game, and with an increase from 70 teams to nearly 230 in ten years it is apparent that the mission is being accomplished. More information can be found at <asp:HyperLink NavigateUrl="http://mcla.us" Text="MCLA" runat="server" /> and <asp:HyperLink NavigateUrl="http://www.collegelax.us" Text="CollegeLax.us" runat="server" />.</p>
</asp:Content>