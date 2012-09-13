function gameDetail() {
    $("span[id^='game']").each(function() {
        var id = $(this).attr('id');
        var number = id.substring(id.indexOf('_') + 1);
        $(this).addClass('tableButton').toggle(
                function() {
                    try {
                        $("tr[id='info_" + number + "']").toggleClass('hidden more');
                        pageTracker._trackEvent('Internal', 'Click', 'Game Recap ' + number);
                    } catch (err) { }
                },
                function() {
                    $("tr[id='info_" + number + "']").toggleClass('hidden more');
                }
            );
    });
    if (!document.location.hash == '') { $('#game_' + (document.location.hash).replace('#', '')).click(); } else { }
};

function displayGames() {
    $('#gamesBoxTable tr').hide();

    var activeTypes = $('ul#tabs li.type.active');
    var selector = [];
    var ha = '';

    $('ul#tabs li.ha.active').each(function() {
        ha = '.' + $(this).attr('id');
        activeTypes.each(function() {
            selector.push(ha + '.' + $(this).attr('id'));
        });
        if (selector.length == 0 || (selector.length == 1 && selector[0] == '.home')) {
            selector.push(ha);
        }
    });

    if (selector.length == 0) {
        activeTypes.each(function() {
            selector.push('.' + $(this).attr('id'));
        });
    }

    if (selector.length == 0) {
        selector.push('.home');
        selector.push('.away');
    }

    $(selector.join(', ')).show();

    //$('#gamesBoxTable tr.fall').hide();

    if ($('#gamesBoxTable tr:visible').size() == 0) {
        $('#gamesBoxTable tr.nogame').show();
    }
};

function gameSelector() {
    var nogames = '<tr class="nogame" style="display:none;"><td colspan="4" style="text-align:center;width:99%;">There aren&#8217;t any games that match your selection. Try changing your criteria above.</td></tr>';
    $(nogames).insertBefore('#gamesBoxTable tr:first');
    var ul = '<ul id="tabs"><li id="home" class="ha" title="Home Games">Home</li><li id="away" class="ha" title="Away Games">Away</li><li id="divisional" class="type" title="Divisional Games">Div</li><li id="none" class="type" title="Non-Divisional SELC Games">SELC</li><li id="out" class="type" title="Out Of Conference Games">OOC</li><li id="playoff" class="type" title="Playoff Games">Play</li></ul><div class="spacer"></div>';
    $('ul#tabs').remove();
    $(ul).insertBefore('#gamesBoxTable');
    $('ul#tabs li').each(function() {
        $(this).toggle(
                function() {
                    try {
                        $(this).addClass('active');
                        displayGames();
                        pageTracker._trackEvent('Internal', 'Click', 'Game Filter ' + $(this).text());
                    } catch (err) { }
                },
                function() {
                    $(this).removeClass('active');
                    displayGames();
                }
            );
    });
};
