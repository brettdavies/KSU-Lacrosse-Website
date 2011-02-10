<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.Player.PlayerModel>>" %>
<% if (false) { %><link rel="stylesheet" type="text/css" href="../../content/css/main.css" /><% } %>
<table style="width:100%;" class="mainTable">
<thead>
<tr>
<th scope="col">#</th>
<th scope="col">Name</th>
<th scope="col">Class</th>
<th scope="col">Eligibility</th>
<th scope="col">Position</th>
<th scope="col">Height</th>
<th scope="col">Weight</th>
<th scope="col">High School</th>
</tr>
</thead>
<tbody>
<% foreach (var player in Model) { %>
<tr>
<td class="nowrap"><%= player.JerseyNum %></td>
<td class="nowrap"><%= player.FullName %></td>
<%--<td><%= Html.ActionLink(player.FullName, player.FullNameURL, null, new { title = player.FullName })%></td>--%>
<td class="nowrap"><%= player.ClassYr %></td>
<td class="nowrap"><%= player.EligibilityYr %></td>
<td class="nowrap"><%= player.Position%></td>
<td class="nowrap"><%= player.HeightFeet %></td>
<td class="nowrap"><%= player.Weight %></td>
<td class="nowrap"><%= player.HighSchool %></td>
</tr>
<% } %>
</tbody>
</table>