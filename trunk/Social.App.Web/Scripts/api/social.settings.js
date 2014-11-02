/**************************/
/*  jQuery Preferences    */
/**************************/
jQuery.support.cors = true;

/**************************/
/*  Domain Preferences    */
/**************************/
var WINDOW_URL = window.location.host;
var DEVELOPMENT_MODE = (WINDOW_URL.indexOf('localhost') > -1 ? true : false);

var HOST = (function ($) {
    var base_url = DEVELOPMENT_MODE ?
            'http://localhost:1469' :
            'http://platform.relsocial.com';

    return {
        BASE_URL: base_url,
        REGISTRATION_URL: base_url + '/api/account/Register',
        AUTHENTICATE_URL: base_url + '/token'
    }
})(jQuery);

/**************************/
/*       Logging          */
/**************************/
function LOG(message) {
    if (DEVELOPMENT_MODE) {
        console.log(message);
    }
}
function LOG_INFO(message) {
    if (DEVELOPMENT_MODE) {
        console.info(message);
    }
}
function LOG_ERROR(message) {
    if (DEVELOPMENT_MODE) {
        console.error(message);
    }
}
