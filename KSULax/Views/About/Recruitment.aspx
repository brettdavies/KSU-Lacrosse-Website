<%@ Page Language="C#" MasterPageFile="~/Views/Shared/About.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="titleContentAbout" runat="server">Recruitment</asp:Content>
<asp:Content ContentPlaceHolderID="AboutContent" runat="server">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title="Home" })%> > <%= Html.ActionLink("About", "Index", "about", null, new { title = "About" })%> > <%= Html.ActionLink("Recruitment", "recruitment", "about", null, new { title = "Recruitment" })%></div>
<h1>Recruitment</h1>
<p>Kennesaw State University Lacrosse extends the opportunity for incoming freshmen or transfer students enrolling at KSU to join the team. All players must be students of Kennesaw State University (no exceptions). If you are interested in participating in this program, please fill out the form below to receive more information. If you are not a student of the university, but would like to attend, please go to <a href="http://admissions.kennesaw.edu/" title="KSU Admissions">admissions</a> to apply.</p>
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
Coach: Tyler Yelkin<br />
404-542-0094<br />
tyelken@ksulax.com<br /><br />
</td>
</tr>
</table>
<h3>Email Us</h3>
<iframe src="https://docs.google.com/forms/d/1kmIm1f7oE9oXATNNRPv5H_pIXolwdRTYvN-NM-crDVw/viewform?embedded=true" width="690" height="500" frameborder="0" marginheight="0" marginwidth="0">Loading...</iframe>
<br />
</asp:Content>