<%@ Control Language="C#" CodeBehind="~/Views/Players/PlayersTemplate.ascx.cs" AutoEventWireup="True" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<KSULax.Models.PlayerSeason>>" %>
<% if (false) { %><link rel="stylesheet" type="text/css" href="../../content/css/main.css" /><% } %>
<% KSULax.PlayersTemplate pt = new KSULax.PlayersTemplate();%>
<%--
<style type="text/css">.biobox {width:400px; height:250px; position: absolute; background: #fff;}</style>
<script type="text/javascript">
    var hover_config = {
        sensitivity: 7,
        interval: 150,
        over: showPlayerHover,
        timeout: 0,
        out: hidePlayerHover
    };

    $(document).ready(function() {
        $("tr[id^='player']").each(function() {
            $(this).hoverIntent(hover_config);
        });
    });

    function showPlayerHover() {
        var id = $(this).attr('id');
        var number = id.substring(id.indexOf('_') + 1);

        if ($('#bio_' + number).length) {
        }
        else {
            var url = '/players/getbio/' + number;
            var textToInsert = [];
            $.getJSON(url, function(bio) {

            textToInsert.push('<h2>' + bio.name + '</h2>');
            textToInsert.push('<h3>Stats</h3>');
            textToInsert.push('<ul>');
            textToInsert.push('<li>' + bio.highschool + '</li>');
            textToInsert.push('<li>' + bio.hometown + ', ' + bio.homestate + '</li>');
            textToInsert.push('</ul>');
            $('body').append('<div id="bio_' + number + '" class="biobox">' + textToInsert.join('') + '</div>');
            });
        }

        $(function(show) {
            $('#bio_' + number)
            .css('top', (show.pageY - 300) + 'px')
            .css('left', (show.pageX) + 'px')
            .fadeIn('fast');
        });

        $(this).mousemove(function(event) {
            $('#bio_' + number)
                .css('top', (event.pageY - 300) + 'px')
                .css('left', (event.pageX) + 'px');
        });
    }

    function hidePlayerHover() {
        var id = $(this).attr('id');
        var number = id.substring(id.indexOf('_') + 1);
        $('#bio_' + number).hide();
    }
</script>
--%>
<table style="width:100%;" class="mainTable">
<thead>
<tr>
<th scope="col">#</th>
<th scope="col">Name</th>
<th scope="col">Class</th>
<th scope="col">Eligibility</th>
<th scope="col">Position</th>
<th scope="col">Height</th>
<th scope="col">Weight</th>
<th scope="col">High School</th>
</tr>
</thead>
<tbody>
<% foreach (var player in Model) { %>
<tr>
<td class="nowrap"><%= Html.Encode(player.jersey.ToString())%></td>
<td class="nowrap"><%= Html.Encode(player.Player.first + " " + player.Player.last)%></td>
<%--<td><% string name = player.Player.first + " " + player.Player.last;%><%= Html.ActionLink(name, name.Replace(' ', '-').ToLower(), null, new { title = name })%></td>--%>
<td class="nowrap"><%= Html.Encode(player.@class)%></td>
<td class="nowrap"><%= Html.Encode(player.eligibility)%></td>
<td class="nowrap"><%= Html.Encode(player.position)%></td>
<td class="nowrap"><%= pt.formatHeight((int)player.height) %></td>
<td class="nowrap"><%= Html.Encode(player.weight)%></td>
<td class="nowrap"><%= Html.Encode(player.Player.highschool)+pt.state(player.Player.homestate)%></td>
</tr>
<% } %>
</tbody>
</table>