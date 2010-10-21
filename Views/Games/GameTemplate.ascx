<%@ Control Language="C#" CodeBehind="~/Views/Games/GameTemplate.ascx.cs" AutoEventWireup="true" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.Game>>" %>
<% if (false) { %><link rel="stylesheet" type="text/css" href="../../content/css/main.css" /><% } %>
<% if (false) { %><style type="text/css">.hidden { display:none; }</style><% } %>
<% KSULax.GameTemplate gt = new KSULax.GameTemplate();%>
<script type="text/javascript">$(document).ready(gameDetail); </script>
<table style="width:100%;" class="mainTable">
<thead>
<tr>
<th scope="col">Day</th>
<th scope="col">Date</th>
<th scope="col">Time</th>
<th scope="col">Opponent</th>
<th scope="col">Location</th>
<th scope="col">Result</th>
<th scope="col">Details</th>
</tr>
</thead>
<tbody>
<%  KSULax.Models.Team ksu = new KSULax.Models.Team();
    KSULax.Models.Team opp = new KSULax.Models.Team();
    bool home = true;
    bool win = true;
    foreach (var game in Model) {
        if (game.HomeTeam.slug.Equals("kennesaw_state"))
        {
            ksu = game.HomeTeam;
            opp = game.AwayTeam;
            home = true;
        }
        else
        {
            ksu = game.AwayTeam;
            opp = game.HomeTeam;
            home = false;
        }
%>
<tr class="<%= home ? "home":"away" %> <%= game.game_type %> <%= (game.game_season_id > game.game_date.Value.Year) ? "fall" : "spring" %>">
<td class="nowrap"><%= Html.Encode(((DateTime)game.game_date).ToString("ddd"))%></td>
<td class="nowrap"><%= Html.Encode(((DateTime)game.game_date).ToString("MMM dd"))%></td>
<td class="nowrap"><%= Html.Encode(((DateTime)game.game_time).ToString("hh:mm tt"))%></td>
<td class="nowrap">
<% if (game.game_type.Equals("scrimage") || game.game_type.Equals("divisional") ||game.game_type.Equals("playoff")){%>
<img class="gametype" src="../../content/images/game_<%= Html.Encode(game.game_type) %>.png" alt="<%= Html.Encode(game.game_type) %> game" title="<%= Html.Encode(game.game_type) %> game" width="19" height="19" />
<%}%>
<img style="vertical-align:middle;" src="../../content/images/teams/<%= Html.Encode(opp.slug) %>_24.png" alt="<%= Html.Encode(opp.abr) %>&apos;s Logo" title="<%= Html.Encode(opp.abr) %>'s Logo" width="24" height="24" />
<% if(!home) {%>@ <%} if(!string.IsNullOrEmpty(opp.team_url)) { %><a href="<%= Html.Encode(opp.team_url)%>" title="<%= Html.Encode(opp.abr)%>'s Homepage"><%= Html.Encode(opp.abr)%></a><% } %>
<% else { %><%= Html.Encode(opp.abr)%><% } %>
</td>
<td style="width:32%;"><%= Html.Encode(game.venue)%></td>
<td class="nowrap"><% if (!game.game_status.Equals("0")) { %><%= Html.Encode(game.game_status)%>
<% } else { string result = gt.gameResult(game.home_team_score, game.away_team_score, home); win = result.Contains("W"); %><%=result%><% } %>
</td>
<td>
<%  bool review = !string.IsNullOrEmpty(game.detail);
    bool photogallery = game.PhotoGalleries.Count > 0;
    bool gameID = game.id > 6000 && game.home_team_score.HasValue;
    if (review || photogallery || gameID) { %><a name="<%= game.id %>"></a><span id="game_<%= game.id %>" title="Game Recap"></span><% } %>
</td></tr>
<% if (review || photogallery || gameID) { %>
<tr id="info_<%= game.id %>" class="hidden">
<td colspan="7">
<% if (review) { %>
<h3>Game Review</h3>
<p><%= game.detail.Replace("<br>","<br/>")%></p>
<% } if (photogallery) {
       var photographer = game.PhotoGalleries.ElementAtOrDefault<KSULax.Models.PhotoGallery>(0).Photographer; if (review)
       { %><br /><% } %>
    <h3>Photos</h3>
    <p>
        <% bool first = true; foreach (var gallery in game.PhotoGalleries)
           {
               if (!first)
               { %>
        |
        <% } first = false; %>
        <a href="<%= gallery.url %>" title="<%=gallery.text%> from <%=photographer.company%>">
            <%=gallery.text%></a><% } %>
        <br />
        from <a href="<%= photographer.url%>" title="<%=photographer.company%>"><%=photographer.company%></a></p>
<% } if (gameID) { if (review||photogallery){ %><br /><% } %><h3>MCLA</h3><% } if (win) { %>
<ul class="sharing" style="margin-bottom:-10px;">
<li><a href="http://twitter.com/share" class="twitter-share-button" data-url="http://ksulax.com/games/<%= game.id %>" data-count="horizontal" data-via="kstatelax"></a></li>
<li><fb:like href="http://ksulax.com/games/<%= game.id %>" show_faces="false" layout="button_count"/></li>
</ul>
<% } if (gameID) { %><p><a href="http://mcla.us/scores/games/<%= game.id %>" title="MCLA Game Recap">GAME RECAP</a></p><% } %>
</td></tr><% } %><% } %></tbody></table>