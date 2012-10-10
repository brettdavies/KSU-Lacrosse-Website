<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl" %>
<script type="text/javascript">$(document).ready(getRankings);</script>
<div class="boxItem">
<div class="boxTitle"><%= Html.ActionLink("National Ranking", null, "national-ranking", new { id = DateTime.Now.Year.ToString() }, new { title = DateTime.Now.Year.ToString() + " National Ranking" })%></div>
<div id="rankingBox" class="boxContent">
<noscript>Javascript must be enabled to see National Rankings</noscript>
</div>
<div class="boxBottom"><img src="../../content/images/gray-arrow.png" alt="" /><a href="http://ksulax.com/national-ranking/<%= DateTime.Now.Year.ToString()%>" title="<%= DateTime.Now.Year.ToString()%> National Ranking"> See Detailed Ranking</a>
</div>
</div>