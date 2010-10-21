<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.Player>" %><%@ Import Namespace="KSULax.Helpers" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server"><% string title = Model.first + " " + Model.last; %><%= title %> &#35;<%= Model.PlayerSeason.ElementAt(0).jersey%></asp:Content>
<asp:Content ContentPlaceHolderID="Header" runat="server"><% string title = Model.first + " " + Model.last; %>
<script type="text/javascript" src="http://platform.twitter.com/widgets.js"></script>
<script type="text/javascript" src="http://connect.facebook.net/en_US/all.js#xfbml=1"></script>
<meta property="og:title" content="<%= title %> #<%= Model.PlayerSeason.ElementAt(0).jersey%>"/>
<meta property="og:url" content="http://ksulax.com/players/<%= title.Replace(' ', '-').ToLower() %>"/>
<meta property="og:description" name="description" content="<%= Html.formatDesc(Model.bio) %>" />
<meta property="og:type" content="article"/>
<% Html.RenderPartial("FacebookGraph"); %>
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<% 
   string title = Model.first + " " + Model.last;
   List<KSULax.Models.PlayerSeason> PSs = new List<KSULax.Models.PlayerSeason>();
   bool curPlayer = false;
   if (Model.PlayerSeason.Count > 0)
   {
       PSs = Model.PlayerSeason.ToList<KSULax.Models.PlayerSeason>();
       PSs.Sort((x, y) => string.Compare(y.season_id.ToString(), x.season_id.ToString()));
       curPlayer = short.Equals(PSs[0].season_id, KSULax.KSU.maxPlayerSeason);
   }
%>

<div id="leftCol">
<% Html.RenderPartial("SponsorsTemplate"); %>
</div>
<div id="mainCol">
<div class="breadcrumbs">
<%= Html.ActionLink("Home","","", null, new { title="Home" })%> > <%= Html.ActionLink("Players", "Index", new { id = string.Empty }, new { title = "Players" })%> > <%= Html.ActionLink(title, title.Replace(' ', '-').ToLower(), null, new { title = title })%></div>
<ul class="sharing">
<li><a href="http://twitter.com/share" class="twitter-share-button" data-url="http://ksulax.com<%= Html.Encode(Request.Path) %>" data-count="horizontal" data-via="kstatelax" data-text="<%= Html.Encode(title)%> Profile Page"></a></li>
<li><fb:like href="http://ksulax.com<%= Html.Encode(Request.Path) %>" show_faces="false" layout="button_count"/></li>
</ul>
<h1><%= title %> <% if (curPlayer) { %>&#35;<%= PSs[0].jersey%><% } %></h1>
<% 
    string imagePath = "/content/images/players/"+Model.id+".png";
    if (!new System.IO.FileInfo(Server.MapPath(imagePath)).Exists)
    {
        imagePath = "/content/images/teams/kennesaw_state_128.png";
    }

    string alt = "Gold Assists Per Game";
%>

<ul class="badges">
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
<li><%= Html.Image("", "~/content/images/teams/coastal_carolina_32.png", alt, new { height = 32, width = 32, title = alt })%></li>
</ul>

<img class="imgBorder" src="<%= imagePath %>" alt="Photo of <%= title %>" title="Photo of <%= title %>" width="100" height="133" align="left" />
<table>
<tbody><tr><td>
<table><tbody>
<tr><td><strong>Name</strong></td><td><%= title %></td></tr>
<tr><td><strong>Highschool</strong></td><td><%= Model.highschool%></td></tr>
<tr><td><strong>Hometown</strong></td><td><%= Model.hometown%>, <%= Model.homestate%></td></tr>
<% if (curPlayer) { %><tr><td><strong>Position</strong></td><td><%= PSs[0].position%></td></tr><% } %>
<% if (curPlayer) { %><tr><td><strong>Class Year</strong></td><td><%= PSs[0].@class%></td></tr><% } %>
</tbody></table>
</td>
<td>
<table><tbody>
<tr><td><strong>Height</strong></td><td><%= PSs[0].height%></td></tr>
<tr><td><strong>Weight</strong></td><td><%= PSs[0].weight%> lbs.</td></tr>
<tr><td><strong>Major</strong></td><td>Communications</td></tr>
<% if (curPlayer) { %><tr><td><strong>Age</strong></td><td>20</td></tr><% } %>
<% if (curPlayer) { %><tr><td><strong>Eligibility</strong></td><td><%= PSs[0].eligibility%></td></tr><% } %>
</tbody></table>
</td></tr>
</tbody></table>

<table class="mainTable" style="clear:both;">
<thead><tr><th scope="col">Player Bio</th></tr></thead>
<tbody><tr><td><%= Model.bio %></td></tr></tbody></table>

<br/>

<table class="mainTable">
<thead><tr><th colspan="9">Season Stats</th></tr></thead>
<tbody>
<tr><td>Season</td><td>Class</td><td>Games Played</td><td>Assists</td><td>Assists Per Game</td><td>Goals</td><td>Goals Per Game</td><td>Points</td><td>Points Per Game</td></tr>
<% foreach (KSULax.Models.PlayerSeason PS in PSs) { %>
<tr><td><%= PS.season_id %></td><td><%= PS.@class %></td><td><%= Model.PlayerGame.Count %></td><td>4</td><td>0</td><td>0</td><td>0</td><td>0</td><td>0</td></tr>
<% } %>
<tr><td>Career</td><td>-</td><td>0</td><td>4</td><td>1</td><td>1</td><td>0</td><td>0</td><td>0</td></tr>
</tbody></table>

<% if (Model.PlayerAward.Count > 0) {
       List<KSULax.Models.PlayerAward> PAs = Model.PlayerAward.ToList<KSULax.Models.PlayerAward>();
           PAs.Sort((x, y) => DateTime.Compare(y.date, x.date));
       %>
<br/>
<table class="mainTable">
<thead><tr><th colspan="2">Awards</th></tr></thead>
<tbody>
<% foreach (KSULax.Models.PlayerAward PA in PAs) { %>
<tr><td><%= PA.date.Year + " " + PA.Award.name %> <%if (PA.award_id.Equals(29)){ %>(Week of <%= PA.date.ToString("MMM dd") %>)<% } %></td></tr>
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
    
    foreach (KSULax.Models.PlayerGame game in Model.PlayerGame.ToList()) {
        //add to career totals
        careerGoals+= game.goals;
        careerAssists += game.assists;
        
        //check game records
        if (game.assists >= gameAssistsGold) { gameAssistsGoldCount++; }
        else if (game.assists >= gameAssistsSilver) { gameAssistsSilverCount++; }

        if (game.goals >= gameGoalsGold) { gameGoalsGoldCount++; }
        else if (game.goals >= gameGoalsSilver) { gameGoalsSilverCount++; }

        if (game.goals + game.assists >= gamePointsGold) { gamePointsGoldCount++; }
        else if (game.goals + game.assists >= gamePointsSilver) { gamePointsSilverCount++; }
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
    
    foreach (KSULax.Models.PlayerSeason PS in PSs)
    {
        if (PS.president.HasValue && PS.president.Value.Equals(true)) { presidentCount++; }
        if (PS.officer.HasValue && PS.officer.Value.Equals(true)) { officerCount++; }
        if (PS.captain.HasValue && PS.captain.Value.Equals(true)) { captainCount++; }
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