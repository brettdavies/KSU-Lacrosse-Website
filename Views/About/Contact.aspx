<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.ContactUsFormModel>" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Contact Us</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Contact Us", "contact", "about", null, new { title = "Contact Us" })%></div>
<h1>Contact Us</h1>
<p>Kennesaw State University Lacrosse extends the opportunity for upcoming freshmen or transfer students enrolling at KSU to join the team. All players must be students of Kennesaw State University (no exceptions). If you are interested in participating in this program, please fill out the form below to receive more information. If you are not a student of the university, but would like to attend, please go to <a href="http://www.kennesaw.edu/admissions/ugadm.shtml" title="KSU Admissions">admissions</a> to apply.</p>
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