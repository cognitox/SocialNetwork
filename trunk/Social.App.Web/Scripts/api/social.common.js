//all script setup
var DEVELOPMENT_MODE = true;

var AjaxProvider = (function () {
    var base_api_url = 'http://platform.relsocial.com/';
    if (DEVELOPMENT_MODE) {
        base_api_url = 'http://localhost:1469/';
    }



})(jQuery);



var AuthToken = (function ($) {
    
           
    
    var AuthenticationProviders = {



    }

    return {
        GetAuthenticationProviders: function () {

        }

    }

})(jquery);
