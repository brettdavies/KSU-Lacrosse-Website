<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Alumni</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title="Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Alumni", "alumni", "about", null, new { title = "Alumni" })%></div>
<h1>Alumni</h1>
<p>The Kennesaw State University men's lacrosse team has grown considerably since its humble beginnings, these players are the reason the program has reached the success that it has.</p>
<br />
<h3>Andrew Congleton (10-12)</h3>
<p>Andrew 'AC13' Congleton was a consistent threat to score from the midfield during his career, scoring 41 goals in his three years at KSU. He led the team in scoring his Senior campaign, was an All-Conference Midfielder, and Team Captain.</p>
<br />
<h3>Andrew Flood (11-12)</h3>
<p>Andrew 'Flash' Flood started every game for the Owls in 2012, leading the team to the SELC Championship game while averaging less than eight goals against per game. Flood also tallied two assists in the Owls' first TV broadcasted game against Missouri State. He was also named all-tournament in the 2012 SELC Tournament.</p>
<br />
<h3>Roary Keown (08-12)</h3>
<p>Keown was a three year starter at defense for the Owls; he was a consistent anchor for the KSU defense in his career. He is known primarily for his interceptions and deflections.</p>
<br />
<h3>Scott Schulze (08-11)</h3>
<p>Scotty Schulze is the most decorated athlete in KSU history. A three time All-American and four time All-Conference selection, Scott is the leading scorer in team history. He finished his career with 240 points. Scott Schulze was named to the SELC 25th Anniversary Team.</p>
<br />
<h3>Kyle Hansen (09-11)</h3>
<p>Kyle Hansen is the most famous alum for the Owls, making his national television debut in 2011. He started every game of the 2009 season and will be remembered for his performance against SCAD in the 2010 SELC Semi-Finals.</p>
<br />
<h3>Isom White (08-11)</h3>
<p>A Powder Springs native and two time 1st team All-Conference midfielder, Isom served as President and Team Captain for the Owls his Senior year. He had 93 career points for the Owls.</p>
<br />
<h3>Jim Faucette (09-11)</h3>
<p>A Kennesaw native, Jim set the record for the most goals by a defenseman in a season in 2010 with 3 and is the only known Owl defenseman to lead the team in scoring in a game.</p>
<br />
<h3>Justin McKay (08-11)</h3>
<p>McKay tallied 74 total points in his four years at KSU. He was known for his dedication and attendance at every practice.</p>
<br />
<h3>Zach Statham (07-10)</h3>
<p>Zach is the only Owl to have earned the honor of being named a MCLA Scholar Athlete (he earned that honor twice). In Statham's time with the Owls he served as a two time President and was a 2010 All-Conference player.</p>
<br />
<h3>Charles Roland (07-10)</h3>
<p>Chuck served as Team Captain and President for the Owls in 2010, the same year he was named an All-Conference midfielder for KSU.</p>
<br />
<h3>Tim Minick (07-10)</h3>
<p>Tim Minick otherwise known as 'the puma' was a notorious goal scorer on the crease, finishing his career with 89 goals.</p>
<br />
<h3>Noah Rosenblum (09-11)</h3>
<p>A two year starter and Team Captain for the Owls, Rosenblum will be remembered for his heroic performance in the Owls first win against Emory in 2010.</p>
<br />
<h3>Murray Webb (09-10)</h3>
<p>Although Murray Webb only played two years at KSU, he left his mark on the program. He anchored the defense during the school's first run to the SELC Conference Championship.</p>
<br />
<h3>Head Coach Ken Byers</h3>
<p>Forever the face of Kennesaw State lacrosse, Ken is a member of the Georgia Lacrosse Hall of Fame and the first coach in school history to lead the team to the SELC Conference Championship Game. Ken guided the team for the first five years of its existence and we wouldn't be where we are now without his efforts.</p>
</asp:Content>