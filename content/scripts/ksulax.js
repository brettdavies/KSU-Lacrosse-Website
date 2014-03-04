function getRankings() {
    var url = '/national-ranking/getranking';
    var begin = '<table style="width:100%;"><tbody><tr>';
    var begin1 = '<td style="text-align:center;"><a href="http://mcla.us/polls/" title="MCLA Coaches Poll"><img src="../../content/images/polls/MCLACoaches.png" height="48" width="114" alt="MCLA Coaches Poll" title="MCLA Coaches Poll" style="border:0px;" /></a></td>';
    var begin3 = '<td style="text-align:center;"><a href="http://www.laxpower.com/update14/binmen/rating06.php" title="LaxPower Poll"><img src="../../content/images/polls/Laxpower.png" height="48" width="47" alt="LaxPower Poll" title="LaxPower Poll" style="border:0px;" /></a></td>';
    var beginend = '</tr><tr style="text-align:center;">'
    var pole1 = '<td><a href="#">-</a></td>';
    var pole3 = pole1;
    var end = '</tr></tbody></table><p class="date">Last Updated enddate</p>';
    var enddate = new Date(0, 0, 0, 0, 0, 0);
    var enddatestr = '';

    $.getJSON(url, function (rankings) {
        $.each(rankings, function (i, ranks) {
            if (ranks != null && ranks.pollSource > 0) {
                var date = new Date(ranks.Datestr);
                if (date > enddate) {
                    enddatestr = ranks.Datestr;
                    enddate = new Date(ranks.Datestr);
                }

                switch (ranks.pollSource) {
                    case 3:
                        {
                            pole3 = '<td><a href="rankUrl" title="rankUrltitle">rank</a></td>';
                            pole3 = pole3.replace('rankUrltitle', 'Poll from ' + ranks.Datestr);
                            pole3 = pole3.replace('date', ranks.Datestr);
                            pole3 = pole3.replace('rankUrl', ranks.Url);
                            pole3 = pole3.replace('rank', ranks.Rank);
                            break;
                        }
                    case 4:
                        {
                            pole1 = '<td><a href="rankUrl" title="rankUrltitle">rank</a></td>';
                            pole1 = pole1.replace('rankUrltitle', 'Poll from ' + ranks.Datestr);
                            pole1 = pole1.replace('date', ranks.Datestr);
                            pole1 = pole1.replace('rankUrl', ranks.Url);
                            pole1 = pole1.replace('rank', ranks.Rank);
                            break;
                        }
                    default: { }
                };
            }
        });

        $(begin + begin1 + begin3 + beginend + pole1 + pole3 + end.replace('enddate', enddatestr)).insertBefore('#rankingBox noscript');
        var links = $('#rankingBox a[href]');
        for (var i = 0; i < links.length; i++) {
            trackLinks(links[i]);
        };
    });
};
