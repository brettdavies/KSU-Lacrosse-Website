<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %><%@ Import Namespace="KSULax.Helpers" %>
<div class="boxItem sponsors">
<div class="boxTitle"><%= Html.ActionLink("Sponsors", "Index", "sponsors", null, new { title = "Sponsors" })%></div>
<div class="boxContent">
</div>
<div class="boxBottom"><asp:Image ImageUrl="~/content/images/gray-arrow.png" AlternateText="Arrow" runat="server" /> <%= Html.ActionLink("View Our Sponsors", "Index", "sponsors", null, new { title = "Sponsors" })%></div>
</div>