
var Common = (function () {
    return {
        getCookie: function getCookie(cname) {
            var name = cname + "=";
            var ca = document.cookie.split(';');
            for (var i = 0; i < ca.length; i++) {
                var c = ca[i];
                while (c.charAt(0) == ' ') c = c.substring(1);
                if (c.indexOf(name) != -1) return c.substring(name.length, c.length);
            }
            return "";
        },
        setCookie: function setCookie(cname, cvalue, exdays) {
            var d = new Date();
            d.setTime(d.getTime() + (exdays*24*60*60*1000));
            var expires = "expires="+d.toUTCString();
            document.cookie = cname + "=" + cvalue + "; " + expires;
        },
        isValidEmail: function validateEmail(email) {
            var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
            return re.test(email);
        },
        isXGreaterThanYCharactersLong: function isXGreaterThanYCharactersLong(x, y) {
            var retVal = false;
            if (x.length > y) {
                retVal = true;
            }
            return retVal;
        },
        containsSpecialCharacters: function containsSpecialCharacters(target) {
            var retVal = false;
            var special = /\W+/;
            if (special.test(target)) {
                retVal = true;
            }
            return retVal;
        },
        containsNumbers: function containsNumbers(target) {
            var retVal = false;
            var num = /[0-9]/;
            if (num.test(target)) {
                retVal = true;
            }
            return retVal;
        },
        containsLetter: function containsLetter(target) {
            var retVal = false;
            var letters = /[a-zA-Z]/;
            if (letters.test(target)) {
                retVal = true;
            }
            return retVal;
        }
    }
})(jQuery);
