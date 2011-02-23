<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.Game.GameScheduleModel>>" %>
<% if (false) { %><link rel="stylesheet" type="text/css" href="../../content/css/main.css" /><% } %>
<% if (false) { %><style type="text/css">.hidden { display:none; }</style><% } %>
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
</tr>
</thead>
<tbody>
<% foreach (var game in Model) { %>
<tr class="game_<%= game.Game.ID %> <%= game.Game.HomeOrAway %> <%= game.Game.Type %> <%= game.Game.FallOrSpring %>" style="<%= (game.Game.SeasonID > game.Game.Date.Year) ? "display:none;" : "" %>">
<td class="nowrap"><%= game.Game.DateDay %></td>
<td class="nowrap"><%= game.Game.DateSchedule%></td>
<td class="nowrap"><%= game.Game.TimeSchedule%></td>
<td class="nowrap">
<% if (game.Game.Type.Equals("scrimage") || game.Game.Type.Equals("divisional") || game.Game.Type.Equals("playoff")) { %>
<img class="gametype" src="../../content/images/game_<%= Html.Encode(game.Game.Type) %>.png" alt="<%= Html.Encode(game.Game.Type) %> game" title="<%= Html.Encode(game.Game.Type) %> game" width="19" height="19" />
<% } %>
<img style="vertical-align:middle;" src="../../content/images/teams/<%= Html.Encode(game.Game.Opponent.Slug) %>_24.png" alt="<%= Html.Encode(game.Game.Opponent.Abr) %>" title="<%= Html.Encode(game.Game.Opponent.Abr) %>" width="24" height="24" />
<% if(!game.Game.isHome) { %>@ <% } if(!string.IsNullOrEmpty(game.Game.Opponent.TeamURL)) { %><a href="<%= Html.Encode(game.Game.Opponent.TeamURL)%>" title="<%= Html.Encode(game.Game.Opponent.Abr)%>'s Homepage"><%= Html.Encode(game.Game.Opponent.Abr)%></a><% } %>
<% else { %><%= game.Game.Opponent.Abr %><% } %>
</td>
<td style="width:32%;"><% if(!game.Game.isHome) { %><%= game.Game.Venue %><% } else { %><%= Html.ActionLink(game.Game.Venue, "owls-nest", "about", null, new { title = "The Owl's Nest" })%><%}%></td>
<td class="nowrap"><% if (!game.Game.StatusNormal) { %><%= Html.Encode(game.Game.Status)%><% } else { %>
<% if (game.Game.hasDetail || game.hasPhotographers || game.Game.isMCLAGame) { %><a name="<%= game.Game.ID %>"></a><span id="game_<%= game.Game.ID %>" title="Game Recap"><%= game.Game.GameResultWL%></span><% }
else { %><%= game.Game.GameResultWL%><% }} %></td>
</tr>
<% if (game.Game.hasDetail || game.hasPhotographers || game.Game.isMCLAGame) { %>
<tr id="info_<%= game.Game.ID %>" class="hidden">
<td colspan="6">
<% if (game.Game.hasDetail) { %><h3>Game Review</h3><p><%= game.Game.Detail %></p><% } %>
<% if (game.hasPhotographers) { Html.RenderPartial("GamePhotoGalleries", game.PhotographerList); } %>
<% if (game.Game.isMCLAGame) { if (game.Game.hasDetail) { %><br /><% } %><h3>MCLA</h3><% } %>
<% if (game.Game.isWin) { %>
<ul class="sharing" style="margin-bottom:-10px;">
<li><a href="http://twitter.com/share" class="twitter-share-button" data-url="http://ksulax.com/games/<%= game.Game.ID %>" data-counturl="http://ksulax.com<%= Html.Encode(Request.Path) %>" data-count="horizontal" data-via="kstatelax"></a></li>
<li><fb:like href="http://ksulax.com/games/<%= game.Game.ID %>" show_faces="false" layout="button_count"/></li>
</ul>
<% } %>
<% if (game.Game.isMCLAGame) { %><p><a href="http://mcla.us/scores/games/<%= game.Game.ID %>" title="MCLA Game Recap">GAME RECAP</a></p><% } %>
</td></tr><% } } %></tbody></table>