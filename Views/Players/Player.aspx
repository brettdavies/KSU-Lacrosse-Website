<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Player.PlayerModel>" %><%@ Import Namespace="KSULax.Helpers" %>

<asp:Content ContentPlaceHolderID="titleContent" runat="server"><%= Model.FullName %> &#35;<%= Model.RecentJerseyNum %></asp:Content>

<asp:Content ContentPlaceHolderID="Header" runat="server">
<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
<script type="text/javascript" src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
<meta property="og:title" content="<%= Model.FullName %> #<%= Model.RecentJerseyNum %>"/>
<meta property="og:url" content="http://ksulax.com/players/<%= Model.FullNameURL %>"/>
<meta property="og:description" name="description" content="<%= Html.formatDesc(Model.Bio) %>" />
<meta property="og:type" content="article"/>
<% Html.RenderPartial("FacebookGraph"); %>
</asp:Content>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol">
<% Html.RenderPartial("SponsorsTemplate"); %>
</div>
<div id="mainCol">
<div class="breadcrumbs">
<%= Html.ActionLink("Home","","", null, new { title = "Home" })%> > <%= Html.ActionLink("Players", "Index", new { id = string.Empty }, new { title = "Players" })%> > <%= Html.ActionLink(Model.FullName, Model.FullNameURL, null, new { title = Model.FullName })%></div>
<ul class="sharing">
<li><a href="http://twitter.com/share" class="twitter-share-button" data-url="http://ksulax.com<%= Html.Encode(Request.Path) %>" data-count="horizontal" data-via="kstatelax" data-text="<%= Html.Encode(Model.FullName)%> Profile Page"></a></li>
<li><fb:like href="http://ksulax.com<%= Html.Encode(Request.Path) %>" show_faces="false" layout="button_count"/></li>
</ul>
<h1><%= Model.FullName %> <% if (Model.isCurPlayer) { %>&#35;<%= Model.RecentJerseyNum %><% } %></h1>
<img class="imgBorder" src="<%= Model.ImagePath %>" alt="Photo of <%= Model.FullName %>" title="Photo of <%= Model.FullName %>" width="100" height="133" align="left" />
<table>
<tbody><tr><td>
<table><tbody>
<tr><td><strong>Name</strong></td><td><%= Model.FullName %></td></tr>
<tr><td><strong>Highschool</strong></td><td><%= Model.HighSchool %></td></tr>
<tr><td><strong>Hometown</strong></td><td><%= Model.Home %></td></tr>
<% if (Model.isCurPlayer) { %><tr><td><strong>Position</strong></td><td><%= Model.RecentSeason.GetValueOrDefault().Position %></td></tr><% } %>
<% if (Model.isCurPlayer) { %><tr><td><strong>Class Year</strong></td><td><%= Model.RecentSeason.GetValueOrDefault().ClassYr%></td></tr><% } %>
</tbody></table>
</td>
<td>
<table><tbody>
<tr><td><strong>Height</strong></td><td><%= Model.HeightFeet %></td></tr>
<tr><td><strong>Weight</strong></td><td><%= Model.RecentSeason.GetValueOrDefault().Weight %> lbs.</td></tr>
<tr><td><strong>Major</strong></td><td><%= Model.Major %></td></tr>
<% if (Model.isCurPlayer) { %><tr><td><strong>Age</strong></td><td>20</td></tr><% } %>
<% if (Model.isCurPlayer) { %><tr><td><strong>Eligibility</strong></td><td><%= Model.RecentSeason.GetValueOrDefault().EligibilityYr %></td></tr><% } %>
</tbody></table>
</td></tr>
</tbody></table>

<table class="mainTable" style="clear:both;">
<thead><tr><th scope="col">Player Bio</th></tr></thead>
<tbody><tr><td><%= Model.Bio %></td></tr></tbody></table>

<br/>

<table class="mainTable">
<thead><tr><th colspan="9">Season Stats</th></tr></thead>
<tbody>
<tr><td>Season</td><td>Class</td><td>Games Played</td><td>Assists</td><td>Assists Per Game</td><td>Goals</td><td>Goals Per Game</td><td>Points</td><td>Points Per Game</td></tr>
<% foreach (KSULax.Models.Player.PlayerGameTotalModel pgtm in Model.PlayerGameTotal) { %>
<tr><td><%= pgtm.SeasonID %></td><td><%= pgtm.ClassYr %></td><td><%= pgtm.GamesPlayed %></td><td><%= pgtm.Assists %></td><td><%= pgtm.Assists / pgtm.GamesPlayed %></td><td><%= pgtm.Goals %></td><td><%= pgtm.Goals / pgtm.GamesPlayed %></td><td><%= pgtm.Goals +  pgtm.Assists %></td><td><%= (pgtm.Goals + pgtm.Assists) / pgtm.GamesPlayed %></td></tr>
<% } %>
<tr><td>Career</td><td>-</td><td><%= Model.CareerGames %></td><td><%= Model.CareerAssists %></td><td><%= Model.CareerAssists / Model.CareerGames %></td><td><%= Model.CareerGoals %></td><td><%= Model.CareerGoals / Model.CareerGames %></td><td><%= Model.CareerGoals +  Model.CareerAssists %></td><td><%= (Model.CareerGoals +  Model.CareerAssists) / Model.CareerGames %></td></tr>
</tbody></table>
<br/>
<% if (Model.PlayerHasAwards) { %>
<table class="mainTable">
<thead><tr><th colspan="2">Awards</th></tr></thead>
<tbody>
<% foreach (KSULax.Entities.PlayerAwardBE pa in Model.PlayerAward) { %>
<tr><td><%= pa.Date.Year + " " + pa.Award.Name %> <%if (pa.AwardID.Equals(29)){ %>(Week of <%= pa.Date.ToString("MMM dd") %>)<% } %></td></tr>
<%}%>
</tbody></table>
<% } %>

<br />
<%
    int careerGoals = 0;
    int careerAssists = 0;

    int gameGoalsGold = 6;
    int gameGoalsSilver = 4;
    int careerGoalsGold = 100;
    int careerGoalsSilver = 50;

    int gameAssistsGold = 4;
    int gameAssistsSilver = 2;
    int careerAssistsGold = 100;
    int careerAssistsSilver = 50;

    int gamePointsGold = 10;
    int gamePointsSilver = 6;
    int careerPointsGold = 100;
    int careerPointsSilver = 50;

    int gameGoalsGoldCount = 0;
    int gameGoalsSilverCount = 0;
    int careerGoalsGoldCount = 0;
    int careerGoalsSilverCount = 0;

    int gameAssistsGoldCount = 0;
    int gameAssistsSilverCount = 0;
    int careerAssistsGoldCount = 0;
    int careerAssistsSilverCount = 0;

    int gamePointsGoldCount = 0;
    int gamePointsSilverCount = 0;
    int careerPointsGoldCount = 0;
    int careerPointsSilverCount = 0;
    
    foreach (KSULax.Entities.PlayerGameBE game in Model.PlayerGame.ToList()) {
        //add to career totals
        careerGoals+= game.Goals;
        careerAssists += game.Assists;
        
        //check game records
        if (game.Assists >= gameAssistsGold) { gameAssistsGoldCount++; }
        else if (game.Assists >= gameAssistsSilver) { gameAssistsSilverCount++; }

        if (game.Goals >= gameGoalsGold) { gameGoalsGoldCount++; }
        else if (game.Goals >= gameGoalsSilver) { gameGoalsSilverCount++; }

        if (game.Goals + game.Assists >= gamePointsGold) { gamePointsGoldCount++; }
        else if (game.Goals + game.Assists >= gamePointsSilver) { gamePointsSilverCount++; }
    }
    
    //check career records
    if (careerAssists >= careerAssistsGold) { careerAssistsGoldCount = careerAssists / careerAssistsGold; }
    else if (careerAssists >= careerAssistsSilver) { careerAssistsSilverCount = careerAssists / careerAssistsSilver; }

    if (careerGoals >= careerGoalsGold) { careerGoalsGoldCount = careerGoals / careerGoalsGold; }
    else if (careerGoals >= careerGoalsSilver) { careerGoalsSilverCount = careerGoals / careerGoalsSilver; }

    if (careerGoals + careerAssists >= careerPointsGold) { careerPointsGoldCount = (careerGoals + careerAssists) / careerPointsGold; }
    else if (careerGoals + careerAssists >= careerPointsSilver) { careerPointsSilverCount = (careerGoals + careerAssists) / careerPointsSilver; }


    int presidentCount = 0;
    int officerCount = 0;
    int captainCount = 0;
    
    foreach (KSULax.Entities.PlayerSeasonBE ps in Model.PlayerSeason)
    {
        if (ps.President) { presidentCount++; }
        if (ps.Officer) { officerCount++; }
        if (ps.Captain) { captainCount++; }
    }    
    %>
<table class="mainTable">
<thead><tr><th colspan="3">Achievements</th></tr></thead>
<tbody>
<tr><td>Career Assists: <%= careerAssists %></td><td>Career Goals: <%= careerGoals %></td><td>Career Points: <%= careerAssists + careerGoals %></td></tr>
<tr><td>Career Gold Assists: <%= careerAssistsGoldCount %></td><td>Career Gold Goals: <%= careerGoalsGoldCount %></td><td>Career Gold Points: <%= careerPointsGoldCount %></td></tr>
<tr><td>Career Silver Assists: <%= careerAssistsSilverCount %></td><td>Career Silver Goals: <%= careerGoalsSilverCount %></td><td>Career Silver Points: <%= careerPointsSilverCount %></td></tr>
<tr><td>Game Gold Assists: <%= gameAssistsGoldCount %></td><td>Game Gold Goals: <%= gameGoalsGoldCount %></td><td>Game Gold Points: <%= gamePointsGoldCount%></td></tr>
<tr><td>Game Silver Assists: <%= gameAssistsSilverCount %></td><td>Game Silver Goals: <%= gameGoalsSilverCount %></td><td>Game Silver Points: <%= gamePointsSilverCount%></td></tr>
<tr><td>President: <%= presidentCount %></td><td>Officer: <%= officerCount %></td><td>Team Captain: <%= captainCount %></td></tr>
</tbody></table>
</div>
</asp:Content>