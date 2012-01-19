function getRankings() {
    var url = '/national-ranking/getranking';
    var begin = '<table style="width:100%;"><tbody><tr>';
    var begin1 = '<td style="text-align:center;"><a href="http://mclamag.com/top23/" title="MCLA Magazine Poll"><img src="../../content/images/polls/MCLAmag.png" height="48" width="55" alt="MCLA Magazine Poll" title="MCLA Magazine Poll" style="border:0px;" /></a></td>';
    var begin2 = '<td style="text-align:center;"><a href="http://www.collegelax.us/polls.php" title="CollegeLax Poll"><img src="../../content/images/polls/CollegeLax.png" height="48" width="44" alt="CollegeLax Poll" title="CollegeLax Poll" style="border:0px;" /></a></td>';
    var begin3 = '<td style="text-align:center;"><a href="http://www.laxpower.com/update12/binmen/rating06.php" title="LaxPower Poll"><img src="../../content/images/polls/Laxpower.png" height="48" width="47" alt="LaxPower Poll" title="LaxPower Poll" style="border:0px;" /></a></td>';
    var beginend = '</tr><tr style="text-align:center;">'
    var pole1 = '<td><a href="#">-</a></td>';
    var pole2 = pole1;
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
                    case 1:
                        {
                            pole1 = '<td><a href="1rankUrl" title="1rankUrltitle">1rank</a></td>';
                            pole1 = pole1.replace(ranks.pollSource + 'rankUrl', ranks.Url);
                            pole1 = pole1.replace(ranks.pollSource + 'rankUrltitle', 'Poll from ' + ranks.Datestr);
                            pole1 = pole1.replace(ranks.pollSource + 'date', ranks.Datestr);
                            pole1 = pole1.replace(ranks.pollSource + 'rank', ranks.Rank);
                            break;
                        }
                    case 2:
                        {
                            pole2 = '<td><a href="2rankUrl" title="2rankUrltitle">2rank</a></td>';
                            pole2 = pole2.replace(ranks.pollSource + 'rankUrl', ranks.Url);
                            pole2 = pole2.replace(ranks.pollSource + 'rankUrltitle', 'Poll from ' + ranks.Datestr);
                            pole2 = pole2.replace(ranks.pollSource + 'date', ranks.Datestr);
                            pole2 = pole2.replace(ranks.pollSource + 'rank', ranks.Rank);
                            break;
                        }
                    case 3:
                        {
                            pole3 = '<td><a href="3rankUrl" title="3rankUrltitle">3rank</a></td>';
                            pole3 = pole3.replace(ranks.pollSource + 'rankUrl', ranks.Url);
                            pole3 = pole3.replace(ranks.pollSource + 'rankUrltitle', 'Poll from ' + ranks.Datestr);
                            pole3 = pole3.replace(ranks.pollSource + 'date', ranks.Datestr);
                            pole3 = pole3.replace(ranks.pollSource + 'rank', ranks.Rank);
                            break;
                        }
                    default: { }
                };
            }
        });

        $(begin + begin1 + begin2 + begin3 + beginend + pole1 + pole2 + pole3 + end.replace('enddate', enddatestr)).insertBefore('#rankingBox noscript');
        var links = $('#rankingBox a[href]');
        for (var i = 0; i < links.length; i++) {
            trackLinks(links[i]);
        };
    });
};
