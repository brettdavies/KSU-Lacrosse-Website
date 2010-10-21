function twitterDates(date_str) {
    var date = new Date(date_str);
    date_str = dateFormat(date, 'isoUtcDateTime');

    var time_formats = [
		[60, 'Just Now'],
		[90, '1 Minute'],
		[3600, 'Minutes', 60],
		[5400, '1 Hour'],
		[86400, 'Hours', 3600],
		[129600, '1 Day'],
		[604800, 'Days', 86400],
		[907200, '1 Week'],
		[2628000, 'Weeks', 604800]
	];

    var time = ('' + date_str).replace(/-/g, "/").replace(/[TZ]/g, " "),
		dt = new Date,
		seconds = ((dt - new Date(time) + (dt.getTimezoneOffset() * 60000)) / 1000),
		token = ' Ago',
		i = 0,
		format;

    if (seconds < 0) {
        seconds = Math.abs(seconds);
        token = '';
    }

    while (format = time_formats[i++]) {
        if (seconds < format[0]) {
            if (format.length == 2) {
                return format[1] + (i > 1 ? token : '');
            } else {
                return Math.round(seconds / format[2]) + ' ' + format[1] + (i > 1 ? token : '');
            }
        }
    }

    var localdate = date.toLocaleDateString();
    return localdate.substring(localdate.indexOf(',') + 2, localdate.length);
};

String.prototype.parseURL = function() {
    return this.replace(/[A-Za-z]+:\/\/[A-Za-z0-9-_]+\.[A-Za-z0-9-_:%&\?\/.=]+/g, function(url) {
        return url.link(url);
    });
};

String.prototype.parseUsername = function() {
    return this.replace(/[@]+[A-Za-z0-9-_]+/g, function(u) {
        var un = u.replace("@", "")
        return u.link("http://twitter.com/" + un);
    });
};

String.prototype.parseHashtag = function() {
    return this.replace(/[#]+[A-Za-z0-9-_]+/g, function(t) {
        var ht = t.replace("#", "%23")
        return t.link("http://search.twitter.com/search?q=" + ht);
    });
};

function getTweets() {
    var url = 'http://api.twitter.com/1/statuses/user_timeline.json?screen_name=kstatelax&skip_user=true&include_rts=true&count=2&callback=?';
    var textToInsert = [];
    $.getJSON(url, function(tweets) {
        $.each(tweets, function(i, tweet) {
            textToInsert.push('<div class="homeNewsItem">');
            textToInsert.push('<div class="date"><a href="http://twitter.com/KStateLax/status/' + tweet.id + '">' + twitterDates((tweet.created_at).replace("+0000 ", "") + " GMT") + '</a></div>');
            textToInsert.push('<p>' + tweet.text.parseURL().parseUsername().parseHashtag() + '</p></div>');
        });
        $('#twitterBox').html(textToInsert.join(''));
        var links = $('#twitterBox a[href]');
        for (var i = 0; i < links.length; i++) {
            trackLinks(links[i]);
        };
    });
};
