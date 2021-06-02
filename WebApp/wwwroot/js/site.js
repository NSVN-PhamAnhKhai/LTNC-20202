// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

(function ($) {

    const timePeriods = { "Last hour": 60 * 60 * 1000, "Last 24 hours": 24 * 60 * 60 * 1000, "Last 7 days": 7 * 24 * 60 * 60 * 1000, "Last 4 weeks": 4 * 7 * 24 * 60 * 60 * 1000 }


    $.fn.ddTableFilter = function (options) {
        options = $.extend(true, $.fn.ddTableFilter.defaultOptions, options);

        return this.each(function () {
            if ($(this).hasClass('ddtf-processed')) {
                refreshFilters(this);
                return;
            }
            var table = $(this);
            var start = new Date();

            $('th:visible', table).each(function (index) {
                if ($(this).hasClass('skip-filter')) return;
                var selectbox = $('<select>');
                var values = [];
                var opts = [];
                selectbox.append('<option value="--all--">' + $(this).text() + '</option>');
                if ($(this).text() != "DateTime") {
                    var col = $('tr:not(.skip-filter) td:nth-child(' + (index + 1) + ')', table).each(function () {
                        var cellVal = options.valueCallback.apply(this);
                        if (cellVal.length == 0) {
                            cellVal = '--empty--';
                        }
                        $(this).attr('ddtf-value', cellVal);
                        if ($.inArray(cellVal, values) === -1) {
                            var cellText = options.textCallback.apply(this);
                            if (cellText.length == 0) { cellText = options.emptyText; }
                            values.push(cellVal);
                            opts.push({ val: cellVal, text: cellText });
                        }
                    });
                    if (opts.length < options.minOptions) {
                        return;
                    }
                    if (options.sortOpt) {
                        opts.sort(options.sortOptCallback);
                    }
                    $.each(opts, function () {
                        $(selectbox).append('<option value="' + this.val + '">' + this.text + '</option>')
                    });

                    $(this).wrapInner('<div style="display:none">');
                    $(this).append(selectbox);

                    selectbox.bind('change', { column: col }, function (event) {
                        var changeStart = new Date();
                        var value = $(this).val();

                        event.data.column.each(function () {
                            if ($(this).attr('ddtf-value') === value || value == '--all--') {
                                $(this).removeClass('ddtf-filtered');
                            }
                            else {
                                $(this).addClass('ddtf-filtered');
                            }
                        });
                        var changeStop = new Date();
                        if (options.debug) {
                            console.log('Search: ' + (changeStop.getTime() - changeStart.getTime()) + 'ms');
                        }
                        refreshFilters(table);

                    });
                    table.addClass('ddtf-processed');
                    if ($.isFunction(options.afterBuild)) {
                        options.afterBuild.apply(table);
                    }
                }
                else {
                    var col = $('tr:not(.skip-filter) td:nth-child(' + (index + 1) + ')', table).each(function () { });
                    for (let key in timePeriods) {
                        opts.push({ val: timePeriods[key], text: key });
                    }
                    if (opts.length < options.minOptions) {
                        return;
                    }
                    $.each(opts, function () {
                        $(selectbox).append('<option value="' + this.val + '">' + this.text + '</option>')
                    });
                    $(this).wrapInner('<div style="display:none">');
                    $(this).append(selectbox);

                    selectbox.bind('change', { column: col }, function (event) {
                        var value = $(this).val();
                        event.data.column.each(function () {
                            if (options.filterByPeriods.apply(this, [value])) {
                                $(this).removeClass('ddtf-filtered');
                            }
                            else {
                                $(this).addClass('ddtf-filtered');
                            }
                        });
                        refreshFilters(table);
                    });
                }
            });

            function refreshFilters(table) {
                var refreshStart = new Date();
                $('tr', table).each(function () {
                    var row = $(this);
                    if ($('td.ddtf-filtered', row).length > 0) {
                        options.transition.hide.apply(row, options.transition.options);
                    }
                    else {
                        options.transition.show.apply(row, options.transition.options);
                    }
                });

                if ($.isFunction(options.afterFilter)) {
                    options.afterFilter.apply(table);
                }

                if (options.debug) {
                    var refreshEnd = new Date();
                    console.log('Refresh: ' + (refreshEnd.getTime() - refreshStart.getTime()) + 'ms');
                }
            }

            if (options.debug) {
                var stop = new Date();
                console.log('Build: ' + (stop.getTime() - start.getTime()) + 'ms');
            }
        });
    };

    $.fn.ddTableFilter.defaultOptions = {
        valueCallback: function () {
            return encodeURIComponent($.trim($(this).text()));
        },
        textCallback: function () {
            return $.trim($(this).text());
        },
        sortOptCallback: function (a, b) {
            return a.text.toLowerCase() > b.text.toLowerCase();
        },
        filterByPeriods: function (strVal) {
            var strText = $(this).text();
            var timeNow = new Date().getTime()
            switch (strVal) {
                case "--all--":
                    return true;
                case "3600000":
                    let oneHour = Number(strVal)
                    return timeNow - (new Date(strText).getTime()) <= oneHour ? true : false;
                case "86400000":
                    let oneDay = Number(strVal)
                    return timeNow - (new Date(strText).getTime()) <= oneDay ? true : false;
                case "604800000":
                    let oneWeek = Number(strVal)
                    return timeNow - (new Date(strText).getTime()) <= oneWeek ? true : false;
                case "2419200000":
                    let oneMonth = Number(strVal)
                    return timeNow - (new Date(strText).getTime()) <= oneMonth ? true : false;
                default:
                    return false;
            }
        },
        afterFilter: null,
        afterBuild: null,
        transition: {
            hide: $.fn.hide,
            show: $.fn.show,
            options: []
        },
        emptyText: '--Empty--',
        sortOpt: true,
        debug: false,
        minOptions: 2
    }
})(jQuery);
