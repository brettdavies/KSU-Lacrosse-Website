<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<KSULax.Models.Player.PlayerModel>" %>
<h1><%= Model.FullName %><% if (Model.isCurPlayer) { %> &#35;<%= Model.JerseyNum %><% } %></h1>
<img class="imgBioBorder" src="<%= Url.Content(Model.ImagePath) %>" alt="<%= Model.FullName %>" title="<%= Model.FullName %>" align="left" />
<table>
<tbody><tr><td>
<table><tbody>
<tr><td><strong>Name</strong></td><td><%= Model.FullName %></td></tr>
<tr><td><strong>Highschool</strong></td><td><%= Model.HighSchool %></td></tr>
<tr><td><strong>Hometown</strong></td><td><%= Model.Home %></td></tr>
<% if (Model.isCurPlayer) { %><tr><td><strong>Class Year</strong></td><td><%= Model.ClassYr%></td></tr><% } %>
<% if (Model.isCurPlayer) { %><tr><td><strong>Eligibility</strong></td><td><%= Model.EligibilityYr %></td></tr><% } %>
</tbody></table>
</td>
<td>
<table><tbody>
<tr><td><strong>Height</strong></td><td><%= Model.HeightFeet %></td></tr>
<tr><td><strong>Weight</strong></td><td><%= Model.Weight %> lbs.</td></tr>
<tr><td><strong>Major</strong></td><td><%= Model.Major %></td></tr>
<% if (Model.isCurPlayer) { %><tr><td><strong>Position</strong></td><td><%= Model.Position %></td></tr><% } %>
<% if (Model.isCurPlayer) { %><tr><td>&nbsp;</td><td>&nbsp;</td></tr><% } %>
</tbody></table>
</td></tr>
</tbody></table>
<table class="mainTable" style="clear:both;">
<thead><tr><th scope="col">Player Bio</th></tr></thead>
<tbody><tr><td><%= Model.Bio %></td></tr></tbody></table>