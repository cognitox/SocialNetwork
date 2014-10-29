//all script setup
var DEVELOPMENT_MODE = true;

var HOST = (function () {
    //sets the base host url depending on development or production
    var base_api_url = 'http://platform.relsocial.com/';
    if (DEVELOPMENT_MODE) {
        base_api_url = 'http://localhost:1469/';
    }
    return {
        URL: base_api_url
    }

})(jQuery);



var AuthToken = (function ($) {

    var statusobj = {
        success: false,
        message: '',
        reset: function () {
            this.success = false;
            this.message = '';
        }
    }

    var request = {
        registeruser: function (url, credentials) {
            //returns a status object
            statusobj.reset();
            $.ajax({
                type: "POST",
                url: url,
                data: JSON.stringify(credentials),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: false, //make sure the request is posted
                crossDomain: true,
                success: function (data) {
                    statusobj.success = true;
                    statusobj.message = 'success';
                    console.log(message);
                },
                failure: function (errMsg) {
                    statusobj.success = false;
                    statusobj.message = errMsg
                    console.log(errMsg);
                },
                error: function (errMsg) {
                    statusobj.success = false;
                    try {
                        //catch the email taken message
                        statusobj.message = errMsg.responseJSON.ModelState[""][1];
                    } catch (error) {
                        statusobj.message = 'Please contact a system administrator.';
                    }
                    /* TODO ... better handle the api error messages.
                    status.message.responseJSON
Object {$id: "1", Message: "The request is invalid.", ModelState: Object}$id: "1"Message: "The request is invalid."ModelState: Object"": Array[2]0: "Name justinjarczyk@gmail.com is already taken."1: "Email 'justinjarczyk@gmail.com' is already taken."length: 2__proto__: Array[0]$id: "2"__proto__: Object__proto__: Object
                    */
                }
            });

            return { success: statusobj.success, message: statusobj.message };
        },
        to: function (url, json) {
            /*
            //add flag to ajax request         
            headers: {
                "Authorization": "Bearer eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3Mi..."
              }
            */
        }
    }

    return {
        RegisterNewUser: function (username, password, confirmpassword) {
            var body = {
                email: username,
                password: password,
                confirmpassword: confirmpassword
            };
            var status = request.registeruser(HOST.URL + '/api/account/Register', body);
            return status;
        }

    }

})(jQuery);
