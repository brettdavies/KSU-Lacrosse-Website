<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Contact Us</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title="Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Contact Us", "contact-us", "about", null, new { title = "Contact Us" })%></div>
<h1>Contact Us</h1>
<p>Please use the form below to contact the team.  If you are a student looking to play for the Owls, please use our <%= Html.ActionLink("Recruitment", "recruitment", "about", null, new { title = "Recruitment" })%> form instead.</p>
<br/>
<h3>Call Us</h3>
<table>
<tr>
<td>
President: Brad Jones<br />
770-856-2557<br />
ksulacrosse@gmail.com<br /><br />
</td>
<td></td>
<td>
Coach: Tyler Yelken<br />
404-542-0094<br />
tyelken@ksulax.com<br /><br />
</td>
</tr>
</table>
<h3>Email Us</h3>
<iframe src="https://docs.google.com/forms/d/1K6Yw2CWVdhb8CtpoDg6TK_PUJkQ7xCaa67Vo9DdLxH0/viewform?embedded=true" width="690" height="625" frameborder="0" marginheight="0" marginwidth="0">Loading...</iframe>
<br />
</asp:Content>