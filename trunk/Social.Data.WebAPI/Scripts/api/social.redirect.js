var Redirect = (function ($) {

    var WINDOW_URL = window.location.host;
    var DEVELOPMENT_MODE = (WINDOW_URL.indexOf('localhost') > -1 ? true : false);

    var HOST = (function () {
        var base_url = DEVELOPMENT_MODE ?
                'http://localhost:1178' :
                'http://www.relsocial.com';
        return {
            BASE_URL: base_url
        }
    })();

    function RemoveBaseUrl(url) {
        var baseUrlPattern = /^https?:\/\/[a-z\:0-9.]+/;
        var result = "";
        var match = baseUrlPattern.exec(url);
        if (match != null) {
            result = match[0];
        }
        if (result.length > 0) {
            url = url.replace(result, "");
        }
        return url;
    }
    var redirect = {
        to: function (authToken, userId) {
            try {
                var currentwindow = window.location.href;
                //var url = HOST.BASE_URL + RemoveBaseUrl(currentwindow);
                var url = HOST.BASE_URL + '?authToken=' + authToken + '&userId=' + userId;
                window.location = url;
            } catch (error) {
                console.log(error);
            }
        }
    }

    return {
        window: function (authToken, userId) {
            return redirect.to(authToken, userId);
        }
    }

})(jQuery);
