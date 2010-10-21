function trackLinks(element) {
    var filetypes = /\.(pdf)$/i;
    var href = $(element).attr('href');

    if ((href.match(/^https?\:/i)) && (!href.match(document.domain))) {
        $(element).click(function() {
            var extLink = href.replace(/^https?\:\/\//i, '');
            pageTracker._trackEvent('External', 'Click', extLink);
        });
    }
    else if (href.match(/^mailto\:/i)) {
        $(element).click(function() {
            var mailLink = href.replace(/^mailto\:/i, '');
            pageTracker._trackEvent('Email', 'Click', mailLink);
        });
    }
    else if (href.match(filetypes)) {
        $(element).click(function() {
            var extension = (/[.]/.exec(href)) ? /[^.]+$/.exec(href) : undefined;
            var filePath = href.replace(/^https?\:\/\/(www.)ksulax\.com\//i, '');
            pageTracker._trackEvent('Download', 'Click - ' + extension, filePath);
        });
    }
};

var pageTracker = null;
function ga() {
    var gaJsHost = (("https:" == document.location.protocol) ? "https://ssl." : "http://www.");
    $.getScript(gaJsHost + "google-analytics.com/ga.js", function() {
        try {
            pageTracker = _gat._getTracker("UA-5630978-4");
            pageTracker._trackPageview();
        } catch (err) { }

        var links = $('a[href]');
        for (var i=0; i < links.length; i++) {
            trackLinks(links[i]);
        };
    });
};
