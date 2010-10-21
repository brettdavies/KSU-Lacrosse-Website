//jQuery.fn.contentChange = function(callback) {
//    var elms = jQuery(this);
//    elms.each(
//        function(i) {
//            var elm = jQuery(this);
//            elm.data("lastContents", elm.html());
//            window.watchContentChange = window.watchContentChange ? window.watchContentChange : [];
//            window.watchContentChange.push({ "element": elm, "callback": callback });
//        }
//    )
//    return elms;
//}

//function contentChangeInterval() {
//    if (window.watchContentChange) {
//        for (i in window.watchContentChange) {
//            if (window.watchContentChange[i].element.data("lastContents") != window.watchContentChange[i].element.html()) {
//                window.watchContentChange[i].callback.apply(window.watchContentChange[i].element);
//                window.watchContentChange[i].element.data("lastContents", window.watchContentChange[i].element.html())
//            };
//        }
//    }
//};

//function fbWidth() {
//    intervalid = setInterval(contentChangeInterval, 1000);
//    $('[show_faces]').contentChange(function() {
//        $('.fb_ltr').css('width', '47px');
//        clearInterval(intervalid);
//        if (FB.XFBML.Host.parseDomTree)
//            setTimeout(FB.XFBML.Host.parseDomTree, 0);
//        $('ul.sharing').show();
//    });
//}