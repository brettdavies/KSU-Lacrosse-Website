<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.Game>>" %>
<% if (false) { %><link rel="stylesheet" type="text/css" href="../../content/css/main.css" /><% } %>
<% KSULax.GameTemplate gt = new KSULax.GameTemplate();int season = Model.ElementAtOrDefault<KSULax.Models.Game>(0).game_season_id.GetValueOrDefault();%>
<script type="text/javascript">$(document).ready(gameSelector); </script>
<div>
<div class="boxTitle"><%= Html.ActionLink(season + " Game Schedule", "Index", "Games", new { id = season }, new { title = season + " Game Schedule" })%></div>
<div class="boxContent" id="gamesBox">
<table style="width:100%;" id="gamesBoxTable">
<%  KSULax.Models.Team ksu = new KSULax.Models.Team();
    KSULax.Models.Team opp = new KSULax.Models.Team();
    bool home = true;
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
<td style="width:28%;"><div style="text-align:center;"><img style="vertical-align:middle;" src="../../content/images/teams/
<%= Html.Encode(opp.slug)%>_32.png" alt="<%= Html.Encode(opp.abr) %>&apos;s Logo" title="<%= Html.Encode(opp.abr) %>'s Logo" width="32" height="32" /></div></td>
<td style="width:23%;"><%= Html.Encode(opp.abr)%></td>
<td style="width:17%;" class="nowrap"><%= Html.Encode(((DateTime)game.game_date).ToString("M / d"))%></td>
<td style="width:32%;" class="nowrap"><% if (!game.game_status.Equals("0")) { %><%= Html.Encode(game.game_status)%><% } %>
<% else { var result = gt.gameResult(game.home_team_score, game.away_team_score, home); if(!result.Equals("-")) {%>
<%= Html.ActionLink(result, "index", "games", new { id = game.game_season_id + "#" + game.id }, new { title = result })%>
<% } else { %><%=result%><% }} %></td>
</tr><% } %>
</table>
</div>
<div class="boxBottom"><img src="../../content/images/gray-arrow.png" alt="" /> <%= Html.ActionLink("See More Games", "Index", "Games", new { id = season }, new { title = season + " Game Schedule" })%></div>
</div>