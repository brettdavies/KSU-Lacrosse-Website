<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %><%@ Import Namespace="KSULax.Helpers" %>
<div class="boxItem sponsors">
<div class="boxTitle"><%= Html.ActionLink("Sponsors", "Index", "sponsors", null, new { title = "Sponsors" })%></div>
<div class="boxContent">
<asp:HyperLink CssClass="sponsorImg" Width="192" Height="74" NavigateUrl="http://www.laxworld.com/atlanta" title="LaxWorld Atlanta" runat="server"><%= Html.Image("", "~/content/images/sponsors/laxworld.jpg", "LaxWorld Atlanta", new { height = 74, width = 192, title = "LaxWorld Atlanta", style = "border:none;" })%></asp:HyperLink>
<asp:HyperLink CssClass="sponsorImglast" Width="192" Height="74" NavigateUrl="http://ksulax.com/content/pdf/Hi-Five-Digital-Productions.pdf" title="Hi Five Digital Productions" runat="server"><%= Html.Image("", "~/content/images/sponsors/hi-five-digital-productions.gif", "Hi Five Digital Productions", new { height = 74, width = 192, title = "Hi Five Digital Productions", style = "border:none;" })%></asp:HyperLink>
</div>
<div class="boxBottom"><asp:Image ImageUrl="~/content/images/gray-arrow.png" AlternateText="Arrow" runat="server" /> <%= Html.ActionLink("View Our Sponsors", "Index", "sponsors", null, new { title = "Sponsors" })%></div>
</div>