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
<h2>Only 50 Spots Left!</h2>
<h3>Registration</h3>
<form action="https://www.paypal.com/cgi-bin/webscr" method="post">
<input type="hidden" name="cmd" value="_xclick">
<input type="hidden" name="business" value="Z753TVXHDWGHQ">
<input type="hidden" name="lc" value="US">
<input type="hidden" name="item_name" value="Winter Skills Clinic">
<input type="hidden" name="amount" value="75.00">
<input type="hidden" name="currency_code" value="USD">
<input type="hidden" name="button_subtype" value="services">
<input type="hidden" name="no_note" value="0">
<input type="hidden" name="cn" value="Add special instructions to the seller">
<input type="hidden" name="no_shipping" value="2">
<input type="hidden" name="rm" value="1">
<input type="hidden" name="return" value="http://ksulax.com/forms/winter-skills-clinic">
<input type="hidden" name="tax_rate" value="0.000">
<input type="hidden" name="shipping" value="0.00">
<input type="hidden" name="bn" value="PP-BuyNowBF:btn_paynow_LG.gif:NonHosted">
<table>
<tr><td><input type="hidden" name="on0" value="Name">Name</td></tr><tr><td><input type="text" name="os0" maxlength="60"></td></tr>
<tr><td><input type="hidden" name="on1" value="Email Address">Email Address</td></tr><tr><td><input type="text" name="os1" maxlength="60"></td></tr>
<tr><td><input type="hidden" name="on2" value="Age">Age</td></tr><tr><td><input type="text" name="os2" maxlength="60"></td></tr>
<tr><td><input type="hidden" name="on3" value="Height">Height</td></tr><tr><td><input type="text" name="os3" maxlength="60"></td></tr>
<tr><td><input type="hidden" name="on4" value="Weight">Weight</td></tr><tr><td><input type="text" name="os4" maxlength="60"></td></tr>
<tr><td><input type="hidden" name="on5" value="Position">Position</td></tr><tr><td><select name="os5">
	<option value="Attack">Attack</option>
	<option value="Midfield">Midfield</option>
	<option value="Defense">Defense</option>
	<option value="Goalie">Goalie</option>
</select></td></tr>
<tr><td><input type="hidden" name="on6" value="Years Experience">Years Experience</td></tr><tr><td><select name="os6">
	<option value="0">0</option>
	<option value="1">1</option>
	<option value="2">2</option>
	<option value="3">3</option>
	<option value="4">4</option>
	<option value="5+">5+</option>
</select></td></tr>
<tr><td><input type="hidden" name="on7" value="T-Shirt Size">T-Shirt Size</td></tr><tr><td><select name="os7">
	<option value="Small">Small</option>
	<option value="Medium">Medium</option>
	<option value="Large">Large</option>
	<option value="Extra Large">Extra Large</option>
</select></td></tr>
<tr><td><input type="hidden" name="on8" value="Emergency Contact Name and Phone Number">Emergency Contact Name and Phone Number</td></tr><tr><td><input type="text" name="os8" maxlength="60"></td></tr>
<tr><td><input type="hidden" name="on9" value="Medical Conditions or Allergies">Medical Conditions or Allergies</td></tr><tr><td><input type="text" name="os9" maxlength="60"></td></tr>
</table>
<input type="image" src="https://www.paypal.com/en_US/i/btn/btn_paynow_LG.gif" border="0" name="submit" alt="PayPal - The safer, easier way to pay online!">
<img alt="" border="0" src="https://www.paypal.com/en_US/i/scr/pixel.gif" width="1" height="1">
</form>
<p>Note: $15 of the $75 registration fee is non-refundable.</p>
<br />
<p>Please print out this waiver and have the player bring it signed and completed with him to the clinic. <asp:HyperLink NavigateUrl="~/content/pdf/Waiver-and-Release-Form.pdf" Text="Owls Nest Waiver and Release Form" ToolTip="Owls Nest Waiver and Release Form" runat="server" /></p>
</div>
</asp:Content>