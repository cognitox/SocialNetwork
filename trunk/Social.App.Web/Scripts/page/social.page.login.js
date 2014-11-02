var LoginForm = (function ($) {

    var page = {
        init: function(){
            //get a cookie if it is defined, then allow the user to set the primary accounts
            var loginCookie = CookieService.getLoginCookie();
            if (loginCookie != '') {
                //prefill the user login page
                var username = $('#log-in-username');
                var password = $('#log-in-password');
                username.text(loginCookie.email);
                password.text('');

                //TODO handle the primary accounts,
                //need to keep in mind that accounts
                //should be able to live and coexist with one another,
                //based on currently set settings
            }
        }
    }

    var loginForm = {
        onClick: function () {
            //display pane
            var pane = $('#error-messages');

            var username = $('#log-in-username');
            var password = $('#log-in-password');
            var status = AccountService.Authenticate(username.val(), password.val());

            if (status.success) {
                location.href = '/Profile';
            } else {
                pane.empty().append(status.message)
            }

        }
    }


    var registrationForm = {
        onClick: function () {
            //display pane
            var pane = $('#error-messages');

            //inputs
            var username = $('#sign-up-username');
            var password = $('#sign-up-password');
            var confirmpassword = $('#sign-up-confirm-password');

            //validate email
            var emailValResult = ValidationService.validateEmail(username.val());
            if (!emailValResult.success) {
                pane.empty().append(emailValResult.message);
                return;
            }

            //validate password
            var passValResult = ValidationService.validatePassword(password.val(), confirmpassword.val());
            if (!passValResult.success) {
                pane.empty().append(passValResult.message);
                return;
            }

            var throbber = '<i id=\'throbber-thinking\' style=\'height: 18px;width: 114px;zoom: 5;padding-left: 50px;padding-top: 10px;\' class=\'glyphicon glyphicon-cog spin\'></i>';
            $('#register-modal-body').append(throbber);

            var status = AccountService.CreateAccount(username.val(), password.val(), confirmpassword.val());

            $('#throbber-thinking').remove();
            pane.empty().append(status.message)

            if (status.success) {
               location.href = '/';
            }

        }
    }

    var listeners = {
        init: function () {
            //registrationform
            $('#register-new-account').click(function (e) {
                e.preventDefault();
                registrationForm.onClick();
            });
            $('#login-from-submit').click(function (e) {
                e.preventDefault();
                loginForm.onClick();
            });
        }
    }

    $(document).ready(function () {
        page.init();
        listeners.init();
    });

})(jQuery);