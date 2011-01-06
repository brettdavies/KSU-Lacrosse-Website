<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">Winter Skills Clinic Information and Registration</asp:Content>
<asp:Content ContentPlaceHolderID="Header" runat="server">
</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol">
<% Html.RenderPartial("SponsorsTemplate"); %>
</div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title="Home" })%> > <%= Html.ActionLink("Forms", "Index", null, new { title="Forms" })%> > <%= Html.ActionLink("Winter Skills Clinic Information and Registration", "winter-skills-clinic", null, new { title = "Winter Skills Clinic Information and Registration" })%></div>
<h1>Winter Skills Clinic Information and Registration</h1>
<p>The Kennesaw State Men's lacrosse club is excited to give back to the community and offer a winter skills tune-up clinic. All the information about the clinic can be found in the <asp:HyperLink NavigateUrl="~/content/pdf/KSU-Mens-Lacrosse-Winter-Skills-Clinic.pdf" Text="clinic's brochure" ToolTip="Winter Skills Clinic Brochure" runat="server" />.</p><br />
<h3>Registration</h3>
<p>Registration for the clinic is easy! First click on the paypal button below and fill out all the required information, then print out the Waiver and Release form and make sure your player brings it with him to the clinic.</p>
<ol>
<li>Paypal</li>
<li><asp:HyperLink NavigateUrl="~/content/pdf/Waiver-and-Release-Form.pdf" Text="Owls Nest Waiver and Release Form" ToolTip="Owls Nest Waiver and Release Form" runat="server" /></li>
</ol></div>
</asp:Content>