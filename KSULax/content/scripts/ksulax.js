function getRankings() {
    var url = '/data/getranking';
    var begin = '<table style="width:100%;"><tbody><tr><td style="text-align:center;"><a href="http://www.collegelax.us/polls.php" title="CollegeLax Poll"><img src="../../content/images/polls/CollegeLax.png" height="48" width="44" alt="CollegeLax Poll" title="CollegeLax Poll" style="border:0px;" /></a></td><td style="text-align:center;"><a href="http://mclamag.com/top23/" title="MCLA Magazine Poll"><img src="../../content/images/polls/MCLAmag.png" height="48" width="55" alt="MCLA Magazine Poll" title="MCLA Magazine Poll" style="border:0px;" /></a></td><td style="text-align:center;"><a href="http://www.laxpower.com/update10/binmen/rating06.php" title="LaxPower Poll"><img src="../../content/images/polls/Laxpower.png" height="48" width="47" alt="LaxPower Poll" title="LaxPower Poll" style="border:0px;" /></a></td></tr><tr style="text-align:center;">';
    var pole2 = '<td><a href="2rankUrl" title="2rankUrltitle">2rank</a></td>';
    var pole1 = '<td><a href="1rankUrl" title="1rankUrltitle">1rank</a></td>';
    var pole3 = '<td><a href="3rankUrl" title="3rankUrltitle">3rank</a></td>';
    var end = '</tr></tbody></table><p class="date">Last Updated enddate</p>';
    var enddate = new Date(0, 0, 0, 0, 0, 0);
    var enddatestr = '';

    $.getJSON(url, function(rankings) {
        $.each(rankings, function(i, ranks) {
            var date = new Date(ranks.datestr);
            if (date > enddate) {
                enddatestr = ranks.datestr;
                enddate = new Date(ranks.datestr);
            }

            switch (ranks.pollSource) {
                case 1:
                    {
                        pole1 = pole1.replace(ranks.pollSource + 'rankUrl', ranks.rankUrl);
                        pole1 = pole1.replace(ranks.pollSource + 'rankUrltitle', 'Poll from ' + ranks.datestr);
                        pole1 = pole1.replace(ranks.pollSource + 'date', ranks.datestr);
                        pole1 = pole1.replace(ranks.pollSource + 'rank', ranks.rank);
                    }
                case 2:
                    {
                        pole2 = pole2.replace(ranks.pollSource + 'rankUrl', ranks.rankUrl);
                        pole2 = pole2.replace(ranks.pollSource + 'rankUrltitle', 'Poll from ' + ranks.datestr);
                        pole2 = pole2.replace(ranks.pollSource + 'date', ranks.datestr);
                        pole2 = pole2.replace(ranks.pollSource + 'rank', ranks.rank);
                    }
                case 3:
                    {
                        pole3 = pole3.replace(ranks.pollSource + 'rankUrl', ranks.rankUrl);
                        pole3 = pole3.replace(ranks.pollSource + 'rankUrltitle', 'Poll from ' + ranks.datestr);
                        pole3 = pole3.replace(ranks.pollSource + 'date', ranks.datestr);
                        pole3 = pole3.replace(ranks.pollSource + 'rank', ranks.rank);
                    }
                default: { }
            }
        });
        $(begin + pole2 + pole1 + pole3 + end.replace('enddate', enddatestr)).insertBefore('#rankingBox noscript');
        var links = $('#rankingBox a[href]');
        for (var i = 0; i < links.length; i++) {
            trackLinks(links[i]);
        };
    });
};
