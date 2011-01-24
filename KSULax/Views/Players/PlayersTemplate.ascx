<%@ Control Language="C#" CodeBehind="~/Views/Players/PlayersTemplate.ascx.cs" AutoEventWireup="True" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.PlayerSeason>>" %>
<% if (false) { %><link rel="stylesheet" type="text/css" href="../../content/css/main.css" /><% } %>
<% KSULax.PlayersTemplate pt = new KSULax.PlayersTemplate();%>
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
<td class="nowrap"><%= Html.Encode(player.jersey.ToString())%></td>
<td class="nowrap"><%= Html.Encode(player.Player.first + " " + player.Player.last)%></td>
<%--<td><% string name = player.Player.first + " " + player.Player.last;%><%= Html.ActionLink(name, name.Replace(' ', '-').ToLower(), null, new { title = name })%></td>--%>
<td class="nowrap"><%= Html.Encode(player.@class)%></td>
<td class="nowrap"><%= Html.Encode(player.eligibility)%></td>
<td class="nowrap"><%= Html.Encode(player.position)%></td>
<td class="nowrap"><%= pt.formatHeight((int)player.height) %></td>
<td class="nowrap"><%= Html.Encode(player.weight)%></td>
<td class="nowrap"><%= Html.Encode(player.Player.highschool)+pt.state(player.Player.homestate)%></td>
</tr>
<% } %>
</tbody>
</table>