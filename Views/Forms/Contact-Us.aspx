<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.ContactUsFormModel>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">Contact Us</asp:Content>
<asp:Content ContentPlaceHolderID="Header" runat="server">
<script src="../../content/scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="../../content/scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>
<script type="text/javascript">
    Sys.Mvc.ValidatorRegistry.validators["email"] = function (rule) {
        // initialization code can go here.
        var filter = /^([\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+\.)*[\w\!\#$\%\&\'\*\+\-\/\=\?\^\`{\|\}\~]+@((((([a-zA-Z0-9]{1}[a-zA-Z0-9\-]{0,62}[a-zA-Z0-9]{1})|[a-zA-Z])\.)+[a-zA-Z]{2,6})|(\d{1,3}\.){3}\d{1,3}(\:\d{1,5})?)$/;

        // we return the function that actually does the validation 
        return function (value, context) {
            if (filter.test(value)) {
                return true;
            }
            return rule.ErrorMessage;
        };
    };
</script>


</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol">
<% Html.RenderPartial("SponsorsTemplate"); %>
</div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("Forms", "Index", null, null, new { title = "Forms" })%> > <%= Html.ActionLink("Contact Us", "contact-us", null, new { title = "Contact Us" })%></div>
<h1>Contact Us</h1>
<p>Kennesaw State University Lacrosse extends the opportunity for upcoming freshmen or transfer students enrolling at KSU to join the team. All players must be students of Kennesaw State University (no exceptions). If you are interested in participating in this program, please fill out the form below to receive more information. If you are not a student of the university, but would like to attend, please go to <a href="http://www.kennesaw.edu/admissions/ugadm.shtml" title="KSU Admissions">admissions</a> to apply.</p>
<br/>
<h3>Call Us</h3>
<ul>
<li>Casey Newton (678-333-3766)</li>
<li>Bradley Jones (770-856-2557)</li>
</ul>
<h3>Email Us</h3>
<% Html.EnableClientValidation(); %>
<% using (Html.BeginForm("contact-us", "forms", FormMethod.Post, new { id = "email_form" })) {%>
<%= Html.ValidationSummary(true) %>
<table style="width:100%;" cellpadding="3">
<tr>
<td style="width:16%;" valign="middle" class="statId"><div style="text-align:right;"><%= Html.LabelFor(model => model.Subject) %></div></td>
<td style="width:84%;" valign="top">
<%= Html.TextBoxFor(model => model.Subject) %>
<%= Html.ValidationMessageFor(model => model.Subject) %>
</td>
</tr>
<tr>
<td valign="middle" class="statId">
<div style="text-align:right;"><%= Html.LabelFor(model => model.Name) %></div>   
</td>
<td valign="top">
<%= Html.TextBoxFor(model => model.Name) %>
<%= Html.ValidationMessageFor(model => model.Name) %>
</td>
</tr>
<tr>
<td valign="middle" class="statId"><div style="text-align:right;"><label for="CompanyName">Company or School</label></div></td>
<td valign="top">
<%= Html.TextBoxFor(model => model.CompanyName) %>
<%= Html.ValidationMessageFor(model => model.CompanyName) %>
</td>
</tr>
<tr>
<td valign="middle" class="statId"><div style="text-align:right;"><%= Html.LabelFor(model => model.Email) %></div></td>
<td valign="top">
<%= Html.TextBoxFor(model => model.Email) %>
<%= Html.ValidationMessageFor(model => model.Email) %>
</td>
</tr>
<tr>
<td valign="middle" class="statId"><div style="text-align:right;"><%= Html.LabelFor(model => model.Phone) %></div></td>
<td valign="top">
<%= Html.TextBoxFor(model => model.Phone) %>
<%= Html.ValidationMessageFor(model => model.Phone) %>
</td>
</tr>
<tr>
<td valign="top" class="statId"><div style="text-align:right;"><%= Html.LabelFor(model => model.Comments) %></div></td>
<td valign="top">
<%= Html.TextAreaFor(model => model.Comments, new { @rows = "10", @cols = "40" })%>
<%= Html.ValidationMessageFor(model => model.Comments) %></td>
</tr>
<tr>
<td valign="top">&nbsp;</td>
<td valign="top"><input id="submit" type="image" value="Send" src="../../content/images/submit_image.png" /></td>
</tr>
</table>
<% } %>
</div>
</asp:Content>