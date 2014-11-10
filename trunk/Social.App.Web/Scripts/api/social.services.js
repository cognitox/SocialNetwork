var CookieService = (function ($) {
    var day = 1;
    var year = (365 * day);

    var LOGIN_COOKIE_NAME = 'Login';
    var LOGIN_COOKIE_EXP = (1000 * year);
    var CURRENT_LOGIN_COOKIE = 1;

    return {
        //login cookies are a list of accounts
        getLoginCookie: function () {
            var retVal = '';
            var loginCookie = Common.getCookie(LOGIN_COOKIE_NAME);
            if (loginCookie != '') {
                LOG_INFO('Getting Cookie [ ' + LOGIN_COOKIE_NAME + ' ] with the value [ ' + loginCookie + ' ]');
                //deserializes to a login cookie object
                var cookie = JSON.parse(loginCookie);
                if (cookie.COOKIEVERSION != CURRENT_LOGIN_COOKIE) {
                    LOG_INFO('need to update the current login cookie version');
                    alert('need to handle the login cookie versioning');
                }
                retVal = JSON.parse(loginCookie);
            }
            return retVal;
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
                success: function (token_info) {
                    var email = token_info.userName;
                    var access_token = token_info.access_token;
                    var expires = token_info['.expires'];
                    var issued = token_info['.issued'];
                    var expires_in = token_info.expires_in;

                    response.success = true;
                    response.message = email + ' has successfully logged in.';
                    LOG(response.message)
                    var account = new Account(email);
                    account.setAuth(access_token, expires, issued, expires_in);
                    LOG('Created Account [ ' + JSON.stringify(account) + ' ]');
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
                    LOG_ERROR(response.message);
                },
                error: function (error_message) {
                    response.success = false;
                    response.message = bad_request_message;
                    LOG_ERROR(response.message);
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
                    LOG(response.message);

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
                    LOG_ERROR(response.message);
                },
                error: function (error_message) {
                    response.success = false;
                    try {
                        var emailAlreadyTaken = error_message.responseJSON.ModelState[""][1];
                        response.message = emailAlreadyTaken;
                    } catch (e) {
                        response.message = bad_request_message;
                    }
                    LOG_ERROR(response.message);
                }
            });
            return response;
        },
        getExternalProviders: function (url) {
            var bad_request_message = 'Please contact a system administrator.';
            var response = new Response();
            LOG('AccountService :: Account.getExternalProviders( ' + url + ');');
            $.ajax({
                type: "GET",
                url: url,
                headers: { "Accept": "application/json" },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false,
                crossDomain: true,
                beforeSend: function (xhr) {
                    xhr.withCredentials = true;
                },
                success: function (logins) {
                    response.success = true;
                    response.message = logins;
                    LOG(response.message);
                },
                failure: function (error_message) {
                    response.success = false;
                    response.message = bad_request_message;
                    LOG_ERROR(response.message);
                },
                error: function (error_message) {
                    response.success = false;
                    response.message = bad_request_message;
                    LOG_ERROR(response.message);
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
        },
        GetExternalProviders: function (url) {
            return request.getExternalProviders(url);
        }
    }
})(jQuery);

var ExternalProviderService = (function ($) {

    var Providers = {
        GetProviders: function (url) {
            return RequestService.GetExternalProviders(url);
        }
    }

    return {
        GetExternalProviders: function () {
            return Providers.GetProviders(HOST.EXTERNAL_LOGINS_URL);
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

var WindowProviderService = (function ($) {
    var linkedInAuthWindow = '';
    var authwindow = {
        open: function () {
            linkedInAuthWindow = window.open($('#linkedin-external-signup').attr('href'), 'RelSocial - LinkedIn Authentication', 'left=20,top=20,width=500,height=500,toolbar=1,resizable=0');
            this.startWindowTracker();
        },

        startWindowTracker: function () {
            setTimeout(this.trackWindow, 3000);
        },
        trackWindow: function () {
            var url = null;
            try {
                url = linkedInAuthWindow.location.href;
                //window.location = url;
                console.log(url);
                if (url.indexOf('access_token=') > -1) {
                    console.log('access token found');
                } else {
                    url = null;
                    console.log('url doesn\'t contain access token.');
                }
            } catch (e) {
                console.log('caught url exception.')
                url = null;
            }

            if (url == null) {
                authwindow.startWindowTracker();
            } else {
                alert('need to set cookie from here, and redirect the request on the web api end of it to a more freindly login successful page');
                alert(url);
                linkedInAuthWindow.close();
            }

        }
    }

    return {
        OpenLinkedInAuthWindow: function () {
            authwindow.open();
            return false;
        }
    }
})(jQuery);