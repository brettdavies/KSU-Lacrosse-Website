<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.PlayerRegistrationModel>" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Player Registration</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("Player Registration", "player-registration", "home", null, new { title = "Player Registration" })%></div>
<h1>Player Registration</h1>
<p></p>
<%= Html.ValidationSummary("Please correct the following errors and try again.") %>
<% using (Html.BeginForm("Contact", "About", FormMethod.Post, new { id = "email_form" })) {%>
<table style="width:100%;" cellpadding="3">
<tr>
<td style="width:16%;" valign="middle" class="statId"><div style="text-align:right;">Subject:</div></td>
<td style="width:84%;" valign="top">
<%= Html.TextBox("Subject")%>
<%= Html.ValidationMessage("Subject", "*")%>
</td>
</tr>
<tr>
<td valign="middle" class="statId">
<div style="text-align:right;">Name:</div>   
</td>
<td valign="top">
<%= Html.TextBox("Name")%>
<%= Html.ValidationMessage("Name", "*")%>
</td>
</tr>
<tr>
<td valign="middle" class="statId"><div style="text-align:right;">Company or School:</div></td>
<td valign="top">
<%= Html.TextBox("CompanyName")%>
</td>
</tr>
<tr>
<td valign="middle" class="statId"><div style="text-align:right;">Email:</div></td>
<td valign="top">
<%= Html.TextBox("Email")%>
<%= Html.ValidationMessage("Email", "*")%>
</td>
</tr>
<tr>
<td valign="middle" class="statId"><div style="text-align:right;">Phone:</div></td>
<td valign="top">
<%= Html.TextBox("Phone")%>
<%= Html.ValidationMessage("Phone", "*")%>
</td>
</tr>
<tr>
<td valign="top" class="statId"><div style="text-align:right;">Comments:</div></td>
<td valign="top">
<%= Html.TextArea("comments", new { @rows = "10", @cols = "40" })%>
<%= Html.ValidationMessage("Comments", "*")%>
</td>
</tr>
<tr>
<td valign="top">&nbsp;</td>
<td valign="top"><input id="submit" type="image" value="Send" src="../../content/images/submit_image.png" /></td>
</tr>
</table>
<% } %>
</asp:Content>