var LoginForm = (function ($) {

    function validateEmail(email) {
        var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
        return re.test(email);
    }
    function passwordIsLongEnough(password) {
        var retVal = false;
        if (password.length > 6) {
            retVal = true;
        }
        return retVal;
    }
    function passwordContainsSpecialCharacters(password) {
        var retVal = false;
        var special = /\W+/;
        if (special.test(password)) {
            retVal = true;
        }
        return retVal;
    }
    function passwordContainsNumbers(password) {
        var retVal = false;
        var num = /[0-9]/;
        if (num.test(password)) {
            retVal = true;
        }


        return retVal;
    }
    function passwordContainsLetter(password) {
        var retVal = false;
        var letters = /[a-zA-Z]/;
        if (letters.test(password)) {
            retVal = true;
        }
        return retVal;
    }

    var listeners = {
        init: function () {
            $('#linkedin-external-signup').click(function () {

            });
            $('#register-new-account').click(function () {
                var username = $('#sign-up-username');
                var password = $('#sign-up-password');
                var confirmpassword = $('#sign-up-confirm-password');

                var passedValidation = false;
                var message = '';
                //do some form validation
                if (validateEmail(username.val())) {
                    if (password.val() == confirmpassword.val()) {
                        if (passwordIsLongEnough(password.val())) {
                            if (passwordContainsLetter(password.val())) {
                                if (passwordContainsSpecialCharacters(password.val())) {
                                    if (passwordContainsNumbers(password.val())) {
                                        passedValidation = true;
                                    } else {
                                        message = 'Password must have at least 1 number.';
                                        password.focus();
                                        confirmpassword.empty();
                                    }
                                } else {
                                    message = 'Password must have at least 1 special character.';
                                    password.focus();
                                    confirmpassword.empty();
                                }
                            } else {
                                message = 'Password must have at least 1 letter.';
                                password.focus();
                                confirmpassword.empty();
                            }
                        } else {
                            message = 'Password must be longer than 6 characters.';
                            password.focus();
                            confirmpassword.empty();
                        }
                    } else {
                        message = 'Password\'s must match.';
                        password.focus();
                        confirmpassword.empty();
                    }
                } else {
                    message = 'Username is not a valid email.';
                    username.focus();
                }

                var pane = $('#error-messages');

                if (passedValidation) {
                    pane.empty();
                    var throbber = '<i id=\'throbber-thinking\' style=\'height: 18px;width: 114px;zoom: 5;padding-left: 50px;padding-top: 10px;\' class=\'glyphicon glyphicon-cog spin\'></i>';
                    var form = $('#reg-form');
                    form.hide();
                    $('#register-modal-body').append(throbber);
                    //need to make ajax request

                    var status = AuthToken.RegisterNewUser(username.val(), password.val(), confirmpassword.val());
                    if (status.success) {
                        location.href = '/Profile';
                    } else {
                        $('#throbber-thinking').remove();
                        form.show();

                        pane.append(status.message)
                    }
                } else {
                    pane.empty();
                    pane.append(message);
                }


            });
        }
    }

    $(document).ready(function () {

        listeners.init();
    });

})(jQuery);