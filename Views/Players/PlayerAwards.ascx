<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KSULax.Models.Player.PlayerAwardModelList>" %>
<% if (Model.PlayerHasAwards) { %>
<table class="mainTable">
<thead><tr><th colspan="2">Awards</th></tr></thead>
<tbody>
<% foreach (var award in Model.playerAwards) { %>
<tr><td><%= award.Date.Year + " " + award.Name %> <% if (award.isWeeklyAward) { %>(Week of <%= award.formatDate %>)<% } %></td></tr>
<%}%>
</tbody></table>
<% } %>