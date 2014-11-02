var CookieService = (function ($) {
    var day = 1;
    var year = (365 * day);

    var LOGIN_COOKIE_NAME = 'Login';
    var LOGIN_COOKIE_EXP = (1000 * year);
    var CURRENT_LOGIN_COOKIE = 1;

    return {
        //login cookies are a list of accounts
        getLoginCookie: function () {
            var loginCookie = Common.getCookie(LOGIN_COOKIE_NAME);
            if (loginCookie != '') {
                LOG_INFO('Getting Cookie [ ' + LOGIN_COOKIE_NAME + ' ] with the value [ ' + loginCookie + ' ]');
                //deserializes to a login cookie object
                var cookie = JSON.parse(loginCookie);
                if (cookie.COOKIEVERSION != CURRENT_LOGIN_COOKIE) {
                    LOG_INFO('need to update the current login cookie version');
                    alert('need to handle the login cookie versioning');
                    //to do this we need to reset the cookie, update the version of the current
                    //login cookie, then handle how we will transition the cookie over to the
                    //new version of the cookie
                }
            }
            var deserialized = JSON.parse(loginCookie);
            return deserialized;

        },
        setLoginCookie: function (loginCookie) {
            var json = JSON.stringify(loginCookie);
            LOG_INFO('Setting Cookie [ ' + LOGIN_COOKIE_NAME + ' ] to expire [ ' + LOGIN_COOKIE_EXP + ', days ] with the value [ ' + json + ' ]');
            Common.setCookie(LOGIN_COOKIE_NAME, json, LOGIN_COOKIE_EXP);
        }
    }
})(jQuery);

var ValidationService = (function ($) {
    var utility = {
        validateEmail: function (email) {
            var message = '';
            var passedValidation = true;

            if (passedValidation && // email address is valid
                !Common.isValidEmail(email)) {
                passedValidation = false;
                message = 'Username is not a valid email.';
            }

            return {
                success: passedValidation,
                message: message
            }
        },
        validatePassword: function (password, confirmPassword) {
            var message = '';
            var passedValidation = true;

            if (passedValidation && // both passwords are equal
                !(password == confirmPassword)) {
                passedValidation = false;
                message = 'Password\'s must match.';
            }

            var MINLENGTH = 6;
            if (passedValidation && //longer than [MINLENGTH] characters
                !Common.isXGreaterThanYCharactersLong(password, MINLENGTH)) {
                passedValidation = false;
                message = 'Password must be longer than 6 characters.';
            }

            if (passedValidation && //contains at lest 1 letter
                !Common.containsLetter(password)) {
                passedValidation = false;
                message = 'Password must have at least 1 letter.';
            }
            if (passedValidation && //contains at least 1 special character
                !Common.containsSpecialCharacters(password)) {
                passedValidation = false;
                message = 'Password must have at least 1 special character.';
            }

            if (passedValidation && //contains at least 1 number
                !Common.containsNumbers(password)) {
                passedValidation = false;
                message = 'Password must have at least 1 number.';
            }

            return {
                success: passedValidation,
                message: message
            }
        }

    }

    return {
        validatePassword: function (password, confirmPassword) {
            return utility.validatePassword(password, confirmPassword);
        },
        validateEmail: function (email) {
            return utility.validateEmail(email);
        }

    }

})(jQuery);

var RequestService = (function () {

    var request = {
        Authenticate: function (url, data) {
            var bad_request_message = 'Please contact a system administrator.';
            var response = new Response();

            LOG('RequestService :: request.Authenticate( ' + url + ', ' + data + ');');
            $.ajax({
                type: "POST",
                url: url,
                headers: {
                    "Accept": "application/json",
                    'Content-Type': 'application/x-www-form-urlencoded'
                },
                data: data,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                crossDomain: true,
                beforeSend: function (xhr) {
                    xhr.withCredentials = true;
                },
                success: function (user_email) {
                    response.success = true;
                    response.message = user_email + ' has successfully logged in.';
                    LOG(response.message)

                    var account = new Account(user_email);
                    //create an account
                    var currentLoginCookie = CookieService.getLoginCookie();
                    if (currentLoginCookie == '') {
                        var newLoginCookie = new LoginCookie();
                        newLoginCookie.setPrimaryAccount(account);
                        CookieService.setLoginCookie(newLoginCookie);
                    } else {
                        var existingLoginCookie = new LoginCookie();
                        //set the information of the existing login cookie
                        existingLoginCookie.parseExistingCookie(currentLoginCookie);
                        existingLoginCookie.setPrimaryAccount(account);
                        CookieService.setLoginCookie(existingLoginCookie);
                    }

                },
                failure: function (error_message) {
                    response.success = false;
                    response.message = bad_request_message;
                    LOG_ERROR(response.message)
                },
                error: function (error_message) {
                    response.success = false;
                    response.message = bad_request_message;
                    LOG_ERROR(response.message)
                }
            });

            return response;
        },
        registerAccount: function (url, data) {
            var bad_request_message = 'Please contact a system administrator.';

            var response = new Response();

            LOG('AccountService :: Account.Create( ' + url + ', ' + data + ');');
            $.ajax({
                type: "POST",
                url: url,
                headers: { "Accept": "application/json" },
                data: data,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                crossDomain: true,
                beforeSend: function (xhr) {
                    xhr.withCredentials = true;
                },
                success: function (user_email) {
                    response.success = true;
                    response.message = user_email + ' has been successfully created';
                    LOG(response.message)

                    var account = new Account(user_email);
                    //create an account
                    var currentLoginCookie = CookieService.getLoginCookie();
                    if (currentLoginCookie == '') {
                        var newLoginCookie = new LoginCookie();
                        newLoginCookie.setPrimaryAccount(account);
                        CookieService.setLoginCookie(newLoginCookie);
                    } else {
                        var existingLoginCookie = new LoginCookie();
                        //set the information of the existing login cookie
                        existingLoginCookie.parseExistingCookie(currentLoginCookie);
                        existingLoginCookie.setPrimaryAccount(account);
                        CookieService.setLoginCookie(existingLoginCookie);
                    }

                },
                failure: function (error_message) {
                    response.success = false;
                    response.message = bad_request_message;
                    LOG_ERROR(response.message)
                },
                error: function (error_message) {
                    response.success = false;
                    try{
                        var emailAlreadyTaken = error_message.responseJSON.ModelState[""][1];
                        response.message = emailAlreadyTaken;
                    } catch (e) {
                        response.message = bad_request_message;
                    }
                    
                    LOG_ERROR(response.message)
                }
            });

            return response;
        }
    }

    return {
        RegisterAccount: function (url, data) {
            return request.registerAccount(url, data);
        },
        Authenticate: function (url, data) {
            return request.Authenticate(url, data);
        }
    }
})(jQuery);

var AccountService = (function ($) {

    var Account = {
        Create: function (url, data) {
            return RequestService.RegisterAccount(url, data);
        },
        Authenticate: function (url, data) {
            return RequestService.Authenticate(url, data);
        }
    }

    return {
        CreateAccount: function (username, password, confirmpassword) {
            //request data
            var data = JSON.stringify({
                email: username,
                password: password,
                confirmpassword: confirmpassword
            });
            //make request
            var status = Account.Create(HOST.REGISTRATION_URL, data);
            return status;
        },
        Authenticate: function (username, password) {
            //request data
            var data = 'grant_type=password&username=' + username + '&password=' + password;
            //make request
            var status = Account.Authenticate(HOST.AUTHENTICATE_URL, data);
            return status;
        }
    }
})(jQuery);
