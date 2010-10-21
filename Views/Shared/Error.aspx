<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<System.Web.Mvc.HandleErrorInfo>" %>
<asp:Content ContentPlaceHolderID="titleContent" runat="server">Error</asp:Content>
<asp:Content ID="errorContent" ContentPlaceHolderID="MainContent" runat="server">
<h1>oops!</h1>
<h2>it looks like something went wrong&#8230; <%if (Model.Exception.Message.Contains("KSULAX||")) {%> <%= Model.Exception.Message.Replace("KSULAX||","") %><% } %></h2>
</asp:Content>