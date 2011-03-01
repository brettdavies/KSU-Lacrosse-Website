<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KSULax.Models.Game.GameListModel>" %>
<% if (false) { %><link rel="stylesheet" type="text/css" href="../../content/css/main.css" /><% } %>
<script type="text/javascript">$(document).ready(gameSelector); </script>
<div>
<div class="boxTitle"><%= Html.ActionLink(Model.Season + " Game Schedule", "Index", "Games", new { id = Model.Season }, new { title = Model.Season + " Game Schedule" })%></div>
<div class="boxContent" id="gamesBox">
<table style="width:100%;" id="gamesBoxTable">
<% foreach (var game in Model.Games) { %>
<tr class="<%= game.HomeOrAway %> <%= game.Type %> <%= game.FallOrSpring %>" style="<%= (game.SeasonID > game.Datetime.Year) ? "display:none;" : "" %>">
<td style="width:28%;"><div style="text-align:center;"><img style="vertical-align:middle;" src="../../content/images/teams/
<%= Html.Encode(game.Opponent.Slug)%>_32.png" alt="<%= Html.Encode(game.Opponent.Abr) %>" title="<%= Html.Encode(game.Opponent.Abr) %>" width="32" height="32" /></div></td>
<td style="width:23%;"><%= Html.Encode(game.Opponent.Abr)%></td>
<td style="width:17%;" class="nowrap"><%= game.DateShort %></td>
<td style="width:32%;" class="nowrap"><% if (!game.StatusNormal) { %><%= game.Status %><% } %>
<% else { var result = game.GameResultWL; if(!result.Equals("-")) { %>
<a href="<%= Html.Encode(Url.Action("Index", "games", new { id = game.SeasonID }) + "#" + game.ID) %>" title="<%= result %>"><%= result %></a>
<% } else if (DateTime.Compare(game.Datetime, DateTime.Now) == 1) { %><%= game.TimeSchedule %><% } else { %><%= result %><% }} %></td>
</tr>
<% } %>
</table>
</div>
<div class="boxBottom"><img src="../../content/images/gray-arrow.png" alt="" /> <%= Html.ActionLink("See More Games", "Index", "Games", new { id = Model.Season }, new { title = Model.Season + " Game Schedule" })%></div>
</div>