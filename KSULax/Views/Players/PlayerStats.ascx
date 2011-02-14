<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KSULax.Models.Player.PlayerGameStatListModel>" %>
<% if (Model.isCurPlayer) { KSULax.Models.Player.PlayerGameTotalModel pgtm = Model.GameStat[Model.GameStat.Count-1]; %>
<table class="mainTable">
<thead><tr><th colspan="9"><%= pgtm.SeasonID %> Stats</th></tr></thead>
<tbody>
<tr><td>Season</td><td>Games Played</td><td>Assists</td><td>Assists Per Game</td><td>Goals</td><td>Goals Per Game</td><td>Points</td><td>Points Per Game</td></tr>
<tr><td><%= pgtm.SeasonID %></td><td><%= pgtm.GamesPlayed %></td><td><%= pgtm.Assists %></td><td><%= pgtm.AssistsPerGame %></td><td><%= pgtm.Goals %></td><td><%= pgtm.GoalsPerGame %></td><td><%= pgtm.Points %></td><td><%= pgtm.PointsPerGame %></td></tr>
</tbody></table>
<% } %>
<table class="mainTable">
<thead><tr><th colspan="9">Career Stats</th></tr></thead>
<tbody>
<tr><td>Season</td><td>Games Played</td><td>Assists</td><td>Assists Per Game</td><td>Goals</td><td>Goals Per Game</td><td>Points</td><td>Points Per Game</td></tr>
<% foreach (KSULax.Models.Player.PlayerGameTotalModel pgtm in Model.GameStat) { %>
<tr><td><%= pgtm.SeasonID %></td><td><%= pgtm.GamesPlayed %></td><td><%= pgtm.Assists %></td><td><%= pgtm.AssistsPerGame %></td><td><%= pgtm.Goals %></td><td><%= pgtm.GoalsPerGame %></td><td><%= pgtm.Points %></td><td><%= pgtm.PointsPerGame %></td></tr>
<% } %>
<tr><td>Career</td><td><%= Model.CareerGames %></td><td><%= Model.CareerAssists %></td><td><%= Model.CareerAssistsPerGame %></td><td><%= Model.CareerGoals %></td><td><%= Model.CareerGoalsPerGame %></td><td><%= Model.CareerPoints %></td><td><%= Model.CareerPointsPerGame %></td></tr>
</tbody></table>