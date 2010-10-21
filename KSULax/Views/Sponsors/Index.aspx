<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<KSULax.Models.HomepageData>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">Sponsors</asp:Content>
<asp:Content ContentPlaceHolderID="MainContent" runat="server">
<div id="leftCol"><% Html.RenderPartial("GameSidebarTemplate", Model.games); %></div>
<div id="mainCol">
<div class="breadcrumbs"><%= Html.ActionLink("Home", "", "", null, new { title = "Home" })%> > <%= Html.ActionLink("Sponsors", "Index", "sponsors", null, new { title = "Sponsors" })%></div>
<h1>Sponsors</h1>
<p>The KSU Club Lacrosse team would like to thank our sponsors for the <%= DateTime.Now.Year %> season.</p>
<ul style="list-style-image:none;list-style-type:none;display:inline;">
<li style="float:left;text-align:center;margin-bottom:2em;margin-right:2em;"><asp:HyperLink NavigateUrl="http://www.laxworld.com/atlanta" title="LaxWorld Atlanta" runat="server"><asp:Image Width="192" Height="74" ImageUrl="~/content/images/sponsors/laxworld.jpg" AlternateText="LaxWorld Atlanta" title="LaxWorld Atlanta" runat="server" /></asp:HyperLink><br />LAXWorld Atlanta</li>
<li style="float:left;text-align:center;margin-bottom:2em;margin-right:2em;"><asp:HyperLink NavigateUrl="~/content/pdf/Hi-Five-Digital-Productions.pdf" title="Hi Five Digital Productions" runat="server"><asp:Image Width="192" Height="74" ImageUrl="~/content/images/sponsors/hi-five-digital-productions.gif" AlternateText="Hi Five Digital Productions" title="Hi Five Digital Productions" runat="server" /></asp:HyperLink><br />Hi Five Digital Productions</li>
</ul>
</div>
</asp:Content>