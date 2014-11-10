
//DTO Objects
function Account(email) {
    this.email = email;
    this.getEmail = function() {
        return this.email;
    }
    this.setAuth = function(access_token, expires, issued, expires_in){
        this.access_token = access_token;
        this.expires = expires;
        this.issued = issued;
        this.expires_in = expires_in;
    }
}


//Request Service Objects
function Response() {
    this.success = false;
    this.message = '';
    this.reset = function() {
        this.success = false;
        this.message = '';
    }
}

//Cookie Objects
function LoginCookie() {
    this.COOKIEVERSION = 1;
    //holds a list of accounts
    this.primaryAccount = new Account('');
    this.secondaryAccounts = [];
    this.parseExistingCookie = function (cookie) {
        this.primaryAccount = new Account(cookie.primaryAccount.email);
        for(var acc in cookie.secondaryAccounts){
            this.secondaryAccounts.push(cookie.secondaryAccounts[acc]);
        }
    }

    this.setPrimaryAccount = function(account) {

        if ((this.primaryAccount.email == '') ||
            (this.primaryAccount.email == account.email)) {
            // if account is new or same account
            this.primaryAccount = account;
        } else {
            //the primary account is a different account
            var tempAccount = this.primaryAccount;
            this.primaryAccount = account;
            
            var updatedSecondary = false;
            for (var idx in this.secondaryAccounts) {
                if (this.secondaryAccounts[idx].email == tempAccount.email) {
                    this.secondaryAccounts[idx] = tempAccount;
                    updatedSecondary = true;
                }
            }
            if(!updatedSecondary){
                this.secondaryAccounts.push(tempAccount);
            }
        }
    }

    this.getPrimaryAccount = function() {
        return primaryAccount;
    }
    this.getSecondaryAccounts = function() {
        return secondaryAccounts;
    }
}
